using UnityEngine;
using TMPro;

public class MyPlayer : MonoBehaviour
{

    //public float moveSpeed = 3f;
    //public float turnSpeed = 150f;
    public int currentAmmo = 10;
    public float health = 100f;
    public TextMeshProUGUI ammo;
     public Transform spawner;
    public GameObject bullet;
    public float bulletSpeed = 100f;
    public Collision collision;
    public AudioSource gunShot;
    public GameFlowManager gameFlowManager;

    void Update()
    {
        // 1. Tank Movement
        // float move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        // float turn = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        
        // transform.Translate(0, 0, move);
        // transform.Rotate(0, turn, 0);

        // 2. Shooting Logic
        if (Input.GetButtonDown("Fire1") && currentAmmo > 0)
        {
            Shoot();
            gunShot.Play();
        }
    }

    void Shoot()
    {
        GameObject bulletInstance = Instantiate(bullet, spawner.position, spawner.rotation);
        bulletInstance.GetComponent<Rigidbody>().linearVelocity = spawner.forward * bulletSpeed * Time.deltaTime;
        Destroy(bulletInstance, 3f);
        currentAmmo--;
        Debug.Log("Shot fired! Ammo left: " + currentAmmo);
        UpdateUI();
    }

    void UpdateUI()
    {
        ammo.text = "Ammo: " + currentAmmo;

        if (currentAmmo <= 3)
        {
            ammo.color = Color.red;
        }
    }

    public void Heal(float amount)
    {
        health = Mathf.Min(health + amount, 100f);
        Debug.Log("Healed! Current Health: " + health);
    }

    public float speed = 5f;
    private float gravity = -9.81f;
    private bool grounded;
    public CharacterController myController;
    public Vector3 velocity;
    public float mouseSen = 100f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void FixedUpdate()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        float MouseX = Input.GetAxis("Mouse X") * mouseSen * Time.deltaTime;

        // Vector3 move = new Vector3(Horizontal, 0, Vertical);
        // myController.Move(move * speed * Time.deltaTime);

        Vector3 forward = myController.transform.forward;
        Vector3 right = myController.transform.right;
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = (forward * Vertical) + (right * Horizontal);
        myController.Move(moveDirection * speed * Time.deltaTime);

        transform.Rotate(Vector3.up * MouseX);

        if (grounded == false)
        {
            velocity.y = gravity;
            myController.Move(velocity * Time.deltaTime);
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
       if(hit.gameObject.CompareTag("Enemy"))
        {
            gameFlowManager.LoseGame();
            Debug.Log("Meow");
        } 
    }
}
