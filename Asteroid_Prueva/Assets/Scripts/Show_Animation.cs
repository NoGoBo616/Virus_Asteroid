using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show_Animation : MonoBehaviour
{
    private Animator animator;

    private void OnEnable()
    {
        animator = GetComponent<Animator>();
    }

    public void Show()
    {
        animator.SetTrigger("Show");
    }
}
