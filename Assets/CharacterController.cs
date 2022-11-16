using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
   



    public float maxSpeed = 0.01f;
    float rotation = 0.2f;
    float camRotation = 0.2f;
    GameObject cam;
    Rigidbody myRigidbody;

    bool isOnGround;
    public GameObject GroundChecker;
    public LayerMask groundLayer;

    float rotationSpeed = 2.0F;
    float camRotationSpeed = 1.5f;

    float jumpForce = 400f;
    

    void Start()
    {
        cam = GameObject.Find("Main Camera");
        myRigidbody = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        camRotation = Mathf.Clamp(camRotation, -40.0f, 40.0f);
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

        Vector3 newVelocity = transform.forward * Input.GetAxis("Vertical") * maxSpeed;
        myRigidbody.velocity = new Vector3(newVelocity.x, myRigidbody.velocity.y, newVelocity.z);

        rotation = rotation + Input.GetAxis("Mouse X") * rotationSpeed;
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotation, 0.0f));

        camRotation = camRotation + Input.GetAxis("Mouse Y") * camRotationSpeed;
        
        cam.transform.localRotation = Quaternion.Euler(new Vector3(camRotation, 0.0f, 0.0f));



    }
}