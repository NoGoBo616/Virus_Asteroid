using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    public GameObject crono;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeMap_Game()
    {
        crono.gameObject.SetActive(true);
        SceneManager.LoadScene(2);
    }

    public void ChangeMap_GameInfiniteMode()
    {
        crono.gameObject.SetActive(false);
        SceneManager.LoadScene(2);
    }

    public void ChangeMap_GameOver()
    {
        crono.gameObject.SetActive(false);
        SceneManager.LoadScene(3);
    }

    public void ChangeMap_Menu()
    {
        crono.gameObject.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void ChangeMap_Options()
    {
        crono.gameObject.SetActive(false);
        SceneManager.LoadScene(4);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
