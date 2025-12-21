using UnityEngine;

public class healthDissapear : MonoBehaviour
{

    public AudioSource audioSource;

    public AudioClip HealthUp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        

    }
    
    

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
        
        Destroy(gameObject);
        }
    }
}
