using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacion_Personaje : MonoBehaviour
{
    private Quaternion initialRotation;

    void Start()
    {
        initialRotation = transform.rotation; // Guarda la rotación inicial
    }

    void LateUpdate()
    {
        transform.rotation = initialRotation; // Restaura la rotación cada frame
    }
}
