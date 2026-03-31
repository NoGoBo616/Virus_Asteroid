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
        anim.SetTrigger("On");
        yield return new WaitForSeconds(0.5f);

        yield return StartCoroutine(
            MusicManager.instance.FadeOutAndThen(() =>
            {
                SceneManager.LoadScene(map);
            })
        );
    }
}
