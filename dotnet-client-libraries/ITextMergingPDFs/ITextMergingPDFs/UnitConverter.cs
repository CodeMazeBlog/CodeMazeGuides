namespace ITextMergingPDFs
{
    public static class UnitConverter
    {
        public static float uu2inch(float uu) => uu / 72f;
        public static float inch2uu(float inch) => inch * 72f;

        public static float inch2mm(float inch) => inch * 25.4f;
        public static float mm2inch(float mm) => mm / 25.4f;

        public static float uu2mm(float uu) => inch2mm(uu2inch(uu));
        public static float mm2uu(float mm) => inch2uu(mm2inch(mm));
    }
}
