using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public int points;
    [SerializeField]
    private TMP_Text title;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
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

    public void Puntuar(int pointsToSum)
    {
        points = points + pointsToSum;
        Debug.Log("Puntuaci�n acumulada "+points);
        title.text = points.ToString();
        StaticPoints.points= points;
    }
}

