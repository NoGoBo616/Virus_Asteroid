using UnityEngine;

public class BulletHell_Power : MonoBehaviour
{
    public GameObject[] positions;
    public GameObject bullets;

    private void OnEnable()
    {
        System.Array.ForEach(positions, obj => Instantiate(bullets, obj.transform.position, obj.transform.rotation));
    }
}
