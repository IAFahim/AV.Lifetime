using UnityEngine;

namespace AV.Lifetime.Realtime
{
    // ===================================================================================
    // LAYER D: BRIDGE & COMPONENT
    // ===================================================================================

    /// <summary>
    /// Component that holds the Context (Owner, Source, Target, etc.) for the lifetime of an object.
    /// Access via ITargetContextSystem.
    /// </summary>
    [AddComponentMenu("AV/Lifetime/Target Context Component")]
    public sealed class TargetContextComponent : MonoBehaviour, ITargetContextSystem
    {
        [SerializeField] 
        private TargetContext _context;

        // -- ITargetContextSystem Implementation --

        TargetContextResult ITargetContextSystem.TryGetContext(out TargetContext context)
        {
            context = _context;
            return TargetContextResult.Success;
        }

        void ITargetContextSystem.SetContext(in TargetContext context)
        {
            _context = context;
        }

        // -- Debug --
        [ContextMenu("⚡ Debug: Log Context")]
        private void DebugLogContext()
        {
            Debug.Log(_context.ToString());
        }
    }
}
