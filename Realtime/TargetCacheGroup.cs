using System;
using System.Runtime.InteropServices;
using AV.Unity.Extend.Runtime.Cache;

namespace AV.Lifetime.Realtime
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct TargetCacheGroup<T>
    {
        public LazyCache<T> Self;
        public LazyCache<T> Owner;
        public LazyCache<T> Source;
        public LazyCache<T> Target;
        public LazyCache<T> Custom0;
        public LazyCache<T> Custom1;
    }
}