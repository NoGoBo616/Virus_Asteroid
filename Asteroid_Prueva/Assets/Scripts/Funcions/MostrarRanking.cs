using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class MostrarRanking : MonoBehaviour
{
    public TMP_Text textoRanking;
    public ArcadeManager arcadeManager;

    private void OnEnable()
    {
        arcadeManager = FindAnyObjectByType<ArcadeManager>();
        ActualizarRanking();
    }

    private void Update()
    {
        if (arcadeManager = null)
        {
            arcadeManager = FindAnyObjectByType<ArcadeManager>();
            ActualizarRanking();
        }
    }

    public void ActualizarRanking()
    {
        if (arcadeManager == null || textoRanking == null) return;

        // 1. Unimos las dos listas en una sola estructura para no perder la relación
        // Usamos Select para crear un objeto anónimo con Nombre y Puntos
        var listaCombinada = new List<EntradaRanking>();

        int cantidad = Mathf.Min(arcadeManager.listaNombres.Count, arcadeManager.listaPuntos.Count);
        for (int i = 0; i < cantidad; i++)
        {
            listaCombinada.Add(new EntradaRanking
            {
                nombre = arcadeManager.listaNombres[i],
                puntos = arcadeManager.listaPuntos[i]
            });
        }

        // 2. Ordenamos la lista de mayor a menor usando LINQ
        var listaOrdenada = listaCombinada.OrderByDescending(x => x.puntos).ToList();

        // 3. Construimos el texto final
        textoRanking.text = "RANKING: \n\n";

        for (int i = 0; i < listaOrdenada.Count; i++)
        {
            // Añadimos un formato visual (ej: 1º PEPE - 500)
            textoRanking.text += $"{i + 1}º {listaOrdenada[i].nombre} <color=#00FF00>{listaOrdenada[i].puntos} pts</color>\n";
        }
    }
}

[System.Serializable]
public class EntradaRanking
{
    public string nombre;
    public int puntos;
}