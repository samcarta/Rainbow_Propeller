using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            UnityEngine.Debug.Log("Key Collected!");

            // TODO: Game Win - UI?

            Destroy(gameObject);
        }
    }
}
