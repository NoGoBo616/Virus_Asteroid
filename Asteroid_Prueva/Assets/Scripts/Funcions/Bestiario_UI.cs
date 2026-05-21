using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Bestiario_UI : MonoBehaviour
{
    [System.Serializable]
    public class DatosEnemigo
    {
        public string Nombre;

        [TextArea]
        public string Descripcion;

        public RuntimeAnimatorController ControladorAnimacion;
        public Sprite ImagenDelEnemigo;
    }

    [Header("UI Elements")]
    public TextMeshProUGUI TextoNombre;
    public TextMeshProUGUI TextoDescripcion;

    public Animator AnimadorEnemigo;
    public Image ImagenEnemigo;

    public Button BotonAnterior;
    public Button BotonSiguiente;

    [Header("Imagen Bloqueada")]
    public Sprite SpriteBloqueado; // 👈 imagen tipo silueta/candado

    [Header("Datos de los Enemigos")]
    public DatosEnemigo[] ListaEnemigos;

    private int paginaActual = 0;

    private void Start()
    {
        ActualizarPagina();
    }

    public void ActualizarPagina()
    {
        if (ListaEnemigos == null || ListaEnemigos.Length == 0)
            return;

        bool desbloqueado =
            Bestiario_Manager.Instance.EstaDesbloqueado(paginaActual);

        if (desbloqueado)
        {
            TextoNombre.text =
                ListaEnemigos[paginaActual].Nombre;

            TextoDescripcion.text =
                ListaEnemigos[paginaActual].Descripcion;

            // Imagen
            if (ImagenEnemigo != null)
            {
                ImagenEnemigo.sprite =
                    ListaEnemigos[paginaActual].ImagenDelEnemigo;
            }

            // Animación
            if (AnimadorEnemigo != null &&
                ListaEnemigos[paginaActual].ControladorAnimacion != null)
            {
                AnimadorEnemigo.runtimeAnimatorController =
                    ListaEnemigos[paginaActual].ControladorAnimacion;

                AnimadorEnemigo.Rebind();
                AnimadorEnemigo.Update(0f);
            }
        }
        else
        {
            TextoNombre.text = "???";

            TextoDescripcion.text =
                "Derrota a este enemigo para registrarlo en el bestiario.";

            // Imagen bloqueada
            if (ImagenEnemigo != null)
            {
                ImagenEnemigo.sprite = SpriteBloqueado;
            }

            // Quitar animación
            if (AnimadorEnemigo != null)
            {
                AnimadorEnemigo.runtimeAnimatorController = null;
            }
        }
    }

    public void CambiarPagina(int direccion)
    {
        paginaActual += direccion;

        if (paginaActual < 0)
            paginaActual = ListaEnemigos.Length - 1;

        if (paginaActual >= ListaEnemigos.Length)
            paginaActual = 0;

        ActualizarPagina();
    }
}

