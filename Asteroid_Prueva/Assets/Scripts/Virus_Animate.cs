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
    }

    private IEnumerator CooldownShield()
    {
        cooldown = false;
        yield return new WaitForSeconds(4);
        cooldown = true;
        yield return null;
    }
}
