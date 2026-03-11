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
    public ArcadeManager managDePuntos;

    private void OnEnable()
    {
        managDePuntos = FindAnyObjectByType<ArcadeManager>();
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
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

    private void Update()
    {
        managDePuntos.puntuacion = points;
    }

    public void Reiniciar()
    {
        points = 0;
    }

    public void Puntuar(int pointsToSum)
    {
        points = points + pointsToSum;
        title.text = points.ToString();
        StaticPoints.points= points;
    }

    private void OnDisable()
    {
        //managDePuntos.GuardarDatos(managDePuntos.nombreJugador, managDePuntos.puntuacion);
    }
}

