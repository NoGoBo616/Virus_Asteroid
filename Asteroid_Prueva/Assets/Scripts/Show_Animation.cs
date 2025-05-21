using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show_Animation : MonoBehaviour
{
    private Animator animator;
    bool showed;

    private void OnEnable()
    {
        showed = true;
        animator = GetComponent<Animator>();
    }

    public void Show()
    {
        if (showed)
        {
            StartCoroutine(Animar());
            animator.SetTrigger("Show");
        }
    }

    private IEnumerator Animar()
    {
        showed = false;
        yield return new WaitForSeconds(10.20f);
        showed = true;
        yield return null;
    }
}
