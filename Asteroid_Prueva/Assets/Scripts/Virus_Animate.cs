using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus_ : MonoBehaviour
{
    private Animator playerAnim;
    public Player_ comprobador;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
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
            playerAnim.SetTrigger("special");
        }
    }
}
