﻿namespace LINQSortingAndFiltering
{
    public static class Extensions
    {
        public static List<T> RemoveNullFilter<T>(this List<T> list)
        {
            foreach (T item in list)
            {
                if(item == null)
                {
                    list.Remove(item);
                }
            }
            return list;
        }
    }
}
