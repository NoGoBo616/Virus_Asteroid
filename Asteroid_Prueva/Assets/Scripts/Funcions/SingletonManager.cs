using System.Collections.Generic;
using UnityEngine;

public class SingletonManager : MonoBehaviour
{
    private static Dictionary<int, SingletonManager> instancias = new Dictionary<int, SingletonManager>();

    public int identificador; 

    void Awake()
    {
        if (instancias.ContainsKey(identificador))
        {
            Debug.Log("Instancia duplicada detectada con ID: " + identificador + ". Destruyendo...");
            Destroy(gameObject);
        }
        else
        {
            instancias[identificador] = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void OnDestroy()
    {
        if (instancias.ContainsKey(identificador) && instancias[identificador] == this)
        {
            instancias.Remove(identificador);
        }
    }
}
