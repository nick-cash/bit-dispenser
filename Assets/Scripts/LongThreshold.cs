using System;
using UnityEngine;
using UnityEngine.Events;

public class LongThreshold : MonoBehaviour
{
    [Serializable]
    public class LongOrLongValue
    {
        [SerializeField]
        private long value;

        [SerializeField]
        public LongValue longValue;

        public long Value
        {
            get
            {
                if (longValue != null)
                {
                    return longValue.Value;
                }

                return value;
            }
        }
    }

    public LongOrLongValue threshold;
    public LongValue valueToWatch;
    public UnityEvent onThresholdMet;

    private void Start()
    {
        valueToWatch.onUpdate += OnUpdate;
    }

    private void OnUpdate(long value)
    {
        if (value >= threshold.Value)
        {
            onThresholdMet.Invoke();
            valueToWatch.onUpdate -= OnUpdate;
        }
    }
}
