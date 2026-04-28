using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus_ : MonoBehaviour
{
    private Animator playerAnim;
    public bool cooldownS;
    public bool cooldownI;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        cooldownS = true;
    }

    private void OnEnable()
    {
        cooldownS = true;
    }

    public void HandleAttack()
    {
        playerAnim.SetTrigger("attack");
    }

    public void HandlePinchos()
    {
        if (cooldownS)
        {
            playerAnim.SetTrigger("special");
            StartCoroutine(CooldownShield());
        }
    }

    public void HandleInvisible()
    {
        if (cooldownI)
        {
            playerAnim.SetTrigger("Invisible");
            StartCoroutine(CooldownI());
        }
    }

    private IEnumerator CooldownShield()
    {
        cooldownS = false;
        cooldownI = false;
        yield return new WaitForSeconds(2);
        cooldownI = true;
        yield return new WaitForSeconds(4);
        cooldownS = true;
        yield return null;
    }

    private IEnumerator CooldownI()
    {
        cooldownS = false;
        cooldownI = false;
        yield return new WaitForSeconds(2);
        cooldownS = true;
        yield return new WaitForSeconds(4);
        cooldownI = true;
        yield return null;
    }
}
