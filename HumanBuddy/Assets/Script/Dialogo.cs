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
        "El proceso digestivo comienza en la boca cuando una persona mastica. Las glándulas salivales producen saliva, un jugo digestivo que humedece los alimentos para transportarlos más fácilmente por el esófago hacia el estómago.",
        "Las glándulas situadas en el revestimiento del estómago producen ácidos estomacales y enzimas que descomponen químicamente los alimentos. Los músculos del estómago mezclan la comida con estos jugos digestivos.",
        "El intestino delgado produce un jugo digestivo, el cual se mezcla con la bilis y un jugo pancreático para completar la descomposición química de proteínas, carbohidratos y grasas.",
        "En el intestino grueso, más agua se transporta desde el tracto gastrointestinal hasta el torrente sanguíneo. Las bacterias en el intestino grueso ayudan a descomponer químicamente los nutrientes restantes y producen vitamina K",
        "La laringe es el órgano fonador, uno de los órganos que nos permite hablar, ya que contiene las cuerdas vocales, está localizada en el cuello y ayuda a evitar que los alimentos y los líquidos entren a la tráquea" };
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
