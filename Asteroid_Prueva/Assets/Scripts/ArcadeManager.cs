using UnityEngine;

public class ArcadeManager : MonoBehaviour
{
    public static ArcadeManager instancia;
    public string nombreJugador;
    public int puntuacion;

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
        PlayerPrefs.SetString("NombreJugador", nombreJugador);
        PlayerPrefs.SetInt("Puntuacion", puntuacion);
        PlayerPrefs.Save();

        if (RankingManager.instancia != null)
            RankingManager.instancia.GuardarPartida(nombreJugador, puntuacion);
    }


}
