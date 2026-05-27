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

    [Header("Textos de Descripción")]
    public TextMeshProUGUI[] textosDescripcion;

    private int paginaActual = 0;

    private void Start()
    {
        // El bestiario inicia cerrado
        panelBestiario.SetActive(false);

        // Nos aseguramos de que el cursor esté libre al empezar el juego
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Al hacer clic en el objeto 3D del mundo
    private void OnMouseDown()
    {
        // Solo lo abrimos si está cerrado
        if (!panelBestiario.activeSelf)
        {
            AbrirBestiario();
        }
    }

    public void AbrirBestiario()
    {
        panelBestiario.SetActive(true);
        MostrarPagina(paginaActual);

        // Al abrir, el mouse debe estar libre para usar los botones del libro
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CerrarBestiario()
    {
        panelBestiario.SetActive(false);

        // ¡AQUÍ ESTABA EL ERROR! 
        // Dejamos el cursor VISIBLE y LIBRE para poder volver a hacer clic en el objeto 3D
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
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
                if (enemigos[i] != null) enemigos[i].SetActive(true);
                if (textosBloqueados[i] != null) textosBloqueados[i].gameObject.SetActive(false);
                if (i < textosDescripcion.Length && textosDescripcion[i] != null) textosDescripcion[i].gameObject.SetActive(true);
            }
            else
            {
                if (enemigos[i] != null) enemigos[i].SetActive(false);
                if (textosBloqueados[i] != null)
                {
                    textosBloqueados[i].gameObject.SetActive(true);
                    textosBloqueados[i].text = "???";
                }
                if (i < textosDescripcion.Length && textosDescripcion[i] != null) textosDescripcion[i].gameObject.SetActive(false);
            }
        }
    }
}