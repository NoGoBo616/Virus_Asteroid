using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crono : MonoBehaviour
{
    public float segundos;
    public int minutos;

    private void OnEnable()
    {
        segundos = 0;
        minutos = 0;
    }

    private void OnDisable()
    {
        segundos = 0;
        minutos = 0;
    }

    private void Update()
    {
        segundos = segundos + 0.01f;

        if (segundos >= 60.0f)
        {
            minutos = minutos + 1;
            segundos = 0.0f;
        }

        if (minutos > 5)
        {
            SceneManager.LoadScene(3);
        }
    }
}
