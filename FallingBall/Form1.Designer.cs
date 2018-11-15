namespace FallingBall
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timMain = new System.Windows.Forms.Timer(this.components);
            this.lblLife = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timMain
            // 
            this.timMain.Enabled = true;
            this.timMain.Interval = 50;
            this.timMain.Tick += new System.EventHandler(this.timMain_Tick);
            // 
            // lblLife
            // 
            this.lblLife.AutoSize = true;
            this.lblLife.Location = new System.Drawing.Point(13, 13);
            this.lblLife.Name = "lblLife";
            this.lblLife.Size = new System.Drawing.Size(59, 12);
            this.lblLife.TabIndex = 0;
            this.lblLife.Text = "生命值：5";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(78, 13);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(47, 12);
            this.lblScore.TabIndex = 1;
            this.lblScore.Text = "分数：0";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 442);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblLife);
            this.DoubleBuffered = true;
            this.Name = "FormMain";
            this.Text = "下落的小球";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormMain_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timMain;
        private System.Windows.Forms.Label lblLife;
        private System.Windows.Forms.Label lblScore;
    }
}

