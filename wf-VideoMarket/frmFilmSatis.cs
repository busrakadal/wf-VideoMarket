using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wf_VideoMarket.Model;

namespace wf_VideoMarket
{
    public partial class frmFilmSatis : Form
    {
        public frmFilmSatis()
        {
            InitializeComponent();
        }
        int SecilenSatisNo;
        int orjAdet;

        private void frmFilmSatis_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            txtTarih.Text = DateTime.Now.ToShortDateString(); //günün tarihi (sadece tarihi alıyoruz saatleri 00:00 diye atıcak)
            //amacımız yeniden eskiye gitmek.
            FilmSatis fs = new FilmSatis();
            fs.SatislariGoster(lvSatislar, txtToplamAdet, txtToplamTutar);
        }

        private void dtpTarih_ValueChanged(object sender, EventArgs e)
        {
            txtTarih.Text = dtpTarih.Value.ToShortDateString(); //datetimepicker dan seçerse onu atcaz textbox a
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }
        private void txtTarih_TextChanged(object sender, EventArgs e)
        {
        }
        private void txtMusteri_TextChanged(object sender, EventArgs e)
        {
        }
        private void txtAdet_TextChanged(object sender, EventArgs e)
        {
            if (txtAdet.Text.Trim() == "") { txtAdet.Text = "1"; txtAdet.SelectAll(); }//adet textini silemiyoruz boş olursa 1 yazıyor.Bu textboxa tıkladığında orada yazılan sayı seçili olsun ve bizim silip yazmamız kolay olsun.? Aşağıda Mouseclick olayı.
            if (!string.IsNullOrEmpty(txtAdet.Text) && !string.IsNullOrEmpty(txtFiyat.Text)) //içinde değer barındırsın demek. trimle aynı işi yapıyor. //boş değilse anlamında olduğu için ! koyduk..
            { 
                txtTutar.Text = Convert.ToString(Convert.ToInt32(txtAdet.Text) * Convert.ToDecimal(txtFiyat.Text)); //adet ve fiyat textine boş değer gelmemesi lazım yoksa hata verir. Amadongü içinde vermez.
            } 
            else
            {
                txtTutar.Text = txtFiyat.Text; //fiyat textinde ne yazarsa tutarda onu yazıyor veya adet yazılıysa çarpıp tutarı veriyor.
            } 

        }
        private void txtFiyat_TextChanged(object sender, EventArgs e)
        {
            if (txtFiyat.Text.Trim() == "") { txtFiyat.Text = "0"; txtFiyat.SelectAll(); }//burda da 0 yazıyor.
            if (!string.IsNullOrEmpty(txtAdet.Text) && !string.IsNullOrEmpty(txtFiyat.Text)) 
            {
                txtTutar.Text = Convert.ToString(Convert.ToInt32(txtAdet.Text) * Convert.ToDecimal(txtFiyat.Text));
            }
            else
            {
                txtTutar.Text = txtFiyat.Text;
            }

        }
        private void txtTutar_TextChanged(object sender, EventArgs e)
        {
        }
        private void txtFilm_TextChanged(object sender, EventArgs e)
        {
        }
        private void txtStok_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnMusteriBul_Click(object sender, EventArgs e)
        {
            frmMusteriSorgulama frm = new frmMusteriSorgulama();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();

            //aldığımız bilgileri burda göstercez.
            txtMusteri.Text = Genel.secilenmusteri;
        }

        private void btnFilmBul_Click(object sender, EventArgs e)
        {
            frmFilmSorgulama frm = new frmFilmSorgulama();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            txtFilm.Text = Genel.secilenfilm;
            txtStok.Text = Genel.secilenmiktar.ToString();
            txtFiyat.Text = Genel.secilenfiyat.ToString();
            
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            btnKaydet.Enabled = true;
            btnDegistir.Enabled = false;
            btnSil.Enabled = false;
            Temizle();
            btnMusteriBul.Enabled = true;
            btnFilmBul.Enabled = true;
            //müşteri ekranı açılsın onu seçince film ekranı seçilsin sonra adet textboxına focuslansın.
            btnMusteriBul_Click(sender, e); //müşteri bula gidicek işi bitince buraya gelicek
            btnFilmBul_Click(sender, e); //film bul içinde aynısını yapcak
            txtAdet.Focus();
        }
        private void Temizle()
        {
            txtAdet.Text = "1";
            txtFiyat.Text = "0";
            txtMusteri.Clear();
            txtFilm.Clear();
            txtStok.Clear();
            Genel.secilenfilm = "";
            Genel.secilenfilmno = 0;
            Genel.secilenmusteri = "";
            Genel.secilenmusterino = 0;
            Genel.secilenmiktar = 0;
            Genel.secilenfiyat = 0;
        }

        //işlem sırası txtAdet sonra txtFiyat ama ekranı hazırlarken yanlışlıkla tıkladığım için yukardalar..
        //txtAdet
        //txtFiyat

        private void txtAdet_MouseClick(object sender, MouseEventArgs e)
        {
            txtAdet.SelectAll(); //textboxa tıklandığında hepsi seçiliyor.
        }
        private void txtFiyat_MouseClick(object sender, MouseEventArgs e)
        {
            txtFiyat.SelectAll();
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //hata verebilecekleri aşağıda elsenin orda yap her zaman..
            if(txtMusteri.Text != "" && txtFilm.Text != "") //zaten o textlere yazı yazamadığı için trim e gerek yok.
            {
                if(Convert.ToInt32(txtAdet.Text) <= Convert.ToInt32(txtStok.Text))
                {
                    FilmSatis fs = new FilmSatis();
                    fs.Tarih = Convert.ToDateTime(txtTarih.Text);
                    fs.FilmNo = Genel.secilenfilmno;
                    fs.MusteriNo = Genel.secilenmusterino;
                    fs.Adet = Convert.ToInt32(txtAdet.Text);
                    fs.BirimFiyat = Convert.ToDecimal(txtFiyat.Text);
                    if (fs.SatisEkle(fs))
                    {
                        MessageBox.Show("Satış Bilgileri Kayıt Edildi.");

                        //Film Stok Miktarı güncellenmeli (satış adedi kadar azaltılmalı).
                        Film f = new Film();
                        if(f.StokGuncelleFromSatisEkle(fs.FilmNo, fs.Adet)) //şu numaralı filmin stoğundan su kadar düşülcek demek
                        {
                            MessageBox.Show("Stok Güncellendi.");
                            fs.SatislariGoster(lvSatislar, txtToplamAdet, txtToplamTutar);
                            btnKaydet.Enabled = false;
                            btnMusteriBul.Enabled = false;
                            btnFilmBul.Enabled = false;
                            Temizle();
                        }
                        else { MessageBox.Show("Stok güncellenemedi."); }
                    }
                    else { MessageBox.Show("Satış tamamlanamadı."); }
                }
                else { MessageBox.Show("Stoktan fazla satamazsınız!","Dikkat! Yetersiz Stok!!"); txtAdet.Text = txtStok.Text; }
            }
            else { MessageBox.Show("Müşterive Film mutlaka seçilmelidir.", "Dikkat! Eksik Bilgi!"); }
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Silmek istiyor musunuz?", "Silinsin mi?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FilmSatis fs = new FilmSatis();
                if (fs.SatisSil(SecilenSatisNo))
                {
                    MessageBox.Show("Satış silindi.", "Değişiklik gerçekleşti.");
                    Film f = new Film();
                    if (f.StokGuncelleFromSatisSil(Genel.secilenfilmno, Convert.ToInt32(txtAdet.Text))) 
                    {
                        MessageBox.Show("Stok Güncellendi.");
                        fs.SatislariGoster(lvSatislar, txtToplamAdet, txtToplamTutar);
                        btnKaydet.Enabled = false;
                        btnMusteriBul.Enabled = false;
                        btnFilmBul.Enabled = false;
                        Temizle();
                    }
                    else { MessageBox.Show("Stok güncellenemedi."); }
                }
                else { MessageBox.Show("Satış gerçekleşemedi."); }
            }
            else { MessageBox.Show("Silme gerçekleşemedi.", "Dikkat!İşlem tamamlanamadı!"); }
        }
        private void lvSatislar_DoubleClick(object sender, EventArgs e) //btnsil den önce olmalı..
        {
            SecilenSatisNo = Convert.ToInt32(lvSatislar.SelectedItems[0].SubItems[0].Text);
            txtTarih.Text = lvSatislar.SelectedItems[0].SubItems[1].Text;
            txtFilm.Text = lvSatislar.SelectedItems[0].SubItems[2].Text;
            txtMusteri.Text = lvSatislar.SelectedItems[0].SubItems[3].Text;
            txtFiyat.Text = lvSatislar.SelectedItems[0].SubItems[4].Text;
            txtAdet.Text = lvSatislar.SelectedItems[0].SubItems[5].Text;
            orjAdet = Convert.ToInt32(lvSatislar.SelectedItems[0].SubItems[5].Text); //bunu değiştir butonu için ekledik.bu değişmicek ama txtadet değişebilir.
            txtTutar.Text = lvSatislar.SelectedItems[0].SubItems[6].Text;
            txtStok.Text = lvSatislar.SelectedItems[0].SubItems[7].Text;
            Genel.secilenfilmno = Convert.ToInt32(lvSatislar.SelectedItems[0].SubItems[8].Text);
            Genel.secilenmusterino = Convert.ToInt32(lvSatislar.SelectedItems[0].SubItems[9].Text);
            btnKaydet.Enabled = false;
            btnDegistir.Enabled = true; 
            btnSil.Enabled = true;
        }
        private void btnDegistir_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtAdet.Text) <= (Convert.ToInt32(txtStok.Text) + orjAdet)) //değiştirde orjadeti göz önünde bulundurman lazım
            {
                //değiştir butonun da adet ve birimfiyat değişebilir diğerleri değişmez o yuzden kapattık
                FilmSatis fs = new FilmSatis();
                //fs.Tarih = Convert.ToDateTime(txtTarih.Text);
                //fs.FilmNo = Genel.secilenfilmno;
                //fs.MusteriNo = Genel.secilenmusterino;
                fs.SatisNo = SecilenSatisNo;
                fs.Adet = Convert.ToInt32(txtAdet.Text);
                fs.BirimFiyat = Convert.ToDecimal(txtFiyat.Text);
                if (fs.SatisGuncelle(fs))
                {
                    MessageBox.Show("Satış Bilgileri Değiştirildi.");
                    if (fs.Adet != orjAdet) //adet değişmediyse stok güncellemeye gerek yok.
                    {
                        Film f = new Film();
                        if (f.StokGuncelleFromSatisDegistir(Genel.secilenfilmno, fs.Adet, orjAdet))
                        {
                            MessageBox.Show("Stok Güncellendi.");
                        }
                        else { MessageBox.Show("Stok güncellenemedi."); }
                    }
                    fs.SatislariGoster(lvSatislar, txtToplamAdet, txtToplamTutar);
                    btnKaydet.Enabled = false;
                    btnMusteriBul.Enabled = false;
                    btnFilmBul.Enabled = false;
                    Temizle();
                }
                else { MessageBox.Show("Satış tamamlanamadı."); }
            }
            else { MessageBox.Show("Stoktan fazla satamazsınız!", "Dikkat! Yetersiz Stok!!"); }
        }
    }
}
