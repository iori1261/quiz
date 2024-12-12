namespace quiz
{
    partial class Form1
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

        #region Windows フォーム デザイナーで生成されたコード

        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.btnOption1 = new System.Windows.Forms.Button();
            this.btnOption2 = new System.Windows.Forms.Button();
            this.btnOption3 = new System.Windows.Forms.Button();
            this.btnOption4 = new System.Windows.Forms.Button();
            this.lblScore = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(245, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(305, 193);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // lblQuestion
            // 
            this.lblQuestion.Font = new System.Drawing.Font("MS UI Gothic", 18F);
            this.lblQuestion.Location = new System.Drawing.Point(125, 222);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(544, 70);
            this.lblQuestion.TabIndex = 2;
            // 
            // btnOption1
            // 
            this.btnOption1.Font = new System.Drawing.Font("MS UI Gothic", 18F);
            this.btnOption1.Location = new System.Drawing.Point(129, 326);
            this.btnOption1.Name = "btnOption1";
            this.btnOption1.Size = new System.Drawing.Size(255, 50);
            this.btnOption1.TabIndex = 3;
            this.btnOption1.UseVisualStyleBackColor = true;
            // 
            // btnOption2
            // 
            this.btnOption2.Font = new System.Drawing.Font("MS UI Gothic", 18F);
            this.btnOption2.Location = new System.Drawing.Point(421, 326);
            this.btnOption2.Name = "btnOption2";
            this.btnOption2.Size = new System.Drawing.Size(248, 50);
            this.btnOption2.TabIndex = 4;
            this.btnOption2.UseVisualStyleBackColor = true;
            // 
            // btnOption3
            // 
            this.btnOption3.Font = new System.Drawing.Font("MS UI Gothic", 18F);
            this.btnOption3.Location = new System.Drawing.Point(129, 416);
            this.btnOption3.Name = "btnOption3";
            this.btnOption3.Size = new System.Drawing.Size(255, 46);
            this.btnOption3.TabIndex = 5;
            this.btnOption3.UseVisualStyleBackColor = true;
            // 
            // btnOption4
            // 
            this.btnOption4.Font = new System.Drawing.Font("MS UI Gothic", 18F);
            this.btnOption4.Location = new System.Drawing.Point(421, 416);
            this.btnOption4.Name = "btnOption4";
            this.btnOption4.Size = new System.Drawing.Size(248, 46);
            this.btnOption4.TabIndex = 6;
            this.btnOption4.UseVisualStyleBackColor = true;
            // 
            // lblScore
            // 
            this.lblScore.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.lblScore.Location = new System.Drawing.Point(12, 505);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(391, 54);
            this.lblScore.TabIndex = 8;
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("MS UI Gothic", 18F);
            this.btnStart.Location = new System.Drawing.Point(637, 493);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(133, 50);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "開始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 568);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.btnOption4);
            this.Controls.Add(this.btnOption3);
            this.Controls.Add(this.btnOption2);
            this.Controls.Add(this.btnOption1);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Button btnOption1;
        private System.Windows.Forms.Button btnOption2;
        private System.Windows.Forms.Button btnOption3;
        private System.Windows.Forms.Button btnOption4;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Button btnStart;
    }
}
