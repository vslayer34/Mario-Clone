using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] audioClips;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Debug.LogWarning("Audio Manager instance failed to instancize");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
