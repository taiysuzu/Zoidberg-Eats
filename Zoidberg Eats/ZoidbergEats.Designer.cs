
namespace Zoidberg_Eats
{
    partial class ZoidbergEats
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZoidbergEats));
            this.titleLabel = new System.Windows.Forms.Label();
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.adLabel = new System.Windows.Forms.Label();
            this.adPictureBox = new System.Windows.Forms.PictureBox();
            this.titleZoidberg = new System.Windows.Forms.PictureBox();
            this.zoidbergBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.adPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.titleZoidberg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoidbergBox)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Futurama Title Font", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.titleLabel.Location = new System.Drawing.Point(12, 330);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(776, 79);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "title";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // subtitleLabel
            // 
            this.subtitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.subtitleLabel.Font = new System.Drawing.Font("Futurama Bold Font", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(225)))), ((int)(((byte)(145)))));
            this.subtitleLabel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.subtitleLabel.Location = new System.Drawing.Point(12, 413);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new System.Drawing.Size(776, 66);
            this.subtitleLabel.TabIndex = 1;
            this.subtitleLabel.Text = "subtitle";
            this.subtitleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // adLabel
            // 
            this.adLabel.BackColor = System.Drawing.Color.Transparent;
            this.adLabel.Font = new System.Drawing.Font("Futurama Bold Font", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adLabel.ForeColor = System.Drawing.Color.White;
            this.adLabel.Location = new System.Drawing.Point(662, -1);
            this.adLabel.Name = "adLabel";
            this.adLabel.Size = new System.Drawing.Size(126, 23);
            this.adLabel.TabIndex = 2;
            this.adLabel.Text = "ad";
            this.adLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.adLabel.Visible = false;
            // 
            // adPictureBox
            // 
            this.adPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.adPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("adPictureBox.BackgroundImage")));
            this.adPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.adPictureBox.Location = new System.Drawing.Point(665, 12);
            this.adPictureBox.Name = "adPictureBox";
            this.adPictureBox.Size = new System.Drawing.Size(123, 166);
            this.adPictureBox.TabIndex = 3;
            this.adPictureBox.TabStop = false;
            this.adPictureBox.Visible = false;
            // 
            // titleZoidberg
            // 
            this.titleZoidberg.BackColor = System.Drawing.Color.Transparent;
            this.titleZoidberg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("titleZoidberg.BackgroundImage")));
            this.titleZoidberg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.titleZoidberg.Location = new System.Drawing.Point(282, 200);
            this.titleZoidberg.Name = "titleZoidberg";
            this.titleZoidberg.Size = new System.Drawing.Size(220, 149);
            this.titleZoidberg.TabIndex = 4;
            this.titleZoidberg.TabStop = false;
            // 
            // zoidbergBox
            // 
            this.zoidbergBox.BackColor = System.Drawing.Color.Transparent;
            this.zoidbergBox.BackgroundImage = global::Zoidberg_Eats.Properties.Resources.zoidberg_left;
            this.zoidbergBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.zoidbergBox.Location = new System.Drawing.Point(16, 396);
            this.zoidbergBox.Name = "zoidbergBox";
            this.zoidbergBox.Size = new System.Drawing.Size(90, 92);
            this.zoidbergBox.TabIndex = 5;
            this.zoidbergBox.TabStop = false;
            this.zoidbergBox.Visible = false;
            // 
            // ZoidbergEats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::Zoidberg_Eats.Properties.Resources.futuramaback;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.zoidbergBox);
            this.Controls.Add(this.adPictureBox);
            this.Controls.Add(this.titleZoidberg);
            this.Controls.Add(this.adLabel);
            this.Controls.Add(this.subtitleLabel);
            this.Controls.Add(this.titleLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ZoidbergEats";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zoidberg Eats";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ZoidbergEats_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ZoidbergEats_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ZoidbergEats_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.adPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.titleZoidberg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoidbergBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subtitleLabel;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label adLabel;
        private System.Windows.Forms.PictureBox adPictureBox;
        private System.Windows.Forms.PictureBox titleZoidberg;
        private System.Windows.Forms.PictureBox zoidbergBox;
    }
}

