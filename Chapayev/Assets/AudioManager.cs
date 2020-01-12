using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject, 0);
        }
    }
}
