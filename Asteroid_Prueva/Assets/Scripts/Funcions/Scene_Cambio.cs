using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Cambio : MonoBehaviour
{
    public Animator anim;
    public Scene_Manager first;

    public void Cargar(int mapa)
    {
        StartCoroutine(Cambio(mapa));
    }

    public void Exit()
    {
        Application.Quit();
    }

    IEnumerator Cambio(int map)
    {
        anim.SetTrigger("On");
        yield return new WaitForSeconds(0.5f);

        yield return StartCoroutine(
            MusicManager.instance.FadeOutAndThen(() =>
            {
                if (first == null)
                {
                    SceneManager.LoadScene(map);
                }
                else
                {
                    if (first.tutorial)
                    {
                        SceneManager.LoadScene(2);
                        first.tutorial = false;
                        first.inGame = true;
                    }
                    else
                    {
                        SceneManager.LoadScene(map);
                    }
                }
            })
        );
    }
}
