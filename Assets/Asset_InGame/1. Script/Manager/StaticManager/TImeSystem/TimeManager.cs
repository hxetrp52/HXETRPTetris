using System.Collections.Generic;
using UnityEngine;

public class TimeManager : ManagerBase
{
    public float DefaultTime { get; private set; }
    public float DeltaTime { get; private set; }
    public float UnScaleDeltaTime { get; private set; }

    private readonly List<GameTimer> timers = new();

    public override void Init()
    {

    }

    public override void ManagerUpdate()
    {
        DefaultTime = Time.time;
        DeltaTime = Time.deltaTime;
        UnScaleDeltaTime = Time.unscaledDeltaTime;

        for (int i = timers.Count - 1; i >= 0; i--)
        {
            var t = timers[i];
            float dt = t.IsUnscaled ? UnScaleDeltaTime : DeltaTime;

            t.TimerUpdate(dt);

            if (t.IsFinished)
                timers.RemoveAt(i);
        }
    }

    public GameTimer StartTimer(float duration, bool unscaled, System.Action onComplete)
    {
        var timer = new GameTimer(duration, unscaled, onComplete);
        timers.Add(timer);
        return timer;
    }
}
