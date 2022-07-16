namespace ActionAndFuncDelegatesInCSharp;

static class Helper
{
    public static T Map<T, K>(this K obj, Func<K, T> mapper) => mapper.Invoke(obj);
}
