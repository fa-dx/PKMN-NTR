namespace ntrbase
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtLog = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.disconnectTimer = new System.Windows.Forms.Timer(this.components);
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.host = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.moneyNum = new System.Windows.Forms.NumericUpDown();
            this.milesNum = new System.Windows.Forms.NumericUpDown();
            this.bpNum = new System.Windows.Forms.NumericUpDown();
            this.pokeMoney = new System.Windows.Forms.Button();
            this.pokeMiles = new System.Windows.Forms.Button();
            this.pokeBP = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dumpBox = new System.Windows.Forms.GroupBox();
            this.DumpInstructionsBtn = new System.Windows.Forms.Button();
            this.radioBattleBox = new System.Windows.Forms.RadioButton();
            this.onlyView = new System.Windows.Forms.CheckBox();
            this.radioParty = new System.Windows.Forms.RadioButton();
            this.radioTrade = new System.Windows.Forms.RadioButton();
            this.radioOpponent = new System.Windows.Forms.RadioButton();
            this.radioDaycare = new System.Windows.Forms.RadioButton();
            this.radioBoxes = new System.Windows.Forms.RadioButton();
            this.dumpBoxes = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.nameek6 = new System.Windows.Forms.TextBox();
            this.dumpPokemon = new System.Windows.Forms.Button();
            this.SlotLabel = new System.Windows.Forms.Label();
            this.slotDump = new System.Windows.Forms.NumericUpDown();
            this.BoxLabel = new System.Windows.Forms.Label();
            this.boxDump = new System.Windows.Forms.NumericUpDown();
            this.itemsGridView = new System.Windows.Forms.DataGridView();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label28 = new System.Windows.Forms.Label();
            this.Lang = new System.Windows.Forms.ComboBox();
            this.pokeLang = new System.Windows.Forms.Button();
            this.pokeSID = new System.Windows.Forms.Button();
            this.SIDNum = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.pokeTID = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.TIDNum = new System.Windows.Forms.NumericUpDown();
            this.secNum = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.minNum = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.pokeTime = new System.Windows.Forms.Button();
            this.pokeName = new System.Windows.Forms.Button();
            this.hourNum = new System.Windows.Forms.NumericUpDown();
            this.playerName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.showKeys = new System.Windows.Forms.Button();
            this.showBerries = new System.Windows.Forms.Button();
            this.showTMs = new System.Windows.Forms.Button();
            this.showMedicine = new System.Windows.Forms.Button();
            this.showItems = new System.Windows.Forms.Button();
            this.keysGridView = new System.Windows.Forms.DataGridView();
            this.tmsGridView = new System.Windows.Forms.DataGridView();
            this.medsGridView = new System.Windows.Forms.DataGridView();
            this.bersGridView = new System.Windows.Forms.DataGridView();
            this.Edit_Items = new System.Windows.Forms.GroupBox();
            this.itemsView7 = new System.Windows.Forms.DataGridView();
            this.nameItem7 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.countItem7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemAdd = new System.Windows.Forms.Button();
            this.itemWrite = new System.Windows.Forms.Button();
            this.label38 = new System.Windows.Forms.Label();
            this.deleteAmount = new System.Windows.Forms.NumericUpDown();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.delPkm = new System.Windows.Forms.Button();
            this.deleteBox = new System.Windows.Forms.NumericUpDown();
            this.deleteSlot = new System.Windows.Forms.NumericUpDown();
            this.cloneWriteTabs = new System.Windows.Forms.TabControl();
            this.cloneTab = new System.Windows.Forms.TabPage();
            this.cloneDoIt = new System.Windows.Forms.Button();
            this.cloneSlotFrom = new System.Windows.Forms.NumericUpDown();
            this.label52 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.cloneBoxFrom = new System.Windows.Forms.NumericUpDown();
            this.label40 = new System.Windows.Forms.Label();
            this.cloneCopiesNo = new System.Windows.Forms.NumericUpDown();
            this.label36 = new System.Windows.Forms.Label();
            this.cloneSlotTo = new System.Windows.Forms.NumericUpDown();
            this.label37 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.cloneBoxTo = new System.Windows.Forms.NumericUpDown();
            this.writeTab = new System.Windows.Forms.TabPage();
            this.writeDoIt = new System.Windows.Forms.Button();
            this.writeBrowse = new System.Windows.Forms.Button();
            this.writeAutoInc = new System.Windows.Forms.CheckBox();
            this.writeCopiesNo = new System.Windows.Forms.NumericUpDown();
            this.label35 = new System.Windows.Forms.Label();
            this.writeSlotTo = new System.Windows.Forms.NumericUpDown();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.writeBoxTo = new System.Windows.Forms.NumericUpDown();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.deleteKeepBackup = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.touchX = new System.Windows.Forms.NumericUpDown();
            this.touchY = new System.Windows.Forms.NumericUpDown();
            this.daycare_select = new System.Windows.Forms.GroupBox();
            this.radioDayCare1 = new System.Windows.Forms.RadioButton();
            this.radioDayCare2 = new System.Windows.Forms.RadioButton();
            this.orgbox_pos = new System.Windows.Forms.GroupBox();
            this.OrganizeMiddle = new System.Windows.Forms.RadioButton();
            this.OrganizeTop = new System.Windows.Forms.RadioButton();
            this.updateLabel = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.typeLSR = new System.Windows.Forms.ComboBox();
            this.RunLSRbot = new System.Windows.Forms.Button();
            this.resumeLSR = new System.Windows.Forms.CheckBox();
            this.label59 = new System.Windows.Forms.Label();
            this.RunWTbot = new System.Windows.Forms.Button();
            this.WTtradesNo = new System.Windows.Forms.NumericUpDown();
            this.label57 = new System.Windows.Forms.Label();
            this.WTBox = new System.Windows.Forms.NumericUpDown();
            this.WTSlot = new System.Windows.Forms.NumericUpDown();
            this.label58 = new System.Windows.Forms.Label();
            this.readResult = new System.Windows.Forms.TextBox();
            this.stopBotButton = new System.Windows.Forms.Button();
            this.manualDLeft = new System.Windows.Forms.Button();
            this.manualTouch = new System.Windows.Forms.Button();
            this.manualX = new System.Windows.Forms.Button();
            this.manualY = new System.Windows.Forms.Button();
            this.manualDUp = new System.Windows.Forms.Button();
            this.manualL = new System.Windows.Forms.Button();
            this.manualB = new System.Windows.Forms.Button();
            this.manualA = new System.Windows.Forms.Button();
            this.manualR = new System.Windows.Forms.Button();
            this.manualSelect = new System.Windows.Forms.Button();
            this.manualDRight = new System.Windows.Forms.Button();
            this.ManualDDown = new System.Windows.Forms.Button();
            this.manualStart = new System.Windows.Forms.Button();
            this.label69 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.miscTabs = new System.Windows.Forms.TabControl();
            this.tabEditTrainer = new System.Windows.Forms.TabPage();
            this.seedRNG = new System.Windows.Forms.TextBox();
            this.label60 = new System.Windows.Forms.Label();
            this.EggSeed = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.PokeDiggerBtn = new System.Windows.Forms.Button();
            this.ReloadFields = new System.Windows.Forms.Button();
            this.Edit_Trainer = new System.Windows.Forms.GroupBox();
            this.label55 = new System.Windows.Forms.Label();
            this.pokeTotalFC = new System.Windows.Forms.Button();
            this.totalFCNum = new System.Windows.Forms.NumericUpDown();
            this.tabControls = new System.Windows.Forms.TabPage();
            this.Remote_Stick = new System.Windows.Forms.GroupBox();
            this.StickX = new System.Windows.Forms.TrackBar();
            this.StickY = new System.Windows.Forms.TrackBar();
            this.StickNumY = new System.Windows.Forms.NumericUpDown();
            this.StickSend = new System.Windows.Forms.Button();
            this.StickNumX = new System.Windows.Forms.NumericUpDown();
            this.label62 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.Remote_touch = new System.Windows.Forms.GroupBox();
            this.label54 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.Remote_buttons = new System.Windows.Forms.GroupBox();
            this.manualSR = new System.Windows.Forms.Button();
            this.tabFilters = new System.Windows.Forms.TabPage();
            this.filterReset = new System.Windows.Forms.Button();
            this.filterRead = new System.Windows.Forms.Button();
            this.filterLoad = new System.Windows.Forms.Button();
            this.filterSave = new System.Windows.Forms.Button();
            this.filterRemove = new System.Windows.Forms.Button();
            this.filterAdd = new System.Windows.Forms.Button();
            this.filterList = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HPlogic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ATKlogic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEFlogic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPAlogic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPDlogic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPElogic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PerfectIVlogic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filterPerIVlogic = new System.Windows.Forms.ComboBox();
            this.filterSPElogic = new System.Windows.Forms.ComboBox();
            this.filterSPDlogic = new System.Windows.Forms.ComboBox();
            this.filterSPAlogic = new System.Windows.Forms.ComboBox();
            this.filterDEFlogic = new System.Windows.Forms.ComboBox();
            this.filterATKlogic = new System.Windows.Forms.ComboBox();
            this.filterHPlogic = new System.Windows.Forms.ComboBox();
            this.label81 = new System.Windows.Forms.Label();
            this.filterPerIVvalue = new System.Windows.Forms.NumericUpDown();
            this.label101 = new System.Windows.Forms.Label();
            this.filterShiny = new System.Windows.Forms.CheckBox();
            this.filterGender = new System.Windows.Forms.ComboBox();
            this.label102 = new System.Windows.Forms.Label();
            this.label103 = new System.Windows.Forms.Label();
            this.filterSPEvalue = new System.Windows.Forms.NumericUpDown();
            this.filterSPDvalue = new System.Windows.Forms.NumericUpDown();
            this.label104 = new System.Windows.Forms.Label();
            this.label105 = new System.Windows.Forms.Label();
            this.label106 = new System.Windows.Forms.Label();
            this.filterAbility = new System.Windows.Forms.ComboBox();
            this.filterDEFvalue = new System.Windows.Forms.NumericUpDown();
            this.label107 = new System.Windows.Forms.Label();
            this.label108 = new System.Windows.Forms.Label();
            this.filterNature = new System.Windows.Forms.ComboBox();
            this.filterSPAvalue = new System.Windows.Forms.NumericUpDown();
            this.filterHPtype = new System.Windows.Forms.ComboBox();
            this.filterHPvalue = new System.Windows.Forms.NumericUpDown();
            this.label109 = new System.Windows.Forms.Label();
            this.label110 = new System.Windows.Forms.Label();
            this.label111 = new System.Windows.Forms.Label();
            this.filterATKvalue = new System.Windows.Forms.NumericUpDown();
            this.label112 = new System.Windows.Forms.Label();
            this.tabBreeding = new System.Windows.Forms.TabPage();
            this.Breed_esvtsv = new System.Windows.Forms.GroupBox();
            this.label50 = new System.Windows.Forms.Label();
            this.ESVlist = new System.Windows.Forms.DataGridView();
            this.ESVlistBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESVlistSlot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESVlistValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESVlistSave = new System.Windows.Forms.Button();
            this.TSVlist = new System.Windows.Forms.ListBox();
            this.TSVlistNum = new System.Windows.Forms.NumericUpDown();
            this.TSVlistAdd = new System.Windows.Forms.Button();
            this.TSVlistLoad = new System.Windows.Forms.Button();
            this.TSVlistRemove = new System.Windows.Forms.Button();
            this.TSVlistSave = new System.Windows.Forms.Button();
            this.Breed_options = new System.Windows.Forms.GroupBox();
            this.modeBreed = new System.Windows.Forms.ComboBox();
            this.readESV = new System.Windows.Forms.CheckBox();
            this.Breed_labelBox = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.quickBreed = new System.Windows.Forms.CheckBox();
            this.slotBreed = new System.Windows.Forms.NumericUpDown();
            this.label84 = new System.Windows.Forms.Label();
            this.boxBreed = new System.Windows.Forms.NumericUpDown();
            this.Breed_labelSlot = new System.Windows.Forms.Label();
            this.eggsNoBreed = new System.Windows.Forms.NumericUpDown();
            this.breedingClear = new System.Windows.Forms.Button();
            this.filterBreeding = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bFilterLoad = new System.Windows.Forms.Button();
            this.runBreedingBot = new System.Windows.Forms.Button();
            this.tabSoftReset = new System.Windows.Forms.TabPage();
            this.SR_options = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.sr_Species = new System.Windows.Forms.ComboBox();
            this.srClear = new System.Windows.Forms.Button();
            this.filtersSoftReset = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn33 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn34 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn35 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn36 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn37 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn38 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn39 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn40 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn41 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn42 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn43 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn44 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn45 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn46 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn47 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn48 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn49 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn50 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.srFilterLoad = new System.Windows.Forms.Button();
            this.tabWonderTrade = new System.Windows.Forms.TabPage();
            this.WT_options = new System.Windows.Forms.GroupBox();
            this.WT_After = new System.Windows.Forms.GroupBox();
            this.WTafter_Delete = new System.Windows.Forms.RadioButton();
            this.WTafter_Restore = new System.Windows.Forms.RadioButton();
            this.WTafter_DoNothing = new System.Windows.Forms.RadioButton();
            this.WTafter_Dump = new System.Windows.Forms.CheckBox();
            this.WT_Sources = new System.Windows.Forms.GroupBox();
            this.WTsource_Random = new System.Windows.Forms.RadioButton();
            this.WTsource_Folder = new System.Windows.Forms.RadioButton();
            this.WTsource_Boxes = new System.Windows.Forms.RadioButton();
            this.WTcollectFC = new System.Windows.Forms.CheckBox();
            this.WT_RunEndless = new System.Windows.Forms.CheckBox();
            this.tabNTRlog = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.shinypic = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moneyNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.milesNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bpNum)).BeginInit();
            this.dumpBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slotDump)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxDump)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SIDNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TIDNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hourNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keysGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bersGridView)).BeginInit();
            this.Edit_Items.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemsView7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deleteAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deleteBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deleteSlot)).BeginInit();
            this.cloneWriteTabs.SuspendLayout();
            this.cloneTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cloneSlotFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cloneBoxFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cloneCopiesNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cloneSlotTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cloneBoxTo)).BeginInit();
            this.writeTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.writeCopiesNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.writeSlotTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.writeBoxTo)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.touchX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.touchY)).BeginInit();
            this.daycare_select.SuspendLayout();
            this.orgbox_pos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WTtradesNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WTBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WTSlot)).BeginInit();
            this.miscTabs.SuspendLayout();
            this.tabEditTrainer.SuspendLayout();
            this.Edit_Trainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.totalFCNum)).BeginInit();
            this.tabControls.SuspendLayout();
            this.Remote_Stick.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StickX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StickY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StickNumY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StickNumX)).BeginInit();
            this.Remote_touch.SuspendLayout();
            this.Remote_buttons.SuspendLayout();
            this.tabFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filterList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterPerIVvalue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterSPEvalue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterSPDvalue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterDEFvalue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterSPAvalue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterHPvalue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterATKvalue)).BeginInit();
            this.tabBreeding.SuspendLayout();
            this.Breed_esvtsv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ESVlist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TSVlistNum)).BeginInit();
            this.Breed_options.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slotBreed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxBreed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eggsNoBreed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterBreeding)).BeginInit();
            this.tabSoftReset.SuspendLayout();
            this.SR_options.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filtersSoftReset)).BeginInit();
            this.tabWonderTrade.SuspendLayout();
            this.WT_options.SuspendLayout();
            this.WT_After.SuspendLayout();
            this.WT_Sources.SuspendLayout();
            this.tabNTRlog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shinypic)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.Black;
            this.txtLog.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtLog.ForeColor = System.Drawing.Color.LawnGreen;
            this.txtLog.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtLog.Location = new System.Drawing.Point(3, 3);
            this.txtLog.MaxLength = 32767000;
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(552, 344);
            this.txtLog.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // disconnectTimer
            // 
            this.disconnectTimer.Interval = 10000;
            this.disconnectTimer.Tick += new System.EventHandler(this.disconnectTimer_Tick);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(130, 18);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(82, 21);
            this.buttonConnect.TabIndex = 1;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Enabled = false;
            this.buttonDisconnect.Location = new System.Drawing.Point(218, 18);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(83, 21);
            this.buttonDisconnect.TabIndex = 2;
            this.buttonDisconnect.Text = "Disconnect";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // host
            // 
            this.host.Location = new System.Drawing.Point(32, 19);
            this.host.Name = "host";
            this.host.Size = new System.Drawing.Size(92, 20);
            this.host.TabIndex = 0;
            this.toolTip1.SetToolTip(this.host, "Input you console\'s local IP address here.\r\nYour computer and your console need t" +
        "o be on the same local network.");
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.buttonDisconnect);
            this.groupBox1.Controls.Add(this.host);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonConnect);
            this.groupBox1.Location = new System.Drawing.Point(7, 368);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(307, 48);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "IP:";
            // 
            // moneyNum
            // 
            this.moneyNum.Location = new System.Drawing.Point(81, 109);
            this.moneyNum.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.moneyNum.Name = "moneyNum";
            this.moneyNum.Size = new System.Drawing.Size(80, 20);
            this.moneyNum.TabIndex = 6;
            this.moneyNum.ThousandsSeparator = true;
            // 
            // milesNum
            // 
            this.milesNum.Location = new System.Drawing.Point(81, 138);
            this.milesNum.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.milesNum.Name = "milesNum";
            this.milesNum.Size = new System.Drawing.Size(80, 20);
            this.milesNum.TabIndex = 8;
            this.milesNum.ThousandsSeparator = true;
            // 
            // bpNum
            // 
            this.bpNum.Location = new System.Drawing.Point(81, 196);
            this.bpNum.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.bpNum.Name = "bpNum";
            this.bpNum.Size = new System.Drawing.Size(80, 20);
            this.bpNum.TabIndex = 12;
            // 
            // pokeMoney
            // 
            this.pokeMoney.AutoSize = true;
            this.pokeMoney.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pokeMoney.Location = new System.Drawing.Point(167, 106);
            this.pokeMoney.Name = "pokeMoney";
            this.pokeMoney.Size = new System.Drawing.Size(42, 23);
            this.pokeMoney.TabIndex = 7;
            this.pokeMoney.Text = "Write";
            this.pokeMoney.UseVisualStyleBackColor = true;
            this.pokeMoney.Click += new System.EventHandler(this.pokeMoney_Click);
            // 
            // pokeMiles
            // 
            this.pokeMiles.AutoSize = true;
            this.pokeMiles.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pokeMiles.Location = new System.Drawing.Point(167, 135);
            this.pokeMiles.Name = "pokeMiles";
            this.pokeMiles.Size = new System.Drawing.Size(42, 23);
            this.pokeMiles.TabIndex = 9;
            this.pokeMiles.Text = "Write";
            this.pokeMiles.UseVisualStyleBackColor = true;
            this.pokeMiles.Click += new System.EventHandler(this.pokeMiles_Click);
            // 
            // pokeBP
            // 
            this.pokeBP.AutoSize = true;
            this.pokeBP.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pokeBP.Location = new System.Drawing.Point(167, 194);
            this.pokeBP.Name = "pokeBP";
            this.pokeBP.Size = new System.Drawing.Size(42, 23);
            this.pokeBP.TabIndex = 13;
            this.pokeBP.Text = "Write";
            this.pokeBP.UseVisualStyleBackColor = true;
            this.pokeBP.Click += new System.EventHandler(this.pokeBP_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Money:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Poké Miles:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 19);
            this.label4.TabIndex = 26;
            this.label4.Text = "Battle Points:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dumpBox
            // 
            this.dumpBox.Controls.Add(this.DumpInstructionsBtn);
            this.dumpBox.Controls.Add(this.radioBattleBox);
            this.dumpBox.Controls.Add(this.onlyView);
            this.dumpBox.Controls.Add(this.radioParty);
            this.dumpBox.Controls.Add(this.radioTrade);
            this.dumpBox.Controls.Add(this.radioOpponent);
            this.dumpBox.Controls.Add(this.radioDaycare);
            this.dumpBox.Controls.Add(this.radioBoxes);
            this.dumpBox.Controls.Add(this.dumpBoxes);
            this.dumpBox.Controls.Add(this.label9);
            this.dumpBox.Controls.Add(this.nameek6);
            this.dumpBox.Controls.Add(this.dumpPokemon);
            this.dumpBox.Controls.Add(this.SlotLabel);
            this.dumpBox.Controls.Add(this.slotDump);
            this.dumpBox.Controls.Add(this.BoxLabel);
            this.dumpBox.Controls.Add(this.boxDump);
            this.dumpBox.Location = new System.Drawing.Point(7, 12);
            this.dumpBox.Name = "dumpBox";
            this.dumpBox.Size = new System.Drawing.Size(311, 137);
            this.dumpBox.TabIndex = 1;
            this.dumpBox.TabStop = false;
            this.dumpBox.Text = "Dump and Edit Pokémon";
            // 
            // DumpInstructionsBtn
            // 
            this.DumpInstructionsBtn.Location = new System.Drawing.Point(230, 10);
            this.DumpInstructionsBtn.Name = "DumpInstructionsBtn";
            this.DumpInstructionsBtn.Size = new System.Drawing.Size(75, 23);
            this.DumpInstructionsBtn.TabIndex = 15;
            this.DumpInstructionsBtn.Text = "How to use";
            this.DumpInstructionsBtn.UseVisualStyleBackColor = true;
            this.DumpInstructionsBtn.Visible = false;
            this.DumpInstructionsBtn.Click += new System.EventHandler(this.DumpInstructionsBtn_Click);
            // 
            // radioBattleBox
            // 
            this.radioBattleBox.AutoSize = true;
            this.radioBattleBox.Location = new System.Drawing.Point(224, 91);
            this.radioBattleBox.Name = "radioBattleBox";
            this.radioBattleBox.Size = new System.Drawing.Size(73, 17);
            this.radioBattleBox.TabIndex = 7;
            this.radioBattleBox.Text = "Battle Box";
            this.radioBattleBox.UseVisualStyleBackColor = true;
            this.radioBattleBox.CheckedChanged += new System.EventHandler(this.radioBattleBox_CheckedChanged);
            // 
            // onlyView
            // 
            this.onlyView.AutoSize = true;
            this.onlyView.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.onlyView.Location = new System.Drawing.Point(238, 66);
            this.onlyView.Name = "onlyView";
            this.onlyView.Size = new System.Drawing.Size(67, 17);
            this.onlyView.TabIndex = 11;
            this.onlyView.Text = "Only edit";
            this.toolTip1.SetToolTip(this.onlyView, "If checked, Pokemon won\'t be dumped to file");
            this.onlyView.UseVisualStyleBackColor = true;
            this.onlyView.CheckedChanged += new System.EventHandler(this.onlyView_CheckedChanged);
            // 
            // radioParty
            // 
            this.radioParty.AutoSize = true;
            this.radioParty.Location = new System.Drawing.Point(224, 114);
            this.radioParty.Name = "radioParty";
            this.radioParty.Size = new System.Drawing.Size(49, 17);
            this.radioParty.TabIndex = 10;
            this.radioParty.Text = "Party";
            this.radioParty.UseVisualStyleBackColor = true;
            this.radioParty.CheckedChanged += new System.EventHandler(this.radioParty_CheckedChanged_1);
            // 
            // radioTrade
            // 
            this.radioTrade.AutoSize = true;
            this.radioTrade.Location = new System.Drawing.Point(9, 114);
            this.radioTrade.Name = "radioTrade";
            this.radioTrade.Size = new System.Drawing.Size(53, 17);
            this.radioTrade.TabIndex = 8;
            this.radioTrade.TabStop = true;
            this.radioTrade.Text = "Trade";
            this.radioTrade.UseVisualStyleBackColor = true;
            this.radioTrade.CheckedChanged += new System.EventHandler(this.radioTrade_CheckedChanged);
            // 
            // radioOpponent
            // 
            this.radioOpponent.AutoSize = true;
            this.radioOpponent.Location = new System.Drawing.Point(119, 114);
            this.radioOpponent.Name = "radioOpponent";
            this.radioOpponent.Size = new System.Drawing.Size(72, 17);
            this.radioOpponent.TabIndex = 9;
            this.radioOpponent.TabStop = true;
            this.radioOpponent.Text = "Opponent";
            this.radioOpponent.UseVisualStyleBackColor = true;
            this.radioOpponent.CheckedChanged += new System.EventHandler(this.radioOpponent_CheckedChanged);
            // 
            // radioDaycare
            // 
            this.radioDaycare.AutoSize = true;
            this.radioDaycare.Location = new System.Drawing.Point(119, 91);
            this.radioDaycare.Name = "radioDaycare";
            this.radioDaycare.Size = new System.Drawing.Size(65, 17);
            this.radioDaycare.TabIndex = 6;
            this.radioDaycare.Text = "Daycare";
            this.radioDaycare.UseVisualStyleBackColor = true;
            this.radioDaycare.CheckedChanged += new System.EventHandler(this.radioDaycare_CheckedChanged);
            // 
            // radioBoxes
            // 
            this.radioBoxes.AutoSize = true;
            this.radioBoxes.Checked = true;
            this.radioBoxes.Location = new System.Drawing.Point(9, 91);
            this.radioBoxes.Name = "radioBoxes";
            this.radioBoxes.Size = new System.Drawing.Size(54, 17);
            this.radioBoxes.TabIndex = 5;
            this.radioBoxes.TabStop = true;
            this.radioBoxes.Text = "Boxes";
            this.radioBoxes.UseVisualStyleBackColor = true;
            this.radioBoxes.CheckedChanged += new System.EventHandler(this.radioBoxes_CheckedChanged);
            // 
            // dumpBoxes
            // 
            this.dumpBoxes.Location = new System.Drawing.Point(119, 62);
            this.dumpBoxes.Name = "dumpBoxes";
            this.dumpBoxes.Size = new System.Drawing.Size(113, 23);
            this.dumpBoxes.TabIndex = 4;
            this.dumpBoxes.Text = "Dump All Boxes";
            this.dumpBoxes.UseVisualStyleBackColor = true;
            this.dumpBoxes.Click += new System.EventHandler(this.dumpBoxes_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(112, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Filename:";
            // 
            // nameek6
            // 
            this.nameek6.Location = new System.Drawing.Point(113, 36);
            this.nameek6.Name = "nameek6";
            this.nameek6.Size = new System.Drawing.Size(192, 20);
            this.nameek6.TabIndex = 2;
            this.nameek6.Text = "pkmn";
            // 
            // dumpPokemon
            // 
            this.dumpPokemon.Location = new System.Drawing.Point(9, 62);
            this.dumpPokemon.Name = "dumpPokemon";
            this.dumpPokemon.Size = new System.Drawing.Size(104, 23);
            this.dumpPokemon.TabIndex = 3;
            this.dumpPokemon.Text = "Dump";
            this.dumpPokemon.UseVisualStyleBackColor = true;
            this.dumpPokemon.Click += new System.EventHandler(this.dumpPokemon_Click);
            // 
            // SlotLabel
            // 
            this.SlotLabel.AutoSize = true;
            this.SlotLabel.Location = new System.Drawing.Point(58, 20);
            this.SlotLabel.Name = "SlotLabel";
            this.SlotLabel.Size = new System.Drawing.Size(28, 13);
            this.SlotLabel.TabIndex = 13;
            this.SlotLabel.Text = "Slot:";
            // 
            // slotDump
            // 
            this.slotDump.Location = new System.Drawing.Point(61, 36);
            this.slotDump.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.slotDump.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.slotDump.Name = "slotDump";
            this.slotDump.Size = new System.Drawing.Size(46, 20);
            this.slotDump.TabIndex = 1;
            this.slotDump.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // BoxLabel
            // 
            this.BoxLabel.AutoSize = true;
            this.BoxLabel.Location = new System.Drawing.Point(6, 20);
            this.BoxLabel.Name = "BoxLabel";
            this.BoxLabel.Size = new System.Drawing.Size(28, 13);
            this.BoxLabel.TabIndex = 12;
            this.BoxLabel.Text = "Box:";
            // 
            // boxDump
            // 
            this.boxDump.Location = new System.Drawing.Point(9, 36);
            this.boxDump.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.boxDump.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.boxDump.Name = "boxDump";
            this.boxDump.Size = new System.Drawing.Size(46, 20);
            this.boxDump.TabIndex = 0;
            this.boxDump.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // itemsGridView
            // 
            this.itemsGridView.AllowUserToAddRows = false;
            this.itemsGridView.AllowUserToDeleteRows = false;
            this.itemsGridView.AllowUserToResizeColumns = false;
            this.itemsGridView.AllowUserToResizeRows = false;
            this.itemsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemsGridView.Enabled = false;
            this.itemsGridView.Location = new System.Drawing.Point(6, 19);
            this.itemsGridView.Name = "itemsGridView";
            this.itemsGridView.RowHeadersVisible = false;
            this.itemsGridView.ShowEditingIcon = false;
            this.itemsGridView.Size = new System.Drawing.Size(191, 177);
            this.itemsGridView.TabIndex = 0;
            // 
            // Item
            // 
            this.Item.Name = "Item";
            // 
            // Amount
            // 
            this.Amount.Name = "Amount";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(17, 228);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(58, 13);
            this.label28.TabIndex = 27;
            this.label28.Text = "Language:";
            // 
            // Lang
            // 
            this.Lang.FormattingEnabled = true;
            this.Lang.Location = new System.Drawing.Point(81, 225);
            this.Lang.Name = "Lang";
            this.Lang.Size = new System.Drawing.Size(80, 21);
            this.Lang.TabIndex = 14;
            this.toolTip1.SetToolTip(this.Lang, "Save your game and restart to see the change.");
            // 
            // pokeLang
            // 
            this.pokeLang.AutoSize = true;
            this.pokeLang.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pokeLang.Location = new System.Drawing.Point(167, 223);
            this.pokeLang.Name = "pokeLang";
            this.pokeLang.Size = new System.Drawing.Size(42, 23);
            this.pokeLang.TabIndex = 15;
            this.pokeLang.Text = "Write";
            this.pokeLang.UseVisualStyleBackColor = true;
            this.pokeLang.Click += new System.EventHandler(this.pokeLang_Click);
            // 
            // pokeSID
            // 
            this.pokeSID.AutoSize = true;
            this.pokeSID.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pokeSID.Location = new System.Drawing.Point(167, 77);
            this.pokeSID.Name = "pokeSID";
            this.pokeSID.Size = new System.Drawing.Size(42, 23);
            this.pokeSID.TabIndex = 5;
            this.pokeSID.Text = "Write";
            this.pokeSID.UseVisualStyleBackColor = true;
            this.pokeSID.Click += new System.EventHandler(this.pokeSID_Click);
            // 
            // SIDNum
            // 
            this.SIDNum.Location = new System.Drawing.Point(81, 80);
            this.SIDNum.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.SIDNum.Name = "SIDNum";
            this.SIDNum.Size = new System.Drawing.Size(80, 20);
            this.SIDNum.TabIndex = 4;
            this.SIDNum.ValueChanged += new System.EventHandler(this.TIDNum_ValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(47, 82);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(28, 13);
            this.label15.TabIndex = 22;
            this.label15.Text = "SID:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(118, 249);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 13);
            this.label14.TabIndex = 30;
            this.label14.Text = "Secs:";
            // 
            // pokeTID
            // 
            this.pokeTID.AutoSize = true;
            this.pokeTID.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pokeTID.Location = new System.Drawing.Point(167, 48);
            this.pokeTID.Name = "pokeTID";
            this.pokeTID.Size = new System.Drawing.Size(42, 23);
            this.pokeTID.TabIndex = 3;
            this.pokeTID.Text = "Write";
            this.pokeTID.UseVisualStyleBackColor = true;
            this.pokeTID.Click += new System.EventHandler(this.pokeTID_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(72, 249);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "Mins:";
            // 
            // TIDNum
            // 
            this.TIDNum.Location = new System.Drawing.Point(81, 51);
            this.TIDNum.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.TIDNum.Name = "TIDNum";
            this.TIDNum.Size = new System.Drawing.Size(80, 20);
            this.TIDNum.TabIndex = 2;
            this.TIDNum.ValueChanged += new System.EventHandler(this.TIDNum_ValueChanged);
            // 
            // secNum
            // 
            this.secNum.Location = new System.Drawing.Point(121, 265);
            this.secNum.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.secNum.Name = "secNum";
            this.secNum.Size = new System.Drawing.Size(40, 20);
            this.secNum.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(47, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "TID:";
            // 
            // minNum
            // 
            this.minNum.Location = new System.Drawing.Point(75, 265);
            this.minNum.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.minNum.Name = "minNum";
            this.minNum.Size = new System.Drawing.Size(40, 20);
            this.minNum.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(37, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Name:";
            // 
            // pokeTime
            // 
            this.pokeTime.AutoSize = true;
            this.pokeTime.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pokeTime.Location = new System.Drawing.Point(167, 262);
            this.pokeTime.Name = "pokeTime";
            this.pokeTime.Size = new System.Drawing.Size(42, 23);
            this.pokeTime.TabIndex = 19;
            this.pokeTime.Text = "Write";
            this.pokeTime.UseVisualStyleBackColor = true;
            this.pokeTime.Click += new System.EventHandler(this.pokeTime_Click);
            // 
            // pokeName
            // 
            this.pokeName.AutoSize = true;
            this.pokeName.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pokeName.Location = new System.Drawing.Point(167, 19);
            this.pokeName.Name = "pokeName";
            this.pokeName.Size = new System.Drawing.Size(42, 23);
            this.pokeName.TabIndex = 1;
            this.pokeName.Text = "Write";
            this.pokeName.UseVisualStyleBackColor = true;
            this.pokeName.Click += new System.EventHandler(this.pokeName_Click);
            // 
            // hourNum
            // 
            this.hourNum.Location = new System.Drawing.Point(6, 265);
            this.hourNum.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.hourNum.Name = "hourNum";
            this.hourNum.Size = new System.Drawing.Size(63, 20);
            this.hourNum.TabIndex = 16;
            // 
            // playerName
            // 
            this.playerName.Location = new System.Drawing.Point(81, 21);
            this.playerName.Name = "playerName";
            this.playerName.Size = new System.Drawing.Size(80, 20);
            this.playerName.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 249);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "Hours:";
            // 
            // showKeys
            // 
            this.showKeys.Location = new System.Drawing.Point(203, 135);
            this.showKeys.Name = "showKeys";
            this.showKeys.Size = new System.Drawing.Size(115, 23);
            this.showKeys.TabIndex = 5;
            this.showKeys.Text = "KEY ITEMS";
            this.showKeys.UseVisualStyleBackColor = true;
            this.showKeys.Click += new System.EventHandler(this.showKeys_Click);
            // 
            // showBerries
            // 
            this.showBerries.Location = new System.Drawing.Point(203, 106);
            this.showBerries.Name = "showBerries";
            this.showBerries.Size = new System.Drawing.Size(115, 23);
            this.showBerries.TabIndex = 4;
            this.showBerries.Text = "BERRIES";
            this.showBerries.UseVisualStyleBackColor = true;
            this.showBerries.Click += new System.EventHandler(this.showBerries_Click);
            // 
            // showTMs
            // 
            this.showTMs.Location = new System.Drawing.Point(203, 77);
            this.showTMs.Name = "showTMs";
            this.showTMs.Size = new System.Drawing.Size(115, 23);
            this.showTMs.TabIndex = 3;
            this.showTMs.Text = "TMs && HMs";
            this.showTMs.UseVisualStyleBackColor = true;
            this.showTMs.Click += new System.EventHandler(this.showTMs_Click);
            // 
            // showMedicine
            // 
            this.showMedicine.Location = new System.Drawing.Point(203, 48);
            this.showMedicine.Name = "showMedicine";
            this.showMedicine.Size = new System.Drawing.Size(115, 23);
            this.showMedicine.TabIndex = 2;
            this.showMedicine.Text = "MEDICINE";
            this.showMedicine.UseVisualStyleBackColor = true;
            this.showMedicine.Click += new System.EventHandler(this.showMedicine_Click);
            // 
            // showItems
            // 
            this.showItems.ForeColor = System.Drawing.Color.Green;
            this.showItems.Location = new System.Drawing.Point(203, 19);
            this.showItems.Name = "showItems";
            this.showItems.Size = new System.Drawing.Size(115, 23);
            this.showItems.TabIndex = 1;
            this.showItems.Text = "ITEMS";
            this.showItems.UseVisualStyleBackColor = true;
            this.showItems.Click += new System.EventHandler(this.showItems_Click);
            // 
            // keysGridView
            // 
            this.keysGridView.AllowUserToAddRows = false;
            this.keysGridView.AllowUserToDeleteRows = false;
            this.keysGridView.AllowUserToResizeColumns = false;
            this.keysGridView.AllowUserToResizeRows = false;
            this.keysGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.keysGridView.Enabled = false;
            this.keysGridView.Location = new System.Drawing.Point(6, 19);
            this.keysGridView.Name = "keysGridView";
            this.keysGridView.RowHeadersVisible = false;
            this.keysGridView.ShowEditingIcon = false;
            this.keysGridView.Size = new System.Drawing.Size(191, 177);
            this.keysGridView.TabIndex = 0;
            this.keysGridView.Visible = false;
            // 
            // tmsGridView
            // 
            this.tmsGridView.AllowUserToAddRows = false;
            this.tmsGridView.AllowUserToDeleteRows = false;
            this.tmsGridView.AllowUserToResizeColumns = false;
            this.tmsGridView.AllowUserToResizeRows = false;
            this.tmsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tmsGridView.Enabled = false;
            this.tmsGridView.Location = new System.Drawing.Point(6, 19);
            this.tmsGridView.Name = "tmsGridView";
            this.tmsGridView.RowHeadersVisible = false;
            this.tmsGridView.ShowEditingIcon = false;
            this.tmsGridView.Size = new System.Drawing.Size(191, 177);
            this.tmsGridView.TabIndex = 0;
            this.tmsGridView.Visible = false;
            // 
            // medsGridView
            // 
            this.medsGridView.AllowUserToAddRows = false;
            this.medsGridView.AllowUserToDeleteRows = false;
            this.medsGridView.AllowUserToResizeColumns = false;
            this.medsGridView.AllowUserToResizeRows = false;
            this.medsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.medsGridView.Enabled = false;
            this.medsGridView.Location = new System.Drawing.Point(6, 19);
            this.medsGridView.Name = "medsGridView";
            this.medsGridView.RowHeadersVisible = false;
            this.medsGridView.ShowEditingIcon = false;
            this.medsGridView.Size = new System.Drawing.Size(191, 177);
            this.medsGridView.TabIndex = 0;
            this.medsGridView.Visible = false;
            // 
            // bersGridView
            // 
            this.bersGridView.AllowUserToAddRows = false;
            this.bersGridView.AllowUserToDeleteRows = false;
            this.bersGridView.AllowUserToResizeColumns = false;
            this.bersGridView.AllowUserToResizeRows = false;
            this.bersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bersGridView.Enabled = false;
            this.bersGridView.Location = new System.Drawing.Point(6, 19);
            this.bersGridView.Name = "bersGridView";
            this.bersGridView.RowHeadersVisible = false;
            this.bersGridView.ShowEditingIcon = false;
            this.bersGridView.Size = new System.Drawing.Size(191, 177);
            this.bersGridView.TabIndex = 0;
            this.bersGridView.Visible = false;
            // 
            // Edit_Items
            // 
            this.Edit_Items.AutoSize = true;
            this.Edit_Items.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Edit_Items.Controls.Add(this.itemsView7);
            this.Edit_Items.Controls.Add(this.itemAdd);
            this.Edit_Items.Controls.Add(this.showKeys);
            this.Edit_Items.Controls.Add(this.itemWrite);
            this.Edit_Items.Controls.Add(this.showBerries);
            this.Edit_Items.Controls.Add(this.showTMs);
            this.Edit_Items.Controls.Add(this.showItems);
            this.Edit_Items.Controls.Add(this.showMedicine);
            this.Edit_Items.Controls.Add(this.itemsGridView);
            this.Edit_Items.Controls.Add(this.medsGridView);
            this.Edit_Items.Controls.Add(this.tmsGridView);
            this.Edit_Items.Controls.Add(this.keysGridView);
            this.Edit_Items.Controls.Add(this.bersGridView);
            this.Edit_Items.Location = new System.Drawing.Point(6, 6);
            this.Edit_Items.Name = "Edit_Items";
            this.Edit_Items.Size = new System.Drawing.Size(324, 215);
            this.Edit_Items.TabIndex = 0;
            this.Edit_Items.TabStop = false;
            this.Edit_Items.Text = "Edit Items";
            // 
            // itemsView7
            // 
            this.itemsView7.AllowUserToAddRows = false;
            this.itemsView7.AllowUserToDeleteRows = false;
            this.itemsView7.AllowUserToResizeColumns = false;
            this.itemsView7.AllowUserToResizeRows = false;
            this.itemsView7.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.itemsView7.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemsView7.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameItem7,
            this.countItem7});
            this.itemsView7.Location = new System.Drawing.Point(6, 19);
            this.itemsView7.Name = "itemsView7";
            this.itemsView7.RowHeadersVisible = false;
            this.itemsView7.ShowEditingIcon = false;
            this.itemsView7.Size = new System.Drawing.Size(191, 177);
            this.itemsView7.TabIndex = 8;
            // 
            // nameItem7
            // 
            this.nameItem7.FillWeight = 3F;
            this.nameItem7.HeaderText = "Item";
            this.nameItem7.Name = "nameItem7";
            // 
            // countItem7
            // 
            this.countItem7.FillWeight = 1F;
            this.countItem7.HeaderText = "Count";
            this.countItem7.Name = "countItem7";
            // 
            // itemAdd
            // 
            this.itemAdd.Location = new System.Drawing.Point(260, 164);
            this.itemAdd.Name = "itemAdd";
            this.itemAdd.Size = new System.Drawing.Size(57, 23);
            this.itemAdd.TabIndex = 7;
            this.itemAdd.Text = "Add Item";
            this.itemAdd.UseVisualStyleBackColor = true;
            this.itemAdd.Click += new System.EventHandler(this.itemAdd_Click);
            // 
            // itemWrite
            // 
            this.itemWrite.Location = new System.Drawing.Point(203, 164);
            this.itemWrite.Name = "itemWrite";
            this.itemWrite.Size = new System.Drawing.Size(57, 23);
            this.itemWrite.TabIndex = 6;
            this.itemWrite.Text = "Write";
            this.itemWrite.UseVisualStyleBackColor = true;
            this.itemWrite.Click += new System.EventHandler(this.itemWrite_Click);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(180, 7);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(61, 13);
            this.label38.TabIndex = 7;
            this.label38.Text = "# to delete:";
            // 
            // deleteAmount
            // 
            this.deleteAmount.Location = new System.Drawing.Point(242, 5);
            this.deleteAmount.Maximum = new decimal(new int[] {
            930,
            0,
            0,
            0});
            this.deleteAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.deleteAmount.Name = "deleteAmount";
            this.deleteAmount.Size = new System.Drawing.Size(50, 20);
            this.deleteAmount.TabIndex = 2;
            this.deleteAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(93, 7);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(25, 13);
            this.label26.TabIndex = 6;
            this.label26.Text = "Slot";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(6, 7);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(25, 13);
            this.label27.TabIndex = 5;
            this.label27.Text = "Box";
            // 
            // delPkm
            // 
            this.delPkm.ForeColor = System.Drawing.Color.Red;
            this.delPkm.Location = new System.Drawing.Point(228, 66);
            this.delPkm.Name = "delPkm";
            this.delPkm.Size = new System.Drawing.Size(75, 23);
            this.delPkm.TabIndex = 4;
            this.delPkm.Text = "Delete";
            this.delPkm.UseVisualStyleBackColor = true;
            this.delPkm.Click += new System.EventHandler(this.delPkm_Click);
            // 
            // deleteBox
            // 
            this.deleteBox.Location = new System.Drawing.Point(37, 5);
            this.deleteBox.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.deleteBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.deleteBox.Name = "deleteBox";
            this.deleteBox.Size = new System.Drawing.Size(50, 20);
            this.deleteBox.TabIndex = 0;
            this.deleteBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.deleteBox.ValueChanged += new System.EventHandler(this.deleteBox_ValueChanged);
            // 
            // deleteSlot
            // 
            this.deleteSlot.Location = new System.Drawing.Point(124, 5);
            this.deleteSlot.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.deleteSlot.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.deleteSlot.Name = "deleteSlot";
            this.deleteSlot.Size = new System.Drawing.Size(50, 20);
            this.deleteSlot.TabIndex = 1;
            this.deleteSlot.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.deleteSlot.ValueChanged += new System.EventHandler(this.deleteSlot_ValueChanged);
            // 
            // cloneWriteTabs
            // 
            this.cloneWriteTabs.Controls.Add(this.cloneTab);
            this.cloneWriteTabs.Controls.Add(this.writeTab);
            this.cloneWriteTabs.Controls.Add(this.tabPage1);
            this.cloneWriteTabs.Location = new System.Drawing.Point(6, 227);
            this.cloneWriteTabs.Name = "cloneWriteTabs";
            this.cloneWriteTabs.SelectedIndex = 0;
            this.cloneWriteTabs.Size = new System.Drawing.Size(317, 121);
            this.cloneWriteTabs.TabIndex = 2;
            this.cloneWriteTabs.TabStop = false;
            // 
            // cloneTab
            // 
            this.cloneTab.Controls.Add(this.cloneDoIt);
            this.cloneTab.Controls.Add(this.cloneSlotFrom);
            this.cloneTab.Controls.Add(this.label52);
            this.cloneTab.Controls.Add(this.label53);
            this.cloneTab.Controls.Add(this.cloneBoxFrom);
            this.cloneTab.Controls.Add(this.label40);
            this.cloneTab.Controls.Add(this.cloneCopiesNo);
            this.cloneTab.Controls.Add(this.label36);
            this.cloneTab.Controls.Add(this.cloneSlotTo);
            this.cloneTab.Controls.Add(this.label37);
            this.cloneTab.Controls.Add(this.label39);
            this.cloneTab.Controls.Add(this.cloneBoxTo);
            this.cloneTab.Location = new System.Drawing.Point(4, 22);
            this.cloneTab.Name = "cloneTab";
            this.cloneTab.Padding = new System.Windows.Forms.Padding(3);
            this.cloneTab.Size = new System.Drawing.Size(309, 95);
            this.cloneTab.TabIndex = 0;
            this.cloneTab.Text = "Clone";
            this.cloneTab.UseVisualStyleBackColor = true;
            // 
            // cloneDoIt
            // 
            this.cloneDoIt.Location = new System.Drawing.Point(228, 65);
            this.cloneDoIt.Name = "cloneDoIt";
            this.cloneDoIt.Size = new System.Drawing.Size(75, 23);
            this.cloneDoIt.TabIndex = 17;
            this.cloneDoIt.Text = "Clone";
            this.cloneDoIt.UseVisualStyleBackColor = true;
            this.cloneDoIt.Click += new System.EventHandler(this.cloneDoIt_Click);
            // 
            // cloneSlotFrom
            // 
            this.cloneSlotFrom.Location = new System.Drawing.Point(124, 50);
            this.cloneSlotFrom.Name = "cloneSlotFrom";
            this.cloneSlotFrom.Size = new System.Drawing.Size(50, 20);
            this.cloneSlotFrom.TabIndex = 16;
            this.cloneSlotFrom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(93, 52);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(25, 13);
            this.label52.TabIndex = 15;
            this.label52.Text = "Slot";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(6, 52);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(25, 13);
            this.label53.TabIndex = 14;
            this.label53.Text = "Box";
            // 
            // cloneBoxFrom
            // 
            this.cloneBoxFrom.Location = new System.Drawing.Point(37, 50);
            this.cloneBoxFrom.Name = "cloneBoxFrom";
            this.cloneBoxFrom.Size = new System.Drawing.Size(50, 20);
            this.cloneBoxFrom.TabIndex = 13;
            this.cloneBoxFrom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(5, 30);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(33, 13);
            this.label40.TabIndex = 12;
            this.label40.Text = "From:";
            // 
            // cloneCopiesNo
            // 
            this.cloneCopiesNo.Location = new System.Drawing.Point(234, 5);
            this.cloneCopiesNo.Name = "cloneCopiesNo";
            this.cloneCopiesNo.Size = new System.Drawing.Size(50, 20);
            this.cloneCopiesNo.TabIndex = 11;
            this.cloneCopiesNo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(180, 7);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(48, 13);
            this.label36.TabIndex = 10;
            this.label36.Text = "# copies";
            // 
            // cloneSlotTo
            // 
            this.cloneSlotTo.Location = new System.Drawing.Point(124, 5);
            this.cloneSlotTo.Name = "cloneSlotTo";
            this.cloneSlotTo.Size = new System.Drawing.Size(50, 20);
            this.cloneSlotTo.TabIndex = 9;
            this.cloneSlotTo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(93, 7);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(25, 13);
            this.label37.TabIndex = 8;
            this.label37.Text = "Slot";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(6, 7);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(25, 13);
            this.label39.TabIndex = 7;
            this.label39.Text = "Box";
            // 
            // cloneBoxTo
            // 
            this.cloneBoxTo.Location = new System.Drawing.Point(37, 5);
            this.cloneBoxTo.Name = "cloneBoxTo";
            this.cloneBoxTo.Size = new System.Drawing.Size(50, 20);
            this.cloneBoxTo.TabIndex = 6;
            this.cloneBoxTo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // writeTab
            // 
            this.writeTab.AllowDrop = true;
            this.writeTab.Controls.Add(this.writeDoIt);
            this.writeTab.Controls.Add(this.writeBrowse);
            this.writeTab.Controls.Add(this.writeAutoInc);
            this.writeTab.Controls.Add(this.writeCopiesNo);
            this.writeTab.Controls.Add(this.label35);
            this.writeTab.Controls.Add(this.writeSlotTo);
            this.writeTab.Controls.Add(this.label34);
            this.writeTab.Controls.Add(this.label33);
            this.writeTab.Controls.Add(this.writeBoxTo);
            this.writeTab.Location = new System.Drawing.Point(4, 22);
            this.writeTab.Name = "writeTab";
            this.writeTab.Padding = new System.Windows.Forms.Padding(3);
            this.writeTab.Size = new System.Drawing.Size(309, 95);
            this.writeTab.TabIndex = 1;
            this.writeTab.Text = "Write file";
            this.writeTab.UseVisualStyleBackColor = true;
            this.writeTab.DragDrop += new System.Windows.Forms.DragEventHandler(this.writeTab_DragDrop);
            this.writeTab.DragEnter += new System.Windows.Forms.DragEventHandler(this.writeTab_DragEnter);
            // 
            // writeDoIt
            // 
            this.writeDoIt.Location = new System.Drawing.Point(228, 66);
            this.writeDoIt.Name = "writeDoIt";
            this.writeDoIt.Size = new System.Drawing.Size(75, 23);
            this.writeDoIt.TabIndex = 5;
            this.writeDoIt.Text = "Write";
            this.writeDoIt.UseVisualStyleBackColor = true;
            this.writeDoIt.Click += new System.EventHandler(this.writeDoIt_Click);
            // 
            // writeBrowse
            // 
            this.writeBrowse.Location = new System.Drawing.Point(9, 66);
            this.writeBrowse.Name = "writeBrowse";
            this.writeBrowse.Size = new System.Drawing.Size(75, 23);
            this.writeBrowse.TabIndex = 4;
            this.writeBrowse.Text = "Browse...";
            this.writeBrowse.UseVisualStyleBackColor = true;
            this.writeBrowse.Click += new System.EventHandler(this.writeBrowse_Click);
            // 
            // writeAutoInc
            // 
            this.writeAutoInc.AutoSize = true;
            this.writeAutoInc.Checked = true;
            this.writeAutoInc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.writeAutoInc.Location = new System.Drawing.Point(9, 31);
            this.writeAutoInc.Name = "writeAutoInc";
            this.writeAutoInc.Size = new System.Drawing.Size(97, 17);
            this.writeAutoInc.TabIndex = 3;
            this.writeAutoInc.Text = "Auto-increment";
            this.toolTip1.SetToolTip(this.writeAutoInc, "Automatically go to next slot after writing.\r\nMust be enabled when importing mult" +
        "iple Pokemon.");
            this.writeAutoInc.UseVisualStyleBackColor = true;
            // 
            // writeCopiesNo
            // 
            this.writeCopiesNo.Location = new System.Drawing.Point(234, 5);
            this.writeCopiesNo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.writeCopiesNo.Name = "writeCopiesNo";
            this.writeCopiesNo.Size = new System.Drawing.Size(50, 20);
            this.writeCopiesNo.TabIndex = 2;
            this.writeCopiesNo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(180, 7);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(48, 13);
            this.label35.TabIndex = 8;
            this.label35.Text = "# copies";
            // 
            // writeSlotTo
            // 
            this.writeSlotTo.Location = new System.Drawing.Point(124, 5);
            this.writeSlotTo.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.writeSlotTo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.writeSlotTo.Name = "writeSlotTo";
            this.writeSlotTo.Size = new System.Drawing.Size(50, 20);
            this.writeSlotTo.TabIndex = 1;
            this.writeSlotTo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.writeSlotTo.ValueChanged += new System.EventHandler(this.writeSlotTo_ValueChanged);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(93, 7);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(25, 13);
            this.label34.TabIndex = 7;
            this.label34.Text = "Slot";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(6, 7);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(25, 13);
            this.label33.TabIndex = 6;
            this.label33.Text = "Box";
            // 
            // writeBoxTo
            // 
            this.writeBoxTo.Location = new System.Drawing.Point(37, 5);
            this.writeBoxTo.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.writeBoxTo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.writeBoxTo.Name = "writeBoxTo";
            this.writeBoxTo.Size = new System.Drawing.Size(50, 20);
            this.writeBoxTo.TabIndex = 0;
            this.writeBoxTo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.writeBoxTo.ValueChanged += new System.EventHandler(this.writeBoxTo_ValueChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.deleteKeepBackup);
            this.tabPage1.Controls.Add(this.label38);
            this.tabPage1.Controls.Add(this.label26);
            this.tabPage1.Controls.Add(this.deleteBox);
            this.tabPage1.Controls.Add(this.label27);
            this.tabPage1.Controls.Add(this.deleteAmount);
            this.tabPage1.Controls.Add(this.deleteSlot);
            this.tabPage1.Controls.Add(this.delPkm);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(309, 95);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Delete";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // deleteKeepBackup
            // 
            this.deleteKeepBackup.AutoSize = true;
            this.deleteKeepBackup.Checked = true;
            this.deleteKeepBackup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.deleteKeepBackup.Location = new System.Drawing.Point(9, 31);
            this.deleteKeepBackup.Name = "deleteKeepBackup";
            this.deleteKeepBackup.Size = new System.Drawing.Size(90, 17);
            this.deleteKeepBackup.TabIndex = 3;
            this.deleteKeepBackup.Text = "Keep backup";
            this.toolTip1.SetToolTip(this.deleteKeepBackup, "Backup to file before deleting");
            this.deleteKeepBackup.UseVisualStyleBackColor = true;
            // 
            // touchX
            // 
            this.touchX.Location = new System.Drawing.Point(6, 19);
            this.touchX.Maximum = new decimal(new int[] {
            319,
            0,
            0,
            0});
            this.touchX.Name = "touchX";
            this.touchX.Size = new System.Drawing.Size(60, 20);
            this.touchX.TabIndex = 12;
            this.toolTip1.SetToolTip(this.touchX, "X (horizontal) coordinate, from the left part of the screen.");
            // 
            // touchY
            // 
            this.touchY.Location = new System.Drawing.Point(72, 19);
            this.touchY.Maximum = new decimal(new int[] {
            239,
            0,
            0,
            0});
            this.touchY.Name = "touchY";
            this.touchY.Size = new System.Drawing.Size(60, 20);
            this.touchY.TabIndex = 13;
            this.toolTip1.SetToolTip(this.touchY, "Y (vertical) coordinate, from the top part of the screen.");
            // 
            // daycare_select
            // 
            this.daycare_select.Controls.Add(this.radioDayCare1);
            this.daycare_select.Controls.Add(this.radioDayCare2);
            this.daycare_select.Location = new System.Drawing.Point(150, 72);
            this.daycare_select.Name = "daycare_select";
            this.daycare_select.Size = new System.Drawing.Size(104, 70);
            this.daycare_select.TabIndex = 5;
            this.daycare_select.TabStop = false;
            this.daycare_select.Text = "Daycare:";
            this.toolTip1.SetToolTip(this.daycare_select, "Ignore this field if you\'re playing in X/Y or S/M.");
            // 
            // radioDayCare1
            // 
            this.radioDayCare1.AutoSize = true;
            this.radioDayCare1.Checked = true;
            this.radioDayCare1.Location = new System.Drawing.Point(6, 19);
            this.radioDayCare1.Name = "radioDayCare1";
            this.radioDayCare1.Size = new System.Drawing.Size(75, 17);
            this.radioDayCare1.TabIndex = 0;
            this.radioDayCare1.TabStop = true;
            this.radioDayCare1.Text = "Route 117";
            this.radioDayCare1.UseVisualStyleBackColor = true;
            // 
            // radioDayCare2
            // 
            this.radioDayCare2.AutoSize = true;
            this.radioDayCare2.Location = new System.Drawing.Point(6, 42);
            this.radioDayCare2.Name = "radioDayCare2";
            this.radioDayCare2.Size = new System.Drawing.Size(86, 17);
            this.radioDayCare2.TabIndex = 1;
            this.radioDayCare2.Text = "Battle Resort";
            this.radioDayCare2.UseVisualStyleBackColor = true;
            // 
            // orgbox_pos
            // 
            this.orgbox_pos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.orgbox_pos.Controls.Add(this.OrganizeMiddle);
            this.orgbox_pos.Controls.Add(this.OrganizeTop);
            this.orgbox_pos.Location = new System.Drawing.Point(6, 71);
            this.orgbox_pos.Name = "orgbox_pos";
            this.orgbox_pos.Size = new System.Drawing.Size(138, 71);
            this.orgbox_pos.TabIndex = 4;
            this.orgbox_pos.TabStop = false;
            this.orgbox_pos.Text = "Organize Boxes position:";
            this.toolTip1.SetToolTip(this.orgbox_pos, "Ignore this field if you\'re playing in X/Y or S/M.");
            // 
            // OrganizeMiddle
            // 
            this.OrganizeMiddle.AutoSize = true;
            this.OrganizeMiddle.Checked = true;
            this.OrganizeMiddle.Location = new System.Drawing.Point(6, 19);
            this.OrganizeMiddle.Name = "OrganizeMiddle";
            this.OrganizeMiddle.Size = new System.Drawing.Size(56, 17);
            this.OrganizeMiddle.TabIndex = 0;
            this.OrganizeMiddle.TabStop = true;
            this.OrganizeMiddle.Text = "Middle";
            this.OrganizeMiddle.UseVisualStyleBackColor = true;
            // 
            // OrganizeTop
            // 
            this.OrganizeTop.AutoSize = true;
            this.OrganizeTop.Location = new System.Drawing.Point(6, 42);
            this.OrganizeTop.Name = "OrganizeTop";
            this.OrganizeTop.Size = new System.Drawing.Size(44, 17);
            this.OrganizeTop.TabIndex = 1;
            this.OrganizeTop.Text = "Top";
            this.OrganizeTop.UseVisualStyleBackColor = true;
            // 
            // updateLabel
            // 
            this.updateLabel.AutoSize = true;
            this.updateLabel.Location = new System.Drawing.Point(224, 356);
            this.updateLabel.Name = "updateLabel";
            this.updateLabel.Size = new System.Drawing.Size(88, 13);
            this.updateLabel.TabIndex = 4;
            this.updateLabel.Text = "Feature disabled.";
            this.toolTip1.SetToolTip(this.updateLabel, "If an update is available, you can click here to go to the release page in GitHub" +
        ".");
            this.updateLabel.Click += new System.EventHandler(this.updateLabel_Click);
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(6, 20);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(37, 13);
            this.label72.TabIndex = 6;
            this.label72.Text = "Mode:";
            // 
            // typeLSR
            // 
            this.typeLSR.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.typeLSR.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.typeLSR.FormattingEnabled = true;
            this.typeLSR.Location = new System.Drawing.Point(49, 17);
            this.typeLSR.Name = "typeLSR";
            this.typeLSR.Size = new System.Drawing.Size(222, 21);
            this.typeLSR.TabIndex = 0;
            this.typeLSR.SelectedIndexChanged += new System.EventHandler(this.typeLSR_SelectedIndexChanged);
            // 
            // RunLSRbot
            // 
            this.RunLSRbot.Location = new System.Drawing.Point(6, 65);
            this.RunLSRbot.Name = "RunLSRbot";
            this.RunLSRbot.Size = new System.Drawing.Size(271, 23);
            this.RunLSRbot.TabIndex = 2;
            this.RunLSRbot.Text = "Start Bot";
            this.RunLSRbot.UseVisualStyleBackColor = true;
            this.RunLSRbot.Click += new System.EventHandler(this.RunLSRbot_Click_1);
            // 
            // resumeLSR
            // 
            this.resumeLSR.AutoSize = true;
            this.resumeLSR.Location = new System.Drawing.Point(457, 19);
            this.resumeLSR.Name = "resumeLSR";
            this.resumeLSR.Size = new System.Drawing.Size(83, 17);
            this.resumeLSR.TabIndex = 3;
            this.resumeLSR.Text = "Resume bot";
            this.resumeLSR.UseVisualStyleBackColor = true;
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(95, 16);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(49, 13);
            this.label59.TabIndex = 6;
            this.label59.Text = "# trades:";
            // 
            // RunWTbot
            // 
            this.RunWTbot.Location = new System.Drawing.Point(6, 187);
            this.RunWTbot.Name = "RunWTbot";
            this.RunWTbot.Size = new System.Drawing.Size(208, 23);
            this.RunWTbot.TabIndex = 3;
            this.RunWTbot.Text = "Start Bot";
            this.RunWTbot.UseVisualStyleBackColor = true;
            this.RunWTbot.Click += new System.EventHandler(this.RunWTbot_Click_1);
            // 
            // WTtradesNo
            // 
            this.WTtradesNo.Location = new System.Drawing.Point(98, 35);
            this.WTtradesNo.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.WTtradesNo.Name = "WTtradesNo";
            this.WTtradesNo.Size = new System.Drawing.Size(46, 20);
            this.WTtradesNo.TabIndex = 2;
            this.WTtradesNo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(49, 16);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(28, 13);
            this.label57.TabIndex = 5;
            this.label57.Text = "Slot:";
            // 
            // WTBox
            // 
            this.WTBox.Location = new System.Drawing.Point(6, 35);
            this.WTBox.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.WTBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WTBox.Name = "WTBox";
            this.WTBox.Size = new System.Drawing.Size(40, 20);
            this.WTBox.TabIndex = 0;
            this.WTBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // WTSlot
            // 
            this.WTSlot.Location = new System.Drawing.Point(52, 35);
            this.WTSlot.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.WTSlot.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WTSlot.Name = "WTSlot";
            this.WTSlot.Size = new System.Drawing.Size(40, 20);
            this.WTSlot.TabIndex = 1;
            this.WTSlot.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(6, 16);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(28, 13);
            this.label58.TabIndex = 4;
            this.label58.Text = "Box:";
            // 
            // readResult
            // 
            this.readResult.Location = new System.Drawing.Point(118, 353);
            this.readResult.Name = "readResult";
            this.readResult.ReadOnly = true;
            this.readResult.Size = new System.Drawing.Size(100, 20);
            this.readResult.TabIndex = 1;
            // 
            // stopBotButton
            // 
            this.stopBotButton.Enabled = false;
            this.stopBotButton.Location = new System.Drawing.Point(804, 5);
            this.stopBotButton.Name = "stopBotButton";
            this.stopBotButton.Size = new System.Drawing.Size(75, 23);
            this.stopBotButton.TabIndex = 4;
            this.stopBotButton.Text = "Stop Bot";
            this.stopBotButton.UseVisualStyleBackColor = true;
            this.stopBotButton.Click += new System.EventHandler(this.stopBotButton_Click);
            // 
            // manualDLeft
            // 
            this.manualDLeft.Location = new System.Drawing.Point(6, 46);
            this.manualDLeft.Name = "manualDLeft";
            this.manualDLeft.Size = new System.Drawing.Size(23, 23);
            this.manualDLeft.TabIndex = 2;
            this.manualDLeft.Text = "←";
            this.manualDLeft.UseVisualStyleBackColor = true;
            this.manualDLeft.Click += new System.EventHandler(this.manualDLeft_Click);
            // 
            // manualTouch
            // 
            this.manualTouch.Location = new System.Drawing.Point(138, 16);
            this.manualTouch.Name = "manualTouch";
            this.manualTouch.Size = new System.Drawing.Size(128, 23);
            this.manualTouch.TabIndex = 14;
            this.manualTouch.Text = "Touch";
            this.manualTouch.UseVisualStyleBackColor = true;
            this.manualTouch.Click += new System.EventHandler(this.manualTouch_Click);
            // 
            // manualX
            // 
            this.manualX.Location = new System.Drawing.Point(214, 19);
            this.manualX.Name = "manualX";
            this.manualX.Size = new System.Drawing.Size(23, 23);
            this.manualX.TabIndex = 6;
            this.manualX.Text = "X";
            this.manualX.UseVisualStyleBackColor = true;
            this.manualX.Click += new System.EventHandler(this.manualX_Click);
            // 
            // manualY
            // 
            this.manualY.Location = new System.Drawing.Point(185, 46);
            this.manualY.Name = "manualY";
            this.manualY.Size = new System.Drawing.Size(23, 23);
            this.manualY.TabIndex = 7;
            this.manualY.Text = "Y";
            this.manualY.UseVisualStyleBackColor = true;
            this.manualY.Click += new System.EventHandler(this.manualY_Click);
            // 
            // manualDUp
            // 
            this.manualDUp.Location = new System.Drawing.Point(35, 19);
            this.manualDUp.Name = "manualDUp";
            this.manualDUp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.manualDUp.Size = new System.Drawing.Size(23, 23);
            this.manualDUp.TabIndex = 0;
            this.manualDUp.Text = "↑";
            this.manualDUp.UseVisualStyleBackColor = true;
            this.manualDUp.Click += new System.EventHandler(this.manualDUp_Click);
            // 
            // manualL
            // 
            this.manualL.Location = new System.Drawing.Point(103, 19);
            this.manualL.Name = "manualL";
            this.manualL.Size = new System.Drawing.Size(23, 23);
            this.manualL.TabIndex = 8;
            this.manualL.Text = "L";
            this.manualL.UseVisualStyleBackColor = true;
            this.manualL.Click += new System.EventHandler(this.manualL_Click);
            // 
            // manualB
            // 
            this.manualB.Location = new System.Drawing.Point(214, 74);
            this.manualB.Name = "manualB";
            this.manualB.Size = new System.Drawing.Size(23, 23);
            this.manualB.TabIndex = 5;
            this.manualB.Text = "B";
            this.manualB.UseVisualStyleBackColor = true;
            this.manualB.Click += new System.EventHandler(this.manualB_Click);
            // 
            // manualA
            // 
            this.manualA.Location = new System.Drawing.Point(243, 46);
            this.manualA.Name = "manualA";
            this.manualA.Size = new System.Drawing.Size(23, 23);
            this.manualA.TabIndex = 4;
            this.manualA.Text = "A";
            this.manualA.UseVisualStyleBackColor = true;
            this.manualA.Click += new System.EventHandler(this.manualA_Click);
            // 
            // manualR
            // 
            this.manualR.Location = new System.Drawing.Point(146, 19);
            this.manualR.Name = "manualR";
            this.manualR.Size = new System.Drawing.Size(23, 23);
            this.manualR.TabIndex = 9;
            this.manualR.Text = "R";
            this.manualR.UseVisualStyleBackColor = true;
            this.manualR.Click += new System.EventHandler(this.manualR_Click);
            // 
            // manualSelect
            // 
            this.manualSelect.Location = new System.Drawing.Point(146, 74);
            this.manualSelect.Name = "manualSelect";
            this.manualSelect.Size = new System.Drawing.Size(62, 23);
            this.manualSelect.TabIndex = 11;
            this.manualSelect.Text = "SELECT";
            this.manualSelect.UseVisualStyleBackColor = true;
            this.manualSelect.Click += new System.EventHandler(this.manualSelect_Click);
            // 
            // manualDRight
            // 
            this.manualDRight.Location = new System.Drawing.Point(64, 46);
            this.manualDRight.Name = "manualDRight";
            this.manualDRight.Size = new System.Drawing.Size(23, 23);
            this.manualDRight.TabIndex = 3;
            this.manualDRight.Text = "→";
            this.manualDRight.UseVisualStyleBackColor = true;
            this.manualDRight.Click += new System.EventHandler(this.manualDRight_Click);
            // 
            // ManualDDown
            // 
            this.ManualDDown.Location = new System.Drawing.Point(35, 74);
            this.ManualDDown.Name = "ManualDDown";
            this.ManualDDown.Size = new System.Drawing.Size(23, 23);
            this.ManualDDown.TabIndex = 1;
            this.ManualDDown.Text = "↓";
            this.ManualDDown.UseVisualStyleBackColor = true;
            this.ManualDDown.Click += new System.EventHandler(this.ManualDDown_Click);
            // 
            // manualStart
            // 
            this.manualStart.Location = new System.Drawing.Point(64, 74);
            this.manualStart.Name = "manualStart";
            this.manualStart.Size = new System.Drawing.Size(62, 23);
            this.manualStart.TabIndex = 10;
            this.manualStart.Text = "START";
            this.manualStart.UseVisualStyleBackColor = true;
            this.manualStart.Click += new System.EventHandler(this.manualStart_Click);
            // 
            // label69
            // 
            this.label69.Location = new System.Drawing.Point(224, 356);
            this.label69.Name = "label69";
            this.label69.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label69.Size = new System.Drawing.Size(331, 19);
            this.label69.TabIndex = 3;
            this.label69.Text = "Version: ";
            this.label69.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(3, 356);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(109, 13);
            this.label71.TabIndex = 2;
            this.label71.Text = "Last Read from RAM:";
            // 
            // miscTabs
            // 
            this.miscTabs.Controls.Add(this.tabEditTrainer);
            this.miscTabs.Controls.Add(this.tabControls);
            this.miscTabs.Controls.Add(this.tabFilters);
            this.miscTabs.Controls.Add(this.tabBreeding);
            this.miscTabs.Controls.Add(this.tabSoftReset);
            this.miscTabs.Controls.Add(this.tabWonderTrade);
            this.miscTabs.Controls.Add(this.tabNTRlog);
            this.miscTabs.Location = new System.Drawing.Point(320, 12);
            this.miscTabs.Name = "miscTabs";
            this.miscTabs.SelectedIndex = 0;
            this.miscTabs.Size = new System.Drawing.Size(566, 404);
            this.miscTabs.TabIndex = 3;
            this.miscTabs.TabStop = false;
            this.miscTabs.Tag = "";
            // 
            // tabEditTrainer
            // 
            this.tabEditTrainer.BackColor = System.Drawing.SystemColors.Control;
            this.tabEditTrainer.Controls.Add(this.seedRNG);
            this.tabEditTrainer.Controls.Add(this.label60);
            this.tabEditTrainer.Controls.Add(this.EggSeed);
            this.tabEditTrainer.Controls.Add(this.label7);
            this.tabEditTrainer.Controls.Add(this.PokeDiggerBtn);
            this.tabEditTrainer.Controls.Add(this.ReloadFields);
            this.tabEditTrainer.Controls.Add(this.Edit_Trainer);
            this.tabEditTrainer.Controls.Add(this.cloneWriteTabs);
            this.tabEditTrainer.Controls.Add(this.Edit_Items);
            this.tabEditTrainer.Location = new System.Drawing.Point(4, 22);
            this.tabEditTrainer.Name = "tabEditTrainer";
            this.tabEditTrainer.Padding = new System.Windows.Forms.Padding(3);
            this.tabEditTrainer.Size = new System.Drawing.Size(558, 378);
            this.tabEditTrainer.TabIndex = 0;
            this.tabEditTrainer.Text = "Edit Save";
            // 
            // seedRNG
            // 
            this.seedRNG.Location = new System.Drawing.Point(159, 353);
            this.seedRNG.Name = "seedRNG";
            this.seedRNG.ReadOnly = true;
            this.seedRNG.Size = new System.Drawing.Size(100, 20);
            this.seedRNG.TabIndex = 8;
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(91, 356);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(62, 13);
            this.label60.TabIndex = 7;
            this.label60.Text = "RNG Seed:";
            // 
            // EggSeed
            // 
            this.EggSeed.Location = new System.Drawing.Point(396, 317);
            this.EggSeed.Name = "EggSeed";
            this.EggSeed.ReadOnly = true;
            this.EggSeed.Size = new System.Drawing.Size(155, 20);
            this.EggSeed.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(333, 320);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Egg Seed:";
            // 
            // PokeDiggerBtn
            // 
            this.PokeDiggerBtn.Location = new System.Drawing.Point(10, 351);
            this.PokeDiggerBtn.Name = "PokeDiggerBtn";
            this.PokeDiggerBtn.Size = new System.Drawing.Size(75, 23);
            this.PokeDiggerBtn.TabIndex = 4;
            this.PokeDiggerBtn.Text = "PokeDigger";
            this.PokeDiggerBtn.UseVisualStyleBackColor = true;
            this.PokeDiggerBtn.Click += new System.EventHandler(this.PokeDiggerBtn_Click);
            // 
            // ReloadFields
            // 
            this.ReloadFields.Location = new System.Drawing.Point(336, 343);
            this.ReloadFields.Name = "ReloadFields";
            this.ReloadFields.Size = new System.Drawing.Size(215, 23);
            this.ReloadFields.TabIndex = 3;
            this.ReloadFields.Text = "Reload Fields";
            this.ReloadFields.UseVisualStyleBackColor = true;
            this.ReloadFields.Click += new System.EventHandler(this.ReloadFields_Click);
            // 
            // Edit_Trainer
            // 
            this.Edit_Trainer.AutoSize = true;
            this.Edit_Trainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Edit_Trainer.Controls.Add(this.label55);
            this.Edit_Trainer.Controls.Add(this.pokeTotalFC);
            this.Edit_Trainer.Controls.Add(this.totalFCNum);
            this.Edit_Trainer.Controls.Add(this.label10);
            this.Edit_Trainer.Controls.Add(this.label12);
            this.Edit_Trainer.Controls.Add(this.label2);
            this.Edit_Trainer.Controls.Add(this.pokeName);
            this.Edit_Trainer.Controls.Add(this.label11);
            this.Edit_Trainer.Controls.Add(this.hourNum);
            this.Edit_Trainer.Controls.Add(this.label15);
            this.Edit_Trainer.Controls.Add(this.pokeTID);
            this.Edit_Trainer.Controls.Add(this.pokeTime);
            this.Edit_Trainer.Controls.Add(this.label4);
            this.Edit_Trainer.Controls.Add(this.minNum);
            this.Edit_Trainer.Controls.Add(this.label28);
            this.Edit_Trainer.Controls.Add(this.secNum);
            this.Edit_Trainer.Controls.Add(this.label14);
            this.Edit_Trainer.Controls.Add(this.pokeBP);
            this.Edit_Trainer.Controls.Add(this.pokeSID);
            this.Edit_Trainer.Controls.Add(this.TIDNum);
            this.Edit_Trainer.Controls.Add(this.playerName);
            this.Edit_Trainer.Controls.Add(this.SIDNum);
            this.Edit_Trainer.Controls.Add(this.label13);
            this.Edit_Trainer.Controls.Add(this.pokeLang);
            this.Edit_Trainer.Controls.Add(this.moneyNum);
            this.Edit_Trainer.Controls.Add(this.label3);
            this.Edit_Trainer.Controls.Add(this.pokeMoney);
            this.Edit_Trainer.Controls.Add(this.pokeMiles);
            this.Edit_Trainer.Controls.Add(this.milesNum);
            this.Edit_Trainer.Controls.Add(this.bpNum);
            this.Edit_Trainer.Controls.Add(this.Lang);
            this.Edit_Trainer.Location = new System.Drawing.Point(336, 6);
            this.Edit_Trainer.Name = "Edit_Trainer";
            this.Edit_Trainer.Size = new System.Drawing.Size(215, 304);
            this.Edit_Trainer.TabIndex = 1;
            this.Edit_Trainer.TabStop = false;
            this.Edit_Trainer.Text = "Edit Trainer";
            // 
            // label55
            // 
            this.label55.Location = new System.Drawing.Point(6, 169);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(69, 18);
            this.label55.TabIndex = 25;
            this.label55.Text = "Total FC:";
            this.label55.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pokeTotalFC
            // 
            this.pokeTotalFC.AutoSize = true;
            this.pokeTotalFC.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pokeTotalFC.Enabled = false;
            this.pokeTotalFC.Location = new System.Drawing.Point(167, 164);
            this.pokeTotalFC.Name = "pokeTotalFC";
            this.pokeTotalFC.Size = new System.Drawing.Size(42, 23);
            this.pokeTotalFC.TabIndex = 11;
            this.pokeTotalFC.Text = "Write";
            this.pokeTotalFC.UseVisualStyleBackColor = true;
            this.pokeTotalFC.Click += new System.EventHandler(this.pokeTotalFC_Click);
            // 
            // totalFCNum
            // 
            this.totalFCNum.Enabled = false;
            this.totalFCNum.Location = new System.Drawing.Point(81, 167);
            this.totalFCNum.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.totalFCNum.Name = "totalFCNum";
            this.totalFCNum.Size = new System.Drawing.Size(80, 20);
            this.totalFCNum.TabIndex = 10;
            this.totalFCNum.ThousandsSeparator = true;
            // 
            // tabControls
            // 
            this.tabControls.BackColor = System.Drawing.SystemColors.Control;
            this.tabControls.Controls.Add(this.Remote_Stick);
            this.tabControls.Controls.Add(this.Remote_touch);
            this.tabControls.Controls.Add(this.Remote_buttons);
            this.tabControls.Controls.Add(this.manualSR);
            this.tabControls.Location = new System.Drawing.Point(4, 22);
            this.tabControls.Name = "tabControls";
            this.tabControls.Padding = new System.Windows.Forms.Padding(3);
            this.tabControls.Size = new System.Drawing.Size(558, 378);
            this.tabControls.TabIndex = 1;
            this.tabControls.Text = "Controls";
            // 
            // Remote_Stick
            // 
            this.Remote_Stick.Controls.Add(this.StickX);
            this.Remote_Stick.Controls.Add(this.StickY);
            this.Remote_Stick.Controls.Add(this.StickNumY);
            this.Remote_Stick.Controls.Add(this.StickSend);
            this.Remote_Stick.Controls.Add(this.StickNumX);
            this.Remote_Stick.Controls.Add(this.label62);
            this.Remote_Stick.Controls.Add(this.label61);
            this.Remote_Stick.Location = new System.Drawing.Point(284, 6);
            this.Remote_Stick.Name = "Remote_Stick";
            this.Remote_Stick.Size = new System.Drawing.Size(268, 154);
            this.Remote_Stick.TabIndex = 28;
            this.Remote_Stick.TabStop = false;
            this.Remote_Stick.Text = "Control Stick";
            // 
            // StickX
            // 
            this.StickX.Location = new System.Drawing.Point(57, 103);
            this.StickX.Maximum = 100;
            this.StickX.Minimum = -100;
            this.StickX.Name = "StickX";
            this.StickX.Size = new System.Drawing.Size(205, 45);
            this.StickX.TabIndex = 17;
            this.StickX.TickFrequency = 25;
            this.StickX.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.StickX.Scroll += new System.EventHandler(this.StickX_Scroll);
            // 
            // StickY
            // 
            this.StickY.Location = new System.Drawing.Point(6, 19);
            this.StickY.Maximum = 100;
            this.StickY.Minimum = -100;
            this.StickY.Name = "StickY";
            this.StickY.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.StickY.Size = new System.Drawing.Size(45, 129);
            this.StickY.TabIndex = 16;
            this.StickY.TickFrequency = 25;
            this.StickY.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.StickY.Scroll += new System.EventHandler(this.StickY_Scroll);
            // 
            // StickNumY
            // 
            this.StickNumY.Location = new System.Drawing.Point(57, 22);
            this.StickNumY.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.StickNumY.Name = "StickNumY";
            this.StickNumY.Size = new System.Drawing.Size(100, 20);
            this.StickNumY.TabIndex = 18;
            this.StickNumY.ValueChanged += new System.EventHandler(this.StickNumY_ValueChanged);
            // 
            // StickSend
            // 
            this.StickSend.Location = new System.Drawing.Point(57, 63);
            this.StickSend.Name = "StickSend";
            this.StickSend.Size = new System.Drawing.Size(205, 23);
            this.StickSend.TabIndex = 20;
            this.StickSend.Text = "Send Command";
            this.StickSend.UseVisualStyleBackColor = true;
            this.StickSend.Click += new System.EventHandler(this.StickSend_Click);
            // 
            // StickNumX
            // 
            this.StickNumX.Location = new System.Drawing.Point(163, 22);
            this.StickNumX.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.StickNumX.Name = "StickNumX";
            this.StickNumX.Size = new System.Drawing.Size(99, 20);
            this.StickNumX.TabIndex = 19;
            this.StickNumX.ValueChanged += new System.EventHandler(this.StickNumX_ValueChanged);
            // 
            // label62
            // 
            this.label62.Location = new System.Drawing.Point(163, 45);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(99, 18);
            this.label62.TabIndex = 25;
            this.label62.Text = "Horizontal";
            this.label62.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label61
            // 
            this.label61.Location = new System.Drawing.Point(57, 45);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(100, 18);
            this.label61.TabIndex = 24;
            this.label61.Text = "Vertical";
            this.label61.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Remote_touch
            // 
            this.Remote_touch.AutoSize = true;
            this.Remote_touch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Remote_touch.Controls.Add(this.label54);
            this.Remote_touch.Controls.Add(this.label30);
            this.Remote_touch.Controls.Add(this.touchX);
            this.Remote_touch.Controls.Add(this.touchY);
            this.Remote_touch.Controls.Add(this.manualTouch);
            this.Remote_touch.Location = new System.Drawing.Point(6, 121);
            this.Remote_touch.Name = "Remote_touch";
            this.Remote_touch.Size = new System.Drawing.Size(272, 71);
            this.Remote_touch.TabIndex = 27;
            this.Remote_touch.TabStop = false;
            this.Remote_touch.Text = "Touchscreen";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(72, 42);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(61, 13);
            this.label54.TabIndex = 15;
            this.label54.Text = "Y (from top)";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(6, 42);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(60, 13);
            this.label30.TabIndex = 15;
            this.label30.Text = "X (from left)";
            // 
            // Remote_buttons
            // 
            this.Remote_buttons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Remote_buttons.Controls.Add(this.manualDUp);
            this.Remote_buttons.Controls.Add(this.manualA);
            this.Remote_buttons.Controls.Add(this.manualR);
            this.Remote_buttons.Controls.Add(this.manualB);
            this.Remote_buttons.Controls.Add(this.manualL);
            this.Remote_buttons.Controls.Add(this.manualSelect);
            this.Remote_buttons.Controls.Add(this.manualDRight);
            this.Remote_buttons.Controls.Add(this.ManualDDown);
            this.Remote_buttons.Controls.Add(this.manualY);
            this.Remote_buttons.Controls.Add(this.manualStart);
            this.Remote_buttons.Controls.Add(this.manualX);
            this.Remote_buttons.Controls.Add(this.manualDLeft);
            this.Remote_buttons.Location = new System.Drawing.Point(6, 6);
            this.Remote_buttons.Name = "Remote_buttons";
            this.Remote_buttons.Size = new System.Drawing.Size(272, 109);
            this.Remote_buttons.TabIndex = 26;
            this.Remote_buttons.TabStop = false;
            this.Remote_buttons.Text = "Buttons";
            // 
            // manualSR
            // 
            this.manualSR.Location = new System.Drawing.Point(284, 169);
            this.manualSR.Name = "manualSR";
            this.manualSR.Size = new System.Drawing.Size(268, 23);
            this.manualSR.TabIndex = 15;
            this.manualSR.Text = "Soft-Reset";
            this.manualSR.UseVisualStyleBackColor = true;
            this.manualSR.Click += new System.EventHandler(this.manualSR_Click);
            // 
            // tabFilters
            // 
            this.tabFilters.Controls.Add(this.filterReset);
            this.tabFilters.Controls.Add(this.filterRead);
            this.tabFilters.Controls.Add(this.filterLoad);
            this.tabFilters.Controls.Add(this.filterSave);
            this.tabFilters.Controls.Add(this.filterRemove);
            this.tabFilters.Controls.Add(this.filterAdd);
            this.tabFilters.Controls.Add(this.filterList);
            this.tabFilters.Controls.Add(this.filterPerIVlogic);
            this.tabFilters.Controls.Add(this.filterSPElogic);
            this.tabFilters.Controls.Add(this.filterSPDlogic);
            this.tabFilters.Controls.Add(this.filterSPAlogic);
            this.tabFilters.Controls.Add(this.filterDEFlogic);
            this.tabFilters.Controls.Add(this.filterATKlogic);
            this.tabFilters.Controls.Add(this.filterHPlogic);
            this.tabFilters.Controls.Add(this.label81);
            this.tabFilters.Controls.Add(this.filterPerIVvalue);
            this.tabFilters.Controls.Add(this.label101);
            this.tabFilters.Controls.Add(this.filterShiny);
            this.tabFilters.Controls.Add(this.filterGender);
            this.tabFilters.Controls.Add(this.label102);
            this.tabFilters.Controls.Add(this.label103);
            this.tabFilters.Controls.Add(this.filterSPEvalue);
            this.tabFilters.Controls.Add(this.filterSPDvalue);
            this.tabFilters.Controls.Add(this.label104);
            this.tabFilters.Controls.Add(this.label105);
            this.tabFilters.Controls.Add(this.label106);
            this.tabFilters.Controls.Add(this.filterAbility);
            this.tabFilters.Controls.Add(this.filterDEFvalue);
            this.tabFilters.Controls.Add(this.label107);
            this.tabFilters.Controls.Add(this.label108);
            this.tabFilters.Controls.Add(this.filterNature);
            this.tabFilters.Controls.Add(this.filterSPAvalue);
            this.tabFilters.Controls.Add(this.filterHPtype);
            this.tabFilters.Controls.Add(this.filterHPvalue);
            this.tabFilters.Controls.Add(this.label109);
            this.tabFilters.Controls.Add(this.label110);
            this.tabFilters.Controls.Add(this.label111);
            this.tabFilters.Controls.Add(this.filterATKvalue);
            this.tabFilters.Controls.Add(this.label112);
            this.tabFilters.Location = new System.Drawing.Point(4, 22);
            this.tabFilters.Name = "tabFilters";
            this.tabFilters.Size = new System.Drawing.Size(558, 378);
            this.tabFilters.TabIndex = 6;
            this.tabFilters.Tag = "";
            this.tabFilters.Text = "Filters";
            // 
            // filterReset
            // 
            this.filterReset.Location = new System.Drawing.Point(346, 161);
            this.filterReset.Name = "filterReset";
            this.filterReset.Size = new System.Drawing.Size(209, 23);
            this.filterReset.TabIndex = 22;
            this.filterReset.Text = "Reset constructor";
            this.filterReset.UseVisualStyleBackColor = true;
            this.filterReset.Click += new System.EventHandler(this.filterReset_Click);
            // 
            // filterRead
            // 
            this.filterRead.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.filterRead.Location = new System.Drawing.Point(6, 192);
            this.filterRead.Name = "filterRead";
            this.filterRead.Size = new System.Drawing.Size(132, 23);
            this.filterRead.TabIndex = 21;
            this.filterRead.Text = "Read Filter";
            this.filterRead.UseVisualStyleBackColor = true;
            this.filterRead.Click += new System.EventHandler(this.filterRead_Click);
            // 
            // filterLoad
            // 
            this.filterLoad.Location = new System.Drawing.Point(455, 190);
            this.filterLoad.Name = "filterLoad";
            this.filterLoad.Size = new System.Drawing.Size(100, 23);
            this.filterLoad.TabIndex = 24;
            this.filterLoad.Text = "Load filter set...";
            this.filterLoad.UseVisualStyleBackColor = true;
            this.filterLoad.Click += new System.EventHandler(this.filterLoad_Click);
            // 
            // filterSave
            // 
            this.filterSave.Location = new System.Drawing.Point(346, 190);
            this.filterSave.Name = "filterSave";
            this.filterSave.Size = new System.Drawing.Size(100, 23);
            this.filterSave.TabIndex = 23;
            this.filterSave.Text = "Save filter set...";
            this.filterSave.UseVisualStyleBackColor = true;
            this.filterSave.Click += new System.EventHandler(this.filterSave_Click);
            // 
            // filterRemove
            // 
            this.filterRemove.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.filterRemove.Location = new System.Drawing.Point(6, 163);
            this.filterRemove.Name = "filterRemove";
            this.filterRemove.Size = new System.Drawing.Size(132, 23);
            this.filterRemove.TabIndex = 20;
            this.filterRemove.Text = "Remove Filter";
            this.filterRemove.UseVisualStyleBackColor = true;
            this.filterRemove.Click += new System.EventHandler(this.filterRemove_Click);
            // 
            // filterAdd
            // 
            this.filterAdd.Location = new System.Drawing.Point(6, 135);
            this.filterAdd.Name = "filterAdd";
            this.filterAdd.Size = new System.Drawing.Size(132, 23);
            this.filterAdd.TabIndex = 19;
            this.filterAdd.Text = "Add Filter";
            this.filterAdd.UseVisualStyleBackColor = true;
            this.filterAdd.Click += new System.EventHandler(this.filterAdd_Click);
            // 
            // filterList
            // 
            this.filterList.AllowUserToAddRows = false;
            this.filterList.AllowUserToDeleteRows = false;
            this.filterList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.filterList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.filterList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.HPlogic,
            this.dataGridViewTextBoxColumn7,
            this.ATKlogic,
            this.dataGridViewTextBoxColumn8,
            this.DEFlogic,
            this.dataGridViewTextBoxColumn9,
            this.SPAlogic,
            this.dataGridViewTextBoxColumn10,
            this.SPDlogic,
            this.dataGridViewTextBoxColumn11,
            this.SPElogic,
            this.dataGridViewTextBoxColumn12,
            this.PerfectIVlogic});
            this.filterList.Location = new System.Drawing.Point(6, 219);
            this.filterList.MultiSelect = false;
            this.filterList.Name = "filterList";
            this.filterList.ReadOnly = true;
            this.filterList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.filterList.Size = new System.Drawing.Size(549, 145);
            this.filterList.TabIndex = 25;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Shiny";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 58;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Nature";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 64;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Ability";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 59;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "HP type";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 65;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Gender";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 67;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "HP";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 47;
            // 
            // HPlogic
            // 
            this.HPlogic.HeaderText = "HP Logic";
            this.HPlogic.Name = "HPlogic";
            this.HPlogic.ReadOnly = true;
            this.HPlogic.Width = 70;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Atk";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 48;
            // 
            // ATKlogic
            // 
            this.ATKlogic.HeaderText = "Atk Logic";
            this.ATKlogic.Name = "ATKlogic";
            this.ATKlogic.ReadOnly = true;
            this.ATKlogic.Width = 71;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Def";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 49;
            // 
            // DEFlogic
            // 
            this.DEFlogic.HeaderText = "Def Logic";
            this.DEFlogic.Name = "DEFlogic";
            this.DEFlogic.ReadOnly = true;
            this.DEFlogic.Width = 72;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "SpA";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 52;
            // 
            // SPAlogic
            // 
            this.SPAlogic.HeaderText = "SpA Logic";
            this.SPAlogic.Name = "SPAlogic";
            this.SPAlogic.ReadOnly = true;
            this.SPAlogic.Width = 75;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "SpD";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 53;
            // 
            // SPDlogic
            // 
            this.SPDlogic.HeaderText = "SpD Logic";
            this.SPDlogic.Name = "SPDlogic";
            this.SPDlogic.ReadOnly = true;
            this.SPDlogic.Width = 76;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "Spe";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 51;
            // 
            // SPElogic
            // 
            this.SPElogic.HeaderText = "Spe Logic";
            this.SPElogic.Name = "SPElogic";
            this.SPElogic.ReadOnly = true;
            this.SPElogic.Width = 74;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "Perfect IVs";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 78;
            // 
            // PerfectIVlogic
            // 
            this.PerfectIVlogic.HeaderText = "Perfect IVs Logic";
            this.PerfectIVlogic.Name = "PerfectIVlogic";
            this.PerfectIVlogic.ReadOnly = true;
            this.PerfectIVlogic.Width = 80;
            // 
            // filterPerIVlogic
            // 
            this.filterPerIVlogic.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.filterPerIVlogic.FormattingEnabled = true;
            this.filterPerIVlogic.Items.AddRange(new object[] {
            ">=",
            ">",
            "=",
            "<",
            "<=",
            "!="});
            this.filterPerIVlogic.Location = new System.Drawing.Point(241, 192);
            this.filterPerIVlogic.Name = "filterPerIVlogic";
            this.filterPerIVlogic.Size = new System.Drawing.Size(60, 21);
            this.filterPerIVlogic.TabIndex = 17;
            // 
            // filterSPElogic
            // 
            this.filterSPElogic.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.filterSPElogic.FormattingEnabled = true;
            this.filterSPElogic.Items.AddRange(new object[] {
            ">=",
            ">",
            "=",
            "<",
            "<=",
            "!=",
            "Even",
            "Odd"});
            this.filterSPElogic.Location = new System.Drawing.Point(241, 165);
            this.filterSPElogic.Name = "filterSPElogic";
            this.filterSPElogic.Size = new System.Drawing.Size(60, 21);
            this.filterSPElogic.TabIndex = 15;
            // 
            // filterSPDlogic
            // 
            this.filterSPDlogic.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.filterSPDlogic.FormattingEnabled = true;
            this.filterSPDlogic.Items.AddRange(new object[] {
            ">=",
            ">",
            "=",
            "<",
            "<=",
            "!=",
            "Even",
            "Odd"});
            this.filterSPDlogic.Location = new System.Drawing.Point(241, 138);
            this.filterSPDlogic.Name = "filterSPDlogic";
            this.filterSPDlogic.Size = new System.Drawing.Size(60, 21);
            this.filterSPDlogic.TabIndex = 13;
            // 
            // filterSPAlogic
            // 
            this.filterSPAlogic.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.filterSPAlogic.FormattingEnabled = true;
            this.filterSPAlogic.Items.AddRange(new object[] {
            ">=",
            ">",
            "=",
            "<",
            "<=",
            "!=",
            "Even",
            "Odd"});
            this.filterSPAlogic.Location = new System.Drawing.Point(241, 111);
            this.filterSPAlogic.Name = "filterSPAlogic";
            this.filterSPAlogic.Size = new System.Drawing.Size(60, 21);
            this.filterSPAlogic.TabIndex = 11;
            // 
            // filterDEFlogic
            // 
            this.filterDEFlogic.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.filterDEFlogic.FormattingEnabled = true;
            this.filterDEFlogic.Items.AddRange(new object[] {
            ">=",
            ">",
            "=",
            "<",
            "<=",
            "!=",
            "Even",
            "Odd"});
            this.filterDEFlogic.Location = new System.Drawing.Point(241, 84);
            this.filterDEFlogic.Name = "filterDEFlogic";
            this.filterDEFlogic.Size = new System.Drawing.Size(60, 21);
            this.filterDEFlogic.TabIndex = 9;
            // 
            // filterATKlogic
            // 
            this.filterATKlogic.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.filterATKlogic.FormattingEnabled = true;
            this.filterATKlogic.Items.AddRange(new object[] {
            ">=",
            ">",
            "=",
            "<",
            "<=",
            "!=",
            "Even",
            "Odd"});
            this.filterATKlogic.Location = new System.Drawing.Point(241, 57);
            this.filterATKlogic.Name = "filterATKlogic";
            this.filterATKlogic.Size = new System.Drawing.Size(60, 21);
            this.filterATKlogic.TabIndex = 7;
            // 
            // filterHPlogic
            // 
            this.filterHPlogic.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.filterHPlogic.FormattingEnabled = true;
            this.filterHPlogic.Items.AddRange(new object[] {
            ">=",
            ">",
            "=",
            "<",
            "<=",
            "!=",
            "Even",
            "Odd"});
            this.filterHPlogic.Location = new System.Drawing.Point(241, 30);
            this.filterHPlogic.Name = "filterHPlogic";
            this.filterHPlogic.Size = new System.Drawing.Size(60, 21);
            this.filterHPlogic.TabIndex = 5;
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.Location = new System.Drawing.Point(3, 10);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(61, 13);
            this.label81.TabIndex = 25;
            this.label81.Text = "Constructor";
            // 
            // filterPerIVvalue
            // 
            this.filterPerIVvalue.Location = new System.Drawing.Point(307, 193);
            this.filterPerIVvalue.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.filterPerIVvalue.Name = "filterPerIVvalue";
            this.filterPerIVvalue.Size = new System.Drawing.Size(33, 20);
            this.filterPerIVvalue.TabIndex = 18;
            // 
            // label101
            // 
            this.label101.AutoSize = true;
            this.label101.Location = new System.Drawing.Point(171, 195);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(64, 13);
            this.label101.TabIndex = 37;
            this.label101.Text = "Perfect IV\'s:";
            // 
            // filterShiny
            // 
            this.filterShiny.AutoSize = true;
            this.filterShiny.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.filterShiny.Location = new System.Drawing.Point(86, 10);
            this.filterShiny.Name = "filterShiny";
            this.filterShiny.Size = new System.Drawing.Size(52, 17);
            this.filterShiny.TabIndex = 0;
            this.filterShiny.Text = "Shiny";
            this.filterShiny.UseVisualStyleBackColor = true;
            // 
            // filterGender
            // 
            this.filterGender.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.filterGender.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.filterGender.FormattingEnabled = true;
            this.filterGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.filterGender.Location = new System.Drawing.Point(61, 108);
            this.filterGender.Name = "filterGender";
            this.filterGender.Size = new System.Drawing.Size(77, 21);
            this.filterGender.TabIndex = 4;
            // 
            // label102
            // 
            this.label102.AutoSize = true;
            this.label102.Location = new System.Drawing.Point(10, 111);
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(45, 13);
            this.label102.TabIndex = 29;
            this.label102.Text = "Gender:";
            // 
            // label103
            // 
            this.label103.AutoSize = true;
            this.label103.Location = new System.Drawing.Point(238, 11);
            this.label103.Name = "label103";
            this.label103.Size = new System.Drawing.Size(44, 13);
            this.label103.TabIndex = 30;
            this.label103.Text = "IV filters";
            // 
            // filterSPEvalue
            // 
            this.filterSPEvalue.Location = new System.Drawing.Point(307, 165);
            this.filterSPEvalue.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.filterSPEvalue.Name = "filterSPEvalue";
            this.filterSPEvalue.Size = new System.Drawing.Size(33, 20);
            this.filterSPEvalue.TabIndex = 16;
            // 
            // filterSPDvalue
            // 
            this.filterSPDvalue.Location = new System.Drawing.Point(307, 139);
            this.filterSPDvalue.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.filterSPDvalue.Name = "filterSPDvalue";
            this.filterSPDvalue.Size = new System.Drawing.Size(33, 20);
            this.filterSPDvalue.TabIndex = 14;
            // 
            // label104
            // 
            this.label104.AutoSize = true;
            this.label104.Location = new System.Drawing.Point(18, 57);
            this.label104.Name = "label104";
            this.label104.Size = new System.Drawing.Size(37, 13);
            this.label104.TabIndex = 27;
            this.label104.Text = "Ability:";
            // 
            // label105
            // 
            this.label105.AutoSize = true;
            this.label105.Location = new System.Drawing.Point(194, 168);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(41, 13);
            this.label105.TabIndex = 36;
            this.label105.Text = "Speed:";
            // 
            // label106
            // 
            this.label106.AutoSize = true;
            this.label106.Location = new System.Drawing.Point(185, 87);
            this.label106.Name = "label106";
            this.label106.Size = new System.Drawing.Size(50, 13);
            this.label106.TabIndex = 33;
            this.label106.Text = "Defense:";
            // 
            // filterAbility
            // 
            this.filterAbility.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.filterAbility.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.filterAbility.FormattingEnabled = true;
            this.filterAbility.Location = new System.Drawing.Point(61, 54);
            this.filterAbility.Name = "filterAbility";
            this.filterAbility.Size = new System.Drawing.Size(77, 21);
            this.filterAbility.TabIndex = 2;
            // 
            // filterDEFvalue
            // 
            this.filterDEFvalue.Location = new System.Drawing.Point(307, 85);
            this.filterDEFvalue.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.filterDEFvalue.Name = "filterDEFvalue";
            this.filterDEFvalue.Size = new System.Drawing.Size(33, 20);
            this.filterDEFvalue.TabIndex = 10;
            // 
            // label107
            // 
            this.label107.AutoSize = true;
            this.label107.Location = new System.Drawing.Point(13, 30);
            this.label107.Name = "label107";
            this.label107.Size = new System.Drawing.Size(42, 13);
            this.label107.TabIndex = 26;
            this.label107.Text = "Nature:";
            // 
            // label108
            // 
            this.label108.AutoSize = true;
            this.label108.Location = new System.Drawing.Point(180, 33);
            this.label108.Name = "label108";
            this.label108.Size = new System.Drawing.Size(55, 13);
            this.label108.TabIndex = 31;
            this.label108.Text = "Hit Points:";
            // 
            // filterNature
            // 
            this.filterNature.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.filterNature.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.filterNature.FormattingEnabled = true;
            this.filterNature.Items.AddRange(new object[] {
            "Hardy",
            "Lonely",
            "Brave",
            "Adamant",
            "Naughty",
            "Bold",
            "Docile",
            "Relaxed",
            "Impish",
            "Lax",
            "Timid",
            "Hasty",
            "Serious",
            "Jolly",
            "Naive",
            "Modest",
            "Mild",
            "Quiet",
            "Bashful",
            "Rash",
            "Calm",
            "Gentle",
            "Sassy",
            "Careful",
            "Quirky"});
            this.filterNature.Location = new System.Drawing.Point(61, 27);
            this.filterNature.Name = "filterNature";
            this.filterNature.Size = new System.Drawing.Size(77, 21);
            this.filterNature.TabIndex = 1;
            // 
            // filterSPAvalue
            // 
            this.filterSPAvalue.Location = new System.Drawing.Point(307, 113);
            this.filterSPAvalue.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.filterSPAvalue.Name = "filterSPAvalue";
            this.filterSPAvalue.Size = new System.Drawing.Size(33, 20);
            this.filterSPAvalue.TabIndex = 12;
            // 
            // filterHPtype
            // 
            this.filterHPtype.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.filterHPtype.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.filterHPtype.FormattingEnabled = true;
            this.filterHPtype.Items.AddRange(new object[] {
            "Fighting",
            "Flying",
            "Poison",
            "Ground",
            "Rock",
            "Bug",
            "Ghost",
            "Steel",
            "Fire",
            "Water",
            "Grass",
            "Electric",
            "Psychic",
            "Ice",
            "Dragon",
            "Dark"});
            this.filterHPtype.Location = new System.Drawing.Point(61, 81);
            this.filterHPtype.Name = "filterHPtype";
            this.filterHPtype.Size = new System.Drawing.Size(77, 21);
            this.filterHPtype.TabIndex = 3;
            // 
            // filterHPvalue
            // 
            this.filterHPvalue.Location = new System.Drawing.Point(307, 31);
            this.filterHPvalue.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.filterHPvalue.Name = "filterHPvalue";
            this.filterHPvalue.Size = new System.Drawing.Size(33, 20);
            this.filterHPvalue.TabIndex = 6;
            // 
            // label109
            // 
            this.label109.AutoSize = true;
            this.label109.Location = new System.Drawing.Point(3, 84);
            this.label109.Name = "label109";
            this.label109.Size = new System.Drawing.Size(52, 13);
            this.label109.TabIndex = 28;
            this.label109.Text = "HP Type:";
            // 
            // label110
            // 
            this.label110.AutoSize = true;
            this.label110.Location = new System.Drawing.Point(156, 115);
            this.label110.Name = "label110";
            this.label110.Size = new System.Drawing.Size(79, 13);
            this.label110.TabIndex = 34;
            this.label110.Text = "Special Attack:";
            // 
            // label111
            // 
            this.label111.AutoSize = true;
            this.label111.Location = new System.Drawing.Point(194, 60);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(41, 13);
            this.label111.TabIndex = 32;
            this.label111.Text = "Attack:";
            // 
            // filterATKvalue
            // 
            this.filterATKvalue.Location = new System.Drawing.Point(307, 58);
            this.filterATKvalue.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.filterATKvalue.Name = "filterATKvalue";
            this.filterATKvalue.Size = new System.Drawing.Size(33, 20);
            this.filterATKvalue.TabIndex = 8;
            // 
            // label112
            // 
            this.label112.AutoSize = true;
            this.label112.Location = new System.Drawing.Point(147, 141);
            this.label112.Name = "label112";
            this.label112.Size = new System.Drawing.Size(88, 13);
            this.label112.TabIndex = 35;
            this.label112.Text = "Special Defense:";
            // 
            // tabBreeding
            // 
            this.tabBreeding.BackColor = System.Drawing.SystemColors.Control;
            this.tabBreeding.Controls.Add(this.Breed_esvtsv);
            this.tabBreeding.Controls.Add(this.Breed_options);
            this.tabBreeding.Controls.Add(this.breedingClear);
            this.tabBreeding.Controls.Add(this.filterBreeding);
            this.tabBreeding.Controls.Add(this.bFilterLoad);
            this.tabBreeding.Controls.Add(this.runBreedingBot);
            this.tabBreeding.Location = new System.Drawing.Point(4, 22);
            this.tabBreeding.Name = "tabBreeding";
            this.tabBreeding.Size = new System.Drawing.Size(558, 378);
            this.tabBreeding.TabIndex = 4;
            this.tabBreeding.Text = "Breeding";
            // 
            // Breed_esvtsv
            // 
            this.Breed_esvtsv.Controls.Add(this.label50);
            this.Breed_esvtsv.Controls.Add(this.ESVlist);
            this.Breed_esvtsv.Controls.Add(this.ESVlistSave);
            this.Breed_esvtsv.Controls.Add(this.TSVlist);
            this.Breed_esvtsv.Controls.Add(this.TSVlistNum);
            this.Breed_esvtsv.Controls.Add(this.TSVlistAdd);
            this.Breed_esvtsv.Controls.Add(this.TSVlistLoad);
            this.Breed_esvtsv.Controls.Add(this.TSVlistRemove);
            this.Breed_esvtsv.Controls.Add(this.TSVlistSave);
            this.Breed_esvtsv.Location = new System.Drawing.Point(272, 6);
            this.Breed_esvtsv.Name = "Breed_esvtsv";
            this.Breed_esvtsv.Size = new System.Drawing.Size(280, 177);
            this.Breed_esvtsv.TabIndex = 28;
            this.Breed_esvtsv.TabStop = false;
            this.Breed_esvtsv.Text = "ESV/TSV";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(218, 16);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(31, 13);
            this.label50.TabIndex = 16;
            this.label50.Text = "TSV:";
            // 
            // ESVlist
            // 
            this.ESVlist.AllowUserToAddRows = false;
            this.ESVlist.AllowUserToDeleteRows = false;
            this.ESVlist.AllowUserToResizeColumns = false;
            this.ESVlist.AllowUserToResizeRows = false;
            this.ESVlist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ESVlist.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.ESVlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ESVlist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ESVlistBox,
            this.ESVlistSlot,
            this.ESVlistValue});
            this.ESVlist.Location = new System.Drawing.Point(6, 17);
            this.ESVlist.Name = "ESVlist";
            this.ESVlist.ReadOnly = true;
            this.ESVlist.RowHeadersWidth = 21;
            this.ESVlist.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ESVlist.Size = new System.Drawing.Size(150, 125);
            this.ESVlist.TabIndex = 8;
            // 
            // ESVlistBox
            // 
            this.ESVlistBox.FillWeight = 50F;
            this.ESVlistBox.HeaderText = "Box";
            this.ESVlistBox.Name = "ESVlistBox";
            this.ESVlistBox.ReadOnly = true;
            // 
            // ESVlistSlot
            // 
            this.ESVlistSlot.FillWeight = 50F;
            this.ESVlistSlot.HeaderText = "Slot";
            this.ESVlistSlot.Name = "ESVlistSlot";
            this.ESVlistSlot.ReadOnly = true;
            // 
            // ESVlistValue
            // 
            this.ESVlistValue.HeaderText = "ESV";
            this.ESVlistValue.Name = "ESVlistValue";
            this.ESVlistValue.ReadOnly = true;
            // 
            // ESVlistSave
            // 
            this.ESVlistSave.Location = new System.Drawing.Point(6, 148);
            this.ESVlistSave.Name = "ESVlistSave";
            this.ESVlistSave.Size = new System.Drawing.Size(150, 23);
            this.ESVlistSave.TabIndex = 9;
            this.ESVlistSave.Text = "Save ESV List";
            this.ESVlistSave.UseVisualStyleBackColor = true;
            this.ESVlistSave.Click += new System.EventHandler(this.ESVlistSave_Click);
            // 
            // TSVlist
            // 
            this.TSVlist.FormattingEnabled = true;
            this.TSVlist.Location = new System.Drawing.Point(162, 17);
            this.TSVlist.Name = "TSVlist";
            this.TSVlist.Size = new System.Drawing.Size(50, 147);
            this.TSVlist.TabIndex = 10;
            // 
            // TSVlistNum
            // 
            this.TSVlistNum.Location = new System.Drawing.Point(218, 32);
            this.TSVlistNum.Maximum = new decimal(new int[] {
            4095,
            0,
            0,
            0});
            this.TSVlistNum.Name = "TSVlistNum";
            this.TSVlistNum.Size = new System.Drawing.Size(56, 20);
            this.TSVlistNum.TabIndex = 11;
            // 
            // TSVlistAdd
            // 
            this.TSVlistAdd.Location = new System.Drawing.Point(218, 58);
            this.TSVlistAdd.Name = "TSVlistAdd";
            this.TSVlistAdd.Size = new System.Drawing.Size(56, 23);
            this.TSVlistAdd.TabIndex = 12;
            this.TSVlistAdd.Text = "Add";
            this.TSVlistAdd.UseVisualStyleBackColor = true;
            this.TSVlistAdd.Click += new System.EventHandler(this.TSVlistAdd_Click);
            // 
            // TSVlistLoad
            // 
            this.TSVlistLoad.Location = new System.Drawing.Point(218, 145);
            this.TSVlistLoad.Name = "TSVlistLoad";
            this.TSVlistLoad.Size = new System.Drawing.Size(56, 23);
            this.TSVlistLoad.TabIndex = 15;
            this.TSVlistLoad.Text = "Load";
            this.TSVlistLoad.UseVisualStyleBackColor = true;
            this.TSVlistLoad.Click += new System.EventHandler(this.TSVlistLoad_Click);
            // 
            // TSVlistRemove
            // 
            this.TSVlistRemove.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TSVlistRemove.Location = new System.Drawing.Point(218, 87);
            this.TSVlistRemove.Name = "TSVlistRemove";
            this.TSVlistRemove.Size = new System.Drawing.Size(56, 23);
            this.TSVlistRemove.TabIndex = 13;
            this.TSVlistRemove.Text = "Remove";
            this.TSVlistRemove.UseVisualStyleBackColor = true;
            this.TSVlistRemove.Click += new System.EventHandler(this.TSVlistRemove_Click);
            // 
            // TSVlistSave
            // 
            this.TSVlistSave.Location = new System.Drawing.Point(218, 116);
            this.TSVlistSave.Name = "TSVlistSave";
            this.TSVlistSave.Size = new System.Drawing.Size(56, 23);
            this.TSVlistSave.TabIndex = 14;
            this.TSVlistSave.Text = "Save";
            this.TSVlistSave.UseVisualStyleBackColor = true;
            this.TSVlistSave.Click += new System.EventHandler(this.TSVlistSave_Click);
            // 
            // Breed_options
            // 
            this.Breed_options.Controls.Add(this.modeBreed);
            this.Breed_options.Controls.Add(this.readESV);
            this.Breed_options.Controls.Add(this.Breed_labelBox);
            this.Breed_options.Controls.Add(this.label75);
            this.Breed_options.Controls.Add(this.quickBreed);
            this.Breed_options.Controls.Add(this.slotBreed);
            this.Breed_options.Controls.Add(this.label84);
            this.Breed_options.Controls.Add(this.boxBreed);
            this.Breed_options.Controls.Add(this.Breed_labelSlot);
            this.Breed_options.Controls.Add(this.eggsNoBreed);
            this.Breed_options.Controls.Add(this.daycare_select);
            this.Breed_options.Controls.Add(this.orgbox_pos);
            this.Breed_options.Location = new System.Drawing.Point(6, 6);
            this.Breed_options.Name = "Breed_options";
            this.Breed_options.Size = new System.Drawing.Size(260, 177);
            this.Breed_options.TabIndex = 27;
            this.Breed_options.TabStop = false;
            this.Breed_options.Text = "Options";
            // 
            // modeBreed
            // 
            this.modeBreed.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.modeBreed.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.modeBreed.FormattingEnabled = true;
            this.modeBreed.Location = new System.Drawing.Point(49, 17);
            this.modeBreed.Name = "modeBreed";
            this.modeBreed.Size = new System.Drawing.Size(205, 21);
            this.modeBreed.TabIndex = 0;
            this.modeBreed.SelectedIndexChanged += new System.EventHandler(this.modeBreed_SelectedIndexChanged);
            // 
            // readESV
            // 
            this.readESV.AutoSize = true;
            this.readESV.Location = new System.Drawing.Point(6, 148);
            this.readESV.Name = "readESV";
            this.readESV.Size = new System.Drawing.Size(137, 17);
            this.readESV.TabIndex = 6;
            this.readESV.Text = "Read ESV after deposit";
            this.readESV.UseVisualStyleBackColor = true;
            // 
            // Breed_labelBox
            // 
            this.Breed_labelBox.AutoSize = true;
            this.Breed_labelBox.Location = new System.Drawing.Point(3, 48);
            this.Breed_labelBox.Name = "Breed_labelBox";
            this.Breed_labelBox.Size = new System.Drawing.Size(28, 13);
            this.Breed_labelBox.TabIndex = 21;
            this.Breed_labelBox.Text = "Box:";
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Location = new System.Drawing.Point(165, 48);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(43, 13);
            this.label75.TabIndex = 23;
            this.label75.Text = "# eggs:";
            // 
            // quickBreed
            // 
            this.quickBreed.AutoSize = true;
            this.quickBreed.Location = new System.Drawing.Point(150, 148);
            this.quickBreed.Name = "quickBreed";
            this.quickBreed.Size = new System.Drawing.Size(85, 17);
            this.quickBreed.TabIndex = 7;
            this.quickBreed.Text = "Quick Breed";
            this.quickBreed.UseVisualStyleBackColor = true;
            // 
            // slotBreed
            // 
            this.slotBreed.Location = new System.Drawing.Point(118, 46);
            this.slotBreed.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.slotBreed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.slotBreed.Name = "slotBreed";
            this.slotBreed.Size = new System.Drawing.Size(41, 20);
            this.slotBreed.TabIndex = 2;
            this.slotBreed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Location = new System.Drawing.Point(6, 20);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(37, 13);
            this.label84.TabIndex = 20;
            this.label84.Text = "Mode:";
            // 
            // boxBreed
            // 
            this.boxBreed.Location = new System.Drawing.Point(37, 46);
            this.boxBreed.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.boxBreed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.boxBreed.Name = "boxBreed";
            this.boxBreed.Size = new System.Drawing.Size(41, 20);
            this.boxBreed.TabIndex = 1;
            this.boxBreed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Breed_labelSlot
            // 
            this.Breed_labelSlot.AutoSize = true;
            this.Breed_labelSlot.Location = new System.Drawing.Point(84, 48);
            this.Breed_labelSlot.Name = "Breed_labelSlot";
            this.Breed_labelSlot.Size = new System.Drawing.Size(28, 13);
            this.Breed_labelSlot.TabIndex = 22;
            this.Breed_labelSlot.Text = "Slot:";
            // 
            // eggsNoBreed
            // 
            this.eggsNoBreed.Location = new System.Drawing.Point(214, 46);
            this.eggsNoBreed.Maximum = new decimal(new int[] {
            930,
            0,
            0,
            0});
            this.eggsNoBreed.Name = "eggsNoBreed";
            this.eggsNoBreed.Size = new System.Drawing.Size(40, 20);
            this.eggsNoBreed.TabIndex = 3;
            this.eggsNoBreed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // breedingClear
            // 
            this.breedingClear.Location = new System.Drawing.Point(278, 189);
            this.breedingClear.Name = "breedingClear";
            this.breedingClear.Size = new System.Drawing.Size(150, 23);
            this.breedingClear.TabIndex = 16;
            this.breedingClear.Text = "Reset all fields";
            this.breedingClear.UseVisualStyleBackColor = true;
            this.breedingClear.Click += new System.EventHandler(this.breedingClear_Click);
            // 
            // filterBreeding
            // 
            this.filterBreeding.AllowUserToAddRows = false;
            this.filterBreeding.AllowUserToDeleteRows = false;
            this.filterBreeding.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.filterBreeding.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.filterBreeding.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewTextBoxColumn19,
            this.dataGridViewTextBoxColumn20,
            this.dataGridViewTextBoxColumn21,
            this.dataGridViewTextBoxColumn22,
            this.dataGridViewTextBoxColumn23,
            this.dataGridViewTextBoxColumn24,
            this.dataGridViewTextBoxColumn25,
            this.dataGridViewTextBoxColumn26,
            this.dataGridViewTextBoxColumn27,
            this.dataGridViewTextBoxColumn28,
            this.dataGridViewTextBoxColumn29,
            this.dataGridViewTextBoxColumn30,
            this.dataGridViewTextBoxColumn31});
            this.filterBreeding.Location = new System.Drawing.Point(6, 218);
            this.filterBreeding.MultiSelect = false;
            this.filterBreeding.Name = "filterBreeding";
            this.filterBreeding.ReadOnly = true;
            this.filterBreeding.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.filterBreeding.Size = new System.Drawing.Size(546, 146);
            this.filterBreeding.TabIndex = 18;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.HeaderText = "Shiny";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 58;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.HeaderText = "Nature";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Width = 64;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.HeaderText = "Ability";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Width = 59;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.HeaderText = "HP type";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.Width = 65;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.HeaderText = "Gender";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.Width = 67;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.HeaderText = "HP";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            this.dataGridViewTextBoxColumn18.Width = 47;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.HeaderText = "HP Logic";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            this.dataGridViewTextBoxColumn19.Width = 70;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.HeaderText = "Atk";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            this.dataGridViewTextBoxColumn20.Width = 48;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.HeaderText = "Atk Logic";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.ReadOnly = true;
            this.dataGridViewTextBoxColumn21.Width = 71;
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.HeaderText = "Def";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.ReadOnly = true;
            this.dataGridViewTextBoxColumn22.Width = 49;
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.HeaderText = "Def Logic";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            this.dataGridViewTextBoxColumn23.ReadOnly = true;
            this.dataGridViewTextBoxColumn23.Width = 72;
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.HeaderText = "SpA";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.ReadOnly = true;
            this.dataGridViewTextBoxColumn24.Width = 52;
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.HeaderText = "SpA Logic";
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            this.dataGridViewTextBoxColumn25.ReadOnly = true;
            this.dataGridViewTextBoxColumn25.Width = 75;
            // 
            // dataGridViewTextBoxColumn26
            // 
            this.dataGridViewTextBoxColumn26.HeaderText = "SpD";
            this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            this.dataGridViewTextBoxColumn26.ReadOnly = true;
            this.dataGridViewTextBoxColumn26.Width = 53;
            // 
            // dataGridViewTextBoxColumn27
            // 
            this.dataGridViewTextBoxColumn27.HeaderText = "SpD Logic";
            this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            this.dataGridViewTextBoxColumn27.ReadOnly = true;
            this.dataGridViewTextBoxColumn27.Width = 76;
            // 
            // dataGridViewTextBoxColumn28
            // 
            this.dataGridViewTextBoxColumn28.HeaderText = "Spe";
            this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            this.dataGridViewTextBoxColumn28.ReadOnly = true;
            this.dataGridViewTextBoxColumn28.Width = 51;
            // 
            // dataGridViewTextBoxColumn29
            // 
            this.dataGridViewTextBoxColumn29.HeaderText = "Spe Logic";
            this.dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
            this.dataGridViewTextBoxColumn29.ReadOnly = true;
            this.dataGridViewTextBoxColumn29.Width = 74;
            // 
            // dataGridViewTextBoxColumn30
            // 
            this.dataGridViewTextBoxColumn30.HeaderText = "Perfect IVs";
            this.dataGridViewTextBoxColumn30.Name = "dataGridViewTextBoxColumn30";
            this.dataGridViewTextBoxColumn30.ReadOnly = true;
            this.dataGridViewTextBoxColumn30.Width = 78;
            // 
            // dataGridViewTextBoxColumn31
            // 
            this.dataGridViewTextBoxColumn31.HeaderText = "Perfect IVs Logic";
            this.dataGridViewTextBoxColumn31.Name = "dataGridViewTextBoxColumn31";
            this.dataGridViewTextBoxColumn31.ReadOnly = true;
            this.dataGridViewTextBoxColumn31.Width = 80;
            // 
            // bFilterLoad
            // 
            this.bFilterLoad.Location = new System.Drawing.Point(439, 189);
            this.bFilterLoad.Name = "bFilterLoad";
            this.bFilterLoad.Size = new System.Drawing.Size(113, 23);
            this.bFilterLoad.TabIndex = 17;
            this.bFilterLoad.Text = "Load filter set...";
            this.bFilterLoad.UseVisualStyleBackColor = true;
            this.bFilterLoad.Click += new System.EventHandler(this.bFilterLoad_Click);
            // 
            // runBreedingBot
            // 
            this.runBreedingBot.Location = new System.Drawing.Point(6, 189);
            this.runBreedingBot.Name = "runBreedingBot";
            this.runBreedingBot.Size = new System.Drawing.Size(260, 23);
            this.runBreedingBot.TabIndex = 19;
            this.runBreedingBot.Text = "Start Bot";
            this.runBreedingBot.UseVisualStyleBackColor = true;
            this.runBreedingBot.Click += new System.EventHandler(this.runBreedingBot_Click_1);
            // 
            // tabSoftReset
            // 
            this.tabSoftReset.BackColor = System.Drawing.SystemColors.Control;
            this.tabSoftReset.Controls.Add(this.SR_options);
            this.tabSoftReset.Controls.Add(this.srClear);
            this.tabSoftReset.Controls.Add(this.filtersSoftReset);
            this.tabSoftReset.Controls.Add(this.srFilterLoad);
            this.tabSoftReset.Controls.Add(this.RunLSRbot);
            this.tabSoftReset.Location = new System.Drawing.Point(4, 22);
            this.tabSoftReset.Name = "tabSoftReset";
            this.tabSoftReset.Size = new System.Drawing.Size(558, 378);
            this.tabSoftReset.TabIndex = 3;
            this.tabSoftReset.Text = "Soft-reset";
            // 
            // SR_options
            // 
            this.SR_options.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SR_options.Controls.Add(this.label72);
            this.SR_options.Controls.Add(this.label8);
            this.SR_options.Controls.Add(this.typeLSR);
            this.SR_options.Controls.Add(this.sr_Species);
            this.SR_options.Controls.Add(this.resumeLSR);
            this.SR_options.Location = new System.Drawing.Point(6, 6);
            this.SR_options.Name = "SR_options";
            this.SR_options.Size = new System.Drawing.Size(546, 53);
            this.SR_options.TabIndex = 10;
            this.SR_options.TabStop = false;
            this.SR_options.Text = "Options";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(277, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Species:";
            this.label8.Visible = false;
            // 
            // sr_Species
            // 
            this.sr_Species.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.sr_Species.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.sr_Species.FormattingEnabled = true;
            this.sr_Species.Location = new System.Drawing.Point(331, 17);
            this.sr_Species.Name = "sr_Species";
            this.sr_Species.Size = new System.Drawing.Size(120, 21);
            this.sr_Species.TabIndex = 1;
            this.sr_Species.Visible = false;
            // 
            // srClear
            // 
            this.srClear.Location = new System.Drawing.Point(283, 65);
            this.srClear.Name = "srClear";
            this.srClear.Size = new System.Drawing.Size(143, 23);
            this.srClear.TabIndex = 4;
            this.srClear.Text = "Reset all fields";
            this.srClear.UseVisualStyleBackColor = true;
            this.srClear.Click += new System.EventHandler(this.srClear_Click);
            // 
            // filtersSoftReset
            // 
            this.filtersSoftReset.AllowUserToAddRows = false;
            this.filtersSoftReset.AllowUserToDeleteRows = false;
            this.filtersSoftReset.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.filtersSoftReset.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.filtersSoftReset.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn32,
            this.dataGridViewTextBoxColumn33,
            this.dataGridViewTextBoxColumn34,
            this.dataGridViewTextBoxColumn35,
            this.dataGridViewTextBoxColumn36,
            this.dataGridViewTextBoxColumn37,
            this.dataGridViewTextBoxColumn38,
            this.dataGridViewTextBoxColumn39,
            this.dataGridViewTextBoxColumn40,
            this.dataGridViewTextBoxColumn41,
            this.dataGridViewTextBoxColumn42,
            this.dataGridViewTextBoxColumn43,
            this.dataGridViewTextBoxColumn44,
            this.dataGridViewTextBoxColumn45,
            this.dataGridViewTextBoxColumn46,
            this.dataGridViewTextBoxColumn47,
            this.dataGridViewTextBoxColumn48,
            this.dataGridViewTextBoxColumn49,
            this.dataGridViewTextBoxColumn50});
            this.filtersSoftReset.Location = new System.Drawing.Point(6, 94);
            this.filtersSoftReset.MultiSelect = false;
            this.filtersSoftReset.Name = "filtersSoftReset";
            this.filtersSoftReset.ReadOnly = true;
            this.filtersSoftReset.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.filtersSoftReset.Size = new System.Drawing.Size(546, 146);
            this.filtersSoftReset.TabIndex = 6;
            // 
            // dataGridViewTextBoxColumn32
            // 
            this.dataGridViewTextBoxColumn32.HeaderText = "Shiny";
            this.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
            this.dataGridViewTextBoxColumn32.ReadOnly = true;
            this.dataGridViewTextBoxColumn32.Width = 58;
            // 
            // dataGridViewTextBoxColumn33
            // 
            this.dataGridViewTextBoxColumn33.HeaderText = "Nature";
            this.dataGridViewTextBoxColumn33.Name = "dataGridViewTextBoxColumn33";
            this.dataGridViewTextBoxColumn33.ReadOnly = true;
            this.dataGridViewTextBoxColumn33.Width = 64;
            // 
            // dataGridViewTextBoxColumn34
            // 
            this.dataGridViewTextBoxColumn34.HeaderText = "Ability";
            this.dataGridViewTextBoxColumn34.Name = "dataGridViewTextBoxColumn34";
            this.dataGridViewTextBoxColumn34.ReadOnly = true;
            this.dataGridViewTextBoxColumn34.Width = 59;
            // 
            // dataGridViewTextBoxColumn35
            // 
            this.dataGridViewTextBoxColumn35.HeaderText = "HP type";
            this.dataGridViewTextBoxColumn35.Name = "dataGridViewTextBoxColumn35";
            this.dataGridViewTextBoxColumn35.ReadOnly = true;
            this.dataGridViewTextBoxColumn35.Width = 65;
            // 
            // dataGridViewTextBoxColumn36
            // 
            this.dataGridViewTextBoxColumn36.HeaderText = "Gender";
            this.dataGridViewTextBoxColumn36.Name = "dataGridViewTextBoxColumn36";
            this.dataGridViewTextBoxColumn36.ReadOnly = true;
            this.dataGridViewTextBoxColumn36.Width = 67;
            // 
            // dataGridViewTextBoxColumn37
            // 
            this.dataGridViewTextBoxColumn37.HeaderText = "HP";
            this.dataGridViewTextBoxColumn37.Name = "dataGridViewTextBoxColumn37";
            this.dataGridViewTextBoxColumn37.ReadOnly = true;
            this.dataGridViewTextBoxColumn37.Width = 47;
            // 
            // dataGridViewTextBoxColumn38
            // 
            this.dataGridViewTextBoxColumn38.HeaderText = "HP Logic";
            this.dataGridViewTextBoxColumn38.Name = "dataGridViewTextBoxColumn38";
            this.dataGridViewTextBoxColumn38.ReadOnly = true;
            this.dataGridViewTextBoxColumn38.Width = 70;
            // 
            // dataGridViewTextBoxColumn39
            // 
            this.dataGridViewTextBoxColumn39.HeaderText = "Atk";
            this.dataGridViewTextBoxColumn39.Name = "dataGridViewTextBoxColumn39";
            this.dataGridViewTextBoxColumn39.ReadOnly = true;
            this.dataGridViewTextBoxColumn39.Width = 48;
            // 
            // dataGridViewTextBoxColumn40
            // 
            this.dataGridViewTextBoxColumn40.HeaderText = "Atk Logic";
            this.dataGridViewTextBoxColumn40.Name = "dataGridViewTextBoxColumn40";
            this.dataGridViewTextBoxColumn40.ReadOnly = true;
            this.dataGridViewTextBoxColumn40.Width = 71;
            // 
            // dataGridViewTextBoxColumn41
            // 
            this.dataGridViewTextBoxColumn41.HeaderText = "Def";
            this.dataGridViewTextBoxColumn41.Name = "dataGridViewTextBoxColumn41";
            this.dataGridViewTextBoxColumn41.ReadOnly = true;
            this.dataGridViewTextBoxColumn41.Width = 49;
            // 
            // dataGridViewTextBoxColumn42
            // 
            this.dataGridViewTextBoxColumn42.HeaderText = "Def Logic";
            this.dataGridViewTextBoxColumn42.Name = "dataGridViewTextBoxColumn42";
            this.dataGridViewTextBoxColumn42.ReadOnly = true;
            this.dataGridViewTextBoxColumn42.Width = 72;
            // 
            // dataGridViewTextBoxColumn43
            // 
            this.dataGridViewTextBoxColumn43.HeaderText = "SpA";
            this.dataGridViewTextBoxColumn43.Name = "dataGridViewTextBoxColumn43";
            this.dataGridViewTextBoxColumn43.ReadOnly = true;
            this.dataGridViewTextBoxColumn43.Width = 52;
            // 
            // dataGridViewTextBoxColumn44
            // 
            this.dataGridViewTextBoxColumn44.HeaderText = "SpA Logic";
            this.dataGridViewTextBoxColumn44.Name = "dataGridViewTextBoxColumn44";
            this.dataGridViewTextBoxColumn44.ReadOnly = true;
            this.dataGridViewTextBoxColumn44.Width = 75;
            // 
            // dataGridViewTextBoxColumn45
            // 
            this.dataGridViewTextBoxColumn45.HeaderText = "SpD";
            this.dataGridViewTextBoxColumn45.Name = "dataGridViewTextBoxColumn45";
            this.dataGridViewTextBoxColumn45.ReadOnly = true;
            this.dataGridViewTextBoxColumn45.Width = 53;
            // 
            // dataGridViewTextBoxColumn46
            // 
            this.dataGridViewTextBoxColumn46.HeaderText = "SpD Logic";
            this.dataGridViewTextBoxColumn46.Name = "dataGridViewTextBoxColumn46";
            this.dataGridViewTextBoxColumn46.ReadOnly = true;
            this.dataGridViewTextBoxColumn46.Width = 76;
            // 
            // dataGridViewTextBoxColumn47
            // 
            this.dataGridViewTextBoxColumn47.HeaderText = "Spe";
            this.dataGridViewTextBoxColumn47.Name = "dataGridViewTextBoxColumn47";
            this.dataGridViewTextBoxColumn47.ReadOnly = true;
            this.dataGridViewTextBoxColumn47.Width = 51;
            // 
            // dataGridViewTextBoxColumn48
            // 
            this.dataGridViewTextBoxColumn48.HeaderText = "Spe Logic";
            this.dataGridViewTextBoxColumn48.Name = "dataGridViewTextBoxColumn48";
            this.dataGridViewTextBoxColumn48.ReadOnly = true;
            this.dataGridViewTextBoxColumn48.Width = 74;
            // 
            // dataGridViewTextBoxColumn49
            // 
            this.dataGridViewTextBoxColumn49.HeaderText = "Perfect IVs";
            this.dataGridViewTextBoxColumn49.Name = "dataGridViewTextBoxColumn49";
            this.dataGridViewTextBoxColumn49.ReadOnly = true;
            this.dataGridViewTextBoxColumn49.Width = 78;
            // 
            // dataGridViewTextBoxColumn50
            // 
            this.dataGridViewTextBoxColumn50.HeaderText = "Perfect IVs Logic";
            this.dataGridViewTextBoxColumn50.Name = "dataGridViewTextBoxColumn50";
            this.dataGridViewTextBoxColumn50.ReadOnly = true;
            this.dataGridViewTextBoxColumn50.Width = 80;
            // 
            // srFilterLoad
            // 
            this.srFilterLoad.Location = new System.Drawing.Point(432, 65);
            this.srFilterLoad.Name = "srFilterLoad";
            this.srFilterLoad.Size = new System.Drawing.Size(120, 23);
            this.srFilterLoad.TabIndex = 5;
            this.srFilterLoad.Text = "Load filter set...";
            this.srFilterLoad.UseVisualStyleBackColor = true;
            this.srFilterLoad.Click += new System.EventHandler(this.srFilterLoad_Click);
            // 
            // tabWonderTrade
            // 
            this.tabWonderTrade.BackColor = System.Drawing.SystemColors.Control;
            this.tabWonderTrade.Controls.Add(this.WT_options);
            this.tabWonderTrade.Controls.Add(this.WT_RunEndless);
            this.tabWonderTrade.Controls.Add(this.RunWTbot);
            this.tabWonderTrade.Location = new System.Drawing.Point(4, 22);
            this.tabWonderTrade.Name = "tabWonderTrade";
            this.tabWonderTrade.Size = new System.Drawing.Size(558, 378);
            this.tabWonderTrade.TabIndex = 2;
            this.tabWonderTrade.Text = "Wonder Trade";
            // 
            // WT_options
            // 
            this.WT_options.Controls.Add(this.label58);
            this.WT_options.Controls.Add(this.WT_After);
            this.WT_options.Controls.Add(this.label57);
            this.WT_options.Controls.Add(this.WTBox);
            this.WT_options.Controls.Add(this.WT_Sources);
            this.WT_options.Controls.Add(this.WTtradesNo);
            this.WT_options.Controls.Add(this.WTcollectFC);
            this.WT_options.Controls.Add(this.WTSlot);
            this.WT_options.Controls.Add(this.label59);
            this.WT_options.Location = new System.Drawing.Point(6, 6);
            this.WT_options.Name = "WT_options";
            this.WT_options.Size = new System.Drawing.Size(304, 175);
            this.WT_options.TabIndex = 11;
            this.WT_options.TabStop = false;
            this.WT_options.Text = "Options";
            // 
            // WT_After
            // 
            this.WT_After.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.WT_After.Controls.Add(this.WTafter_Delete);
            this.WT_After.Controls.Add(this.WTafter_Restore);
            this.WT_After.Controls.Add(this.WTafter_DoNothing);
            this.WT_After.Controls.Add(this.WTafter_Dump);
            this.WT_After.Location = new System.Drawing.Point(150, 16);
            this.WT_After.Name = "WT_After";
            this.WT_After.Size = new System.Drawing.Size(148, 123);
            this.WT_After.TabIndex = 10;
            this.WT_After.TabStop = false;
            this.WT_After.Text = "After trading";
            // 
            // WTafter_Delete
            // 
            this.WTafter_Delete.AutoSize = true;
            this.WTafter_Delete.Location = new System.Drawing.Point(6, 88);
            this.WTafter_Delete.Name = "WTafter_Delete";
            this.WTafter_Delete.Size = new System.Drawing.Size(136, 17);
            this.WTafter_Delete.TabIndex = 1;
            this.WTafter_Delete.Text = "Delete traded pokémon";
            this.WTafter_Delete.UseVisualStyleBackColor = true;
            // 
            // WTafter_Restore
            // 
            this.WTafter_Restore.AutoSize = true;
            this.WTafter_Restore.Location = new System.Drawing.Point(6, 65);
            this.WTafter_Restore.Name = "WTafter_Restore";
            this.WTafter_Restore.Size = new System.Drawing.Size(101, 17);
            this.WTafter_Restore.TabIndex = 1;
            this.WTafter_Restore.Text = "Restore backup";
            this.WTafter_Restore.UseVisualStyleBackColor = true;
            // 
            // WTafter_DoNothing
            // 
            this.WTafter_DoNothing.AutoSize = true;
            this.WTafter_DoNothing.Checked = true;
            this.WTafter_DoNothing.Location = new System.Drawing.Point(6, 42);
            this.WTafter_DoNothing.Name = "WTafter_DoNothing";
            this.WTafter_DoNothing.Size = new System.Drawing.Size(77, 17);
            this.WTafter_DoNothing.TabIndex = 1;
            this.WTafter_DoNothing.TabStop = true;
            this.WTafter_DoNothing.Text = "Do nothing";
            this.WTafter_DoNothing.UseVisualStyleBackColor = true;
            // 
            // WTafter_Dump
            // 
            this.WTafter_Dump.AutoSize = true;
            this.WTafter_Dump.Location = new System.Drawing.Point(6, 20);
            this.WTafter_Dump.Name = "WTafter_Dump";
            this.WTafter_Dump.Size = new System.Drawing.Size(109, 17);
            this.WTafter_Dump.TabIndex = 0;
            this.WTafter_Dump.Text = "Dump boxes and:";
            this.WTafter_Dump.UseVisualStyleBackColor = true;
            // 
            // WT_Sources
            // 
            this.WT_Sources.AutoSize = true;
            this.WT_Sources.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.WT_Sources.Controls.Add(this.WTsource_Random);
            this.WT_Sources.Controls.Add(this.WTsource_Folder);
            this.WT_Sources.Controls.Add(this.WTsource_Boxes);
            this.WT_Sources.Location = new System.Drawing.Point(6, 61);
            this.WT_Sources.Name = "WT_Sources";
            this.WT_Sources.Size = new System.Drawing.Size(138, 101);
            this.WT_Sources.TabIndex = 8;
            this.WT_Sources.TabStop = false;
            this.WT_Sources.Text = "Pokémon Source";
            // 
            // WTsource_Random
            // 
            this.WTsource_Random.AutoSize = true;
            this.WTsource_Random.Location = new System.Drawing.Point(6, 65);
            this.WTsource_Random.Name = "WTsource_Random";
            this.WTsource_Random.Size = new System.Drawing.Size(124, 17);
            this.WTsource_Random.TabIndex = 2;
            this.WTsource_Random.Text = "WT Folder (Random)";
            this.WTsource_Random.UseVisualStyleBackColor = true;
            // 
            // WTsource_Folder
            // 
            this.WTsource_Folder.AutoSize = true;
            this.WTsource_Folder.Location = new System.Drawing.Point(6, 42);
            this.WTsource_Folder.Name = "WTsource_Folder";
            this.WTsource_Folder.Size = new System.Drawing.Size(126, 17);
            this.WTsource_Folder.TabIndex = 1;
            this.WTsource_Folder.Text = "Wonder Trade Folder";
            this.WTsource_Folder.UseVisualStyleBackColor = true;
            // 
            // WTsource_Boxes
            // 
            this.WTsource_Boxes.AutoSize = true;
            this.WTsource_Boxes.Checked = true;
            this.WTsource_Boxes.Location = new System.Drawing.Point(6, 19);
            this.WTsource_Boxes.Name = "WTsource_Boxes";
            this.WTsource_Boxes.Size = new System.Drawing.Size(71, 17);
            this.WTsource_Boxes.TabIndex = 0;
            this.WTsource_Boxes.TabStop = true;
            this.WTsource_Boxes.Text = "PC Boxes";
            this.WTsource_Boxes.UseVisualStyleBackColor = true;
            // 
            // WTcollectFC
            // 
            this.WTcollectFC.AutoSize = true;
            this.WTcollectFC.Enabled = false;
            this.WTcollectFC.Location = new System.Drawing.Point(150, 145);
            this.WTcollectFC.Name = "WTcollectFC";
            this.WTcollectFC.Size = new System.Drawing.Size(134, 17);
            this.WTcollectFC.TabIndex = 7;
            this.WTcollectFC.Text = "Collect FC after a trade";
            this.WTcollectFC.UseVisualStyleBackColor = true;
            // 
            // WT_RunEndless
            // 
            this.WT_RunEndless.AutoSize = true;
            this.WT_RunEndless.Location = new System.Drawing.Point(220, 191);
            this.WT_RunEndless.Name = "WT_RunEndless";
            this.WT_RunEndless.Size = new System.Drawing.Size(90, 17);
            this.WT_RunEndless.TabIndex = 9;
            this.WT_RunEndless.Text = "Run endessly";
            this.WT_RunEndless.UseVisualStyleBackColor = true;
            // 
            // tabNTRlog
            // 
            this.tabNTRlog.BackColor = System.Drawing.SystemColors.Control;
            this.tabNTRlog.Controls.Add(this.updateLabel);
            this.tabNTRlog.Controls.Add(this.txtLog);
            this.tabNTRlog.Controls.Add(this.readResult);
            this.tabNTRlog.Controls.Add(this.label69);
            this.tabNTRlog.Controls.Add(this.label71);
            this.tabNTRlog.Location = new System.Drawing.Point(4, 22);
            this.tabNTRlog.Name = "tabNTRlog";
            this.tabNTRlog.Size = new System.Drawing.Size(558, 378);
            this.tabNTRlog.TabIndex = 5;
            this.tabNTRlog.Tag = "1";
            this.tabNTRlog.Text = "NTR Log";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(274, 152);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 30);
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            // 
            // shinypic
            // 
            this.shinypic.Location = new System.Drawing.Point(274, 152);
            this.shinypic.Name = "shinypic";
            this.shinypic.Size = new System.Drawing.Size(10, 10);
            this.shinypic.TabIndex = 19;
            this.shinypic.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(891, 430);
            this.Controls.Add(this.shinypic);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.stopBotButton);
            this.Controls.Add(this.miscTabs);
            this.Controls.Add(this.dumpBox);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "PKMN-NTR";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moneyNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.milesNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bpNum)).EndInit();
            this.dumpBox.ResumeLayout(false);
            this.dumpBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slotDump)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxDump)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SIDNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TIDNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hourNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keysGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bersGridView)).EndInit();
            this.Edit_Items.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.itemsView7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deleteAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deleteBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deleteSlot)).EndInit();
            this.cloneWriteTabs.ResumeLayout(false);
            this.cloneTab.ResumeLayout(false);
            this.cloneTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cloneSlotFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cloneBoxFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cloneCopiesNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cloneSlotTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cloneBoxTo)).EndInit();
            this.writeTab.ResumeLayout(false);
            this.writeTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.writeCopiesNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.writeSlotTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.writeBoxTo)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.touchX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.touchY)).EndInit();
            this.daycare_select.ResumeLayout(false);
            this.daycare_select.PerformLayout();
            this.orgbox_pos.ResumeLayout(false);
            this.orgbox_pos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WTtradesNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WTBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WTSlot)).EndInit();
            this.miscTabs.ResumeLayout(false);
            this.tabEditTrainer.ResumeLayout(false);
            this.tabEditTrainer.PerformLayout();
            this.Edit_Trainer.ResumeLayout(false);
            this.Edit_Trainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.totalFCNum)).EndInit();
            this.tabControls.ResumeLayout(false);
            this.tabControls.PerformLayout();
            this.Remote_Stick.ResumeLayout(false);
            this.Remote_Stick.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StickX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StickY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StickNumY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StickNumX)).EndInit();
            this.Remote_touch.ResumeLayout(false);
            this.Remote_touch.PerformLayout();
            this.Remote_buttons.ResumeLayout(false);
            this.tabFilters.ResumeLayout(false);
            this.tabFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filterList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterPerIVvalue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterSPEvalue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterSPDvalue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterDEFvalue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterSPAvalue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterHPvalue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterATKvalue)).EndInit();
            this.tabBreeding.ResumeLayout(false);
            this.Breed_esvtsv.ResumeLayout(false);
            this.Breed_esvtsv.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ESVlist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TSVlistNum)).EndInit();
            this.Breed_options.ResumeLayout(false);
            this.Breed_options.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slotBreed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxBreed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eggsNoBreed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterBreeding)).EndInit();
            this.tabSoftReset.ResumeLayout(false);
            this.SR_options.ResumeLayout(false);
            this.SR_options.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filtersSoftReset)).EndInit();
            this.tabWonderTrade.ResumeLayout(false);
            this.tabWonderTrade.PerformLayout();
            this.WT_options.ResumeLayout(false);
            this.WT_options.PerformLayout();
            this.WT_After.ResumeLayout(false);
            this.WT_After.PerformLayout();
            this.WT_Sources.ResumeLayout(false);
            this.WT_Sources.PerformLayout();
            this.tabNTRlog.ResumeLayout(false);
            this.tabNTRlog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shinypic)).EndInit();
            this.ResumeLayout(false);

        }

        public System.Windows.Forms.TextBox txtLog;
		private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer disconnectTimer;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.TextBox host;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown moneyNum;
        private System.Windows.Forms.NumericUpDown milesNum;
        private System.Windows.Forms.NumericUpDown bpNum;
        private System.Windows.Forms.Button pokeMoney;
        private System.Windows.Forms.Button pokeMiles;
        private System.Windows.Forms.Button pokeBP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox dumpBox;
        private System.Windows.Forms.Button dumpPokemon;
        private System.Windows.Forms.Label SlotLabel;
        private System.Windows.Forms.NumericUpDown slotDump;
        private System.Windows.Forms.Label BoxLabel;
        private System.Windows.Forms.NumericUpDown boxDump;
        private System.Windows.Forms.TextBox nameek6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button dumpBoxes;
        private System.Windows.Forms.RadioButton radioDaycare;
        private System.Windows.Forms.RadioButton radioBoxes;
        private System.Windows.Forms.DataGridView itemsGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown TIDNum;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button pokeTID;
        private System.Windows.Forms.Button pokeTime;
        private System.Windows.Forms.NumericUpDown hourNum;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown minNum;
        private System.Windows.Forms.NumericUpDown secNum;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button showKeys;
        private System.Windows.Forms.Button showBerries;
        private System.Windows.Forms.Button showTMs;
        private System.Windows.Forms.Button showMedicine;
        private System.Windows.Forms.Button showItems;
        private System.Windows.Forms.DataGridView keysGridView;
        private System.Windows.Forms.DataGridView tmsGridView;
        private System.Windows.Forms.DataGridView medsGridView;
        private System.Windows.Forms.DataGridView bersGridView;
        private System.Windows.Forms.GroupBox Edit_Items;
        private System.Windows.Forms.Button itemWrite;
        private System.Windows.Forms.Button itemAdd;
        private System.Windows.Forms.RadioButton radioOpponent;
        private System.Windows.Forms.RadioButton radioTrade;
        private System.Windows.Forms.Button pokeSID;
        private System.Windows.Forms.NumericUpDown SIDNum;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button delPkm;
        private System.Windows.Forms.NumericUpDown deleteBox;
        private System.Windows.Forms.NumericUpDown deleteSlot;
        private System.Windows.Forms.Button pokeLang;
        private System.Windows.Forms.Button pokeName;
        private System.Windows.Forms.TextBox playerName;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox Lang;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.NumericUpDown deleteAmount;
        private System.Windows.Forms.RadioButton radioParty;
        private System.Windows.Forms.CheckBox onlyView;
        private System.Windows.Forms.RadioButton radioBattleBox;
        private System.Windows.Forms.TabControl cloneWriteTabs;
        private System.Windows.Forms.TabPage cloneTab;
        private System.Windows.Forms.TabPage writeTab;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.NumericUpDown writeBoxTo;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.NumericUpDown writeSlotTo;
        private System.Windows.Forms.NumericUpDown writeCopiesNo;
        private System.Windows.Forms.Button writeDoIt;
        private System.Windows.Forms.Button writeBrowse;
        private System.Windows.Forms.CheckBox writeAutoInc;
        private System.Windows.Forms.Button cloneDoIt;
        private System.Windows.Forms.NumericUpDown cloneSlotFrom;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.NumericUpDown cloneBoxFrom;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.NumericUpDown cloneCopiesNo;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.NumericUpDown cloneSlotTo;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.NumericUpDown cloneBoxTo;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox deleteKeepBackup;
        private System.Windows.Forms.Button RunLSRbot;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Button RunWTbot;
        private System.Windows.Forms.NumericUpDown WTtradesNo;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.NumericUpDown WTBox;
        private System.Windows.Forms.NumericUpDown WTSlot;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Button manualDLeft;
        private System.Windows.Forms.Button manualTouch;
        private System.Windows.Forms.Button manualX;
        private System.Windows.Forms.Button manualY;
        private System.Windows.Forms.Button manualDUp;
        private System.Windows.Forms.Button manualL;
        private System.Windows.Forms.Button manualB;
        private System.Windows.Forms.NumericUpDown touchY;
        private System.Windows.Forms.Button manualA;
        private System.Windows.Forms.Button manualR;
        private System.Windows.Forms.NumericUpDown touchX;
        private System.Windows.Forms.Button manualSelect;
        private System.Windows.Forms.Button manualDRight;
        private System.Windows.Forms.Button ManualDDown;
        private System.Windows.Forms.Button manualStart;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Button stopBotButton;
        private System.Windows.Forms.TextBox readResult;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.ComboBox typeLSR;
        private System.Windows.Forms.CheckBox resumeLSR;
        private System.Windows.Forms.TabControl miscTabs;
        private System.Windows.Forms.TabPage tabEditTrainer;
        private System.Windows.Forms.TabPage tabControls;
        private System.Windows.Forms.TabPage tabWonderTrade;
        private System.Windows.Forms.TabPage tabSoftReset;
        private System.Windows.Forms.GroupBox Edit_Trainer;
        private System.Windows.Forms.TabPage tabNTRlog;
        private System.Windows.Forms.Button manualSR;
        private System.Windows.Forms.Button srFilterLoad;
        private System.Windows.Forms.TabPage tabBreeding;
        private System.Windows.Forms.CheckBox quickBreed;
        private System.Windows.Forms.Button TSVlistLoad;
        private System.Windows.Forms.Button TSVlistSave;
        private System.Windows.Forms.Button TSVlistRemove;
        private System.Windows.Forms.Button TSVlistAdd;
        private System.Windows.Forms.NumericUpDown TSVlistNum;
        private System.Windows.Forms.ListBox TSVlist;
        private System.Windows.Forms.Button ESVlistSave;
        private System.Windows.Forms.DataGridView ESVlist;
        private System.Windows.Forms.DataGridViewTextBoxColumn ESVlistBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ESVlistSlot;
        private System.Windows.Forms.DataGridViewTextBoxColumn ESVlistValue;
        private System.Windows.Forms.CheckBox readESV;
        private System.Windows.Forms.Button bFilterLoad;
        private System.Windows.Forms.GroupBox daycare_select;
        private System.Windows.Forms.RadioButton radioDayCare1;
        private System.Windows.Forms.RadioButton radioDayCare2;
        private System.Windows.Forms.GroupBox orgbox_pos;
        private System.Windows.Forms.RadioButton OrganizeMiddle;
        private System.Windows.Forms.RadioButton OrganizeTop;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.Button runBreedingBot;
        private System.Windows.Forms.ComboBox modeBreed;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.Label Breed_labelBox;
        private System.Windows.Forms.NumericUpDown slotBreed;
        private System.Windows.Forms.NumericUpDown eggsNoBreed;
        private System.Windows.Forms.NumericUpDown boxBreed;
        private System.Windows.Forms.Label Breed_labelSlot;
        private System.Windows.Forms.TabPage tabFilters;
        private System.Windows.Forms.ComboBox filterPerIVlogic;
        private System.Windows.Forms.ComboBox filterSPElogic;
        private System.Windows.Forms.ComboBox filterSPDlogic;
        private System.Windows.Forms.ComboBox filterSPAlogic;
        private System.Windows.Forms.ComboBox filterDEFlogic;
        private System.Windows.Forms.ComboBox filterATKlogic;
        private System.Windows.Forms.ComboBox filterHPlogic;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.NumericUpDown filterPerIVvalue;
        private System.Windows.Forms.Label label101;
        private System.Windows.Forms.CheckBox filterShiny;
        private System.Windows.Forms.ComboBox filterGender;
        private System.Windows.Forms.Label label102;
        private System.Windows.Forms.Label label103;
        private System.Windows.Forms.NumericUpDown filterSPEvalue;
        private System.Windows.Forms.NumericUpDown filterSPDvalue;
        private System.Windows.Forms.Label label104;
        private System.Windows.Forms.Label label105;
        private System.Windows.Forms.Label label106;
        private System.Windows.Forms.ComboBox filterAbility;
        private System.Windows.Forms.NumericUpDown filterDEFvalue;
        private System.Windows.Forms.Label label107;
        private System.Windows.Forms.Label label108;
        private System.Windows.Forms.ComboBox filterNature;
        private System.Windows.Forms.NumericUpDown filterSPAvalue;
        private System.Windows.Forms.ComboBox filterHPtype;
        private System.Windows.Forms.NumericUpDown filterHPvalue;
        private System.Windows.Forms.Label label109;
        private System.Windows.Forms.Label label110;
        private System.Windows.Forms.Label label111;
        private System.Windows.Forms.NumericUpDown filterATKvalue;
        private System.Windows.Forms.Label label112;
        private System.Windows.Forms.Button filterRead;
        private System.Windows.Forms.Button filterLoad;
        private System.Windows.Forms.Button filterSave;
        private System.Windows.Forms.Button filterRemove;
        private System.Windows.Forms.Button filterAdd;
        private System.Windows.Forms.DataGridView filterList;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn HPlogic;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn ATKlogic;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEFlogic;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPAlogic;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPDlogic;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPElogic;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn PerfectIVlogic;
        private System.Windows.Forms.DataGridView filterBreeding;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn30;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn31;
        private System.Windows.Forms.DataGridView filtersSoftReset;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn33;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn34;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn35;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn36;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn37;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn38;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn39;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn40;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn41;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn42;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn43;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn44;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn45;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn46;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn47;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn48;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn49;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn50;
        private System.Windows.Forms.Button ReloadFields;
        private System.Windows.Forms.CheckBox WTcollectFC;
        private System.Windows.Forms.DataGridView itemsView7;
        private System.Windows.Forms.DataGridViewComboBoxColumn nameItem7;
        private System.Windows.Forms.DataGridViewTextBoxColumn countItem7;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Button pokeTotalFC;
        private System.Windows.Forms.NumericUpDown totalFCNum;
        private System.Windows.Forms.Button StickSend;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.NumericUpDown StickNumX;
        private System.Windows.Forms.NumericUpDown StickNumY;
        private System.Windows.Forms.TrackBar StickY;
        private System.Windows.Forms.TrackBar StickX;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox shinypic;
        private System.Windows.Forms.Button PokeDiggerBtn;
        private System.Windows.Forms.Button filterReset;
        private System.Windows.Forms.Button breedingClear;
        private System.Windows.Forms.Button srClear;
        private System.Windows.Forms.Label updateLabel;
        private System.Windows.Forms.Button DumpInstructionsBtn;
        private System.Windows.Forms.TextBox EggSeed;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox sr_Species;
        private System.Windows.Forms.GroupBox WT_Sources;
        private System.Windows.Forms.RadioButton WTsource_Random;
        private System.Windows.Forms.RadioButton WTsource_Folder;
        private System.Windows.Forms.RadioButton WTsource_Boxes;
        private System.Windows.Forms.CheckBox WT_RunEndless;
        private System.Windows.Forms.GroupBox WT_After;
        private System.Windows.Forms.RadioButton WTafter_Delete;
        private System.Windows.Forms.RadioButton WTafter_Restore;
        private System.Windows.Forms.RadioButton WTafter_DoNothing;
        private System.Windows.Forms.CheckBox WTafter_Dump;
        private System.Windows.Forms.GroupBox Remote_Stick;
        private System.Windows.Forms.GroupBox Remote_touch;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.GroupBox Remote_buttons;
        private System.Windows.Forms.GroupBox Breed_options;
        private System.Windows.Forms.GroupBox Breed_esvtsv;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.GroupBox SR_options;
        private System.Windows.Forms.GroupBox WT_options;
        private System.Windows.Forms.TextBox seedRNG;
        private System.Windows.Forms.Label label60;
    }
}

