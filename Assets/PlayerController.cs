using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed;
    public float noramalSpeed = 0.0f;
    public float crouchSpeed = 5.0f;

    float rotation = 0.2f;
    float camRotation = 0.2f;
    GameObject cam;
    Rigidbody myRigidbody;

    bool isOnGround;
    public GameObject GroundChecker;
    public LayerMask groundLayer;

    float rotationSpeed = 2.0F;
    float camRotationSpeed = 1.5f;
    float jumpForce = 300f;

    public float maxCrouch = -5.0f;
    float crouchTimer;
    

    void Start()
    {
        cam = GameObject.Find("Main Camera");
        myRigidbody = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        camRotation = Mathf.Clamp(camRotation, -40.0f, 40.0f);

        crouchTimer = maxCrouch;
    }
    void Update()
    {
        isOnGround = Physics.CheckSphere(GroundChecker.transform.position, 0.1f, groundLayer);

        if (isOnGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody.AddForce(transform.up * jumpForce);
            float horizontally = Input.GetAxis("Horizontal");
            float vertically = Input.GetAxis("Vertical");
        }

        if (Input.GetKey(KeyCode.LeftShift) && crouchTimer > 5.0f)
        {
            maxSpeed = crouchSpeed;
            crouchTimer = crouchTimer = Time.deltaTime;
        } else
        {
            maxSpeed = noramalSpeed;
            if (Input.GetKey(KeyCode.LeftShift) == false) 
            { 
               crouchTimer = crouchTimer + Time.deltaTime;
            }
        }
        crouchTimer = Mathf.Clamp(crouchTimer, 5.0f, maxCrouch);     

        Vector3 newVelocity = (transform.forward * Input.GetAxis("Vertical") * maxSpeed) + (transform.right * Input.GetAxis("Horizontal") *maxSpeed);
        myRigidbody.velocity = new Vector3(newVelocity.x, myRigidbody.velocity.y, newVelocity.z);

        rotation = rotation + Input.GetAxis("Mouse X") * rotationSpeed;
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotation, 0.0f));

        camRotation = camRotation + Input.GetAxis("Mouse Y") * camRotationSpeed;
        
        cam.transform.localRotation = Quaternion.Euler(new Vector3(camRotation, 0.0f, 0.0f));



    }
}