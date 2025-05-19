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
        cooldownS = true;
        cooldownI = true;
        playerAnim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        cooldownS = true;
        cooldownI = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnim.SetTrigger("attack");
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (cooldownS)
            {
                playerAnim.SetTrigger("special");
                StartCoroutine(CooldownShield());
            }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (cooldownI)
            {
                playerAnim.SetTrigger("Invisible");
                StartCoroutine(CooldownI());
            }
            
        }
    } 

    private IEnumerator CooldownShield()
    {
        cooldownS = false;
        cooldownI = false;
        yield return new WaitForSeconds(2);
        cooldownI = true;
        yield return new WaitForSeconds(2);
        cooldownS = true;
        yield return null;
    }

    private IEnumerator CooldownI()
    {
        cooldownS = false;
        cooldownI = false;
        yield return new WaitForSeconds(2);
        cooldownS = true;
        yield return new WaitForSeconds(2);
        cooldownI = true;
        yield return null;
    }
}
