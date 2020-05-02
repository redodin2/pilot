using System;
using System.Collections.Generic;
using System.Text;

namespace MainApp.Shared.FP
{
    public static class Extenstions
    {
        public static K Map<T, K>(this T t, Func<T, K> f) where T : notnull => f(t);

        public static void Do<T>(this T t, Action<T> f) where T : notnull => f(t);
        public static T Effect<T>(this T t, Action<T> f) where T : notnull { f(t); return t; }

        public static void IfSome<T>(this T? t, Action<T> f) where T : class => t?.Do(f);
        public static void IfSome<T>(this T? t, Action<T> f) where T : struct => t?.Do(f);
    }
}
