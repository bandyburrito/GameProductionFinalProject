using NUnit.Framework.Internal;
using UnityEngine;

public class enemydeath : MonoBehaviour
{
    public int MaxHP = 100;
    private int CurrentHP;
    private int DamageTaken = 0;
    public GameObject character;

    void Start()
    {
        CurrentHP = MaxHP;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CurrentHP = MaxHP - DamageTaken;

        if (CurrentHP<=0)
        {
            Destroy(gameObject);
            DamageTaken = 0;
            Instantiate(gameObject, new Vector3(character.transform.position.x +- Random.Range(10,40), -100, character.transform.position.z +- Random.Range(10,40)), transform.rotation);
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