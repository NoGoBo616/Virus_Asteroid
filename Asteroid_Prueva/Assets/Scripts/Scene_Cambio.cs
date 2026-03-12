using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Cambio : MonoBehaviour
{
    public void Cargar(int mapa)
    {
        SceneManager.LoadScene(mapa);
    }
}
