using System.Linq;
using UnityEngine;

public class Boton3D : MonoBehaviour
{
    [Header("Mapa")]
    public Scene_Cambio scene;
    public int mapSelected;
    public Levels_Manager manager;
    public int levelSelected;
    public bool desbloqueado;
    public int minPoints;
    public ArcadeManager puntos;

    [Header("Vectores de tamaño")]
    public Vector3 normalScale;
    public Vector3 selectlScale;

    private void OnEnable()
    {
        manager = FindAnyObjectByType<Levels_Manager>();
        puntos = FindAnyObjectByType<ArcadeManager>();
    }

    private void Update()
    {
        FindManagers();

        if (puntos.listaPuntos.Max() >= minPoints || puntos.puntuacion >= minPoints)
        {
            desbloqueado = true;
        }
    }

    void FindManagers()
    {
        if (manager == null)
        {
            manager = FindAnyObjectByType<Levels_Manager>();
        }
        if (puntos == null)
        {
            puntos = FindAnyObjectByType<ArcadeManager>();
        }
    }

    //Detectado
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
        if (desbloqueado)
        {
            scene.Cargar(mapSelected);
            manager.Cambiar(levelSelected);
        }
    }
}
