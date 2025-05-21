using UnityEngine;

public class Radio : MonoBehaviour, IInteractuable
{
    [SerializeField] AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Interact()
    {

        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        else
        {
            audioSource.Play();
        }
    }
}
