using UnityEngine;
using UnityEngine.Events;

public class LongThreshold : MonoBehaviour
{
    public long threshold;
    public LongValue valueToWatch;
    public UnityEvent onThresholdMet;

    private void Start()
    {
        valueToWatch.onUpdate += OnUpdate;
    }

    private void OnUpdate(long value)
    {
        if (value >= threshold)
        {
            onThresholdMet.Invoke();
        }
    }
}
