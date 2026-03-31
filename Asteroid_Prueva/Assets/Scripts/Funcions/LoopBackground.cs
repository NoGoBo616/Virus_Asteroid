using UnityEngine;

public class LoopingBackground : MonoBehaviour
{
    public GameObject[] backgrounds;
    public float scrollSpeed = 2f;

    private float backgroundWidth;

    void Start()
    {
        backgroundWidth = backgrounds[0].GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        foreach (GameObject bg in backgrounds)
        {
            bg.transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

            if (bg.transform.position.x <= -backgroundWidth)
            {
                float rightMostX = GetRightMostBackgroundX();
                bg.transform.position = new Vector3(rightMostX + backgroundWidth, bg.transform.position.y, bg.transform.position.z);
            }
        }
    }

    float GetRightMostBackgroundX()
    {
        float maxX = float.MinValue;
        foreach (GameObject bg in backgrounds)
        {
            if (bg.transform.position.x > maxX)
                maxX = bg.transform.position.x;
        }
        return maxX;
    }
}
