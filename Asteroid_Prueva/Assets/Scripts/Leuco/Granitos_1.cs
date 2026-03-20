using UnityEngine;

public class Granitos_1 : MonoBehaviour
{
    public Leucocito padre;
    public GameObject[] granitos;
    public int live;
    public int ran1;
    public int ran2;

    private void OnEnable()
    {
        ran1 = Random.Range(0, 3);
        ran2 = Random.Range(0, 3);
        while (ran2 == ran1)
        {
            ran2 = Random.Range(0, 3);
        }
        granitos[ran1].gameObject.SetActive(true);
        granitos[ran2].gameObject.SetActive(true);
        live = 2;
        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 180));
    }

    private void Update()
    {
        if (live <= 0) this.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        padre.KillLeuco();
    }
}
