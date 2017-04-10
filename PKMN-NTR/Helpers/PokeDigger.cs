﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ntrbase.Properties;

namespace ntrbase.Helpers
{
    public partial class PokeDigger : Form
    {
        const int POKEBYTES = 232;
        int pid;
        uint querySeq = 0;
        byte[] recvData;
        struct Result
        {
            public byte[] data { get; set; }
            public int offset { get; set; }
        }
        List<Result> allResults;

        public PokeDigger(int pid, bool connected)
        {
            this.pid = pid;
            allResults = new List<Result>();
            InitializeComponent();
            Program.ntrClient.DataReady += handleDataReady;
            if (!connected)
            {
                DoItBtn.Enabled = false;
            }
            GUISetReady();
        }

        private void PokeDigger_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.ntrClient.DataReady -= handleDataReady;
        }

        private void GUISetReady()
        {
            StatusLabel.Text = "Status: Ready";
            progressBar.Value = 0;
            CancelBtn.Enabled = false;
            querySeq = 0;
        }

        private void StartWorker(ref byte[] data)
        {
            if (DigWorker.IsBusy)
            {
                MessageBox.Show("Another operation is in progress! Please wait.");
                return;
            }
            StatusLabel.Text = "Status: Processing";
            CancelBtn.Enabled = true;

            DigWorker.RunWorkerAsync(data);
        }

        private void DoItBtn_Click(object sender, EventArgs e)
        {
            if (querySeq != 0)
            {
                MessageBox.Show("Another operation is in progress! Please wait.");
                return;
            }
            
            uint start = Convert.ToUInt32(StartAddrText.Text, 16);
            uint size = Convert.ToUInt32(SizeText.Text, 16);
            querySeq = Program.scriptHelper.data(start, size, pid);
            StatusLabel.Text = "Status: Waiting for data";
            CancelBtn.Enabled = true;
        }

        private void FromFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog file_dialog = new OpenFileDialog();
            file_dialog.Title = "Choose a memory dump file";
            file_dialog.ShowDialog();

            if (file_dialog.FileName == "")
            {
                return;
            }

            byte[] fileBytes = File.ReadAllBytes(file_dialog.FileName);
            StartWorker(ref fileBytes);
        }

        private void handleDataReady(object sender, DataReadyEventArgs e)
        {
            if (e.seq != querySeq) //somebody else's data
            {
                return;
            }
            
            recvData = e.data;
            if (DumpSaveCB.Checked) { 
                string folderPath = @Application.StartupPath + "\\Digger\\";
                (new FileInfo(folderPath)).Directory.Create();
                string fileName = folderPath + "dump " + StartAddrText.Text + ".bin";
                fileName = MainForm.NextAvailableFilename(fileName);
            
                FileStream fs = File.OpenWrite(fileName);
                fs.Write(recvData, 0, recvData.Length);
                fs.Close();
            }
            //Thanks to this, processing will be done in GUI thread
            //so we don't need to use SetBlahblahblah functions everywhere
            MainForm.SetText(UglyMultithreadingHack, "b");
        }

        private void UglyMultithreadingHack_TextChanged(object sender, EventArgs e)
        {
            if (UglyMultithreadingHack.Text == "b")
            {
                UglyMultithreadingHack.Text = "a";
                querySeq = 0; //reset to default
                StartWorker(ref recvData);
            }
        }

        private void DigWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            List<Result> results = new List<Result>();
            byte[] source = (byte[])e.Argument;
            int length = source.Length - POKEBYTES + 1;
            int nextProgress = 0;
            int progressStep = (int)((double)length / 100.0);
            bool fullMode = !FastModeCB.Checked;
            
            for (int i = 0; i < length; i++)
            {
                //Check sanity. Rejects ~50% of positions
                if (source[i+4] == 0 && source[i+5] == 0)
                {
                    uint seed = BitConverter.ToUInt32(source, i + 0);
                    //In fast mode skip if EC == 0. Rejects ~90% of positions
                    if (fullMode || seed != 0) 
                    {
                        //Decrypt partially, calculate checksum
                        //We don't need to deshuffle, it won't affect the checksum
                        ushort checksum = 0;
                        for (int j = 8; j < POKEBYTES; j += 2)
                        {
                            seed = seed * 0x41C64E6D + 0x00006073;
                            checksum += (ushort)(BitConverter.ToUInt16(source, i + j) ^ (ushort)(seed >> 16));
                        }

                        //Allows very few positions, but there's still some garbage
                        if (checksum == BitConverter.ToUInt16(source, i + 6))
                        {
                            byte[] dataFound = new byte[POKEBYTES];
                            Array.Copy(source, i, dataFound, 0, POKEBYTES);
                            //Decrypt it properly this time
                            dataFound = PKHeX.decryptArray(dataFound);
                            PKHeX pkFound = new PKHeX();
                            pkFound.Data = dataFound;

                            if (pkFound.Species >= 1 && pkFound.Species <= 802)
                            {
                                //Almost certainly valid
                                results.Add(new Result { data = dataFound, offset = i });
                            }
                        }
                    }
                }
                
                if (i >= nextProgress) {
                    //The condition will be checked every 1% of progress to improve performance
                    if (worker.CancellationPending == true)
                    {
                        e.Cancel = true;
                        break;
                    }

                    int progress = (int)((100.0 * (double)i) / (double)length);
                    worker.ReportProgress(progress);
                    nextProgress = i + progressStep;
                }
            }

            allResults.AddRange(results);
        }

        private void DigWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void DigWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            GUISetReady();
            
            int resultsCount = allResults.Count;
            if (resultsCount == 0)
                return;

            ResultsGrid.Rows.Clear();
            ResultsGrid.Rows.Add(resultsCount);

            int i = 0;
            foreach (Result r in allResults) {
                PKHeX pkInfo = new PKHeX();
                pkInfo.Data = r.data;

                ResultsGrid.Rows[i].Tag = r.data;
                Bitmap sprite = getSprite(pkInfo.Species, pkInfo.AltForm, pkInfo.IsEgg);
                ResultsGrid.Rows[i].Cells[0].Value = sprite;
                ResultsGrid.Rows[i].Height = sprite.Height;
                ResultsGrid.Rows[i].Cells[1].Value = LookupTable.getLevel(pkInfo.Species, (int)pkInfo.EXP);
                ResultsGrid.Rows[i].Cells[2].Value = pkInfo.Nickname;
                ResultsGrid.Rows[i].Cells[4].Value = pkInfo.PID.ToString("X8");
                ResultsGrid.Rows[i].Cells[5].Value = r.offset.ToString("X8");
                i++;
            }
        }

        private Bitmap getSprite(int speciesindex, int formindex, bool isegg)
        {
            string resname;
            if (isegg)
                resname = "egg";
            else if (formindex == 0 || speciesindex == 493 || speciesindex == 773) // All Arceus / Silvally formes have same sprite
                resname = "_" + speciesindex;
            else
                resname = "_" + speciesindex + "_" + formindex;
            Bitmap data;
            data = (Bitmap)Resources.ResourceManager.GetObject(resname);
            if (data == null)
                data = (Bitmap)Resources.ResourceManager.GetObject("unknown");
            return data;
        }

        private void DumpBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in ResultsGrid.Rows)
            {
                DataGridViewCheckBoxCell checkboxCell = (DataGridViewCheckBoxCell)r.Cells[3];
                if (checkboxCell.Value == null || (bool)checkboxCell.Value == false)
                {
                    continue;
                }
                string folderPath = @Application.StartupPath + "\\Digger\\";
                (new FileInfo(folderPath)).Directory.Create();
                string fileName = folderPath + "pkmn" + ".pk7";
                fileName = MainForm.NextAvailableFilename(fileName);

                byte[] data = (byte[])r.Tag;
                FileStream fs = File.OpenWrite(fileName);
                fs.Write(data, 0, data.Length);
                fs.Close();
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            ResultsGrid.Rows.Clear();
            allResults.Clear();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            if (DigWorker.IsBusy)
            {
                DigWorker.CancelAsync();
            }
            
            GUISetReady();
        }

        private void StepPlusBtn_Click(object sender, EventArgs e)
        {
            uint start = Convert.ToUInt32(StartAddrText.Text, 16);
            uint size = Convert.ToUInt32(SizeText.Text, 16);
            start += size;
            StartAddrText.Text = String.Format("0x{0:X8}", start);
        }

        private void StepMinusBtn_Click(object sender, EventArgs e)
        {
            uint start = Convert.ToUInt32(StartAddrText.Text, 16);
            uint size = Convert.ToUInt32(SizeText.Text, 16);
            start -= size;
            StartAddrText.Text = String.Format("0x{0:X8}", start);
        }

        private void FastModeCB_CheckedChanged(object sender, EventArgs e)
        {
            if (FastModeCB.Checked)
            {
                MessageBox.Show("In fast mode, Pokemon data with encryption constant equal to 0 will be skipped.\r\n" +
                    "This will exclude some valid Pokemon, but will massively speed up the search.");
            }
        }

        private void InvertBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in ResultsGrid.Rows)
            {
                DataGridViewCheckBoxCell checkboxCell = (DataGridViewCheckBoxCell)r.Cells[3];
                if (checkboxCell.Value == null || (bool)checkboxCell.Value == false)
                {
                    checkboxCell.Value = true;
                }
                else
                {
                    checkboxCell.Value = null;
                }
            }
        }

        private void HelpBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hover your mouse cursor over all the controls to find out what they do.");
            toolTip1.SetToolTip(HelpBtn, "Congratulations! You have demonstrated your ability to follow orders.");
        }
    }

}
