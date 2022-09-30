using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    private Animator playeranimator;

    private float velocidad = 1.0F;
    public float velocidadCorrer = 20.0F;
    public float velocidadCaminar = 1.0F;

    public float rotationSpeed = 100.0F;

    AnimatorStateInfo currentState;
    CapsuleCollider capsuleCollider;

    bool grabObject;
    public GameObject obj;
    private Rigidbody rb;


    //caida
    public float Gravedad = -9.81f;
    public Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask floorMask;
    bool isGrounded;

    //Dialogo
    public Dialogo dialogo;
    public PlayerProfile playerProfile;

    public GameEvent saveEvent;



    // Start is called before the first frame update
    void Start()
    {
        playeranimator = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        currentState = playeranimator.GetCurrentAnimatorStateInfo(0);



        //Correr

        if (Input.GetKeyUp(KeyCode.Q))
        {
            playerProfile.ReduceGemaLevel();
        }

        if (Input.GetKey(KeyCode.Q)&& playerProfile.gemaLevel>0)
        {
     
            playeranimator.SetTrigger("run");
            
        }
        else
        {
            playeranimator.ResetTrigger("run");
            velocidad = velocidadCaminar;
        }

        // Movimiento
        playeranimator.SetFloat("speed", Input.GetAxis("Vertical"));
        playeranimator.SetFloat("direccion", Input.GetAxis("Horizontal"));
        transform.Translate(0, 0, Input.GetAxis("Vertical") * velocidad * Time.deltaTime);
        //rb.velocity = new Vector3 (0, 0, Input.GetAxis("Vertical") * velocidad * Time.deltaTime);
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime, 0);



        //Caer

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, floorMask);


        //Si esta callendo
        if (!isGrounded)
        {
            velocity.y += Gravedad * Time.deltaTime;
            transform.Translate(0, velocity.y * Time.deltaTime, 0);

        }

        //Debug.Log(velocity.y);


        //Unico salto
        
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playeranimator.SetTrigger("jump");
            //velocidad = velocidadCorrer;
            velocity.y = Mathf.Sqrt(3 * -2f * Gravedad);
            transform.Translate(0, velocity.y * Time.deltaTime, 0);


        }
        
        //salto multiple
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            playeranimator.SetTrigger("jump");
            velocidad = velocidadCorrer;
            velocity.y = Mathf.Sqrt(3 * -2f * Gravedad);
            transform.Translate(0, velocity.y * Time.deltaTime, 0);


        }*/


        //Agarrar
        if (Input.GetKeyDown(KeyCode.G))
        {
            playeranimator.SetTrigger("grab");
        }

        if (currentState.IsName("IdleGrab_Neutral"))
            grabObject = true;
        else
            grabObject = false;


    }
    

    public void ChangeSizeCapsule(float size)
    {
        capsuleCollider.height = size;

    }



    private void OnAnimatorIK(int layerIndex)
    {
        if(grabObject)
        {
            playeranimator.SetLookAtPosition(obj.transform.position);
            playeranimator.SetLookAtWeight(1.0f, 1.0f, 1.0f, 1.0f);
            playeranimator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1.0f);
            playeranimator.SetIKPosition(AvatarIKGoal.RightHand, obj.transform.position);
        }
        else
        {
            playeranimator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0f);
            playeranimator.SetLookAtWeight(0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("item"))
        {
            switch (other.gameObject.name)
            {
                case "boca":
                    dialogo.StartDialogue(0);
                    playerProfile.AddOrgano(1, 0);
                    break;
                case "stomago":
                    dialogo.StartDialogue(1);
                    playerProfile.AddOrgano(1, 1);
                    break;
                case "laringe":
                    dialogo.StartDialogue(2);
                    playerProfile.AddOrgano(1, 2);
                    break;
                case "intestino_grueso":
                    dialogo.StartDialogue(3);
                    playerProfile.AddOrgano(1, 3);
                    break;
                case "intestino_delgado":
                    dialogo.StartDialogue(4);
                    playerProfile.AddOrgano(1, 4);
                    break;
                

            }
            saveEvent.Raise();
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            
        }

        if (other.gameObject.CompareTag("joya"))
        {

            playerProfile.GemaLevel = 1;
            saveEvent.Raise();
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
        }
        Debug.Log(other.gameObject.name);


    }


}
