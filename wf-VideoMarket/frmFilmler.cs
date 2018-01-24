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
    public partial class frmFilmler : Form
    {
        public frmFilmler()
        {
            InitializeComponent();
        }
        int SecilenFilmNo;
        int SecilenTurNo;
        private void frmFilmler_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

            Film f = new Film();
            f.FilmleriGoster(lvFilmler);

            FilmTuru ft = new FilmTuru(); //hangi classın içine yazıcağımızı söylüyor.
            ft.FilmTurleriGoster(cbFilmTurleri); //filmturu classının içine yazıyoruz.
        }
        private void cbFilmTurleri_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtFilmTuru.Text = cbFilmTurleri.SelectedItem.ToString(); //comboboxdan seçilen değer filmtürü textboxına yerleşsin demek. selectedıtem : seçileni nesne olarak getiriyor.
            //FilmTuru ft = new FilmTuru();
            //SecilenTurNo = ft.FilmTurNoGetirByFilmTuru(txtFilmTuru.Text);
            //--------------------------------------------------
            //new ile değerleri olmayan yani propertyleri boş nesneler oluşurken, biz cbFilmTurlerinden seçilen FilmTuru nesnesinin değerlerine sahip yeni bir nesne oluşturuyoruz.
            //FilmTurleriGoster(ComboBox liste) bunu değiştirdiğimiz için burayı da böyle yaptık.
            FilmTuru ft = (FilmTuru)cbFilmTurleri.SelectedItem; //comboboxdan seçilen ıtemsların özellikleriyle aynı bi nesne oluştur.
            //FilmTuru ft = cbFilmTurleri.SelectedItem as FilmTuru; //yukarıdaki satırla aynı.
            txtFilmTuru.Text = ft.TurAd; //seçilen nesne de hem türü hemde tür nosu oluşuyor.
            SecilenTurNo = ft.FilmTurNo;
            txtYonetmen.Focus();
        }

        private void txtFilmeGore_TextChanged(object sender, EventArgs e)
        {
            Film f = new Film();
            f.FilmleriGosterByAdaGore(lvFilmler, txtFilmeGore.Text);
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
            if (txtFilmAdi.Text.Trim() != "" && txtFilmTuru.Text.Trim() != "" && txtYonetmen.Text.Trim() != "")
            {
                Film f = new Film();
                f.FilmAd = txtFilmAdi.Text;
                f.Yonetmen = txtYonetmen.Text;
                if (f.FilmKontrol(f))
                {
                    MessageBox.Show("Girdiğiniz film önceden kayıtlıdır.");
                    txtFilmAdi.Focus();
                }
                else
                {
                    //eksik propertyleri tamamlicaz 
                    f.FilmTurNo = SecilenTurNo;
                    f.Oyuncular = txtOyuncular.Text;
                    f.Ozet = txtOzet.Text;
                    //sayısal alan kontrolü fiyat ve miktar için..
                    try //sayı yerine harf girerse hata verdirmek için
                    {
                        f.Fiyat = Convert.ToDecimal(txtFiyat.Text);
                    }
                    catch(FormatException) //özel hatalar : harf hatasına bakar.Oraya yanlışla harf girerse napalım?.
                    {
                        f.Fiyat = 0; //boş geçildiyse veya harf girildiyse 0 olarak verelim diyor.
                    }
                    catch (Exception) //harf hatasından başka beklenmedik bi hata varsa buraya gelicek mesaj vericek
                    {
                        MessageBox.Show("Fiyat alanını kontrol ediniz.", "Dikkat hatalı fiyat girişi!");
                        txtFiyat.Focus();
                        return;
                    }
                    try 
                    {
                        f.Miktar = Convert.ToInt32(txtMiktar.Text);
                    }
                    catch (FormatException) 
                    {
                        f.Miktar = 1; //miktar kolonunu sql den 10 dan 1 e indir default unu
                    }
                    catch (Exception) 
                    {
                        MessageBox.Show("Miktar alanını kontrol ediniz.", "Dikkat hatalı miktar girişi!");
                        txtMiktar.Focus();
                        return;
                    }

                    if (f.FilmEkle(f))
                    {
                        MessageBox.Show("Film eklendi.", "Kayıt tamamlandı.");
                        Temizle();
                        btnKaydet.Enabled = false;
                        f.FilmleriGoster(lvFilmler);
                    }
                    else
                    {
                        MessageBox.Show("Kayıt gerçekleşemedi.", "Dikkat!İşlem tamamlanamadı!");
                        txtFilmAdi.Focus();
                    }
                }
            }
        }

        private void Temizle()
        {
            txtFilmAdi.Clear();
            txtYonetmen.Clear();
            txtOyuncular.Clear();
            txtOzet.Clear();
            txtFiyat.Text = "0";
            txtMiktar.Text = "1";
            txtFilmAdi.Focus();


        }

        private void lvFilmler_DoubleClick(object sender, EventArgs e)  
        {
            SecilenFilmNo = Convert.ToInt32(lvFilmler.SelectedItems[0].SubItems[0].Text);
            txtFilmAdi.Text = lvFilmler.SelectedItems[0].SubItems[1].Text;
            SecilenTurNo = Convert.ToInt32(lvFilmler.SelectedItems[0].SubItems[2].Text);
            txtFilmTuru.Text = lvFilmler.SelectedItems[0].SubItems[3].Text;
            txtYonetmen.Text = lvFilmler.SelectedItems[0].SubItems[4].Text;
            txtOyuncular.Text = lvFilmler.SelectedItems[0].SubItems[5].Text;
            txtOzet.Text = lvFilmler.SelectedItems[0].SubItems[6].Text;
            txtFiyat.Text = lvFilmler.SelectedItems[0].SubItems[7].Text;
            txtMiktar.Text = lvFilmler.SelectedItems[0].SubItems[8].Text;
            btnDegistir.Enabled = true;
            btnSil.Enabled = true;
            btnKaydet.Enabled = false;
            txtFilmAdi.Focus();
        }

        private void btnDegistir_Click(object sender, EventArgs e)
        {
            if (txtFilmAdi.Text.Trim() != "" && txtFilmTuru.Text.Trim() != "" && txtYonetmen.Text.Trim() != "")
            {
                Film f = new Film();
                f.FilmNo = SecilenFilmNo;
                f.FilmAd = txtFilmAdi.Text;
                f.Yonetmen = txtYonetmen.Text;
                if (f.FilmKontrolByDegistir(f)) 
                {
                    MessageBox.Show("Girdiğiniz film önceden kayıtlı!", "Zaten var!");
                    txtFilmAdi.Focus();
                }
                else
                {
                    f.FilmTurNo = SecilenTurNo;
                    f.Oyuncular = txtOyuncular.Text;
                    f.Ozet = txtOzet.Text;
                    try 
                    {
                        f.Fiyat = Convert.ToDecimal(txtFiyat.Text);
                    }
                    catch (FormatException) 
                    {
                        f.Fiyat = 0; 
                    }
                    catch (Exception) 
                    {
                        MessageBox.Show("Fiyat alanını kontrol ediniz.", "Dikkat hatalı fiyat girişi!");
                        txtFiyat.Focus();
                        return;
                    }
                    try
                    {
                        f.Miktar = Convert.ToInt32(txtMiktar.Text);
                    }
                    catch (FormatException)
                    {
                        f.Miktar = 1; 
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Miktar alanını kontrol ediniz.", "Dikkat hatalı miktar girişi!");
                        txtMiktar.Focus();
                        return;
                    }

                    if (f.FilmGuncelle(f))
                    {
                        MessageBox.Show("Film güncellendi.", "Değişiklik gerçekleşti");
                        Temizle();
                        btnDegistir.Enabled = false;
                        btnSil.Enabled = false;
                        f.FilmleriGoster(lvFilmler);
                    }
                    else
                    {
                        MessageBox.Show("Değişiklik gerçekleşemedi.", "Dikkat!İşlem tamamlanamadı!");
                        txtFilmAdi.Focus();
                    }
                }
            }
            else
            {
                MessageBox.Show("Müşteri girmelisiniz.", "Eksik bilgi!");
                txtFilmAdi.Focus();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Silmek istiyor musunuz?", "Silinsin mi?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Film f = new Film();
                if (f.FilmSil(SecilenFilmNo))
                {
                    MessageBox.Show("Film silindi.", "Değişiklik gerçekleşti.");
                    Temizle();
                    btnDegistir.Enabled = false;
                    btnSil.Enabled = false;
                    f.FilmleriGoster(lvFilmler);
                }
                else
                {
                    MessageBox.Show("Silme gerçekleşemedi.", "Dikkat!İşlem tamamlanamadı!");
                    txtFilmAdi.Focus();
                }
            }
        }
    }
}
