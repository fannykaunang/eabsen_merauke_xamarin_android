using System;

namespace NavDrawer.Model
{
    public class Pegawai
    {
        public int USERID { get; set; }
        public string NAMA_PEGAWAI { get; set; }
        //public string TEMPAT_LAHIR { get; set; }
        //public DateTime TGL_LAHIR { get; set; }
        //public string FOTO_FILEPATH { get; set; }
    }

    public class PegawaiImg
    {
        public PegawaiImg(string NAMA_PEGAWAI, int FOTO_FILEPATH)
        {
            this.NAMA_PEGAWAI = NAMA_PEGAWAI;
            //this.TEMPAT_LAHIR = TEMPAT_LAHIR;
            //this.TGL_LAHIR = TGL_LAHIR;
            //this.USERID = USERID;
            this.FOTO_FILEPATH = FOTO_FILEPATH;
        }

        public string NAMA_PEGAWAI { get; }
        public string TEMPAT_LAHIR { get; }
        public string TGL_LAHIR { get; }
        public int USERID { get; }
        public int FOTO_FILEPATH { get; }
    }
}