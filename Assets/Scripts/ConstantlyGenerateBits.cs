using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ConstantlyGenerateBits : MonoBehaviour
{
    public Text label;
    public LongValue bits;
    public LongValue bitsPerSecond;

    private float time;
    private float fractionalBits;
    private long bitsGenerated;

    public void Start()
    {
        StartCoroutine(Generate());
    }

    private void Update()
    {
        var bitsPerSecond = (long)Math.Round((bitsGenerated / Math.Max(time, 1)));
        label.text = string.Format("{0} bits / second", bitsPerSecond);
    }

    private IEnumerator Generate()
    {
        while (true)
        {
            time += Time.deltaTime;

            fractionalBits += (bitsPerSecond.Value * Time.deltaTime);

            if (fractionalBits > 1.0f)
            {
                var newBits = (long)fractionalBits;
                fractionalBits -= newBits;

                bits.Value += newBits;
                bitsGenerated += newBits;
            }

            yield return null;
        }
    }
}
