namespace Camera
{
    partial class MainForm
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
            this.btStartWatch = new System.Windows.Forms.Button();
            this.pbVideo = new System.Windows.Forms.PictureBox();
            this.btStopWatch = new System.Windows.Forms.Button();
            this.lvCameras = new System.Windows.Forms.ListView();
            this.btRefreshCamers = new System.Windows.Forms.Button();
            this.lbCameras = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbVideo)).BeginInit();
            this.SuspendLayout();
            // 
            // btStartWatch
            // 
            this.btStartWatch.Location = new System.Drawing.Point(12, 325);
            this.btStartWatch.Name = "btStartWatch";
            this.btStartWatch.Size = new System.Drawing.Size(209, 56);
            this.btStartWatch.TabIndex = 0;
            this.btStartWatch.Text = "Воспроизвести";
            this.btStartWatch.UseVisualStyleBackColor = true;
            this.btStartWatch.Click += new System.EventHandler(this.btStartWatch_Click);
            // 
            // pbVideo
            // 
            this.pbVideo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbVideo.Location = new System.Drawing.Point(227, 9);
            this.pbVideo.Name = "pbVideo";
            this.pbVideo.Size = new System.Drawing.Size(839, 574);
            this.pbVideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbVideo.TabIndex = 1;
            this.pbVideo.TabStop = false;
            // 
            // btStopWatch
            // 
            this.btStopWatch.Location = new System.Drawing.Point(12, 387);
            this.btStopWatch.Name = "btStopWatch";
            this.btStopWatch.Size = new System.Drawing.Size(209, 56);
            this.btStopWatch.TabIndex = 2;
            this.btStopWatch.Text = "Остановить";
            this.btStopWatch.UseVisualStyleBackColor = true;
            this.btStopWatch.Click += new System.EventHandler(this.btStopWatch_Click);
            // 
            // lvCameras
            // 
            this.lvCameras.HideSelection = false;
            this.lvCameras.Location = new System.Drawing.Point(12, 44);
            this.lvCameras.MultiSelect = false;
            this.lvCameras.Name = "lvCameras";
            this.lvCameras.Size = new System.Drawing.Size(209, 197);
            this.lvCameras.TabIndex = 3;
            this.lvCameras.UseCompatibleStateImageBehavior = false;
            this.lvCameras.View = System.Windows.Forms.View.List;
            // 
            // btRefreshCamers
            // 
            this.btRefreshCamers.Location = new System.Drawing.Point(12, 247);
            this.btRefreshCamers.Name = "btRefreshCamers";
            this.btRefreshCamers.Size = new System.Drawing.Size(209, 72);
            this.btRefreshCamers.TabIndex = 4;
            this.btRefreshCamers.Text = "Обновить список камер";
            this.btRefreshCamers.UseVisualStyleBackColor = true;
            this.btRefreshCamers.Click += new System.EventHandler(this.btRefreshCamers_Click);
            // 
            // lbCameras
            // 
            this.lbCameras.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCameras.Location = new System.Drawing.Point(12, 9);
            this.lbCameras.Name = "lbCameras";
            this.lbCameras.Size = new System.Drawing.Size(150, 32);
            this.lbCameras.TabIndex = 5;
            this.lbCameras.Text = "Список камер";
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1073, 596);
            this.Controls.Add(this.lbCameras);
            this.Controls.Add(this.btRefreshCamers);
            this.Controls.Add(this.lvCameras);
            this.Controls.Add(this.btStopWatch);
            this.Controls.Add(this.pbVideo);
            this.Controls.Add(this.btStartWatch);
            this.Name = "MainForm";
            this.Text = "Камеры наблюдения";
            ((System.ComponentModel.ISupportInitialize)(this.pbVideo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btStartWatch;
        private System.Windows.Forms.PictureBox pbVideo;
        private System.Windows.Forms.Button btStopWatch;
        private System.Windows.Forms.ListView lvCameras;
        private System.Windows.Forms.Button btRefreshCamers;
        private System.Windows.Forms.Label lbCameras;
    }
}

