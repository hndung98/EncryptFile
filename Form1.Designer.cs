namespace EncryptFile
{
    partial class Form1
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
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMaHoa = new System.Windows.Forms.Label();
            this.btnLink = new System.Windows.Forms.Button();
            this.pnlA = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.pnlMD5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxOutput = new System.Windows.Forms.TextBox();
            this.tbxInput = new System.Windows.Forms.TextBox();
            this.btnCryp = new System.Windows.Forms.Button();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mD5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlDES = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.btnDecryptDES = new System.Windows.Forms.Button();
            this.btnEncryptDES = new System.Windows.Forms.Button();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnLinkDES = new System.Windows.Forms.Button();
            this.tbxFilePath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ofdDES = new System.Windows.Forms.OpenFileDialog();
            this.pnlA.SuspendLayout();
            this.pnlMD5.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.pnlDES.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(113, 24);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(277, 20);
            this.txtFilePath.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(55, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chọn File";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMaHoa
            // 
            this.lblMaHoa.Location = new System.Drawing.Point(50, 69);
            this.lblMaHoa.Name = "lblMaHoa";
            this.lblMaHoa.Size = new System.Drawing.Size(57, 27);
            this.lblMaHoa.TabIndex = 2;
            this.lblMaHoa.Text = "Mật Khẩu";
            this.lblMaHoa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLink
            // 
            this.btnLink.Location = new System.Drawing.Point(396, 24);
            this.btnLink.Name = "btnLink";
            this.btnLink.Size = new System.Drawing.Size(41, 20);
            this.btnLink.TabIndex = 3;
            this.btnLink.Text = "...";
            this.btnLink.UseVisualStyleBackColor = true;
            this.btnLink.Click += new System.EventHandler(this.BtnLink_Click);
            // 
            // pnlA
            // 
            this.pnlA.Controls.Add(this.label8);
            this.pnlA.Controls.Add(this.btnDecrypt);
            this.pnlA.Controls.Add(this.btnEncrypt);
            this.pnlA.Controls.Add(this.txtPassword);
            this.pnlA.Controls.Add(this.lblMaHoa);
            this.pnlA.Controls.Add(this.btnLink);
            this.pnlA.Controls.Add(this.txtFilePath);
            this.pnlA.Controls.Add(this.label1);
            this.pnlA.Location = new System.Drawing.Point(21, 51);
            this.pnlA.Name = "pnlA";
            this.pnlA.Size = new System.Drawing.Size(454, 164);
            this.pnlA.TabIndex = 4;
            this.pnlA.Visible = false;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(-3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 24);
            this.label8.TabIndex = 10;
            this.label8.Text = "Normal";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(255, 115);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(108, 24);
            this.btnDecrypt.TabIndex = 6;
            this.btnDecrypt.Text = "Giãi Mã";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.BtnDecrypt_Click);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(113, 115);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(108, 24);
            this.btnEncrypt.TabIndex = 5;
            this.btnEncrypt.Text = "Mã Hoá";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.BtnMaHoa_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(113, 73);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(88, 20);
            this.txtPassword.TabIndex = 4;
            // 
            // pnlMD5
            // 
            this.pnlMD5.Controls.Add(this.label2);
            this.pnlMD5.Controls.Add(this.label4);
            this.pnlMD5.Controls.Add(this.label3);
            this.pnlMD5.Controls.Add(this.tbxOutput);
            this.pnlMD5.Controls.Add(this.tbxInput);
            this.pnlMD5.Controls.Add(this.btnCryp);
            this.pnlMD5.Location = new System.Drawing.Point(218, 226);
            this.pnlMD5.Name = "pnlMD5";
            this.pnlMD5.Size = new System.Drawing.Size(454, 164);
            this.pnlMD5.TabIndex = 4;
            this.pnlMD5.Visible = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(-3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "MD5";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(50, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 27);
            this.label4.TabIndex = 11;
            this.label4.Text = "Output";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(50, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 27);
            this.label3.TabIndex = 10;
            this.label3.Text = "Input";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.Label3_Click);
            // 
            // tbxOutput
            // 
            this.tbxOutput.Location = new System.Drawing.Point(110, 73);
            this.tbxOutput.Name = "tbxOutput";
            this.tbxOutput.Size = new System.Drawing.Size(277, 20);
            this.tbxOutput.TabIndex = 9;
            // 
            // tbxInput
            // 
            this.tbxInput.Location = new System.Drawing.Point(110, 24);
            this.tbxInput.Name = "tbxInput";
            this.tbxInput.Size = new System.Drawing.Size(277, 20);
            this.tbxInput.TabIndex = 7;
            // 
            // btnCryp
            // 
            this.btnCryp.Location = new System.Drawing.Point(193, 115);
            this.btnCryp.Name = "btnCryp";
            this.btnCryp.Size = new System.Drawing.Size(97, 22);
            this.btnCryp.TabIndex = 5;
            this.btnCryp.Text = "Hash";
            this.btnCryp.UseVisualStyleBackColor = true;
            this.btnCryp.Click += new System.EventHandler(this.BtnCryp_Click);
            // 
            // ofd
            // 
            this.ofd.FileName = "ofd";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuToolStripMenuItem,
            this.ExitToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(920, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuToolStripMenuItem
            // 
            this.MenuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.normalToolStripMenuItem,
            this.DESToolStripMenuItem,
            this.mD5ToolStripMenuItem});
            this.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem";
            this.MenuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.MenuToolStripMenuItem.Text = "Menu";
            // 
            // normalToolStripMenuItem
            // 
            this.normalToolStripMenuItem.Name = "normalToolStripMenuItem";
            this.normalToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.normalToolStripMenuItem.Text = "Normal";
            this.normalToolStripMenuItem.Click += new System.EventHandler(this.NormalToolStripMenuItem_Click);
            // 
            // DESToolStripMenuItem
            // 
            this.DESToolStripMenuItem.Name = "DESToolStripMenuItem";
            this.DESToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.DESToolStripMenuItem.Text = "DES";
            this.DESToolStripMenuItem.Click += new System.EventHandler(this.DESToolStripMenuItem_Click);
            // 
            // mD5ToolStripMenuItem
            // 
            this.mD5ToolStripMenuItem.Name = "mD5ToolStripMenuItem";
            this.mD5ToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.mD5ToolStripMenuItem.Text = "MD5";
            this.mD5ToolStripMenuItem.Click += new System.EventHandler(this.MD5ToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(12, 20);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(38, 20);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.ExitToolStripMenuItem1_Click);
            // 
            // pnlDES
            // 
            this.pnlDES.Controls.Add(this.label7);
            this.pnlDES.Controls.Add(this.btnDecryptDES);
            this.pnlDES.Controls.Add(this.btnEncryptDES);
            this.pnlDES.Controls.Add(this.tbxPassword);
            this.pnlDES.Controls.Add(this.label5);
            this.pnlDES.Controls.Add(this.btnLinkDES);
            this.pnlDES.Controls.Add(this.tbxFilePath);
            this.pnlDES.Controls.Add(this.label6);
            this.pnlDES.Location = new System.Drawing.Point(274, 27);
            this.pnlDES.Name = "pnlDES";
            this.pnlDES.Size = new System.Drawing.Size(454, 164);
            this.pnlDES.TabIndex = 4;
            this.pnlDES.Visible = false;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(-3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 24);
            this.label7.TabIndex = 9;
            this.label7.Text = "DES";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label7.Click += new System.EventHandler(this.Label7_Click);
            // 
            // btnDecryptDES
            // 
            this.btnDecryptDES.Location = new System.Drawing.Point(255, 115);
            this.btnDecryptDES.Name = "btnDecryptDES";
            this.btnDecryptDES.Size = new System.Drawing.Size(108, 24);
            this.btnDecryptDES.TabIndex = 6;
            this.btnDecryptDES.Text = "Giãi Mã";
            this.btnDecryptDES.UseVisualStyleBackColor = true;
            this.btnDecryptDES.Click += new System.EventHandler(this.BtnDecryptDES_Click);
            // 
            // btnEncryptDES
            // 
            this.btnEncryptDES.Location = new System.Drawing.Point(113, 115);
            this.btnEncryptDES.Name = "btnEncryptDES";
            this.btnEncryptDES.Size = new System.Drawing.Size(108, 24);
            this.btnEncryptDES.TabIndex = 5;
            this.btnEncryptDES.Text = "Mã Hoá";
            this.btnEncryptDES.UseVisualStyleBackColor = true;
            this.btnEncryptDES.Click += new System.EventHandler(this.BtnEncryptDES_Click);
            // 
            // tbxPassword
            // 
            this.tbxPassword.Location = new System.Drawing.Point(113, 73);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.Size = new System.Drawing.Size(88, 20);
            this.tbxPassword.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(50, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 27);
            this.label5.TabIndex = 2;
            this.label5.Text = "Mật Khẩu";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLinkDES
            // 
            this.btnLinkDES.Location = new System.Drawing.Point(396, 24);
            this.btnLinkDES.Name = "btnLinkDES";
            this.btnLinkDES.Size = new System.Drawing.Size(41, 20);
            this.btnLinkDES.TabIndex = 3;
            this.btnLinkDES.Text = "...";
            this.btnLinkDES.UseVisualStyleBackColor = true;
            this.btnLinkDES.Click += new System.EventHandler(this.BtnLinkDES_Click);
            // 
            // tbxFilePath
            // 
            this.tbxFilePath.Location = new System.Drawing.Point(113, 24);
            this.tbxFilePath.Name = "tbxFilePath";
            this.tbxFilePath.Size = new System.Drawing.Size(277, 20);
            this.tbxFilePath.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(55, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Chọn File";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ofdDES
            // 
            this.ofdDES.FileName = "ofdDES";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 544);
            this.Controls.Add(this.pnlDES);
            this.Controls.Add(this.pnlMD5);
            this.Controls.Add(this.pnlA);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.pnlA.ResumeLayout(false);
            this.pnlA.PerformLayout();
            this.pnlMD5.ResumeLayout(false);
            this.pnlMD5.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlDES.ResumeLayout(false);
            this.pnlDES.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMaHoa;
        private System.Windows.Forms.Button btnLink;
        private System.Windows.Forms.Panel pnlA;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Button btnCryp;
        private System.Windows.Forms.TextBox tbxInput;
        private System.Windows.Forms.TextBox tbxOutput;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.Panel pnlMD5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem mD5ToolStripMenuItem;
        private System.Windows.Forms.Panel pnlDES;
        private System.Windows.Forms.Button btnDecryptDES;
        private System.Windows.Forms.Button btnEncryptDES;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnLinkDES;
        private System.Windows.Forms.TextBox tbxFilePath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.OpenFileDialog ofdDES;
    }
}

