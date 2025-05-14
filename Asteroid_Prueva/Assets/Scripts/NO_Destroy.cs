using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NO_Destroy : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
