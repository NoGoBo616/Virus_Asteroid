using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crono : MonoBehaviour
{
    public float segundos;
    public int minutos;
    public PointSystem puntos;

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

        if (minutos > 1)
        {
            if (puntos.points < 5000)
            {
                SceneManager.LoadScene(5);
                gameObject.SetActive(false);
            }
            else
            {
                SceneManager.LoadScene(6);
                gameObject.SetActive(false);
            }
        }
    }
}
