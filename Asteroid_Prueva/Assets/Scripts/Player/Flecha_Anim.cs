using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha_Anim : MonoBehaviour
{
    public Animator animator;
    public bool cooldown;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        cooldown = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (cooldown)
            {
                animator.SetTrigger("attack");
                StartCoroutine(Bullet());
            }
        }
    }

    private IEnumerator Bullet()
    {
        cooldown = false;
        yield return new WaitForSeconds(0.6f);
        cooldown = true;
        yield return null;
    }
}
