using UnityEngine;

public class Levels_Manager : MonoBehaviour
{
    public GameObject[] levels;

    public void Cambiar(int nivel)
    {
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].SetActive(false);
        }
        levels[nivel].SetActive(true);
    }
}
