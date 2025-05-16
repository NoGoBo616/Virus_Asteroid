using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    public GameObject crono;
    public int map;
    public GameObject map1;
    public GameObject map2;
    public GameObject map3;

    public void ChangeMap_Game()
    {
        map = Random.Range(1, 4);
        SceneManager.LoadScene(2);
        crono.gameObject.SetActive(true);
        
    }

    public void ChangeMap_GameInfiniteMode()
    {
        map = Random.Range(1, 4);
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

    private void Update()
    {
        if (map <= 1)
        {
            map1.gameObject.SetActive(true);
            map2.gameObject.SetActive(false);
            map3.gameObject.SetActive(false);
        }

        if (map == 2)
        {
            map1.gameObject.SetActive(false);
            map2.gameObject.SetActive(true);
            map3.gameObject.SetActive(false);
        }

        if (map >= 3)
        {
            map1.gameObject.SetActive(false);
            map2.gameObject.SetActive(false);
            map3.gameObject.SetActive(true);
        }
    }
}
