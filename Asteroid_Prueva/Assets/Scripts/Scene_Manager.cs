using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Linq;

public class Scene_Manager : MonoBehaviour
{
    public GameObject crono;
    public int map;
    public GameObject[] maps;
    public bool inGame;

    public void ChangeMap_Game()
    {
        if (GlobalAudioManager.Instance != null)
        {
            GlobalAudioManager.Instance.PlaySFX(0);
        }
        map = Random.Range(1, 4);
        SceneManager.LoadScene(2);
        crono.gameObject.SetActive(true);
    }

    public void ChangeMap_GameInfiniteMode()
    {
        if (GlobalAudioManager.Instance != null)
        {
            GlobalAudioManager.Instance.PlaySFX(0);
        }
        crono.gameObject.SetActive(false);
        SceneManager.LoadScene(2);
        inGame = true;
       
    }

    public void ChangeMap_GameOver()
    {
        crono.gameObject.SetActive(false);
        SceneManager.LoadScene(3);
        inGame = false;
    }

    public void ChangeMap_Menu()
    {
        if (GlobalAudioManager.Instance != null)
        {
            GlobalAudioManager.Instance.PlaySFX(0);
        }
        crono.gameObject.SetActive(false);
        SceneManager.LoadScene(1);
        inGame = false;
    }

    public void ChangeMap_Options()
    {
        if (GlobalAudioManager.Instance != null)
        {
            GlobalAudioManager.Instance.PlaySFX(0);
        }
        crono.gameObject.SetActive(false);
        SceneManager.LoadScene(4);
    }

    public void ExitGame()
    {
        if (GlobalAudioManager.Instance != null)
        {
            GlobalAudioManager.Instance.PlaySFX(0);
        }
        Application.Quit();
    }

    private void Update()
    {
        System.Linq.Enumerable.Range(0, maps.Length).ToList().ForEach(i => maps[i].SetActive(i == map));
    }
}
