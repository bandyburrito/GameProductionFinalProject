using UnityEngine;

public class enemydeath : MonoBehaviour
{

    public float Health = 3;
    public float DamageTaken = 1;
    public AudioSource audiosource;
    public AudioClip enemydeathsfx;
    public GameObject deathParticles;
    public Transform ParticleSpawner;

    

    

    void Update()
    {
       audiosource = GetComponent<AudioSource>();

    }

    
        
    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.tag == "Shotgun")
        {
            Health -= DamageTaken; 
            audiosource.PlayOneShot(enemydeathsfx);
            Debug.Log("Enemy took Damage");

            DeathSequence();


            
        }
    
    }    

    void DeathSequence()
    {
        if (Health <= 0)
            {
                audiosource.PlayOneShot(enemydeathsfx);
                GameObject DeathParticles =Instantiate(deathParticles,     // /object
                ParticleSpawner.transform.position,            // /position
                ParticleSpawner.transform.rotation);     // rot
                Destroy(gameObject);
                
                
            }
    }
    
}











