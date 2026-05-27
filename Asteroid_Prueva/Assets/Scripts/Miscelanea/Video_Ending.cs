using System.Collections;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class Video_Ending : MonoBehaviour
{
    public GameObject final_Bueno;
    public GameObject final_Malo;
    public VideoPlayer final_Bueno_Player;
    public VideoPlayer final_Malo_Player;
    public ArcadeManager manager;
    public Animator anim;

    void OnEnable()
    {
        manager = FindAnyObjectByType<ArcadeManager>();

        if (manager.listaPuntos.Max() >= 7500)
        {
            StartCoroutine(GoodEnding());
        }
        if (manager.listaPuntos.Max() <= 7500)
        {
            StartCoroutine(BadEnding());
        }
    }

    IEnumerator GoodEnding()
    {
        final_Bueno.SetActive(true);
        final_Bueno_Player.Play();
        yield return new WaitForSeconds(5);
        anim.SetTrigger("Final");
        yield return new WaitForSeconds(2);
        final_Bueno.SetActive(false);
        yield return null;
    }

    IEnumerator BadEnding()
    {
        final_Malo.SetActive(true);
        final_Malo_Player.Play();
        yield return new WaitForSeconds(5);
        anim.SetTrigger("Final");
        yield return new WaitForSeconds(2);
        final_Malo.SetActive(false);
        yield return null;
    }
}
