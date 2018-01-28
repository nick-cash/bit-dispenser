using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DieOnTriggerEnter2D : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);
    }
}
