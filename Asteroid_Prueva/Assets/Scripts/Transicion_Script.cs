using UnityEngine;

public class Transicion_Script : MonoBehaviour
{
    public Animator animator;

    private void OnEnable()
    {
        animator.SetTrigger("Off");
    }
}
