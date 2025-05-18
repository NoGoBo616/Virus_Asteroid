using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  
    public GameObject VFX;

    void Start()
    {
        Destroy(gameObject, 2f); // Destruye después de 2 segundos
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto golpeado es un clon (hijo del asteroide)
        if (other.CompareTag("AsteroidClone"))
        {
            Destroy(other.gameObject); 
            Destroy(this.gameObject);
            PointSystem pointSystem = other.gameObject.GetComponent<PointSystem>();
            if (pointSystem != null)
            {
                int points = pointSystem.points;
                GameManager.Instance.Puntuar(points);
            }
        }
    }
}
