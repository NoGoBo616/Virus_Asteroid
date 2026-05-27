using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ArcadeManager : MonoBehaviour
{
    public static ArcadeManager instancia;
    public string nombreJugador;
    public int puntuacion;
    public List<string> listaNombres = new List<string>();
    public List<int> listaPuntos = new List<int>();

    [Header("Comprovar")]
    public bool[] llaves;

    private void Update()
    {
        if (listaPuntos.Max() >= 0)
        {
            llaves[0] = true;
        }
        if (listaPuntos.Max() >= 4000)
        {
            llaves[1] = true;
        }
        if (listaPuntos.Max() >= 6000)
        {
            llaves[2] = true;
        }
        if (listaPuntos.Max() >= 7000)
        {
            llaves[3] = true;
        }
    }

    // Guardar nombre y puntuación actual
    public void GuardarDatos(string nombre, int puntos)
    {
        nombreJugador = nombre;
        puntuacion = puntos;

        // Guardar también en PlayerPrefs para persistencia
        PlayerPrefs.SetString("NombreJugador", nombreJugador);
        PlayerPrefs.SetInt("Puntuacion", puntuacion);
        PlayerPrefs.Save();
    }

    // Cargar datos guardados
    public void CargarDatos()
    {
        nombreJugador = PlayerPrefs.GetString("NombreJugador", "AAA");
        puntuacion = PlayerPrefs.GetInt("Puntuacion", 0);
    }

    public void FinalizarPartida()
    {
        listaNombres.Add(nombreJugador);
        listaPuntos.Add(puntuacion);

        PlayerPrefs.SetString("NombreJugador", nombreJugador);
        PlayerPrefs.SetInt("Puntuacion", puntuacion);
        PlayerPrefs.Save();

        if (RankingManager.instancia != null)
            RankingManager.instancia.GuardarPartida(nombreJugador, puntuacion);
    }


}
