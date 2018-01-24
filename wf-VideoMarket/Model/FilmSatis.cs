using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf_VideoMarket.Model
{
    public class FilmSatis
    {
        //veri tabanın da oluşturduğun her tablo için bi class oluşturcan!!!
        //prop yaz iki kez tab tuşuna bas aynı diğerleri gibi oluyor ama daha kısa.şu an tanımladıklarımız properties

        #region Properties
        public int SatisNo { get; set; } //private larda _küçğk harf olucak
        public DateTime Tarih { get; set; }
        public int FilmNo { get; set; }
        public int MusteriNo { get; set; }
        public int Adet { get; set; }
        public decimal BirimFiyat { get; set; }
        #endregion

        SqlConnection conn = new SqlConnection(Genel.connStr);

        public void SatislariGoster(ListView liste, TextBox TopAdet, TextBox TopTutar) //textboxların referanslarını aldık
        {
            liste.Items.Clear();
            int TAdet = 0;
            decimal TTutar = 0;
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("Select SatisNo,Tarih,FilmAd,MusteriAd + ' ' + MusteriSoyad as Musteri, BirimFiyat, Adet, BirimFiyat * Adet as Tutar, Miktar, fs.FilmNo, fs.MusteriNo from FilmSatis fs inner join Filmler f on fs.FilmNo=f.FilmNo inner join Musteriler m on fs.MusteriNo=m.MusteriNo where fs.Silindi=0 order by SatisNo desc ", conn);
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                liste.Items.Add(dr[0].ToString());
                liste.Items[i].SubItems.Add(dr[1].ToString());
                liste.Items[i].SubItems.Add(dr[2].ToString());
                liste.Items[i].SubItems.Add(dr[3].ToString());
                liste.Items[i].SubItems.Add(string.Format("{0:#,##0}", Convert.ToDecimal(dr[4].ToString()))); //sayıyı üçer üçer gösterir,kuruş istiyosak .00 (0:#,##0.00)koycaz
                liste.Items[i].SubItems.Add(dr[5].ToString());
                liste.Items[i].SubItems.Add(string.Format("{0:#,##0}", Convert.ToDecimal(dr[6].ToString())));
                liste.Items[i].SubItems.Add(dr[7].ToString());
                liste.Items[i].SubItems.Add(dr[8].ToString());
                liste.Items[i].SubItems.Add(dr[9].ToString());
                TAdet += Convert.ToInt32(dr["Adet"]); //dr[5] yapılabilir.
                TTutar += Convert.ToDecimal(dr["Tutar"]); //dr[6]
                i++;
            }
            dr.Close();
            conn.Close();
            TopAdet.Text = TAdet.ToString();
            //TopTutar.Text = string.Format("{0:#,##0}", TTutar);
            TopTutar.Text = string.Format("{0:c}", TTutar); //kuruşlu ve sonuna tl gelir.
        }
        public DataTable SatislariGosterByTarihlerArasi(DateTime Tarih1, DateTime Tarih2) //geriye bi datatable döndürcez
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select Convert(Date,Tarih,104) as Tarih, FilmAd, MusteriAd + ' ' + MusteriSoyad as Musteri, BirimFiyat, Adet, BirimFiyat * Adet as Tutar from FilmSatis fs inner join Filmler f on fs.FilmNo=f.FilmNo inner join Musteriler m on fs.MusteriNo=m.MusteriNo where fs.Silindi=0 and Convert(Date,Tarih,104) between Convert(Date,@Tarih1,104) and Convert(Date,@Tarih2,104)", conn);
            da.SelectCommand.Parameters.Add("@Tarih1", SqlDbType.DateTime).Value = Tarih1;
            da.SelectCommand.Parameters.Add("@Tarih2", SqlDbType.DateTime).Value = Tarih2;
            try
            {
                da.Fill(dt); //execute ettiğimiz yer buraya brackpoint koy catch e düşerse sorguda hata var demek. sorguyu önce sql çalıştırırsan daha iyi olur.
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            return dt; //doldurduğumuz datatable döndürüyoruz.
        }
        public bool SatisEkle(FilmSatis yeni)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("Insert into FilmSatis(Tarih, FilmNo, MusteriNo, Adet, BirimFiyat) values(@Tarih, @FilmNo, @MusteriNo, @Adet, @BirimFiyat)", conn);
            comm.Parameters.Add("@Tarih", SqlDbType.DateTime).Value = yeni.Tarih;
            comm.Parameters.Add("@FilmNo", SqlDbType.Int).Value = yeni.FilmNo;
            comm.Parameters.Add("@MusteriNo", SqlDbType.Int).Value = yeni.MusteriNo;
            comm.Parameters.Add("@Adet", SqlDbType.Int).Value = yeni.Adet;
            comm.Parameters.Add("@BirimFiyat", SqlDbType.Money).Value = yeni.BirimFiyat;
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                Sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }
            return Sonuc;
        }
        public bool SatisGuncelle(FilmSatis guncel)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("Update FilmSatis Set Adet = @Adet, BirimFiyat = @BirimFiyat where SatisNo = @SatisNo", conn);
            comm.Parameters.Add("@SatisNo", SqlDbType.Int).Value = guncel.SatisNo;
            comm.Parameters.Add("@Adet", SqlDbType.Int).Value = guncel.Adet;
            comm.Parameters.Add("@BirimFiyat", SqlDbType.Money).Value = guncel.BirimFiyat;
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                Sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }
            return Sonuc;
        }
        public bool SatisSil(int SilinecekNo)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("Update FilmSatis set Silindi=1 where SatisNo=@SatisNo", conn);
            comm.Parameters.Add("@SatisNo", SqlDbType.Int).Value = SilinecekNo;
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                Sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }
            return Sonuc;
        }

    }
}
