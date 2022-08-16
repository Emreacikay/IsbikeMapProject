namespace JsonWebTokenAPI.Models
{
    public class Isbike
    {
        public int Id { get; set; }
        public int istasyon_no { get; set; }
        public string adi { get; set; }
        public bool aktif { get; set; }
        public int bos { get; set; }
        public int dolu { get; set; }
        public float lat { get; set; }
        public float lon { get; set; }
        public DateTime sonBaglanti { get; set; }

    }
}
