using System;
using UnityEngine;

[CreateAssetMenu(fileName = "LongValue", menuName = "Data/LongValue")]
public class LongValue : ScriptableObject
{
    [SerializeField]
    private long value;

    [SerializeField]
    private long startingValue;

    public event Action<long> onUpdate;

    public long Value
    {
        get { return this.value; }
        set
        {
            this.value = value;

            if (onUpdate != null)
            {
                onUpdate(this.value);
            }
        }
    }

    private void OnEnable()
    {
        value = startingValue;
    }
}
