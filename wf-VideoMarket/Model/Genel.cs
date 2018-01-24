using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wf_VideoMarket.Model
{
    public class Genel
    {
        //bağlantı ayarlarını koyacağımız genel bi class açtık.static ler classlarını new le objeye dönüştürmeden class adına ulaşabiliyoduk. connStr değişken

        public static string connStr = "Data Source=LENOVO-PC\\MSSQL2016; Initial Catalog=VideoMarket; uid=sa; pwd=123416";

        //bilgileri taşımak için buraya static bilgiler koyabiliriz.(satış ekranına seçilen müşteri adı ve filmi getirtmek için burda tanımladık.) //istediğimiz yerde genel. diye bunları kullanabiliriz.
        public static int secilenfilmno;
        public static string secilenfilm;
        public static int secilenmiktar;
        public static decimal secilenfiyat;
        public static int secilenmusterino;
        public static string secilenmusteri;
    }
}
