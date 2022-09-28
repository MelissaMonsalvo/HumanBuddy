using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Organo : MonoBehaviour
{
    // Start is called before the first frame update

    //Dialogo
    public Dialogo dialogo;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dialogo.StartDialogue(0);
            
        }
       
    }
   
}
