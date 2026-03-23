using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Live_System : MonoBehaviour
{
    public float vida;
    public bool dañado;
    [SerializeField] Image player_Live;
    public Scene_Cambio cambio;
    
    public Live_System manager;
    [SerializeField] public int damageSfxIndex;

    private void Start()
    {
        vida = 1;
        dañado = true;
    }

    private void OnEnable()
    {
        vida = 1;
    }

    private void Update()
    {
        player_Live.fillAmount = vida;
        if (vida >= 1) vida = 1;
        if (vida <= 0)
        {
            vida = 0;
            cambio.Cargar(3);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlaySFX(damageSfxIndex); 
            }

            vida = vida - 0.05f;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Police") && dañado)
        {
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlaySFX(damageSfxIndex);
            }

            vida = vida - 0.05f;
            StartCoroutine(CoolDown());
        }
    }

    IEnumerator CoolDown()
    {
        dañado = false;
        yield return new WaitForSeconds(1);
        dañado = true;
        yield return null;
    }
}
