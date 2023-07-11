using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Service_Station
{
    [DesignerGenerated()]
    public partial class Form_CompanyDepartmentID : Form
    {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is object)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _ComboBoxDepartment = new ComboBox();
            _ComboBoxDepartment.SelectedIndexChanged += new EventHandler(ComboBoxDepartment_SelectedIndexChanged);
            Label1 = new Label();
            _ButtonExit = new Button();
            _ButtonExit.Click += new EventHandler(ButtonExit_Click);
            LabelDepartment = new Label();
            ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            RectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            LabelCompanyID = new Label();
            LabelDepartmentID = new Label();
            _ButtonCancel = new Button();
            _ButtonCancel.Click += new EventHandler(ButtonCancel_Click);
            SuspendLayout();
            // 
            // ComboBoxDepartment
            // 
            _ComboBoxDepartment.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _ComboBoxDepartment.FormattingEnabled = true;
            _ComboBoxDepartment.Location = new Point(192, 119);
            _ComboBoxDepartment.Name = "_ComboBoxDepartment";
            _ComboBoxDepartment.Size = new Size(400, 28);
            _ComboBoxDepartment.TabIndex = 1;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Font = new Font("Microsoft Sans Serif", 18.0f, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            Label1.Location = new Point(189, 29);
            Label1.Name = "Label1";
            Label1.Size = new Size(298, 29);
            Label1.TabIndex = 2;
            Label1.Text = "Choose The Department";
            // 
            // ButtonExit
            // 
            _ButtonExit.Location = new Point(589, 194);
            _ButtonExit.Name = "_ButtonExit";
            _ButtonExit.Size = new Size(75, 23);
            _ButtonExit.TabIndex = 3;
            _ButtonExit.Text = "Exit";
            _ButtonExit.UseVisualStyleBackColor = true;
            // 
            // LabelDepartment
            // 
            LabelDepartment.AutoSize = true;
            LabelDepartment.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            LabelDepartment.Location = new Point(72, 122);
            LabelDepartment.Name = "LabelDepartment";
            LabelDepartment.Size = new Size(114, 20);
            LabelDepartment.TabIndex = 5;
            LabelDepartment.Text = "Department :";
            // 
            // ShapeContainer1
            // 
            ShapeContainer1.Location = new Point(0, 0);
            ShapeContainer1.Margin = new Padding(0);
            ShapeContainer1.Name = "ShapeContainer1";
            ShapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] { RectangleShape1 });
            ShapeContainer1.Size = new Size(676, 232);
            ShapeContainer1.TabIndex = 6;
            ShapeContainer1.TabStop = false;
            // 
            // RectangleShape1
            // 
            RectangleShape1.Location = new Point(34, 92);
            RectangleShape1.Name = "RectangleShape1";
            RectangleShape1.Size = new Size(603, 77);
            // 
            // LabelCompanyID
            // 
            LabelCompanyID.AutoSize = true;
            LabelCompanyID.Location = new Point(30, 20);
            LabelCompanyID.Name = "LabelCompanyID";
            LabelCompanyID.Size = new Size(40, 13);
            LabelCompanyID.TabIndex = 9;
            LabelCompanyID.Text = "LabelC";
            LabelCompanyID.Visible = false;
            // 
            // LabelDepartmentID
            // 
            LabelDepartmentID.AutoSize = true;
            LabelDepartmentID.Location = new Point(29, 41);
            LabelDepartmentID.Name = "LabelDepartmentID";
            LabelDepartmentID.Size = new Size(41, 13);
            LabelDepartmentID.TabIndex = 10;
            LabelDepartmentID.Text = "LabelD";
            LabelDepartmentID.Visible = false;
            // 
            // ButtonCancel
            // 
            _ButtonCancel.Location = new Point(21, 194);
            _ButtonCancel.Name = "_ButtonCancel";
            _ButtonCancel.Size = new Size(75, 23);
            _ButtonCancel.TabIndex = 11;
            _ButtonCancel.Text = "Cancel";
            _ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // FrmCompanyDepartmentID
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(676, 232);
            ControlBox = false;
            Controls.Add(_ButtonCancel);
            Controls.Add(LabelDepartmentID);
            Controls.Add(LabelCompanyID);
            Controls.Add(LabelDepartment);
            Controls.Add(_ButtonExit);
            Controls.Add(Label1);
            Controls.Add(_ComboBoxDepartment);
            Controls.Add(ShapeContainer1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmCompanyDepartmentID";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Load += new EventHandler(FrmCompanyDepartmentID_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        private ComboBox _ComboBoxDepartment;

        internal ComboBox ComboBoxDepartment
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ComboBoxDepartment;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ComboBoxDepartment != null)
                {
                    _ComboBoxDepartment.SelectedIndexChanged -= ComboBoxDepartment_SelectedIndexChanged;
                }

                _ComboBoxDepartment = value;
                if (_ComboBoxDepartment != null)
                {
                    _ComboBoxDepartment.SelectedIndexChanged += ComboBoxDepartment_SelectedIndexChanged;
                }
            }
        }

        internal Label Label1;
        private Button _ButtonExit;

        internal Button ButtonExit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ButtonExit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ButtonExit != null)
                {
                    _ButtonExit.Click -= ButtonExit_Click;
                }

                _ButtonExit = value;
                if (_ButtonExit != null)
                {
                    _ButtonExit.Click += ButtonExit_Click;
                }
            }
        }

        internal Label LabelDepartment;
        internal Microsoft.VisualBasic.PowerPacks.ShapeContainer ShapeContainer1;
        internal Microsoft.VisualBasic.PowerPacks.RectangleShape RectangleShape1;
        internal Label LabelCompanyID;
        internal Label LabelDepartmentID;
        private Button _ButtonCancel;

        internal Button ButtonCancel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ButtonCancel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ButtonCancel != null)
                {
                    _ButtonCancel.Click -= ButtonCancel_Click;
                }

                _ButtonCancel = value;
                if (_ButtonCancel != null)
                {
                    _ButtonCancel.Click += ButtonCancel_Click;
                }
            }
        }
    }
}