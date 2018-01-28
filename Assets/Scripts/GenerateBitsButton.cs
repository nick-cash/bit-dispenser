using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GenerateBitsButton : MonoBehaviour
{
    public LongValue bits;
    public LongValue bitsPerClick;
    public Text buttonText;

    private readonly List<string> BIT_VALUES = new List<string>{ "0", "1" };

    public void Generate()
    {
        bits.Value += bitsPerClick.Value;
        buttonText.text = GetBitString();
    }

    private string GetBitString()
    {
        var stringBuilder = new StringBuilder();

        for (var i = 0; i < bitsPerClick.Value; i++)
        {
            stringBuilder.Append(BIT_VALUES[Random.Range(0, BIT_VALUES.Count)]);
        }

        return stringBuilder.ToString();
    }
}
