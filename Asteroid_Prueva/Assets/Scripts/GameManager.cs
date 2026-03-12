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
        

        // Reinicia la puntuación en ArcadeManager
        if (ArcadeManager.instancia != null)
            ArcadeManager.instancia.puntuacion = 0;

        // Aquí puedes actualizar la UI si tienes un UIManager
        // if (UIManager.Instance != null)
        //     UIManager.Instance.ActualizarPuntos(puntos);

        // Reactivar el panel o reiniciar la escena si es necesario
        Time.timeScale = 1; // Asegúrate de despausar el juego
    }

    public void Puntuar(int pointsToSum)
    {
        points = points + pointsToSum;
        title.text = points.ToString();
        StaticPoints.points= points;
        managDePuntos.GuardarDatos(managDePuntos.nombreJugador, managDePuntos.puntuacion);
    }
}

