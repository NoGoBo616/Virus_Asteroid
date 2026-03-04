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
            showed = false;
            animator.SetTrigger("Show");
        }
        else
        {
            showed = true;
            animator.SetTrigger("Hide");
        }
    }
}
