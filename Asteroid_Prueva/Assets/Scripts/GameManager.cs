using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int points;

    private void Start()
    {
        Reiniciar();
    }

    public void Reiniciar()
    {
        points = 0;
    }

    public void Puntuar()
    {
        points = points + 100;
        Debug.Log(points);
    }
}
