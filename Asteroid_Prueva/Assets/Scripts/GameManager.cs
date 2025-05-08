using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int points;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Reiniciar();
        points = 0;
    }

    public void Reiniciar()
    {
        points = 0;
    }

    public void Puntuar()
    {
        points = points + 100;
    }
}
