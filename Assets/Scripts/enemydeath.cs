using NUnit.Framework.Internal;
using UnityEngine;

public class enemydeath : MonoBehaviour
{
    public int MaxHP = 100;
    private int CurrentHP;
    public GameObject character;

    void Start()
    {
        CurrentHP = MaxHP;
        character = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (CurrentHP<=0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shotgun"))
        {
            CurrentHP -= 20;
        }
    }
}