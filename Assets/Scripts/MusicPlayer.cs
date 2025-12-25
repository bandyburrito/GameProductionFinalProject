using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip music;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Music"))
        {
            audioSource.PlayOneShot(music);
        }    
    }

}
