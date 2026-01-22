using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace AV.Lifetime.Realtime
{
    // ===================================================================================
    // LAYER A: DATA & DEFINITIONS
    // ===================================================================================

    public enum TargetContextResult
    {
        Success,
        NotFound,
        InvalidInput
    }

    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct TargetContext
    {
        public Transform Owner;
        public Transform Source;
        public Transform Target;
        public Transform Custom0;
        public Transform Custom1;

        // ⭐️ DEBUG CARD
        public override string ToString()
        {
            return $"[CTX] O:{N(Owner)} S:{N(Source)} T:{N(Target)}";
            
            static string N(Transform t) => t ? t.name : "null";
        }
    }
}
