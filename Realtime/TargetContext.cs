using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace AV.Lifetime.Realtime
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct TargetContext
    {
        public Transform Owner;
        public Transform Source;
        public Transform Target;
        public Transform Custom0;
        public Transform Custom1;
    }
}