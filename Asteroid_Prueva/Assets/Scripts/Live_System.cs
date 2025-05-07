using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Live_System : MonoBehaviour
{
    public float vida;
    [SerializeField] Image player_Live;
    public int points;
    public Live_System manager;

    private void Start()
    {
        vida = 1;
    }

    private void Update()
    {
        player_Live.fillAmount = vida;

        if (vida <= 0)
        {
            vida = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            vida = vida - 0.05f;
        }
    }

    public void MorePoints()
    {
        points = points + 100;
        Debug.Log(points);
    }
}
