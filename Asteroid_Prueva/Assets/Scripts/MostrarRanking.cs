using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MostrarRanking : MonoBehaviour
{
    public TMP_Text textoRanking;

    void Start()
    {
        ActualizarRanking();
    }

    public void VolverAlMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void ActualizarRanking()
    {
        if (RankingManager.instancia == null) return;

        textoRanking.text = "";
        var ranking = RankingManager.instancia.ObtenerRanking();

        for (int i = 0; i < ranking.Count; i++)
        {
            textoRanking.text += (i + 1) + ". " +
                                 ranking[i].nombre + " - " +
                                 ranking[i].puntos.ToString("D5") +
                                 " pts (" + ranking[i].fecha + ")\n";
        }
    }
}
