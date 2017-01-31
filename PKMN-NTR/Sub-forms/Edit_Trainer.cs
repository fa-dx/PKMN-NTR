using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PKHeX.Core;

namespace ntrbase.Sub_forms
{
    public partial class Edit_Trainer : Form
    {
        private GameVersion game;

        public Edit_Trainer(GameVersion ver)
        {
            InitializeComponent();
            switch (Program.gCmdWindow.SAV.Version)
            {
                case GameVersion.X:
                case GameVersion.Y:
                case GameVersion.OR:
                case GameVersion.AS:
                    break;
                case GameVersion.SN:
                case GameVersion.MN:
                    break;
            }
        }

        private void Edit_Trainer_Load(object sender, EventArgs e)
        {

        }
    }
}
