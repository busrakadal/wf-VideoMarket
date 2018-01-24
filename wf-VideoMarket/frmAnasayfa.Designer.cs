namespace wf_VideoMarket
{
    partial class frmAnasayfa
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
            this.mnuAnasayfa = new System.Windows.Forms.MenuStrip();
            this.mitmFilmBilgileri = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmFilmTanimlama = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmFilmTuruTanimlama = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmFilmSorgulama = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmMusteriler = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmMusteriTanimlama = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmMusteriSorgulama = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmSatisIslemleri = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmFilmSatis = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmSatisSorgulama = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmRaporlama = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmDetayliSatisRaporu = new System.Windows.Forms.ToolStripMenuItem();
            this.mitmCikis = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAnasayfa.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuAnasayfa
            // 
            this.mnuAnasayfa.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitmFilmBilgileri,
            this.mitmMusteriler,
            this.mitmSatisIslemleri,
            this.mitmRaporlama,
            this.mitmCikis});
            this.mnuAnasayfa.Location = new System.Drawing.Point(0, 0);
            this.mnuAnasayfa.Name = "mnuAnasayfa";
            this.mnuAnasayfa.Size = new System.Drawing.Size(720, 24);
            this.mnuAnasayfa.TabIndex = 1;
            this.mnuAnasayfa.Text = "menuStrip1";
            // 
            // mitmFilmBilgileri
            // 
            this.mitmFilmBilgileri.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitmFilmTanimlama,
            this.mitmFilmTuruTanimlama,
            this.mitmFilmSorgulama});
            this.mitmFilmBilgileri.Name = "mitmFilmBilgileri";
            this.mitmFilmBilgileri.Size = new System.Drawing.Size(84, 20);
            this.mitmFilmBilgileri.Text = "&Film Bilgileri";
            // 
            // mitmFilmTanimlama
            // 
            this.mitmFilmTanimlama.Name = "mitmFilmTanimlama";
            this.mitmFilmTanimlama.Size = new System.Drawing.Size(188, 22);
            this.mitmFilmTanimlama.Text = "Film &Tanımlama";
            this.mitmFilmTanimlama.Click += new System.EventHandler(this.mitmFilmTanimlama_Click);
            // 
            // mitmFilmTuruTanimlama
            // 
            this.mitmFilmTuruTanimlama.Name = "mitmFilmTuruTanimlama";
            this.mitmFilmTuruTanimlama.Size = new System.Drawing.Size(188, 22);
            this.mitmFilmTuruTanimlama.Text = "F&ilm Türü Tanımlama";
            this.mitmFilmTuruTanimlama.Click += new System.EventHandler(this.mitmFilmTuruTanimlama_Click);
            // 
            // mitmFilmSorgulama
            // 
            this.mitmFilmSorgulama.Name = "mitmFilmSorgulama";
            this.mitmFilmSorgulama.Size = new System.Drawing.Size(188, 22);
            this.mitmFilmSorgulama.Text = "Film &Sorgulama";
            this.mitmFilmSorgulama.Click += new System.EventHandler(this.mitmFilmSorgulama_Click);
            // 
            // mitmMusteriler
            // 
            this.mitmMusteriler.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitmMusteriTanimlama,
            this.mitmMusteriSorgulama});
            this.mitmMusteriler.Name = "mitmMusteriler";
            this.mitmMusteriler.Size = new System.Drawing.Size(72, 20);
            this.mitmMusteriler.Text = "&Müşteriler";
            // 
            // mitmMusteriTanimlama
            // 
            this.mitmMusteriTanimlama.Name = "mitmMusteriTanimlama";
            this.mitmMusteriTanimlama.Size = new System.Drawing.Size(177, 22);
            this.mitmMusteriTanimlama.Text = "Müşteri &Tanımlama";
            this.mitmMusteriTanimlama.Click += new System.EventHandler(this.mitmMusteriTanimlama_Click);
            // 
            // mitmMusteriSorgulama
            // 
            this.mitmMusteriSorgulama.Name = "mitmMusteriSorgulama";
            this.mitmMusteriSorgulama.Size = new System.Drawing.Size(177, 22);
            this.mitmMusteriSorgulama.Text = "Müşteri &Sorgulama";
            this.mitmMusteriSorgulama.Click += new System.EventHandler(this.mitmMusteriSorgulama_Click);
            // 
            // mitmSatisIslemleri
            // 
            this.mitmSatisIslemleri.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitmFilmSatis,
            this.mitmSatisSorgulama});
            this.mitmSatisIslemleri.Name = "mitmSatisIslemleri";
            this.mitmSatisIslemleri.Size = new System.Drawing.Size(90, 20);
            this.mitmSatisIslemleri.Text = "&Satış İşlemleri";
            // 
            // mitmFilmSatis
            // 
            this.mitmFilmSatis.Name = "mitmFilmSatis";
            this.mitmFilmSatis.Size = new System.Drawing.Size(158, 22);
            this.mitmFilmSatis.Text = "&Film Satış";
            this.mitmFilmSatis.Click += new System.EventHandler(this.mitmFilmSatis_Click);
            // 
            // mitmSatisSorgulama
            // 
            this.mitmSatisSorgulama.Name = "mitmSatisSorgulama";
            this.mitmSatisSorgulama.Size = new System.Drawing.Size(158, 22);
            this.mitmSatisSorgulama.Text = "Satış &Sorgulama";
            this.mitmSatisSorgulama.Click += new System.EventHandler(this.mitmSatisSorgulama_Click);
            // 
            // mitmRaporlama
            // 
            this.mitmRaporlama.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitmDetayliSatisRaporu});
            this.mitmRaporlama.Name = "mitmRaporlama";
            this.mitmRaporlama.Size = new System.Drawing.Size(76, 20);
            this.mitmRaporlama.Text = "&Raporlama";
            // 
            // mitmDetayliSatisRaporu
            // 
            this.mitmDetayliSatisRaporu.Name = "mitmDetayliSatisRaporu";
            this.mitmDetayliSatisRaporu.Size = new System.Drawing.Size(175, 22);
            this.mitmDetayliSatisRaporu.Text = "&Detaylı Satış Analizi";
            // 
            // mitmCikis
            // 
            this.mitmCikis.Name = "mitmCikis";
            this.mitmCikis.Size = new System.Drawing.Size(44, 20);
            this.mitmCikis.Text = "&Çıkış";
            this.mitmCikis.Click += new System.EventHandler(this.mitmCikis_Click);
            // 
            // frmAnasayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 490);
            this.Controls.Add(this.mnuAnasayfa);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuAnasayfa;
            this.Name = "frmAnasayfa";
            this.Text = "Video Market AnaSayfa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmAnasayfa_Load);
            this.mnuAnasayfa.ResumeLayout(false);
            this.mnuAnasayfa.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuAnasayfa;
        private System.Windows.Forms.ToolStripMenuItem mitmFilmBilgileri;
        private System.Windows.Forms.ToolStripMenuItem mitmFilmTanimlama;
        private System.Windows.Forms.ToolStripMenuItem mitmFilmTuruTanimlama;
        private System.Windows.Forms.ToolStripMenuItem mitmFilmSorgulama;
        private System.Windows.Forms.ToolStripMenuItem mitmMusteriler;
        private System.Windows.Forms.ToolStripMenuItem mitmMusteriTanimlama;
        private System.Windows.Forms.ToolStripMenuItem mitmMusteriSorgulama;
        private System.Windows.Forms.ToolStripMenuItem mitmSatisIslemleri;
        private System.Windows.Forms.ToolStripMenuItem mitmFilmSatis;
        private System.Windows.Forms.ToolStripMenuItem mitmSatisSorgulama;
        private System.Windows.Forms.ToolStripMenuItem mitmRaporlama;
        private System.Windows.Forms.ToolStripMenuItem mitmDetayliSatisRaporu;
        private System.Windows.Forms.ToolStripMenuItem mitmCikis;
    }
}