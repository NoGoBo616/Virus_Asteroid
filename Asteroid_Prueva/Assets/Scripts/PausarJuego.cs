using UnityEngine;
using UnityEngine.SceneManagement;

public class PausarJuego : MonoBehaviour




{
    public GameObject menuPausa;
    public bool juegoPausado = false;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Pausar();

        }

    }

    public void Pausar()
    {
        if (juegoPausado == false)
        {
            menuPausa.SetActive(true);
            Time.timeScale = 0;
            juegoPausado = true;
        }
        else
        {
            menuPausa.SetActive(false);
            Time.timeScale = 1;
            juegoPausado = false;
        }

    }
    public void SalirAlMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);

    }

}

