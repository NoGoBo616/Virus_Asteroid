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
    public bool pasado;
    public int minPoints;
    public int maxPoints;
    public ArcadeManager puntos;

    [Header("Materiales")]
    public Material podrio;
    public Material normal;
    public Material bloqueado;
    public Material seleccionado;
    public Material actual;

    private void OnEnable()
    {
        manager = FindAnyObjectByType<Levels_Manager>();
        puntos = FindAnyObjectByType<ArcadeManager>();
        FijarTextura();
    }

    private void Update()
    {
        if (manager == null || puntos == null) FindManagers();
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
        if (manager != null || puntos != null)FijarTextura();
    }

    void FijarTextura()
    {
        if (puntos.listaPuntos.Max() >= minPoints || puntos.puntuacion >= minPoints)
        {
            pasado = false;
            desbloqueado = true;
        }
        if (puntos.listaPuntos.Max() >= maxPoints || puntos.puntuacion >= maxPoints)
        {
            desbloqueado = false;
            pasado = true;
        }

        if (pasado)
        {
            GetComponent<Renderer>().material = podrio;
            actual = podrio;
        }
        else
        {
            if (desbloqueado)
            {
                GetComponent<Renderer>().material = normal;
                actual = normal;
            }
            else
            {
                GetComponent<Renderer>().material = bloqueado;
                actual = bloqueado;
            }
        }
    } 

    //Detectado
    private void OnMouseEnter()
    {
       if (desbloqueado || pasado) GetComponent<Renderer>().material = seleccionado;
    }

    private void OnMouseExit()
    {
        GetComponent<Renderer>().material = actual;
    }

    //Clicado
    void OnMouseDown()
    {
        if (desbloqueado || pasado)
        {
            scene.Cargar(mapSelected);
            manager.Cambiar(levelSelected);
        }
        else
        {
            Debug.Log("nop");
        }
    }
}
