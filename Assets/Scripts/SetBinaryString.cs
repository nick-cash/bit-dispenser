using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SetBinaryString : MonoBehaviour
{
    public Text text;
    public LongValue numberOfBitsInString;

    private readonly List<string> BIT_VALUES = new List<string>{ "0", "1" };

    public void SetString()
    {
        text.text = GetBitString();
    }

    protected string GetBitString()
    {
        var stringBuilder = new StringBuilder();

        for (var i = 0; i < numberOfBitsInString.Value; i++)
        {
            stringBuilder.Append(BIT_VALUES[Random.Range(0, BIT_VALUES.Count)]);
        }

        return stringBuilder.ToString();
    }

    private void Start()
    {
        SetString();
    }
}
