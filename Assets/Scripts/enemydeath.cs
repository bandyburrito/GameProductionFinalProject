using UnityEngine;
using UnityEngine.UI;


public class enemydeath : MonoBehaviour
{

    public Image HealthBar;
    public float HealthAmount = 100f;
    

    public float Health = 9;
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
    public GameObject Box1;
    public GameObject Box2;
    private float EnemyKilled;
    

    void Start()
    {
        
        
        




    }
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


            if (Health <= 0)
            {
            Instantiate(deathParticles, gameObject.transform.position, gameObject.transform.rotation);    
            Destroy(gameObject.GetComponent<SkinnedMeshRenderer>());
            Debug.Log("Enemy Skin Removed");
            Destroy(gameObject);
            Debug.Log("Enemy Killed after 3 seconds");
            }
            


            


            
        }
    
    }

    


    


    
}











