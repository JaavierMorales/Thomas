using UnityEngine;

public class PlayerDeathSound : MonoBehaviour
{
    public AudioClip deathSound; 
    private AudioSource audioSource;

    void Start()
    {

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlayDeathSound()
    {
        if (deathSound != null)
        {
            audioSource.PlayOneShot(deathSound);
        }
    }
}