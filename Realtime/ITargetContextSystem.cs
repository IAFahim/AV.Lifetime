namespace AV.Lifetime.Realtime
{
    // ===================================================================================
    // LAYER D: CONTRACT
    // ===================================================================================

    public interface ITargetContextSystem
    {
        TargetContextResult TryGetContext(out TargetContext context);
        void SetContext(in TargetContext context);
    }
}
