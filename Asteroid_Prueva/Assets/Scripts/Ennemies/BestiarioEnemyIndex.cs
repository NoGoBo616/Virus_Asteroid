using UnityEngine;

public class BestiarioEnemyIndex : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int indice;
    public Bestiario_Manager manager;

    private void OnEnable()
    {
        manager=FindAnyObjectByType<Bestiario_Manager>();
    }
    private void OnDestroy()
    {
        // Escudo 1: Si la escena se está cerrando o cambiando, salimos inmediatamente
        if (!gameObject.scene.isLoaded) return;

        // Escudo 2: Comprobamos que el manager realmente exista en la escena
        if (manager != null)
        {
            if (manager.enemigosDesbloqueados[indice] == false)
            {
                manager.DesbloquearEnemigo(indice);
            }
        }
    }
}
