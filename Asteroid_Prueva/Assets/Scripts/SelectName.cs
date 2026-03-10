using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectName : MonoBehaviour
{
    public TMP_InputField inputText;
    public TMP_Text textoNombre;
    public Image luz;
    public GameObject botonAceptar;

    private void Awake()
    {
        luz.color = Color.red;
    }

    private void Update()
    {
        textoNombre.text = inputText.text;
        if (textoNombre.text.Length < 2)
        {
            luz.color = Color.red;
            botonAceptar.SetActive(false);
        }
        else
        {
            luz.color = Color.green;
            botonAceptar.SetActive(true);
        }
    }

    public void Aceptar()
    {
        string nombre = inputText.text;

        // Guardamos el nombre en ArcadeManager
        ArcadeManager.instancia.nombreJugador = nombre;

        // Cambiamos a la escena principal
       
    }
}
