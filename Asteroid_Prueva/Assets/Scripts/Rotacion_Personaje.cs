using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacion_Personaje : MonoBehaviour
{
    private Quaternion initialRotation;

    void Start()
    {
        initialRotation = transform.rotation; // Guarda la rotaci�n inicial
    }

    void LateUpdate()
    {
        transform.rotation = initialRotation; // Restaura la rotaci�n cada frame
    }
}
