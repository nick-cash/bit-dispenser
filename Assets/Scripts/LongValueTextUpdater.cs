using System;
using UnityEngine;
using UnityEngine.UI;

public class LongValueTextUpdater : MonoBehaviour
{
    public Text text;
    public LongValue longValue;
    public int numericBase = 10;

    private void Update()
    {
        text.text = Convert.ToString(longValue.value, numericBase);
    }
}
