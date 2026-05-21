using UnityEngine;

public class Boton_Bestiario_Toggle : MonoBehaviour
{
    [Header("Paneles de la UI")]
    public GameObject panelBestiario;     // El panel que contiene todo tu bestiario
    public GameObject panelMenuPrincipal; // Opcional: Tu menú normal (déjalo vacío si no quieres que se oculte)

    [Header("Referencias de Scripts")]
    public Bestiario_UI scriptUIBestiario; // Referencia al script que maneja las páginas

    // Esta función la vincularemos al botón único
    public void AlternarBestiario()
    {
        if (panelBestiario == null) return;

        // Detectamos si el bestiario está activo actualmente y lo invertimos
        bool activar = !panelBestiario.activeSelf;

        // Activamos o desactivamos el bestiario
        panelBestiario.SetActive(activar);

        // Opcional: Si pusiste el menú principal, hace lo contrario que el bestiario
        if (panelMenuPrincipal != null)
        {
            panelMenuPrincipal.SetActive(!activar);
        }

        // Si el bestiario se acaba de abrir, actualizamos la página e información
        if (activar && scriptUIBestiario != null)
        {
            scriptUIBestiario.ActualizarPagina();
        }
    }
}