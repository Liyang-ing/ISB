namespace Helo
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaxId = new System.Windows.Forms.TextBox();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.txtRead = new System.Windows.Forms.RichTextBox();
            this.btnInit = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtRightNumber = new System.Windows.Forms.TextBox();
            this.txtCatched = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblResult1 = new System.Windows.Forms.Label();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.btnSendBack = new System.Windows.Forms.Button();
            this.progressBar3 = new System.Windows.Forms.ProgressBar();
            this.lblResult2 = new System.Windows.Forms.Label();
            this.lblResult3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCom = new System.Windows.Forms.TextBox();
            this.txtOpe = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(425, 261);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(111, 45);
            this.btnGo.TabIndex = 0;
            this.btnGo.Text = "開始查詢";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(136, 303);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.ReadOnly = true;
            this.txtNumber.Size = new System.Drawing.Size(238, 22);
            this.txtNumber.TabIndex = 1;
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(136, 348);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(238, 22);
            this.txtResult.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 313);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "資料庫抓取的號碼：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 358);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "查詢後結果：";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(136, 254);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(100, 22);
            this.txtId.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 257);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "目前id：";
            // 
            // txtMaxId
            // 
            this.txtMaxId.Location = new System.Drawing.Point(0, 3);
            this.txtMaxId.Name = "txtMaxId";
            this.txtMaxId.Size = new System.Drawing.Size(10, 22);
            this.txtMaxId.TabIndex = 8;
            this.txtMaxId.Visible = false;
            // 
            // serialPort
            // 
            this.serialPort.BaudRate = 115200;
            this.serialPort.PortName = "COM3";
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPortRead_DataReceived);
            // 
            // txtRead
            // 
            this.txtRead.Location = new System.Drawing.Point(26, 112);
            this.txtRead.Name = "txtRead";
            this.txtRead.Size = new System.Drawing.Size(348, 131);
            this.txtRead.TabIndex = 9;
            this.txtRead.Text = "";
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(263, 44);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(111, 45);
            this.btnInit.TabIndex = 10;
            this.btnInit.Text = "開啟連線";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(425, 147);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(111, 45);
            this.btnSend.TabIndex = 11;
            this.btnSend.Text = "加入資料庫";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtRightNumber
            // 
            this.txtRightNumber.Location = new System.Drawing.Point(26, 3);
            this.txtRightNumber.Name = "txtRightNumber";
            this.txtRightNumber.Size = new System.Drawing.Size(10, 22);
            this.txtRightNumber.TabIndex = 14;
            this.txtRightNumber.Visible = false;
            // 
            // txtCatched
            // 
            this.txtCatched.Location = new System.Drawing.Point(12, 3);
            this.txtCatched.Name = "txtCatched";
            this.txtCatched.Size = new System.Drawing.Size(10, 22);
            this.txtCatched.TabIndex = 13;
            this.txtCatched.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(560, 156);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(142, 30);
            this.progressBar1.TabIndex = 15;
            // 
            // lblResult1
            // 
            this.lblResult1.AutoSize = true;
            this.lblResult1.Location = new System.Drawing.Point(731, 180);
            this.lblResult1.Name = "lblResult1";
            this.lblResult1.Size = new System.Drawing.Size(0, 12);
            this.lblResult1.TabIndex = 16;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(560, 266);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(142, 30);
            this.progressBar2.TabIndex = 17;
            // 
            // btnSendBack
            // 
            this.btnSendBack.Location = new System.Drawing.Point(425, 375);
            this.btnSendBack.Name = "btnSendBack";
            this.btnSendBack.Size = new System.Drawing.Size(111, 45);
            this.btnSendBack.TabIndex = 18;
            this.btnSendBack.Text = "傳回資料";
            this.btnSendBack.UseVisualStyleBackColor = true;
            this.btnSendBack.Click += new System.EventHandler(this.btnSendBack_Click);
            // 
            // progressBar3
            // 
            this.progressBar3.Location = new System.Drawing.Point(560, 391);
            this.progressBar3.Name = "progressBar3";
            this.progressBar3.Size = new System.Drawing.Size(142, 30);
            this.progressBar3.TabIndex = 19;
            // 
            // lblResult2
            // 
            this.lblResult2.AutoSize = true;
            this.lblResult2.Location = new System.Drawing.Point(731, 290);
            this.lblResult2.Name = "lblResult2";
            this.lblResult2.Size = new System.Drawing.Size(0, 12);
            this.lblResult2.TabIndex = 20;
            // 
            // lblResult3
            // 
            this.lblResult3.AutoSize = true;
            this.lblResult3.Location = new System.Drawing.Point(731, 391);
            this.lblResult3.Name = "lblResult3";
            this.lblResult3.Size = new System.Drawing.Size(0, 12);
            this.lblResult3.TabIndex = 21;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(103, 57);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 23;
            this.label5.Text = "使用連線：";
            // 
            // txtCom
            // 
            this.txtCom.Location = new System.Drawing.Point(38, 3);
            this.txtCom.Name = "txtCom";
            this.txtCom.Size = new System.Drawing.Size(10, 22);
            this.txtCom.TabIndex = 24;
            this.txtCom.Visible = false;
            // 
            // txtOpe
            // 
            this.txtOpe.Location = new System.Drawing.Point(54, 3);
            this.txtOpe.Name = "txtOpe";
            this.txtOpe.Size = new System.Drawing.Size(10, 22);
            this.txtOpe.TabIndex = 29;
            this.txtOpe.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Helo.Properties.Resources._1323051487_1715957599;
            this.pictureBox1.Location = new System.Drawing.Point(427, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 51);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(502, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 31;
            this.label6.Text = "重新整理";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(425, 313);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(251, 12);
            this.label7.TabIndex = 27;
            this.label7.Text = "P.S.若有新資料加入，請資料庫加入完再點選。";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 515);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtOpe);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCom);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lblResult3);
            this.Controls.Add(this.lblResult2);
            this.Controls.Add(this.progressBar3);
            this.Controls.Add(this.btnSendBack);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.lblResult1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.txtRightNumber);
            this.Controls.Add(this.txtCatched);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnInit);
            this.Controls.Add(this.txtRead);
            this.Controls.Add(this.txtMaxId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.btnGo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "網內外辨識";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMaxId;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.RichTextBox txtRead;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtRightNumber;
        private System.Windows.Forms.TextBox txtCatched;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblResult1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Button btnSendBack;
        private System.Windows.Forms.ProgressBar progressBar3;
        private System.Windows.Forms.Label lblResult2;
        private System.Windows.Forms.Label lblResult3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCom;
        private System.Windows.Forms.TextBox txtOpe;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

