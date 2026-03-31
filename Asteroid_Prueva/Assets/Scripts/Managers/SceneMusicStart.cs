using UnityEngine;

public class SceneMusicStart : MonoBehaviour
{
    public int songIndex;

    void Start()
    {
        MusicManager.instance.SetSong(songIndex);
    }
}
