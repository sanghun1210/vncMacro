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
            this.textBox_waitTime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox_ipchnage = new System.Windows.Forms.ComboBox();
            this.textBox_log = new System.Windows.Forms.TextBox();
            this.Stop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Ok
            // 
            this.Ok.Location = new System.Drawing.Point(86, 260);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(94, 34);
            this.Ok.TabIndex = 0;
            this.Ok.Text = "시작";
            this.Ok.UseVisualStyleBackColor = true;
            this.Ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "네이버 ID : ";
            // 
            // textBox_id
            // 
            this.textBox_id.Location = new System.Drawing.Point(115, 86);
            this.textBox_id.Name = "textBox_id";
            this.textBox_id.Size = new System.Drawing.Size(220, 21);
            this.textBox_id.TabIndex = 2;
            // 
            // textBox_pw
            // 
            this.textBox_pw.Location = new System.Drawing.Point(115, 117);
            this.textBox_pw.Name = "textBox_pw";
            this.textBox_pw.Size = new System.Drawing.Size(220, 21);
            this.textBox_pw.TabIndex = 4;
            this.textBox_pw.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "네이버 PW : ";
            // 
            // textBox_mainTarget
            // 
            this.textBox_mainTarget.Location = new System.Drawing.Point(115, 150);
            this.textBox_mainTarget.Name = "textBox_mainTarget";
            this.textBox_mainTarget.Size = new System.Drawing.Size(220, 21);
            this.textBox_mainTarget.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "메인검색어 : ";
            // 
            // textBox_subTarget
            // 
            this.textBox_subTarget.Location = new System.Drawing.Point(115, 183);
            this.textBox_subTarget.Name = "textBox_subTarget";
            this.textBox_subTarget.Size = new System.Drawing.Size(220, 21);
            this.textBox_subTarget.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "연관검색어 : ";
            // 
            // textBox_waitTime
            // 
            this.textBox_waitTime.Location = new System.Drawing.Point(115, 216);
            this.textBox_waitTime.Name = "textBox_waitTime";
            this.textBox_waitTime.Size = new System.Drawing.Size(73, 21);
            this.textBox_waitTime.TabIndex = 12;
            this.textBox_waitTime.Text = "40";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 219);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "대기시간 : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(190, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "(분)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "Browser  : ";
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
            // 
            // comboBox_ipchnage
            // 
            this.comboBox_ipchnage.FormattingEnabled = true;
            this.comboBox_ipchnage.Items.AddRange(new object[] {
            "TunnerBear",
            "ProxyServer"});
            this.comboBox_ipchnage.Location = new System.Drawing.Point(116, 22);
            this.comboBox_ipchnage.Name = "comboBox_ipchnage";
            this.comboBox_ipchnage.Size = new System.Drawing.Size(219, 20);
            this.comboBox_ipchnage.TabIndex = 20;
            // 
            // textBox_log
            // 
            this.textBox_log.Location = new System.Drawing.Point(354, 22);
            this.textBox_log.Multiline = true;
            this.textBox_log.Name = "textBox_log";
            this.textBox_log.Size = new System.Drawing.Size(390, 272);
            this.textBox_log.TabIndex = 21;
            // 
            // Stop
            // 
            this.Stop.Location = new System.Drawing.Point(187, 260);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(94, 34);
            this.Stop.TabIndex = 22;
            this.Stop.Text = "중지";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // VpnMacro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 311);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.textBox_log);
            this.Controls.Add(this.comboBox_ipchnage);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_waitTime);
            this.Controls.Add(this.label6);
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
        private System.Windows.Forms.TextBox textBox_waitTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox_ipchnage;
        private System.Windows.Forms.TextBox textBox_log;
        private System.Windows.Forms.Button Stop;
    }
}

