using UnityEngine;
using UnityEngine.Audio;
public class Options : MonoBehaviour
{
    [Header("Audio")]
    public AudioMixer audioMixer;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}
