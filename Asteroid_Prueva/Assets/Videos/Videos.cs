using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Videos : MonoBehaviour
{
    public float time;
    public int scene;
    public Animator anim;

    private void OnEnable()
    {
        StartCoroutine(Pasar());
    }

    private IEnumerator Pasar()
    {
        yield return new WaitForSeconds(time);
        anim.SetTrigger("On");
        SceneManager.LoadScene(scene);
        yield return null;
    }
}
