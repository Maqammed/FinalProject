using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants //*Constants == Sabit (Proje sabitleri)
{
    public static class Messages //*static deyende newlenmeyen class olur yeniki newlemerik hecvaxt,bele sabit seylerde isdifade olunur https://youtu.be/NlAj9dT3MiA?t=5660
    {
        public static string ProductAdded = "Urun eklendi"; //bunlar public'dir deye bas herifi boyuk yazilir,ama normalda kicik yazilir (PascalCase)
        public static string ProductNameInvalid = "Urun Ismi gecersiz";
        public static string MaintenanceTime = "Sistem bakimda";
        public static string ProductListed = "Urunler listelendi";

        public static string ProductCountOfCategoryError = "En fazla 10 kategori ola bilir";

        public static string ProductNameAlreadyExists = "Urun ismi zaten var";
        public static string CategoryLimitExists = "Categori limiti asildigi icin urun eklenemiyor";
    }
}
