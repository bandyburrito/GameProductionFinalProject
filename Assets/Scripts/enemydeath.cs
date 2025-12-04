using UnityEngine;

public class enemydeath : MonoBehaviour
{

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


            if (EnemyHP <= 0)
            {
                Destroy(gameObject);
                Debug.Log("Enemy Destroyed");
            }
        }
    }
}











