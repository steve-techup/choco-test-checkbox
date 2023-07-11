using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Service_Station.CARETAG_Main
{
    public partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && components is object)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.TextBoxEPC = new System.Windows.Forms.TextBox();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this._ButtonReadInstrument = new System.Windows.Forms.Button();
            this._Button_AcceptService = new System.Windows.Forms.Button();
            this.TotalNumber = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslStatus1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslReadPause1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.readerPowerBar = new UIControls.WinForms.Controls.ReaderPowerBar();
            this.Label1 = new System.Windows.Forms.Label();
            this._PictureBox_World = new System.Windows.Forms.PictureBox();
            this._ButtonStatus = new System.Windows.Forms.Button();
            this._PictureBox1 = new System.Windows.Forms.PictureBox();
            this._TopTitle = new System.Windows.Forms.Label();
            this.PowerStatus = new System.Windows.Forms.Label();
            this._TrackBarControl1 = new DevExpress.XtraEditors.TrackBarControl();
            this.LabelPower = new System.Windows.Forms.Label();
            this.TextBoxPower = new System.Windows.Forms.TextBox();
            this.LabelInserted = new System.Windows.Forms.Label();
            this.StatusUpdate = new System.Windows.Forms.Label();
            this.TextBox_InstrumentName = new System.Windows.Forms.TextBox();
            this._DataGridViewRules = new System.Windows.Forms.DataGridView();
            this.Rule = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._Button_Check_All = new System.Windows.Forms.Button();
            this._ButtonLifeCycle = new System.Windows.Forms.Button();
            this._Button_SentBack = new System.Windows.Forms.Button();
            this._Button_Service = new System.Windows.Forms.Button();
            this._DataGridView_Service = new System.Windows.Forms.DataGridView();
            this.Label_EPC_NR = new System.Windows.Forms.Label();
            this._TextBox_Service_Info = new System.Windows.Forms.TextBox();
            this._ComboBox_Weeks = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this._Button_Report = new System.Windows.Forms.Button();
            this.CheckBox_UseFilter = new System.Windows.Forms.CheckBox();
            this._Button_Send_To_Service = new System.Windows.Forms.Button();
            this._Button_RESET = new System.Windows.Forms.Button();
            this.Label_DataGrid_Green = new System.Windows.Forms.Label();
            this.btnLogOut = new UIControls.WinForms.Controls.BtnLogOut();
            this.statusStrip1.SuspendLayout();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._PictureBox_World)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._TrackBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._TrackBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._DataGridViewRules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._DataGridView_Service)).BeginInit();
            this.SuspendLayout();
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            resources.ApplyResources(this.settingsToolStripMenuItem, "settingsToolStripMenuItem");
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // TextBoxEPC
            // 
            resources.ApplyResources(this.TextBoxEPC, "TextBoxEPC");
            this.TextBoxEPC.Name = "TextBoxEPC";
            this.TextBoxEPC.ReadOnly = true;
            this.TextBoxEPC.TabStop = false;
            // 
            // _ButtonReadInstrument
            // 
            resources.ApplyResources(this._ButtonReadInstrument, "_ButtonReadInstrument");
            this._ButtonReadInstrument.Name = "_ButtonReadInstrument";
            this.ToolTip1.SetToolTip(this._ButtonReadInstrument, resources.GetString("_ButtonReadInstrument.ToolTip"));
            this._ButtonReadInstrument.UseVisualStyleBackColor = true;
            this._ButtonReadInstrument.Click += new System.EventHandler(this.ButtonReadInstrument_Click);
            // 
            // _Button_AcceptService
            // 
            resources.ApplyResources(this._Button_AcceptService, "_Button_AcceptService");
            this._Button_AcceptService.Name = "_Button_AcceptService";
            this._Button_AcceptService.UseVisualStyleBackColor = true;
            this._Button_AcceptService.Click += new System.EventHandler(this.Button_AcceptService_Click);
            // 
            // TotalNumber
            // 
            resources.ApplyResources(this.TotalNumber, "TotalNumber");
            this.TotalNumber.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.TotalNumber.Name = "TotalNumber";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatus1,
            this.tsslReadPause1});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // tsslStatus1
            // 
            resources.ApplyResources(this.tsslStatus1, "tsslStatus1");
            this.tsslStatus1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.tsslStatus1.Name = "tsslStatus1";
            // 
            // tsslReadPause1
            // 
            this.tsslReadPause1.BackColor = System.Drawing.Color.Red;
            resources.ApplyResources(this.tsslReadPause1, "tsslReadPause1");
            this.tsslReadPause1.Name = "tsslReadPause1";
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.DarkOrange;
            this.Panel1.Controls.Add(this.readerPowerBar);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Controls.Add(this._PictureBox_World);
            this.Panel1.Controls.Add(this._ButtonStatus);
            this.Panel1.Controls.Add(this._PictureBox1);
            this.Panel1.Controls.Add(this._TopTitle);
            resources.ApplyResources(this.Panel1, "Panel1");
            this.Panel1.Name = "Panel1";
            // 
            // readerPowerBar
            // 
            resources.ApplyResources(this.readerPowerBar, "readerPowerBar");
            this.readerPowerBar.Name = "readerPowerBar";
            // 
            // Label1
            // 
            resources.ApplyResources(this.Label1, "Label1");
            this.Label1.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.Label1.Name = "Label1";
            // 
            // _PictureBox_World
            // 
            this._PictureBox_World.Image = global::Service_Station.My.Resources.Resources.World_Map;
            resources.ApplyResources(this._PictureBox_World, "_PictureBox_World");
            this._PictureBox_World.Name = "_PictureBox_World";
            this._PictureBox_World.TabStop = false;
            this._PictureBox_World.Click += new System.EventHandler(this.PictureBox_World_Click);
            // 
            // _ButtonStatus
            // 
            resources.ApplyResources(this._ButtonStatus, "_ButtonStatus");
            this._ButtonStatus.Name = "_ButtonStatus";
            this._ButtonStatus.TabStop = false;
            this._ButtonStatus.UseVisualStyleBackColor = true;
            this._ButtonStatus.Click += new System.EventHandler(this.ButtonStatus_Click);
            // 
            // _PictureBox1
            // 
            this._PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this._PictureBox1.Image = global::Service_Station.My.Resources.Resources.Knowledge_Hub_logo;
            resources.ApplyResources(this._PictureBox1, "_PictureBox1");
            this._PictureBox1.Name = "_PictureBox1";
            this._PictureBox1.TabStop = false;
            this._PictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // _TopTitle
            // 
            resources.ApplyResources(this._TopTitle, "_TopTitle");
            this._TopTitle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this._TopTitle.Name = "_TopTitle";
            this._TopTitle.Click += new System.EventHandler(this.TopTitle_Click);
            // 
            // PowerStatus
            // 
            resources.ApplyResources(this.PowerStatus, "PowerStatus");
            this.PowerStatus.Name = "PowerStatus";
            // 
            // _TrackBarControl1
            // 
            resources.ApplyResources(this._TrackBarControl1, "_TrackBarControl1");
            this._TrackBarControl1.Name = "_TrackBarControl1";
            // 
            // 
            // 
            this._TrackBarControl1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this._TrackBarControl1.Properties.LargeChange = 10;
            this._TrackBarControl1.Properties.Maximum = 60;
            this._TrackBarControl1.Properties.SmallChange = 5;
            this._TrackBarControl1.Properties.TickFrequency = 5;
            this._TrackBarControl1.TabStop = false;
            this._TrackBarControl1.BeforeShowValueToolTip += new DevExpress.XtraEditors.TrackBarValueToolTipEventHandler(this.TrackBarControl1_BeforeShowValueToolTip);
            this._TrackBarControl1.ValueChanged += new System.EventHandler(this.TrackBarControl1_B);
            // 
            // LabelPower
            // 
            resources.ApplyResources(this.LabelPower, "LabelPower");
            this.LabelPower.Name = "LabelPower";
            // 
            // TextBoxPower
            // 
            this.TextBoxPower.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TextBoxPower.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.TextBoxPower, "TextBoxPower");
            this.TextBoxPower.Name = "TextBoxPower";
            this.TextBoxPower.ReadOnly = true;
            // 
            // LabelInserted
            // 
            resources.ApplyResources(this.LabelInserted, "LabelInserted");
            this.LabelInserted.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.LabelInserted.Name = "LabelInserted";
            // 
            // StatusUpdate
            // 
            resources.ApplyResources(this.StatusUpdate, "StatusUpdate");
            this.StatusUpdate.Name = "StatusUpdate";
            // 
            // TextBox_InstrumentName
            // 
            this.TextBox_InstrumentName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.TextBox_InstrumentName, "TextBox_InstrumentName");
            this.TextBox_InstrumentName.Name = "TextBox_InstrumentName";
            this.TextBox_InstrumentName.ReadOnly = true;
            // 
            // _DataGridViewRules
            // 
            this._DataGridViewRules.AllowUserToAddRows = false;
            this._DataGridViewRules.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._DataGridViewRules.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._DataGridViewRules.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._DataGridViewRules.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this._DataGridViewRules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._DataGridViewRules.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Rule});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._DataGridViewRules.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this._DataGridViewRules, "_DataGridViewRules");
            this._DataGridViewRules.MultiSelect = false;
            this._DataGridViewRules.Name = "_DataGridViewRules";
            this._DataGridViewRules.RowHeadersVisible = false;
            this._DataGridViewRules.RowTemplate.Height = 32;
            this._DataGridViewRules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this._DataGridViewRules.ShowEditingIcon = false;
            this._DataGridViewRules.ShowRowErrors = false;
            this._DataGridViewRules.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewRules_CellClick);
            this._DataGridViewRules.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridViewRules_ColumnHeaderMouseClick);
            // 
            // Rule
            // 
            this.Rule.FalseValue = "0";
            resources.ApplyResources(this.Rule, "Rule");
            this.Rule.Name = "Rule";
            // 
            // _Button_Check_All
            // 
            resources.ApplyResources(this._Button_Check_All, "_Button_Check_All");
            this._Button_Check_All.Name = "_Button_Check_All";
            this._Button_Check_All.UseVisualStyleBackColor = true;
            this._Button_Check_All.Click += new System.EventHandler(this.Button_Check_All_Click);
            // 
            // _ButtonLifeCycle
            // 
            resources.ApplyResources(this._ButtonLifeCycle, "_ButtonLifeCycle");
            this._ButtonLifeCycle.Name = "_ButtonLifeCycle";
            this._ButtonLifeCycle.UseVisualStyleBackColor = true;
            this._ButtonLifeCycle.Click += new System.EventHandler(this.ButtonLifeCycle_Click);
            // 
            // _Button_SentBack
            // 
            resources.ApplyResources(this._Button_SentBack, "_Button_SentBack");
            this._Button_SentBack.Name = "_Button_SentBack";
            this._Button_SentBack.UseVisualStyleBackColor = true;
            this._Button_SentBack.Click += new System.EventHandler(this.ButtonSentBack_Click);
            // 
            // _Button_Service
            // 
            resources.ApplyResources(this._Button_Service, "_Button_Service");
            this._Button_Service.Name = "_Button_Service";
            this._Button_Service.UseVisualStyleBackColor = true;
            this._Button_Service.Click += new System.EventHandler(this.Button_Service_Click);
            // 
            // _DataGridView_Service
            // 
            this._DataGridView_Service.AllowUserToAddRows = false;
            this._DataGridView_Service.AllowUserToDeleteRows = false;
            this._DataGridView_Service.AllowUserToResizeRows = false;
            this._DataGridView_Service.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._DataGridView_Service.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this._DataGridView_Service, "_DataGridView_Service");
            this._DataGridView_Service.Name = "_DataGridView_Service";
            this._DataGridView_Service.ReadOnly = true;
            this._DataGridView_Service.RowHeadersVisible = false;
            this._DataGridView_Service.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this._DataGridView_Service.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_Service_CellClick);
            // 
            // Label_EPC_NR
            // 
            resources.ApplyResources(this.Label_EPC_NR, "Label_EPC_NR");
            this.Label_EPC_NR.Name = "Label_EPC_NR";
            // 
            // _TextBox_Service_Info
            // 
            resources.ApplyResources(this._TextBox_Service_Info, "_TextBox_Service_Info");
            this._TextBox_Service_Info.Name = "_TextBox_Service_Info";
            this._TextBox_Service_Info.Click += new System.EventHandler(this.TextBox_Service_Info_Click);
            // 
            // _ComboBox_Weeks
            // 
            resources.ApplyResources(this._ComboBox_Weeks, "_ComboBox_Weeks");
            this._ComboBox_Weeks.FormattingEnabled = true;
            this._ComboBox_Weeks.Name = "_ComboBox_Weeks";
            this._ComboBox_Weeks.SelectedIndexChanged += new System.EventHandler(this.ComboBox_Weeks_SelectedIndexChanged);
            // 
            // Label2
            // 
            resources.ApplyResources(this.Label2, "Label2");
            this.Label2.Name = "Label2";
            // 
            // _Button_Report
            // 
            resources.ApplyResources(this._Button_Report, "_Button_Report");
            this._Button_Report.Name = "_Button_Report";
            this._Button_Report.UseVisualStyleBackColor = true;
            this._Button_Report.Click += new System.EventHandler(this.Button_Report_Click);
            // 
            // CheckBox_UseFilter
            // 
            resources.ApplyResources(this.CheckBox_UseFilter, "CheckBox_UseFilter");
            this.CheckBox_UseFilter.Name = "CheckBox_UseFilter";
            this.CheckBox_UseFilter.UseVisualStyleBackColor = true;
            // 
            // _Button_Send_To_Service
            // 
            resources.ApplyResources(this._Button_Send_To_Service, "_Button_Send_To_Service");
            this._Button_Send_To_Service.Name = "_Button_Send_To_Service";
            this._Button_Send_To_Service.UseVisualStyleBackColor = true;
            this._Button_Send_To_Service.Click += new System.EventHandler(this.Button_Send_To_Service_Click);
            // 
            // _Button_RESET
            // 
            resources.ApplyResources(this._Button_RESET, "_Button_RESET");
            this._Button_RESET.Name = "_Button_RESET";
            this._Button_RESET.UseVisualStyleBackColor = true;
            this._Button_RESET.Click += new System.EventHandler(this.Button_RESET_Click);
            // 
            // Label_DataGrid_Green
            // 
            resources.ApplyResources(this.Label_DataGrid_Green, "Label_DataGrid_Green");
            this.Label_DataGrid_Green.Name = "Label_DataGrid_Green";
            // 
            // btnLogOut
            // 
            this.btnLogOut.ButtonType = UIControls.WinForms.Controls.BtnLogOutLabel.Logout;
            resources.ApplyResources(this.btnLogOut, "btnLogOut");
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.OnLogout += new UIControls.WinForms.Controls._OnLogout(this.btnLogOut_OnLogout);
            // 
            // FrmMain
            // 
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.Label_DataGrid_Green);
            this.Controls.Add(this._Button_RESET);
            this.Controls.Add(this._Button_Send_To_Service);
            this.Controls.Add(this.CheckBox_UseFilter);
            this.Controls.Add(this._Button_Report);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this._ComboBox_Weeks);
            this.Controls.Add(this._TextBox_Service_Info);
            this.Controls.Add(this.Label_EPC_NR);
            this.Controls.Add(this._Button_Service);
            this.Controls.Add(this._DataGridView_Service);
            this.Controls.Add(this.LabelPower);
            this.Controls.Add(this._TrackBarControl1);
            this.Controls.Add(this.TextBoxPower);
            this.Controls.Add(this.PowerStatus);
            this.Controls.Add(this._Button_SentBack);
            this.Controls.Add(this._ButtonLifeCycle);
            this.Controls.Add(this._Button_Check_All);
            this.Controls.Add(this._DataGridViewRules);
            this.Controls.Add(this.TextBox_InstrumentName);
            this.Controls.Add(this.StatusUpdate);
            this.Controls.Add(this.LabelInserted);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.TotalNumber);
            this.Controls.Add(this._Button_AcceptService);
            this.Controls.Add(this._ButtonReadInstrument);
            this.Controls.Add(this.TextBoxEPC);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._PictureBox_World)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._TrackBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._TrackBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._DataGridViewRules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._DataGridView_Service)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolStripMenuItem settingsToolStripMenuItem;
        private Label label3;
        private TextBox TextBoxEPC;
        internal ToolTip ToolTip1;
        private Button _ButtonReadInstrument;

        internal Button ButtonReadInstrument
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ButtonReadInstrument;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ButtonReadInstrument != null)
                {
                    _ButtonReadInstrument.Click -= ButtonReadInstrument_Click;
                }

                _ButtonReadInstrument = value;
                if (_ButtonReadInstrument != null)
                {
                    _ButtonReadInstrument.Click += ButtonReadInstrument_Click;
                }
            }
        }

        private Button _Button_AcceptService;

        internal Button Button_AcceptService
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button_AcceptService;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button_AcceptService != null)
                {
                    _Button_AcceptService.Click -= Button_AcceptService_Click;
                }

                _Button_AcceptService = value;
                if (_Button_AcceptService != null)
                {
                    _Button_AcceptService.Click += Button_AcceptService_Click;
                }
            }
        }

        internal Microsoft.VisualBasic.PowerPacks.ShapeContainer ShapeContainer1;
        internal Label TotalNumber;
        internal StatusStrip statusStrip1;
        internal Panel Panel1;
        private PictureBox _PictureBox1;

        internal PictureBox PictureBox1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PictureBox1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PictureBox1 != null)
                {
                    _PictureBox1.Click -= PictureBox1_Click;
                }

                _PictureBox1 = value;
                if (_PictureBox1 != null)
                {
                    _PictureBox1.Click += PictureBox1_Click;
                }
            }
        }

        private Label _TopTitle;

        internal Label TopTitle
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TopTitle;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TopTitle != null)
                {
                    _TopTitle.Click -= TopTitle_Click;
                }

                _TopTitle = value;
                if (_TopTitle != null)
                {
                    _TopTitle.Click += TopTitle_Click;
                }
            }
        }

        private Button _ButtonStatus;

        internal Button ButtonStatus
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ButtonStatus;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ButtonStatus != null)
                {
                    _ButtonStatus.Click -= ButtonStatus_Click;
                }

                _ButtonStatus = value;
                if (_ButtonStatus != null)
                {
                    _ButtonStatus.Click += ButtonStatus_Click;
                }
            }
        }

        private DevExpress.XtraEditors.TrackBarControl _TrackBarControl1;

        internal DevExpress.XtraEditors.TrackBarControl TrackBarControl1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TrackBarControl1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TrackBarControl1 != null)
                {
                    _TrackBarControl1.BeforeShowValueToolTip -= TrackBarControl1_BeforeShowValueToolTip;
                    _TrackBarControl1.ValueChanged -= TrackBarControl1_B;
                }

                _TrackBarControl1 = value;
                if (_TrackBarControl1 != null)
                {
                    _TrackBarControl1.BeforeShowValueToolTip += TrackBarControl1_BeforeShowValueToolTip;
                    _TrackBarControl1.ValueChanged += TrackBarControl1_B;
                }
            }
        }

        internal Label LabelPower;
        internal TextBox TextBoxPower;
        internal Label LabelInserted;
        internal Label PowerStatus;
        internal Label StatusUpdate;
        internal TextBox TextBox_InstrumentName;
        private DataGridView _DataGridViewRules;

        internal DataGridView DataGridViewRules
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DataGridViewRules;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DataGridViewRules != null)
                {
                    _DataGridViewRules.CellClick -= DataGridViewRules_CellClick;
                    _DataGridViewRules.ColumnHeaderMouseClick -= DataGridViewRules_ColumnHeaderMouseClick;
                }

                _DataGridViewRules = value;
                if (_DataGridViewRules != null)
                {
                    _DataGridViewRules.CellClick += DataGridViewRules_CellClick;
                    _DataGridViewRules.ColumnHeaderMouseClick += DataGridViewRules_ColumnHeaderMouseClick;
                }
            }
        }

        private Button _Button_Check_All;

        internal Button Button_Check_All
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button_Check_All;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button_Check_All != null)
                {
                    _Button_Check_All.Click -= Button_Check_All_Click;
                }

                _Button_Check_All = value;
                if (_Button_Check_All != null)
                {
                    _Button_Check_All.Click += Button_Check_All_Click;
                }
            }
        }

        private ToolStripStatusLabel tsslStatus1;
        private ToolStripStatusLabel tsslReadPause1;
        private Button _ButtonLifeCycle;

        internal Button ButtonLifeCycle
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ButtonLifeCycle;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ButtonLifeCycle != null)
                {
                    _ButtonLifeCycle.Click -= ButtonLifeCycle_Click;
                }

                _ButtonLifeCycle = value;
                if (_ButtonLifeCycle != null)
                {
                    _ButtonLifeCycle.Click += ButtonLifeCycle_Click;
                }
            }
        }

        private Button _Button_SentBack;

        internal Button Button_SentBack
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button_SentBack;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button_SentBack != null)
                {
                    _Button_SentBack.Click -= ButtonSentBack_Click;
                }

                _Button_SentBack = value;
                if (_Button_SentBack != null)
                {
                    _Button_SentBack.Click += ButtonSentBack_Click;
                }
            }
        }

        private PictureBox _PictureBox_World;

        internal PictureBox PictureBox_World
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PictureBox_World;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PictureBox_World != null)
                {
                    _PictureBox_World.Click -= PictureBox_World_Click;
                }

                _PictureBox_World = value;
                if (_PictureBox_World != null)
                {
                    _PictureBox_World.Click += PictureBox_World_Click;
                }
            }
        }

        internal Label Label1;
        private Button _Button_Service;

        internal Button Button_Service
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button_Service;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button_Service != null)
                {
                    _Button_Service.Click -= Button_Service_Click;
                }

                _Button_Service = value;
                if (_Button_Service != null)
                {
                    _Button_Service.Click += Button_Service_Click;
                }
            }
        }

        private DataGridView _DataGridView_Service;

        internal DataGridView DataGridView_Service
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DataGridView_Service;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DataGridView_Service != null)
                {
                    _DataGridView_Service.CellClick -= DataGridView_Service_CellClick;
                }

                _DataGridView_Service = value;
                if (_DataGridView_Service != null)
                {
                    _DataGridView_Service.CellClick += DataGridView_Service_CellClick;
                }
            }
        }

        internal Label Label_EPC_NR;
        private TextBox _TextBox_Service_Info;

        internal TextBox TextBox_Service_Info
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TextBox_Service_Info;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TextBox_Service_Info != null)
                {
                    _TextBox_Service_Info.Click -= TextBox_Service_Info_Click;
                }

                _TextBox_Service_Info = value;
                if (_TextBox_Service_Info != null)
                {
                    _TextBox_Service_Info.Click += TextBox_Service_Info_Click;
                }
            }
        }

        private ComboBox _ComboBox_Weeks;

        internal ComboBox ComboBox_Weeks
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ComboBox_Weeks;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ComboBox_Weeks != null)
                {
                    _ComboBox_Weeks.SelectedIndexChanged -= ComboBox_Weeks_SelectedIndexChanged;
                }

                _ComboBox_Weeks = value;
                if (_ComboBox_Weeks != null)
                {
                    _ComboBox_Weeks.SelectedIndexChanged += ComboBox_Weeks_SelectedIndexChanged;
                }
            }
        }

        internal Label Label2;
        private Button _Button_Report;

        internal Button Button_Report
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button_Report;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button_Report != null)
                {
                    _Button_Report.Click -= Button_Report_Click;
                }

                _Button_Report = value;
                if (_Button_Report != null)
                {
                    _Button_Report.Click += Button_Report_Click;
                }
            }
        }

        internal CheckBox CheckBox_UseFilter;
        internal DataGridViewCheckBoxColumn Rule;
        private Button _Button_Send_To_Service;

        internal Button Button_Send_To_Service
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button_Send_To_Service;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button_Send_To_Service != null)
                {
                    _Button_Send_To_Service.Click -= Button_Send_To_Service_Click;
                }

                _Button_Send_To_Service = value;
                if (_Button_Send_To_Service != null)
                {
                    _Button_Send_To_Service.Click += Button_Send_To_Service_Click;
                }
            }
        }

        private Button _Button_RESET;

        internal Button Button_RESET
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button_RESET;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button_RESET != null)
                {
                    _Button_RESET.Click -= Button_RESET_Click;
                }

                _Button_RESET = value;
                if (_Button_RESET != null)
                {
                    _Button_RESET.Click += Button_RESET_Click;
                }
            }
        }

        internal Label Label_DataGrid_Green;
        private UIControls.WinForms.Controls.ReaderPowerBar readerPowerBar;
        private UIControls.WinForms.Controls.BtnLogOut btnLogOut;
    }
}