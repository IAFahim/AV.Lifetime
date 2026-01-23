using System.Runtime.CompilerServices;
using AV.Unity.Extend.Runtime.Cache;
using UnityEngine;

namespace AV.Lifetime.Realtime
{
    /// <summary>
    /// Logic for target resolution and component caching.
    /// NOTE: TryLazyResolveComponent uses managed types (Component) and is NOT Burst-compatible.
    /// This is main-thread only logic - do not use in Burst Jobs.
    /// </summary>
    public static class TargetLogic
    {
        /// <summary>
        /// Lazily resolves a component reference with caching.
        /// WARNING: NOT Burst-compatible - uses Unity Component (managed type).
        /// For main-thread only use.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryLazyResolveComponent<T>(
            this ref LazyCache<T> cache,
            in Transform root,
            out T component)
        {
            if (cache.IsCached)
            {
                component = cache.Reference;
                return cache.Exists;
            }

            if (root == null)
            {
                component = default;
                cache.IsCached = true; // Cached null
                cache.Exists = false;
                return false;
            }

            cache.Exists = root.TryGetComponent(out cache.Reference);
            cache.IsCached = true;

            component = cache.Reference;
            return cache.Exists;
        }


        /// <summary>
        /// Gets a Transform based on ETarget enum.
        /// WARNING: NOT Burst-compatible - uses Unity Transform (managed type).
        /// For main-thread only use.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetTransform(in Transform self, in TargetContext targetContext, in ETarget target,
            out Transform transform)
        {
            switch (target)
            {
                case ETarget.Self: transform = self; break;
                case ETarget.Owner: transform = targetContext.Owner; break;
                case ETarget.Source: transform = targetContext.Source; break;
                case ETarget.Target: transform = targetContext.Target; break;
                case ETarget.Custom0: transform = targetContext.Custom0; break;
                case ETarget.Custom1: transform = targetContext.Custom1; break;
                default:
                    transform = null;
                    return false;
            }

            return transform != null;
        }


        /// <summary>
        /// Resolves a component from a target cache group.
        /// WARNING: NOT Burst-compatible - uses generic Component types.
        /// For main-thread only use.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryResolveGroup<T>(
            in Transform self,
            ref TargetCacheGroup<T> targetCacheGroup,
            in TargetContext targetContext,
            in ETarget target,
            out T component) where T : Component
        {
            if (!TryGetTransform(self, targetContext, target, out var transform))
            {
                component = null;
                return false;
            }

            switch (target)
            {
                case ETarget.Self: return targetCacheGroup.Self.TryLazyResolveComponent(in transform, out component);
                case ETarget.Owner: return targetCacheGroup.Owner.TryLazyResolveComponent(in transform, out component);
                case ETarget.Source: return targetCacheGroup.Source.TryLazyResolveComponent(in transform, out component);
                case ETarget.Target: return targetCacheGroup.Target.TryLazyResolveComponent(in transform, out component);
                case ETarget.Custom0: return targetCacheGroup.Custom0.TryLazyResolveComponent(in transform, out component);
                case ETarget.Custom1: return targetCacheGroup.Custom1.TryLazyResolveComponent(in transform, out component);
                default:
                    component = null;
                    return false;
            }
        }
    }
}
