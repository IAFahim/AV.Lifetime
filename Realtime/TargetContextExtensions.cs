using UnityEngine;

namespace AV.Lifetime.Realtime
{
    // ===================================================================================
    // LAYER C: API (TryX Extensions)
    // ===================================================================================

    public static class TargetContextExtensions
    {
        public static TargetContextResult TryGetTarget(
            this ref TargetContext context, 
            Transform self, 
            ETarget targetType, 
            out Transform result)
        {
            if (TargetContextLogic.TryGetTransform(in self, in context, in targetType, out result))
            {
                return TargetContextResult.Success;
            }
            
            result = null;
            return TargetContextResult.NotFound;
        }
    }
}
