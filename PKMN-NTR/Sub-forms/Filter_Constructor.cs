using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using pkmn_ntr.Helpers;
using System.IO;

namespace pkmn_ntr.Sub_forms
{
    public partial class Filter_Constructor : Form
    {
        private const string FOLDERBOT = "Bot";

        public Filter_Constructor()
        {
            InitializeComponent();
        }

        private void Filter_Constructor_Load(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void filterAdd_Click(object sender, EventArgs e)
        {
            filterList.Rows.Add(filterShiny.Checked ? 1 : 0, Convert.ToInt32(filterNature.SelectedIndex), Convert.ToInt32(filterAbility.SelectedIndex), Convert.ToInt32(filterHPtype.SelectedIndex), Convert.ToInt32(filterGender.SelectedIndex), Convert.ToInt32(filterHPvalue.Value), Convert.ToInt32(filterHPlogic.SelectedIndex), Convert.ToInt32(filterATKvalue.Value), Convert.ToInt32(filterATKlogic.SelectedIndex), Convert.ToInt32(filterDEFvalue.Value), Convert.ToInt32(filterDEFlogic.SelectedIndex), Convert.ToInt32(filterSPAvalue.Value), Convert.ToInt32(filterSPAlogic.SelectedIndex), Convert.ToInt32(filterSPDvalue.Value), Convert.ToInt32(filterSPDlogic.SelectedIndex), Convert.ToInt32(filterSPEvalue.Value), Convert.ToInt32(filterSPElogic.SelectedIndex), Convert.ToInt32(filterPerIVvalue.Value), Convert.ToInt32(filterPerIVlogic.SelectedIndex));
        }

        private void filterRemove_Click(object sender, EventArgs e)
        {
            if (filterList.SelectedRows.Count > 0 && filterList.Rows.Count > 0)
            {
                filterList.Rows.RemoveAt(filterList.SelectedRows[0].Index);
            }
            else
                MessageBox.Show("There is no filter selected.");
        }

        private void filterRead_Click(object sender, EventArgs e)
        {
            if (filterList.SelectedRows.Count > 0)
            {
                if ((int)filterList.SelectedRows[0].Cells[0].Value == 1)
                {
                    Delg.SetChecked(filterShiny, true);
                }
                else
                {
                    Delg.SetChecked(filterShiny, false);
                }
                Delg.SetSelectedIndex(filterNature, (int)filterList.SelectedRows[0].Cells[1].Value);
                Delg.SetSelectedIndex(filterAbility, (int)filterList.SelectedRows[0].Cells[2].Value);
                Delg.SetSelectedIndex(filterHPtype, (int)filterList.SelectedRows[0].Cells[3].Value);
                Delg.SetSelectedIndex(filterGender, (int)filterList.SelectedRows[0].Cells[4].Value);
                Delg.SetValue(filterHPvalue, (int)filterList.SelectedRows[0].Cells[5].Value);
                Delg.SetSelectedIndex(filterHPlogic, (int)filterList.SelectedRows[0].Cells[6].Value);
                Delg.SetValue(filterATKvalue, (int)filterList.SelectedRows[0].Cells[7].Value);
                Delg.SetSelectedIndex(filterATKlogic, (int)filterList.SelectedRows[0].Cells[8].Value);
                Delg.SetValue(filterDEFvalue, (int)filterList.SelectedRows[0].Cells[9].Value);
                Delg.SetSelectedIndex(filterDEFlogic, (int)filterList.SelectedRows[0].Cells[10].Value);
                Delg.SetValue(filterSPAvalue, (int)filterList.SelectedRows[0].Cells[11].Value);
                Delg.SetSelectedIndex(filterSPAlogic, (int)filterList.SelectedRows[0].Cells[12].Value);
                Delg.SetValue(filterSPDvalue, (int)filterList.SelectedRows[0].Cells[13].Value);
                Delg.SetSelectedIndex(filterSPDlogic, (int)filterList.SelectedRows[0].Cells[14].Value);
                Delg.SetValue(filterSPEvalue, (int)filterList.SelectedRows[0].Cells[15].Value);
                Delg.SetSelectedIndex(filterSPElogic, (int)filterList.SelectedRows[0].Cells[16].Value);
                Delg.SetValue(filterPerIVvalue, (int)filterList.SelectedRows[0].Cells[17].Value);
                Delg.SetSelectedIndex(filterPerIVlogic, (int)filterList.SelectedRows[0].Cells[18].Value);
            }
            else
            {
                MessageBox.Show("There is no filter selected.");
            }
        }

        private void filterSave_Click(object sender, EventArgs e)
        {
            try
            {
                string folderPath = System.Windows.Forms.@Application.StartupPath + "\\" + FOLDERBOT + "\\";
                (new FileInfo(folderPath)).Directory.Create();

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "PKMN-NTR Filter|*.pftr";
                saveFileDialog1.Title = "Save a filter set";
                saveFileDialog1.InitialDirectory = folderPath;
                saveFileDialog1.ShowDialog();

                if (saveFileDialog1.FileName != "")
                {
                    var filters = new StringBuilder();
                    foreach (DataGridViewRow row in filterList.Rows)
                    {
                        var cells = row.Cells.Cast<DataGridViewCell>();
                        filters.AppendLine(string.Join(",", cells.Select(cell => cell.Value).ToArray()));
                    }
                    File.WriteAllText(saveFileDialog1.FileName, filters.ToString());
                    MessageBox.Show("Filter set saved");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void filterLoad_Click(object sender, EventArgs e)
        {
            try
            {
                string folderPath = @Application.StartupPath + "\\" + FOLDERBOT + "\\";
                (new FileInfo(folderPath)).Directory.Create();
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "PKMN-NTR Filter|*.pftr";
                openFileDialog1.Title = "Select a filter set";
                openFileDialog1.InitialDirectory = folderPath;
                openFileDialog1.ShowDialog();
                if (openFileDialog1.FileName != "")
                {
                    filterList.Rows.Clear();
                    List<int[]> rows = File.ReadAllLines(openFileDialog1.FileName).Select(s => s.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray()).ToList();
                    foreach (int[] row in rows)
                    {
                        filterList.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8], row[9], row[10], row[11], row[12], row[13], row[14], row[15], row[16], row[17], row[18]);
                    }
                    MessageBox.Show("Filter set loaded");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void filterReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            Delg.SetChecked(filterShiny, false);
            Delg.SetSelectedIndex(filterNature, -1);
            Delg.SetSelectedIndex(filterAbility, -1);
            Delg.SetSelectedIndex(filterHPtype, -1);
            Delg.SetSelectedIndex(filterGender, -1);
            Delg.SetSelectedIndex(filterHPlogic, 0);
            Delg.SetSelectedIndex(filterATKlogic, 0);
            Delg.SetSelectedIndex(filterDEFlogic, 0);
            Delg.SetSelectedIndex(filterSPAlogic, 0);
            Delg.SetSelectedIndex(filterSPDlogic, 0);
            Delg.SetSelectedIndex(filterSPElogic, 0);
            Delg.SetSelectedIndex(filterPerIVlogic, 0);
            Delg.SetValue(filterHPvalue, 0);
            Delg.SetValue(filterATKvalue, 0);
            Delg.SetValue(filterDEFvalue, 0);
            Delg.SetValue(filterSPAvalue, 0);
            Delg.SetValue(filterSPDvalue, 0);
            Delg.SetValue(filterSPEvalue, 0);
        }
    }
}
