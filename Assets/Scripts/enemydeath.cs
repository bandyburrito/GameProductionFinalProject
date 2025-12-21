using NUnit.Framework.Internal;
using UnityEngine;

public class enemydeath : MonoBehaviour
{
<<<<<<< Updated upstream

    public float EnemyHP = 100;
    public float DamageTaken = 35;

    

    void Start()
    {
        
    }

    void Update()
    {
       
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Shotgun"))
        {
            EnemyHP -= DamageTaken;
            Debug.Log("Enemy HP: " + EnemyHP);
=======
    public int MaxHP = 100;
    private int CurrentHP = 100;
    private int DamageTaken = 34;
    public GameObject character;
    public AudioClip deathSound;
    public AudioSource audioSource;

    void Start()
    {
        CurrentHP = MaxHP;
        character = GameObject.FindGameObjectWithTag("Player");

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CurrentHP = MaxHP - DamageTaken;

        if (CurrentHP<=0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shotgun"))
        {
>>>>>>> Stashed changes

            CurrentHP =- DamageTaken;

<<<<<<< Updated upstream
            if (EnemyHP <= 0)
            {
                Destroy(gameObject);
                Debug.Log("Enemy Destroyed");
            }
        }
    }
}











=======
        if (CurrentHP<=0)
        {
            Destroy(gameObject);
            DamageTaken = 0;
            Instantiate(gameObject, new Vector3(character.transform.position.x +- Random.Range(10,40), -100, character.transform.position.z +- Random.Range(10,40)), transform.rotation);
            
            audioSource.PlayOneShot(deathSound);

        }
        }
    }
}
>>>>>>> Stashed changes
