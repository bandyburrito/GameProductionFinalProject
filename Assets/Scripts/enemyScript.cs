using UnityEngine;

public class enemyScript : MonoBehaviour
{

    public GameObject character;
    public float enemyMoveSpeed = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(character.transform);
        transform.position += transform.forward * enemyMoveSpeed * Time.deltaTime;
    }
}
