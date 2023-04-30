using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager S {get; private set;}
    public List<AudioClip> sounds;
    private AudioSource audioSource;

    private void Awake()
    {
        if (S != null && S != this)
        {
            Destroy(this);
            return;
        }
        S = this;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(int index)
    {
        audioSource.PlayOneShot(sounds[index]);
    }
}
