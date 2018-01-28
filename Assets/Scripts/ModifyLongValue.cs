using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ModifyLongValue : MonoBehaviour
{
    public enum Operation
    {
        Add,
        Subtract,
        Multiply,
        Set,
    }

    public long modifier;
    public LongValue longValue;
    public Operation operation;

    public void Modify()
    {
        switch (operation)
        {
            case Operation.Add:
                longValue.Value += modifier;
                break;

            case Operation.Subtract:
                longValue.Value -= modifier;
                break;

            case Operation.Multiply:
                longValue.Value *= modifier;
                break;

            case Operation.Set:
                longValue.Value = modifier;
                break;
        }
    }
}
