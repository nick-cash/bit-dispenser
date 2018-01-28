using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GenerateBitsButton : SetBinaryString
{
    public LongValue bits;

    public void Generate()
    {
        bits.Value += numberOfBitsInString.Value;
        SetString();
    }
}
