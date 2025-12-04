using UnityEngine;

public class enemydeath : MonoBehaviour
{
    public int MaxHP = 100;
    private int CurrentHP;
    private int DamageTaken = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentHP = MaxHP;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        CurrentHP = MaxHP - DamageTaken;

        if (CurrentHP==0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            DamageTaken += 50;
        }
    }


}
