namespace ReturnNullFromAGenericMethod
{
    public static class ValueTypeHelpers
    {
        public static T? FindItem<T>(List<T> items, T id) where T : struct
        {
            return null;
        }
    }
}
