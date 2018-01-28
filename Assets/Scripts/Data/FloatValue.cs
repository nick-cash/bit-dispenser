using UnityEngine;

[CreateAssetMenu(fileName = "FloatValue", menuName = "Data/FloatValue")]
public class FloatValue : ScriptableObject
{
    public float value;
    public float startingValue;

    private void OnEnable()
    {
        value = startingValue;
    }
}
