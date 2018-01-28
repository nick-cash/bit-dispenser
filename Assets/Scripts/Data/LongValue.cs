using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LongValue", menuName = "Data/LongValue")]
public class LongValue : ScriptableObject
{
    public long value;
    public long startingValue;

    private void OnEnable()
    {
        value = startingValue;
    }
}
