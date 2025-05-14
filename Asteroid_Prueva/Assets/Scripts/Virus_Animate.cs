using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus_ : MonoBehaviour
{
    private Animator playerAnim;
    public bool cooldown;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        cooldown = true;
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
            if (cooldown)
            {
                playerAnim.SetTrigger("special");
                StartCoroutine(CooldownShield());
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(CooldownI());
        }
    }

    private IEnumerator CooldownShield()
    {
        cooldown = false;
        yield return new WaitForSeconds(4);
        cooldown = true;
        yield return null;
    }

    private IEnumerator CooldownI()
    {
        cooldown = false;
        yield return new WaitForSeconds(2);
        cooldown = true;
        yield return null;
    }
}
