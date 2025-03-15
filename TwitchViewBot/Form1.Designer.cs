namespace TwitchViewBot
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
            this.userNameBox = new System.Windows.Forms.TextBox();
            this.userNameLbl = new System.Windows.Forms.Label();
            this.numViewersTxt = new System.Windows.Forms.TextBox();
            this.NumOfViewersLbl = new System.Windows.Forms.Label();
            this.LogTxtBx = new System.Windows.Forms.TextBox();
            this.txtLogLbl = new System.Windows.Forms.Label();
            this.startBtn = new System.Windows.Forms.Button();
            this.stopBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.liveViewerLabel = new System.Windows.Forms.Label();
            this.refreshInterval = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this.refreshInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // userNameBox
            // 
            this.userNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameBox.Location = new System.Drawing.Point(17, 51);
            this.userNameBox.Name = "userNameBox";
            this.userNameBox.Size = new System.Drawing.Size(400, 38);
            this.userNameBox.TabIndex = 0;
            // 
            // userNameLbl
            // 
            this.userNameLbl.AutoSize = true;
            this.userNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameLbl.Location = new System.Drawing.Point(12, 23);
            this.userNameLbl.Name = "userNameLbl";
            this.userNameLbl.Size = new System.Drawing.Size(189, 25);
            this.userNameLbl.TabIndex = 1;
            this.userNameLbl.Text = "Twitch UserName:";
            // 
            // numViewersTxt
            // 
            this.numViewersTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numViewersTxt.Location = new System.Drawing.Point(17, 133);
            this.numViewersTxt.Name = "numViewersTxt";
            this.numViewersTxt.Size = new System.Drawing.Size(400, 38);
            this.numViewersTxt.TabIndex = 2;
            // 
            // NumOfViewersLbl
            // 
            this.NumOfViewersLbl.AutoSize = true;
            this.NumOfViewersLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumOfViewersLbl.Location = new System.Drawing.Point(12, 105);
            this.NumOfViewersLbl.Name = "NumOfViewersLbl";
            this.NumOfViewersLbl.Size = new System.Drawing.Size(201, 25);
            this.NumOfViewersLbl.TabIndex = 3;
            this.NumOfViewersLbl.Text = "Number of Viewers:";
            // 
            // LogTxtBx
            // 
            this.LogTxtBx.Location = new System.Drawing.Point(15, 448);
            this.LogTxtBx.Multiline = true;
            this.LogTxtBx.Name = "LogTxtBx";
            this.LogTxtBx.Size = new System.Drawing.Size(402, 454);
            this.LogTxtBx.TabIndex = 4;
            // 
            // txtLogLbl
            // 
            this.txtLogLbl.AutoSize = true;
            this.txtLogLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogLbl.Location = new System.Drawing.Point(12, 420);
            this.txtLogLbl.Name = "txtLogLbl";
            this.txtLogLbl.Size = new System.Drawing.Size(55, 25);
            this.txtLogLbl.TabIndex = 5;
            this.txtLogLbl.Text = "Log:";
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(17, 326);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(165, 73);
            this.startBtn.TabIndex = 6;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            // 
            // stopBtn
            // 
            this.stopBtn.Location = new System.Drawing.Point(252, 326);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(165, 73);
            this.stopBtn.TabIndex = 7;
            this.stopBtn.Text = "Stop";
            this.stopBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 267);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Bots Watching: ";
            // 
            // liveViewerLabel
            // 
            this.liveViewerLabel.AutoSize = true;
            this.liveViewerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.liveViewerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.liveViewerLabel.Location = new System.Drawing.Point(288, 267);
            this.liveViewerLabel.Name = "liveViewerLabel";
            this.liveViewerLabel.Size = new System.Drawing.Size(24, 25);
            this.liveViewerLabel.TabIndex = 9;
            this.liveViewerLabel.Text = "0";
            this.liveViewerLabel.Click += new System.EventHandler(this.liveViewerLabel_Click);
            // 
            // refreshInterval
            // 
            this.refreshInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshInterval.Location = new System.Drawing.Point(293, 199);
            this.refreshInterval.Name = "refreshInterval";
            this.refreshInterval.Size = new System.Drawing.Size(124, 30);
            this.refreshInterval.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(275, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "Refresh Interval in Minutes:";
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(420, -3);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(18, 935);
            this.vScrollBar1.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 932);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.refreshInterval);
            this.Controls.Add(this.liveViewerLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.txtLogLbl);
            this.Controls.Add(this.LogTxtBx);
            this.Controls.Add(this.NumOfViewersLbl);
            this.Controls.Add(this.numViewersTxt);
            this.Controls.Add(this.userNameLbl);
            this.Controls.Add(this.userNameBox);
            this.Name = "Form1";
            this.Text = "Twitch View Bot";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.refreshInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox userNameBox;
        private System.Windows.Forms.Label userNameLbl;
        private System.Windows.Forms.TextBox numViewersTxt;
        private System.Windows.Forms.Label NumOfViewersLbl;
        private System.Windows.Forms.TextBox LogTxtBx;
        private System.Windows.Forms.Label txtLogLbl;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label liveViewerLabel;
        private System.Windows.Forms.NumericUpDown refreshInterval;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.VScrollBar vScrollBar1;
    }
}

