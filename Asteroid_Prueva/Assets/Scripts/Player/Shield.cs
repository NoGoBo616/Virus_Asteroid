using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GolpeCinemachine shake;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto golpeado es un clon (hijo del asteroide)
        if (other.CompareTag("AsteroidClone") || other.CompareTag("Flora") || other.CompareTag("Asteroid") || other.CompareTag("Police"))
        {
            shake.Sehekear();
            Destroy(other.gameObject);
        }
    }
}
