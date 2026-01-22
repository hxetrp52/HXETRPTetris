public class GameTimer
{
    public float Duration { get; private set; }
    public float Elapsed { get; private set; }
    public bool IsUnscaled { get; private set; }

    public bool IsFinished => Elapsed >= Duration;

    private System.Action onComplete;

    public GameTimer(float duration, bool unscaled, System.Action onComplete)
    {
        Duration = duration;
        IsUnscaled = unscaled;
        this.onComplete = onComplete;
    }

    public void TimerUpdate(float dt)
    {
        Elapsed += dt;

        if (IsFinished)
            onComplete?.Invoke();
    }
}
