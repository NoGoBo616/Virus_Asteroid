using System.Collections.Generic;
using UnityEngine;

public class SingletonManager : MonoBehaviour
{
    // Diccionario para rastrear instancias por su ID
    private static Dictionary<int, SingletonManager> instancias = new Dictionary<int, SingletonManager>();

    public int identificador; // Define este ID en el inspector para cada objeto

    void Awake()
    {
        // Comprobamos si ya existe una instancia con este identificador
        if (instancias.ContainsKey(identificador))
        {
            // Si ya existe, destruimos esta copia nueva
            Debug.Log("Instancia duplicada detectada con ID: " + identificador + ". Destruyendo...");
            Destroy(gameObject);
        }
        else
        {
            // Si es la primera vez, nos registramos en el diccionario
            instancias[identificador] = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void OnDestroy()
    {
        // Limpiamos el diccionario si el objeto se destruye (por seguridad)
        if (instancias.ContainsKey(identificador) && instancias[identificador] == this)
        {
            instancias.Remove(identificador);
        }
    }
}
