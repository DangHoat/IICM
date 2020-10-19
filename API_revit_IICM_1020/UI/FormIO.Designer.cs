namespace API_revit_IICM_1020.UI
{
    partial class FormIO
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
            if (disposing && (components != null))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormIO));
            this.btnCancel1 = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listParameter = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnUpdate = new System.Windows.Forms.Button();
            this.comboBoxParam = new System.Windows.Forms.ComboBox();
            this.textBoxParam = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancel1
            // 
            this.btnCancel1.Location = new System.Drawing.Point(378, 393);
            this.btnCancel1.Name = "btnCancel1";
            this.btnCancel1.Size = new System.Drawing.Size(75, 23);
            this.btnCancel1.TabIndex = 1;
            this.btnCancel1.Text = "Cancel";
            this.btnCancel1.UseVisualStyleBackColor = true;
            this.btnCancel1.Click += new System.EventHandler(this.btnCancel1_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(536, 393);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Parameter";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(375, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Value";
            // 
            // listParameter
            // 
            this.listParameter.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.listParameter.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listParameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listParameter.ForeColor = System.Drawing.SystemColors.MenuText;
            this.listParameter.HideSelection = false;
            this.listParameter.Location = new System.Drawing.Point(40, 94);
            this.listParameter.Name = "listParameter";
            this.listParameter.Size = new System.Drawing.Size(571, 283);
            this.listParameter.TabIndex = 7;
            this.listParameter.UseCompatibleStateImageBehavior = false;
            this.listParameter.View = System.Windows.Forms.View.Details;
            this.listParameter.SelectedIndexChanged += new System.EventHandler(this.listParameter_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Parameter";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 409;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(459, 393);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // comboBoxParam
            // 
            this.comboBoxParam.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboBoxParam.DropDownWidth = 100;
            this.comboBoxParam.Enabled = false;
            this.comboBoxParam.FormattingEnabled = true;
            this.comboBoxParam.Location = new System.Drawing.Point(40, 56);
            this.comboBoxParam.Name = "comboBoxParam";
            this.comboBoxParam.Size = new System.Drawing.Size(233, 21);
            this.comboBoxParam.TabIndex = 9;
            // 
            // textBoxParam
            // 
            this.textBoxParam.Location = new System.Drawing.Point(378, 57);
            this.textBoxParam.Name = "textBoxParam";
            this.textBoxParam.Size = new System.Drawing.Size(233, 20);
            this.textBoxParam.TabIndex = 10;
            this.textBoxParam.TextChanged += new System.EventHandler(this.textBoxParam_TextChanged);
            // 
            // FormIO
            // 
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(654, 458);
            this.Controls.Add(this.textBoxParam);
            this.Controls.Add(this.comboBoxParam);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.listParameter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormIO";
            this.Text = "IICM";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabControl tabView;
        private System.Windows.Forms.TabPage tabParam;
        private System.Windows.Forms.TabPage tabImport;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader param;
        private System.Windows.Forms.ColumnHeader valueParam;
        private System.Windows.Forms.GroupBox preview;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button choseFile;
        private System.Windows.Forms.ListView listParam;
        private System.Windows.Forms.Button btnCancel1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listParameter;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ComboBox comboBoxParam;
        private System.Windows.Forms.TextBox textBoxParam;
    }
}