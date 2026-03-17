using UnityEngine;

public class Boton3D : MonoBehaviour
{
    [Header("Mapa")]
    public Scene_Cambio scene;
    public int mapSelected;

    [Header("Vectores de tamaño")]
    public Vector3 normalScale;
    public Vector3 selectlScale;

    //Boton
    private void OnMouseEnter()
    {
        this.gameObject.transform.localScale = selectlScale;
    }

    private void OnMouseExit()
    {
        this.gameObject.transform.localScale = normalScale;
    }

    //Clicado
    void OnMouseDown()
    {
        scene.Cargar(mapSelected);
    }
}
