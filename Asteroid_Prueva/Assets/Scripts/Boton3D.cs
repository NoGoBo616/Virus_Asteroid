using UnityEngine;

public class Boton3D : MonoBehaviour
{
    [Header("Mapa")]
    public Scene_Manager manager;
    public int mapSelected;

    [Header("Vectores de tamaño")]
    public Vector3 normalScale;
    public Vector3 selectlScale;

    private void OnEnable()
    {
        manager = FindAnyObjectByType<Scene_Manager>();
    }

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
        manager.map = mapSelected;
        manager.ChangeMap_GameInfiniteMode();
    }
}
