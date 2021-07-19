using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void Play(string name)
    {
        foreach(Sound s in sounds)
        {
            if (s.name == name)
            {
                s.source.Play();
            }
        }
    }

    public void PlayOneShot(string name)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name)
            {
                s.source.PlayOneShot(s.clip);
            }
        }
    }
}
