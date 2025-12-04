using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.RenderGraphModule;

public class enemyScript : MonoBehaviour
{

    public GameObject character;
    public float enemyMoveSpeed = 15f;
    public Rigidbody rb;
    private quaternion attackRotation;

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            attackRotation = transform.rotation;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemyMoveSpeed = 0f;
            transform.rotation = attackRotation;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemyMoveSpeed = 15f;
        }
    }
}
