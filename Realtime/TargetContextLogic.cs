using System.Runtime.CompilerServices;
using AV.Unity.Extend.Runtime.Cache;
using UnityEngine;

namespace AV.Lifetime.Realtime
{
    // ===================================================================================
    // LAYER B: LOGIC (Stateless)
    // ===================================================================================

    public static class TargetContextLogic
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetTransform(
            in Transform self,
            in TargetContext context,
            in ETarget targetType,
            out Transform result)
        {
            switch (targetType)
            {
                case ETarget.Self: result = self; break;
                case ETarget.Owner: result = context.Owner; break;
                case ETarget.Source: result = context.Source; break;
                case ETarget.Target: result = context.Target; break;
                case ETarget.Custom0: result = context.Custom0; break;
                case ETarget.Custom1: result = context.Custom1; break;
                default:
                    result = null;
                    return false;
            }
            return result != null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryResolveGroup<T>(
            in Transform self,
            ref TargetCacheGroup<T> cacheGroup,
            in TargetContext context,
            in ETarget targetType,
            out T component) where T : Component
        {
            // 1. Resolve Transform
            if (!TryGetTransform(self, context, targetType, out var transform))
            {
                component = null;
                return false;
            }

            // 2. Resolve Component from Cache
            switch (targetType)
            {
                case ETarget.Self: return cacheGroup.Self.TryLazyResolveComponent(in transform, out component);
                case ETarget.Owner: return cacheGroup.Owner.TryLazyResolveComponent(in transform, out component);
                case ETarget.Source: return cacheGroup.Source.TryLazyResolveComponent(in transform, out component);
                case ETarget.Target: return cacheGroup.Target.TryLazyResolveComponent(in transform, out component);
                case ETarget.Custom0: return cacheGroup.Custom0.TryLazyResolveComponent(in transform, out component);
                case ETarget.Custom1: return cacheGroup.Custom1.TryLazyResolveComponent(in transform, out component);
                default:
                    component = null;
                    return false;
            }
        }
    }
}
