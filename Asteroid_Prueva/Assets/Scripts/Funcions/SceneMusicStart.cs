using UnityEngine;

public class SceneMusicStart : MonoBehaviour
{
    public int songIndex;

    private void OnEnable()
    {
        MusicManager.instance.SetSong(songIndex);
    }
}
