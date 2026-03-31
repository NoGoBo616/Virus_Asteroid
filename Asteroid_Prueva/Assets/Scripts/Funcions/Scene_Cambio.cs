using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Cambio : MonoBehaviour
{
    public Animator anim;

    public void Cargar(int mapa)
    {
        StartCoroutine(Cambio(mapa));
    }

    IEnumerator Cambio(int map)
    {
        //  Lanzar animación
        anim.SetTrigger("On");

        // Esperar un poco a que empiece la animación
        yield return new WaitForSeconds(0.5f);

        //  Fade de música
        yield return StartCoroutine(
            MusicManager.instance.FadeOutAndThen(() =>
            {
                SceneManager.LoadScene(map);
            })
        );
    }
}
