using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class BinaryDropper : MonoBehaviour
{
    public float chanceToSpawn;
    public Transform container;
    public GameObject textPrefab;

    private void Update()
    {
        if (Random.value <= chanceToSpawn)
        {
            var newBitDrop = Instantiate(textPrefab, container);

            var newX = Random.value * 800 * (Random.value > 0.5 ? 1 : -1);

            var newBitDropTransform = newBitDrop.transform;

            newBitDropTransform.localPosition = new Vector3(newX, newBitDropTransform.localPosition.y, newBitDropTransform.localPosition.z);
        }
    }
}
