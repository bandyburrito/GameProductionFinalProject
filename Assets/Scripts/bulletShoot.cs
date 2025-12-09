using System;
using UnityEngine;

public class bulletShoot : MonoBehaviour
{

    [SerializeField] public float bulletspeed = 20f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
    transform.position += transform.up * bulletspeed * Time.fixedDeltaTime ;   
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            
            Destroy(gameObject);
            Debug.Log("Bullet Destroyed");
        }


        if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
            Debug.Log("Bullet Destroyed");
        }
    }




    


    



}
