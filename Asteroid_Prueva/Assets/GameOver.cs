using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private TMP_Text title;
    // Start is called before the first frame update
    void Start()
    {
        title.text = StaticPoints.points.ToString();
    }

}
