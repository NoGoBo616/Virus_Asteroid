using UnityEngine;
using TMPro;

public class BestiarioInteractuable : MonoBehaviour
{
    [Header("UI")]
    public GameObject panelBestiario;

    [Header("Páginas")]
    public GameObject[] paginas;

    [Header("Enemigos")]
    public GameObject[] enemigos;

    [Header("Texto ???")]
    public TextMeshProUGUI[] textosBloqueados;

    private int paginaActual = 0;

    private void OnEnable()
    {
        MostrarPagina(paginaActual);
    }

    private void OnMouseDown()
    {
        Debug.Log("Bestiario interactuado. Abriendo menú...");
        AbrirMenu();
    }

    public void AbrirMenu()
    {
        panelBestiario.SetActive(true);
        MostrarPagina(paginaActual);
    }

    public void CerrarMenu()
    {
        panelBestiario.SetActive(false);
    }

    public void PaginaSiguiente()
    {
        if (paginaActual < paginas.Length - 1)
        {
            paginaActual++;
            MostrarPagina(paginaActual);
        }
    }

    public void PaginaAnterior()
    {
        if (paginaActual > 0)
        {
            paginaActual--;
            MostrarPagina(paginaActual);
        }
    }

    void MostrarPagina(int index)
    {
        for (int i = 0; i < paginas.Length; i++)
        {
            bool esActual = (i == index);

            paginas[i].SetActive(esActual);

            if (!esActual)
                continue;

            bool desbloqueado = false;

            if (Bestiario_Manager.Instance != null &&
                Bestiario_Manager.Instance.enemigosDesbloqueados != null &&
                i < Bestiario_Manager.Instance.enemigosDesbloqueados.Length)
            {
                desbloqueado = Bestiario_Manager.Instance.enemigosDesbloqueados[i];
            }

            if (desbloqueado)
            {
                if (enemigos[i] != null)
                    enemigos[i].SetActive(true);

                if (textosBloqueados[i] != null)
                    textosBloqueados[i].gameObject.SetActive(false);
            }
            else
            {
                if (enemigos[i] != null)
                    enemigos[i].SetActive(false);

                if (textosBloqueados[i] != null)
                {
                    textosBloqueados[i].gameObject.SetActive(true);
                    textosBloqueados[i].text = "???";
                }
            }
        }
    }
}

