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

        //PlayerPrefs.SetInt("Enemigo_" + index, 1);
        //PlayerPrefs.Save();

        Debug.Log("Enemigo desbloqueado: " + index);
    }
}
