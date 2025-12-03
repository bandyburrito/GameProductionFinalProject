using UnityEngine;

public class enemydeath : MonoBehaviour
{
    public int MaxHP = 100;
    public int CurrentHP = 100;
    public int DamageTaken = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHP==0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            CurrentHP -= 50;
        }
    }


}
