using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movespeed = 10f;
    public float jumpSpeed = 10f;
    public Rigidbody rb;
    private bool isGrounded;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        
        


        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, 0f, moveZ);

        rb.MovePosition(rb.position + movement * movespeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }


    }
    
    
    

}
