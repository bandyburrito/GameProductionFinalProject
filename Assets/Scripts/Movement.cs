using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Rendering;
public class Movement : MonoBehaviour
{
    private float waitTime = 2f;
    private float bulletsShot = 0f;
    private bool CharacterDied = false;
    public Image HealthBar;
    public float MAXHP = 100f;
    public float DamageTaken = 20f;
    public float movespeed = 10f;
    public Rigidbody rb;
    public float jumpSpeed = 25f;
    public float MouseSensitivity = 2f; 
    public Transform playerCamera; 
    private Vector2 turn;
    private Vector3 moveDirection;
    private bool isGrounded;
    public GameObject GunBullet;
    public GameObject GunSpawn;
    private bool isJumping;
    private AudioSource audioSource;
    public AudioClip jumpSound;
    public AudioClip shootingSound;
    public AudioClip HealthUP;
    public GameObject Box1;
    public GameObject Box2;
    public AudioClip DOORSOPENED;

    



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        rb.freezeRotation = true;
        Cursor.lockState = CursorLockMode.Locked;
        audioSource = GetComponent<AudioSource>();
        audioSource = GetComponent<AudioSource>();
        

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
            audioSource.PlayOneShot(jumpSound);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (bulletsShot > 10)
            {
                ReloadTime();
                bulletsShot =- 10f;
            }
            else{
                Instantiate(GunBullet, GunSpawn.transform.position, GunSpawn.transform.rotation);
                transform.position += transform.up * 10f * Time.deltaTime;
                audioSource.PlayOneShot(shootingSound); 
                bulletsShot += 1;
            }
        }

        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
        Debug.Log("All enemies dead! LETS GO QIPITI");
        DestoryBoxes();
        audioSource.PlayOneShot(DOORSOPENED);
       
        }

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDirection.normalized * movespeed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            isJumping = false;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            MAXHP -= DamageTaken;
            HealthBar.fillAmount -= 0.20f;
            Debug.Log("Player took Damage");

            if (MAXHP <= 0)
            {
                Destroy(gameObject);
                CharacterDied = true;
                DeathManager();
            }
        }

        if (collision.gameObject.CompareTag("HealthPack") && MAXHP < 100f)
        {
            MAXHP += 20f;
            HealthBar.fillAmount += 0.20f;
            audioSource.PlayOneShot(HealthUP);
           

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

    public void DeathManager()
    {
        SceneManager.LoadScene(1);
    }

    private IEnumerator ReloadTime()
    {
        yield return new WaitForSeconds(waitTime);
        
        

    }

    public void DestoryBoxes()
    {
        Destroy(Box1);
        Destroy(Box2);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Transport"))
        {
            SceneManager.LoadScene(2);
        }
    }

   

   

}

