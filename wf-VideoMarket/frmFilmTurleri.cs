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
    public partial class frmFilmTurleri : Form
    {
        public frmFilmTurleri()
        {
            InitializeComponent();
        }
        private int SecilenTurNo; //değiştir ve sil için geçerli doubleclicke gectiğimizde yazdık.
        private void frmFilmTurleri_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            //Model.FilmTuru //model klasörünün içinde olduğu çin böylede yaparız ama uzun olur yukarıya eklemek daha iyi.
            FilmTuru ft = new FilmTuru();
            ft.FilmTurleriGoster(lvFilmTurleri);
        }
        private void Temizle()
        {
            txtFilmTuru.Clear();
            txtAciklama.Clear();
            txtFilmTuru.Focus();
        }
        private void btnYeni_Click(object sender, EventArgs e)
        {
            btnKaydet.Enabled = true;
            btnDegistir.Enabled = false;
            btnSil.Enabled = false;
            Temizle();
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if(txtFilmTuru.Text.Trim() != "")
            {
                FilmTuru ft = new FilmTuru();
                if(ft.FilmTuruKontrol(txtFilmTuru.Text)) //ekrandan girilen filmtürü veritabanında var mı diye kontrol edicek. true yada false göndercek, doğrudan if içine alabilirim
                {
                    MessageBox.Show("Girdiğiniz film türü önceden kayıtlı!","Zaten var!");
                    txtFilmTuru.Focus();
                }
                else
                {
                    //kaydetme işlemini gerçekleştircez.
                    ft.TurAd = txtFilmTuru.Text;
                    ft.Aciklama = txtAciklama.Text;
                    if(ft.FilmTuruEkle(ft))
                    {
                        MessageBox.Show("Film türü eklendi.", "Kayıt tamamlandı.");
                        Temizle(); //textboxları temizledim
                        btnKaydet.Enabled = false; //butonu pasif hale getirdim
                        ft.FilmTurleriGoster(lvFilmTurleri); //kayıtları göstercem listview da
                    }
                    else
                    {
                        MessageBox.Show("Kayıt gerçekleşemedi.", "Dikkat!İşlem tamamlanamadı!");
                        txtFilmTuru.Focus();
                    }
                }
            }
            else
            {
                MessageBox.Show("Film türü girmelisiniz.", "Eksik bilgi!");
                txtFilmTuru.Focus();
            }
        }
        private void lvFilmTurleri_DoubleClick(object sender, EventArgs e)
        {
            //listview da değiştirmek istediğim satırı çift tıklayıp yukarıdaki textboxlara gitmesini sağlicam.
            SecilenTurNo = Convert.ToInt32(lvFilmTurleri.SelectedItems[0].SubItems[0].Text); //seçilen satırı yakalıyoruz
            txtFilmTuru.Text = lvFilmTurleri.SelectedItems[0].SubItems[1].Text;
            txtAciklama.Text = lvFilmTurleri.SelectedItems[0].SubItems[2].Text;
            btnDegistir.Enabled = true;
            btnSil.Enabled = true;
            btnKaydet.Enabled = false;
            txtFilmTuru.Focus();
        }

        private void btnDegistir_Click(object sender, EventArgs e)
        {
            if (txtFilmTuru.Text.Trim() != "")
            {
                FilmTuru ft = new FilmTuru();
                if (ft.FilmTuruKontrolFromDegistir(txtFilmTuru.Text, SecilenTurNo)) //FilmTuruKontrol le hemen hemen aynı.
                {
                    MessageBox.Show("Girdiğiniz film türü önceden kayıtlı!", "Zaten var!");
                    txtFilmTuru.Focus();
                }
                else
                {
                    ft.FilmTurNo = SecilenTurNo; //ilk kaydederken tür noya gerek yok ama şimdi güncellediğim için var
                    ft.TurAd = txtFilmTuru.Text;
                    ft.Aciklama = txtAciklama.Text;
                    if (ft.FilmTuruGuncelle(ft))
                    {
                        MessageBox.Show("Film türü güncellendi.", "Değişiklik gerçekleşti.");
                        Temizle();
                        btnDegistir.Enabled = false;
                        btnSil.Enabled = false;
                        ft.FilmTurleriGoster(lvFilmTurleri);
                    }
                    else
                    {
                        MessageBox.Show("Değişiklik gerçekleşemedi.", "Dikkat!İşlem tamamlanamadı!");
                        txtFilmTuru.Focus();
                    }
                }
            }
            else
            {
                MessageBox.Show("Film türü girmelisiniz.", "Eksik bilgi!");
                txtFilmTuru.Focus();
            }
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Silmek istiyor musunuz?","Silinsin mi?",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) //yes secerse silcez, no secerse bişi yapmicaz
            {
                FilmTuru ft = new FilmTuru();
                if(ft.FilmTuruSil(SecilenTurNo))
                {
                    MessageBox.Show("Film türü silindi.", "Değişiklik gerçekleşti.");
                    Temizle();
                    btnDegistir.Enabled = false;
                    btnSil.Enabled = false;
                    ft.FilmTurleriGoster(lvFilmTurleri);
                }
                else
                {
                    MessageBox.Show("Silme gerçekleşemedi.", "Dikkat!İşlem tamamlanamadı!");
                    txtFilmTuru.Focus();
                }
            }
        }
    }
}
