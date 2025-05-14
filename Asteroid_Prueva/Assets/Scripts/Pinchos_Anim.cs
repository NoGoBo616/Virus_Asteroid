using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinchos_Anim : MonoBehaviour
{
    public GameObject prefab; // El prefab que quieres instanciar

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Obtiene el primer punto de contacto
        ContactPoint2D contact = collision.contacts[0];

        // Instancia el prefab en ese punto
        Instantiate(prefab, contact.point, Quaternion.identity);
    }
}
