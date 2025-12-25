using UnityEngine;

public class bulletShoot : MonoBehaviour
{

    [SerializeField] public float bulletspeed;

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
        transform.position += transform.forward * bulletspeed * Time.fixedDeltaTime;  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
            Debug.Log("Bullet Destroyed");
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
            Debug.Log("Bullet Destroyed");
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }



}
