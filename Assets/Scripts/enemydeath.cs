using UnityEngine;

public class enemydeath : MonoBehaviour
{

    public float Health = 3;
    public float DamageTaken = 1;
    public AudioSource audiosource;
    public AudioClip enemydeathsfx;
    public GameObject deathParticles;
    public Transform ParticleSpawner;
    private float moveSpeed = 5f;
    public float frequency = 5f;
    public float magnitude = 5f;

    private Vector3 axis;
    private Vector3 pos;

    void Start()
    {
        pos = gameObject.transform.position;
        axis = gameObject.transform.position;
    }





    void Update()
    {
       audiosource = GetComponent<AudioSource>();

       axis += transform.forward * moveSpeed * Time.deltaTime;

        // 2. Calculate the sine offset based on time
        // We add this offset to the RIGHT axis (perpendicular to forward)
        pos = axis + transform.right * Mathf.Sin(Time.time * frequency) * magnitude;

        // 3. Apply the calculated position to the enemy
        gameObject.transform.position = pos;

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
                GameObject DeathParticles = Instantiate(deathParticles, ParticleSpawner.transform.position,ParticleSpawner.rotation);    
                
                
                
            }
            
    }
    
}











