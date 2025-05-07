using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MenuGameOver : MonoBehaviour
{
    [SerializeField] private GameObject menuGameOver;
    private Live_System live_System;

    private void Start()
    {
        live_System = GameObject.FindGameObjectWithTag("Player").GetComponent<Live_System>();
        live_System.MuerteJugador += ActivarMenu;


    }
    private void ActivarMenu(object sender ,EventArgs e)
    { 
    menuGameOver.SetActive(true);
    
    }
    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    
    }

    public void MenuInicial(string nombre)
    {
        SceneManager.LoadScene(nombre);
    
    }

    public void Salir()
    {
        UnityEditor.EditorApplication.isPlaying=false;
        Application.Quit();
    
    }
}
