using UnityEngine;

public class Detector_3D : MonoBehaviour
{
    public GameObject tabla_a_mostrar;
    public bool mouseEnOriginal = false;
    public bool mouseEnTabla = false;

    // Asignamos el evento a la tabla también al iniciar
    void Start()
    {
        // Añadimos un script auxiliar a la tabla dinámicamente si no lo tiene
        if (tabla_a_mostrar != null)
        {
            var detector = tabla_a_mostrar.GetComponent<DetectorRatonTabla>();
            if (detector == null) detector = tabla_a_mostrar.AddComponent<DetectorRatonTabla>();

            // Le pasamos una referencia de este script
            detector.scriptPadre = this;
        }
    }

    private void OnMouseEnter()
    {
        mouseEnOriginal = true;
        ActualizarEstadoTabla();
    }

    private void OnMouseExit()
    {
        mouseEnOriginal = false;
        // Damos un margen mínimo de tiempo para que el ratón cruce el espacio entre objetos
        Invoke("ActualizarEstadoTabla", 0.1f);
    }

    public void SetMouseEnTabla(bool encima)
    {
        mouseEnTabla = encima;
        ActualizarEstadoTabla();
    }

    void ActualizarEstadoTabla()
    {
        // Si el ratón está en cualquiera de los dos, la tabla se mantiene activa
        tabla_a_mostrar.SetActive(mouseEnOriginal || mouseEnTabla);
    }
}

public class DetectorRatonTabla : MonoBehaviour
{
    public Detector_3D scriptPadre;

    private void OnMouseEnter() => scriptPadre.SetMouseEnTabla(true);
    private void OnMouseExit() => scriptPadre.SetMouseEnTabla(false);
}
