using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateBitsButton : MonoBehaviour
{
    public LongValue bits;
    public Text buttonText;

    private readonly List<string> BIT_VALUES = new List<string>{ "0", "1" };

    public void Generate()
    {
        bits.Value++;
        buttonText.text = BIT_VALUES[Random.Range(0, BIT_VALUES.Count)];
    }
}
