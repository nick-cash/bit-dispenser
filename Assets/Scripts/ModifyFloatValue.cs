using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ModifyFloatValue : MonoBehaviour
{
    public enum Operation
    {
        Add,
        Subtract,
        Multiply,
        Set,
    }

    public float modifier;
    public FloatValue floatValue;
    public Operation operation;

    public void Modify()
    {
        switch (operation)
        {
            case Operation.Add:
                floatValue.Value += modifier;
                break;

            case Operation.Subtract:
                floatValue.Value -= modifier;
                break;

            case Operation.Multiply:
                floatValue.Value *= modifier;
                break;

            case Operation.Set:
                floatValue.Value = modifier;
                break;
        }
    }
}
