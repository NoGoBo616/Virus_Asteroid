using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Partida
{
    public string nombre;
    public int puntos;
    public string fecha;

    public Partida(string n, int p)
    {
        nombre = n;
        puntos = p;
        fecha = System.DateTime.Now.ToString("dd/MM/yyyy HH:mm");
    }
}

[System.Serializable]
public class Historial
{
    public List<Partida> partidas = new List<Partida>();
}

public class RankingManager : MonoBehaviour
{
    public static RankingManager instancia;
    private Historial historial = new Historial();
    private string key = "RankingJSON";

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
            CargarRanking();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Guardar nombre y puntos de una partida
    public void GuardarPartida(string nombre, int puntos)
    {
        historial.partidas.Add(new Partida(nombre, puntos));

        // Orden descendente por puntos
        historial.partidas.Sort((a, b) => b.puntos.CompareTo(a.puntos));

        // Limitar a 10 partidas (opcional)
        if (historial.partidas.Count > 10)
            historial.partidas.RemoveRange(10, historial.partidas.Count - 10);

        // Guardar en PlayerPrefs
        string json = JsonUtility.ToJson(historial);
        PlayerPrefs.SetString(key, json);
        PlayerPrefs.Save();
    }

    public List<Partida> ObtenerRanking()
    {
        return historial.partidas;
    }

    private void CargarRanking()
    {
        if (PlayerPrefs.HasKey(key))
        {
            string json = PlayerPrefs.GetString(key);
            historial = JsonUtility.FromJson<Historial>(json);
        }
    }

}
