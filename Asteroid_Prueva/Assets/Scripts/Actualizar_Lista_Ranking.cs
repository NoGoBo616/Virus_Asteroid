using UnityEngine;

public class Actualizar_Lista_Ranking : MonoBehaviour
{
    public ArcadeManager ranking;

    private void OnEnable()
    {
        ranking = FindAnyObjectByType<ArcadeManager>();
    }

    private void Update()
    {
        if (ranking != null)
        {
            ranking = FindAnyObjectByType<ArcadeManager>();
        }
    }

    public void Boton()
    {
        ranking.FinalizarPartida();
    }
}
