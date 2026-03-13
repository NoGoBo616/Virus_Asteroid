using UnityEngine;
using UnityEngine.SceneManagement;

public class Transicion_Script : MonoBehaviour
{
    public Animator animator;

    private void OnEnable()
    {
        animator.SetTrigger("Off");
    }

    private void OnDisable()
    {
        animator.SetTrigger("On");
    }
}
