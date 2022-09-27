using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public CharacterController cc;
    public float Velocidad = 12;
    public float rotationSpeed = 180;
    public float Gravedad = -9.81f;
    public Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask floorMask;
    bool isGrounded;
    /*void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, floorMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -3f;
        }

        //if (Input.GetButtonDown("Jump") && isGrounded)
        if (Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(3 * -2f * Gravedad);
        }

        float x = 0; //Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        cc.Move(move * Velocidad * Time.deltaTime);
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed, 0);


        velocity.y += Gravedad * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);

    }*/

    public float speed;
    public float jumpForce;
    public float velocidadRot;
    public Camera camara;


    private Rigidbody rb;
    private Vector3 movement;
    private Vector3 localMovement;
    private bool enableController;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Confined;
    }
    void Update()
    {
        movement = Vector3.zero;
        if (!enableController)
            return;
        CalculateMovement();
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();


        //rb.velocity = camara.transform.TransformDirection(movement) + Vector3.up*rb.velocity.y;
        //rb.velocity = camara.transform.TransformDirection(movement*Time.deltaTime*velocidadRot);
        localMovement = camara.transform.TransformDirection(movement);
        rb.velocity = Vector3.ProjectOnPlane(localMovement, Vector3.up);
        transform.Rotate(0, Input.GetAxis("Mouse X") * velocidadRot * Time.deltaTime, 0);
        //camara.transform.Rotate(-Input.GetAxis("Mouse Y") * velocidadRot * Time.deltaTime, 0, 0);
        if (Input.GetKeyDown(KeyCode.G))
            ChangeGravity();

    }
    private void ChangeGravity()
    {
        Physics.gravity = Vector3.up * 9.81f;
    }
    private void Jump()
    {
        //movement.y = 25f;
        rb.AddForce(Vector3.up * jumpForce);
    }
    private void CalculateMovement()
    {
        movement.x = Input.GetAxis("Horizontal") * speed;
        movement.z = Input.GetAxis("Vertical") * speed;
    }
    public void EnableController()
    {
        enableController = true;
    }
    public void DisableController()
    {
        enableController = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("estomago"))
        {
           Debug.Log("ESSSSSSSSSSSS");
        }
    }

}
