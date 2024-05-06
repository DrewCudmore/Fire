using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class ExampleClass : MonoBehaviour
{
    public AudioClip otherClip;

    IEnumerator Start()
    {
        AudioSource audio = GetComponent<AudioSource>();

        audio.Play();
        yield return new WaitForSeconds(15);
        audio.volume = 0.1F;
        audio.clip = otherClip;
        audio.Play();
    }
}
