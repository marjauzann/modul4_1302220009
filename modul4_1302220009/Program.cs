public class Program
{
    public enum NamaBuah
    {
        Apel, Aprikot, Alpukat,
        Pisang, Paprika, Blackberry,
        Ceri, Kelapa, Jagung
    }

    public class KodeBuah
    {
        public NamaBuah namaBuah;
        public KodeBuah(NamaBuah namaBuah)
        {
            this.namaBuah = namaBuah;
        }
        String[] nomorKodeBuah =
        {
            "A00", "B00", "C00",
            "D00", "E00", "F00",
            "H00", "I00",
            "J00", "K00", "L00",
            "M00", "N00", "O00",
        };
        public String getKodeBuah()
        {
            return nomorKodeBuah[(int)namaBuah];
        }
    }
}