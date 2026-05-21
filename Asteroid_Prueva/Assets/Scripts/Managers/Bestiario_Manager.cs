using UnityEngine;

public class Bestiario_Manager : MonoBehaviour
{
    public bool[] enemigosDesbloqueados;
    public static Bestiario_Manager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Opcional: para que no se destruya al cambiar de escena
            CargarProgreso();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void DesbloquearEnemigo(int index)
    {
        if (index < 0 || index >= enemigosDesbloqueados.Length)
            return;

        enemigosDesbloqueados[index] = true;

        // Descomentado para que guarde el progreso automáticamente
        PlayerPrefs.SetInt("Enemigo_" + index, 1);
        PlayerPrefs.Save();

        Debug.Log("Enemigo desbloqueado: " + index);
    }

    // Nueva función pública para que la UI sepa si el enemigo está desbloqueado
    public bool EstaDesbloqueado(int index)
    {
        if (index < 0 || index >= enemigosDesbloqueados.Length) return false;
        return enemigosDesbloqueados[index];
    }

    private void CargarProgreso()
    {
        for (int i = 0; i < enemigosDesbloqueados.Length; i++)
        {
            enemigosDesbloqueados[i] = PlayerPrefs.GetInt("Enemigo_" + i, 0) == 1;
        }
    }
}