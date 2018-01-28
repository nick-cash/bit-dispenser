using System;
using UnityEngine;
using UnityEngine.UI;

public class LongValueTextUpdater : MonoBehaviour
{
    public Text text;
    public LongValue longValue;
    public int numericBase = 10;
    public string format = "{0}";

    private void Update()
    {
        text.text = string.Format(format, Convert.ToString(longValue.Value, numericBase));
    }
}
