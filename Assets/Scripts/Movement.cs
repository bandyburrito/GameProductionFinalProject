using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float movespeed = 10f;
    public Rigidbody rb;
    public float jumpSpeed = 10f;
    public float MouseSensitivity = 2f; 
    public Transform playerCamera; 
    private Vector2 turn;
    private Vector3 moveDirection;
    private bool isGrounded;
    public GameObject GunBullet;
    public GameObject GunSpawn;
    private bool isJumping;
    public int GroundSlamSpeed = 10000;
    private bool CanSlam;
    public float gravMultiplier;
    public float maxHP;
    public float damageTaken = 0;
    public ParticleSystem muzzleFlash;
    public Image healthBar;
    public AudioSource audioSource;
    public AudioClip shootingSFX;
    public AudioClip jumpingSFX;
    public AudioClip healingSFX;
    public AudioClip damageSFX;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        
        turn.x += Input.GetAxis("Mouse X") * MouseSensitivity;
        turn.y += Input.GetAxis("Mouse Y") * MouseSensitivity;
        
        turn.y = Mathf.Clamp(turn.y, -90f, 90f);
        playerCamera.localRotation = Quaternion.Euler(-turn.y, 0, 0);
        transform.localRotation = Quaternion.Euler(0, turn.x, 0);

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        moveDirection = (transform.forward * moveY) + (transform.right * moveX);

        

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            audioSource.PlayOneShot(jumpingSFX);
        }

        if (rb.linearVelocity.y<0)
        {
            rb.AddForce(Vector3.down * gravMultiplier * Time.deltaTime, ForceMode.Impulse);
        }

        if (Input.GetMouseButtonDown(0))
        {
            muzzleFlash.Play();
            audioSource.PlayOneShot(shootingSFX);

            Instantiate(GunBullet, GunSpawn.transform.position, GunSpawn.transform.rotation);
            transform.position += transform.right * 10f * Time.deltaTime;
        }

        CanSlam = isGrounded == false && isJumping == true;
        if (Input.GetKeyDown(KeyCode.LeftControl) && CanSlam)
        {
            rb.AddForce( Physics.gravity * rb.mass * GroundSlamSpeed * Time.deltaTime);
        }

    
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDirection.normalized * movespeed * Time.deltaTime);
        healthBar.fillAmount = (maxHP-damageTaken) / 100f;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            isJumping = false;
        }

        if (collision.gameObject.CompareTag("HealthPack"))
        {
            damageTaken -= 20;
            audioSource.PlayOneShot(healingSFX);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            isJumping = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            damageTaken += 30;
            audioSource.PlayOneShot(damageSFX);
            
            if (damageTaken>=maxHP)
            {
                Debug.Log("YOU DIED");
                SceneManager.LoadScene(1);
            }
            else
            {
                Debug.Log("Damage taken");
            }
        }

        if (other.gameObject.CompareTag("Transport"))
        {
            SceneManager.LoadScene(2);
        }
    }
}