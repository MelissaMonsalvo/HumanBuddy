using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogo : MonoBehaviour
{
    public GameObject panelDialogo;

    public TextMeshProUGUI titleText;
    public TextMeshProUGUI dialogueText;
    string[] titulos = { 
        "Boca", 
        "Estomago", 
        "Intestino delgado", 
        "Intestino grueso", 
        "Laringe" };
    string[] lines = { 
        "Boca fjdhfhfi",
        "Estomago fkjsdfs",
        "Intestino delgado sajdks",
        "Intestino grueso dsijadias",
        "Laringe ijjisjd" };
    public float textSpeed = 0.1f;
    int index;



    /* private void OnTriggerEnter(Collider other)
     {
         if (other.gameObject.CompareTag("estomago"))
         {
             index = 1;
             dialogueText.text = lines[index];
             StartDialogue();
             Debug.Log("Colision");
         }

     }*/



    // Start is called before the first frame update
    void Start()
    {
        panelDialogo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StopAllCoroutines();
            dialogueText.text = lines[index];
            titleText.text = titulos[index];
        }
    }

    public void StartDialogue(int indice)
    {
        panelDialogo.SetActive(true);
        index = indice;
        dialogueText.text = string.Empty;
        titleText.text = string.Empty;
        StartCoroutine(WriteLine());
    }
    IEnumerator WriteLine()
    {
        foreach (char letter in titulos[index].ToCharArray())
        {
            titleText.text += letter;
            yield return new WaitForSeconds(textSpeed);

        }
        foreach (char letter in lines[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed);


        }
    }

    public void ocultarPanelDialogo()
    {
        panelDialogo.SetActive(false);
    }


}
