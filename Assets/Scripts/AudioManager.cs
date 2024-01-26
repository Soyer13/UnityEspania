using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioManager instance;


    public AudioSource SFXSource;

    public AudioClip[] SFXClips;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    public void PlaySFX(int ID)
    {
        SFXSource.clip = SFXClips[ID];
        SFXSource.Play();
    }
}
