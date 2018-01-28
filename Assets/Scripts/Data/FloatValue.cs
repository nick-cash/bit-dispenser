using System;
using UnityEngine;

[CreateAssetMenu(fileName = "FloatValue", menuName = "Data/FloatValue")]
public class FloatValue : ScriptableObject
{
    [SerializeField]
    private float value;

    [SerializeField]
    private float startingValue;

    public event Action<float> onUpdate;

    public float Value
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
