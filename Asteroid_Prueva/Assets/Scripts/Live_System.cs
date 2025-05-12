using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Live_System : MonoBehaviour
{
    public float vida;
    [SerializeField] Image player_Live;
    public int points;
    public Live_System manager;
    [SerializeField] public int damageSfxIndex;

    private void Start()
    {
        vida = 1;
    }

    private void OnEnable()
    {
        vida = 1;
    }

    private void Update()
    {
        player_Live.fillAmount = vida;

        if (vida <= 0)
        {
            vida = 0;
            SceneManager.LoadScene(2);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Live_System");
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlaySFX(damageSfxIndex); 
            }

            vida = vida - 0.05f;
        }
    }

    public void MorePoints()
    {
        points = points + 100;
        Debug.Log(points);
    }
}
