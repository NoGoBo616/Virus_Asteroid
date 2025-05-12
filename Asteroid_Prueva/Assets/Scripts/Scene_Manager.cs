using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    public TMP_Text textPuntos;
    public int specificMap;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeMap_Game()
    {
        SceneManager.LoadScene(1);
    }

    public void ChangeMap_GameInfiniteMode()
    {
        SceneManager.LoadScene(1);
    }

    public void ChangeMap_GameOver()
    {
        SceneManager.LoadScene(2);
    }

    public void ChangeMap_Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void ChangeMap_Options()
    {
        SceneManager.LoadScene(3);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
