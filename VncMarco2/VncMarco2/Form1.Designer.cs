namespace VncMarco2
{
    partial class VpnMacro
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
            this.Ok = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_id = new System.Windows.Forms.TextBox();
            this.textBox_pw = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_mainTarget = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_subTarget = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox_ipchnage = new System.Windows.Forms.ComboBox();
            this.textBox_log = new System.Windows.Forms.TextBox();
            this.listView_Main = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox_unitWaitTime = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBox_isUseTunnerBear = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Ok
            // 
            this.Ok.Location = new System.Drawing.Point(126, 311);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(174, 54);
            this.Ok.TabIndex = 7;
            this.Ok.Text = "시작";
            this.Ok.UseVisualStyleBackColor = true;
            this.Ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "네이버 ID : ";
            // 
            // textBox_id
            // 
            this.textBox_id.Location = new System.Drawing.Point(113, 22);
            this.textBox_id.Name = "textBox_id";
            this.textBox_id.Size = new System.Drawing.Size(187, 21);
            this.textBox_id.TabIndex = 0;
            // 
            // textBox_pw
            // 
            this.textBox_pw.Location = new System.Drawing.Point(113, 51);
            this.textBox_pw.Name = "textBox_pw";
            this.textBox_pw.Size = new System.Drawing.Size(187, 21);
            this.textBox_pw.TabIndex = 1;
            this.textBox_pw.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "네이버 PW : ";
            // 
            // textBox_mainTarget
            // 
            this.textBox_mainTarget.Location = new System.Drawing.Point(112, 79);
            this.textBox_mainTarget.Name = "textBox_mainTarget";
            this.textBox_mainTarget.Size = new System.Drawing.Size(188, 21);
            this.textBox_mainTarget.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "메인 검색어 : ";
            // 
            // textBox_subTarget
            // 
            this.textBox_subTarget.Location = new System.Drawing.Point(112, 108);
            this.textBox_subTarget.Name = "textBox_subTarget";
            this.textBox_subTarget.Size = new System.Drawing.Size(188, 21);
            this.textBox_subTarget.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "연관 검색어 : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "Browser  : ";
            this.label8.Visible = false;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(117, 56);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(68, 16);
            this.radioButton1.TabIndex = 15;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Chrome";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Visible = false;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Enabled = false;
            this.radioButton2.Location = new System.Drawing.Point(201, 56);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(61, 16);
            this.radioButton2.TabIndex = 16;
            this.radioButton2.Text = "Firefox";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.Visible = false;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 12);
            this.label10.TabIndex = 19;
            this.label10.Text = "IP 변경방법 :";
            this.label10.Visible = false;
            // 
            // comboBox_ipchnage
            // 
            this.comboBox_ipchnage.FormattingEnabled = true;
            this.comboBox_ipchnage.Items.AddRange(new object[] {
            "TunnerBear",
            "ProxyServer"});
            this.comboBox_ipchnage.Location = new System.Drawing.Point(-34, 12);
            this.comboBox_ipchnage.Name = "comboBox_ipchnage";
            this.comboBox_ipchnage.Size = new System.Drawing.Size(219, 20);
            this.comboBox_ipchnage.TabIndex = 20;
            this.comboBox_ipchnage.Visible = false;
            // 
            // textBox_log
            // 
            this.textBox_log.Location = new System.Drawing.Point(322, 311);
            this.textBox_log.Multiline = true;
            this.textBox_log.Name = "textBox_log";
            this.textBox_log.Size = new System.Drawing.Size(606, 165);
            this.textBox_log.TabIndex = 9;
            // 
            // listView_Main
            // 
            this.listView_Main.HideSelection = false;
            this.listView_Main.Location = new System.Drawing.Point(322, 22);
            this.listView_Main.Name = "listView_Main";
            this.listView_Main.Size = new System.Drawing.Size(606, 223);
            this.listView_Main.TabIndex = 6;
            this.listView_Main.UseCompatibleStateImageBehavior = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(126, 192);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 53);
            this.button1.TabIndex = 5;
            this.button1.Text = "추가";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_unitWaitTime
            // 
            this.textBox_unitWaitTime.Location = new System.Drawing.Point(112, 136);
            this.textBox_unitWaitTime.Name = "textBox_unitWaitTime";
            this.textBox_unitWaitTime.Size = new System.Drawing.Size(57, 21);
            this.textBox_unitWaitTime.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 33;
            this.label5.Text = "검색후 대기 :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(172, 141);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 12);
            this.label9.TabIndex = 34;
            this.label9.Text = "(초)";
            // 
            // checkBox_isUseTunnerBear
            // 
            this.checkBox_isUseTunnerBear.AutoSize = true;
            this.checkBox_isUseTunnerBear.Location = new System.Drawing.Point(128, 371);
            this.checkBox_isUseTunnerBear.Name = "checkBox_isUseTunnerBear";
            this.checkBox_isUseTunnerBear.Size = new System.Drawing.Size(100, 16);
            this.checkBox_isUseTunnerBear.TabIndex = 8;
            this.checkBox_isUseTunnerBear.Text = "튜너베어 사용";
            this.checkBox_isUseTunnerBear.UseVisualStyleBackColor = true;
            // 
            // VpnMacro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 493);
            this.Controls.Add(this.checkBox_isUseTunnerBear);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox_unitWaitTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView_Main);
            this.Controls.Add(this.textBox_log);
            this.Controls.Add(this.comboBox_ipchnage);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_subTarget);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_mainTarget);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_pw);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_id);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Ok);
            this.Name = "VpnMacro";
            this.Text = "VpnMacro";
            this.Load += new System.EventHandler(this.VpnMacro_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Ok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_id;
        private System.Windows.Forms.TextBox textBox_pw;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_mainTarget;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_subTarget;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox_ipchnage;
        private System.Windows.Forms.TextBox textBox_log;
        private System.Windows.Forms.ListView listView_Main;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_unitWaitTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBox_isUseTunnerBear;
    }
}

