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
        "El proceso digestivo comienza en la boca cuando una persona mastica. Las gl�ndulas salivales producen saliva, un jugo digestivo que humedece los alimentos para transportarlos m�s f�cilmente por el es�fago hacia el est�mago.",
        "Las gl�ndulas situadas en el revestimiento del est�mago producen �cidos estomacales y enzimas que descomponen qu�micamente los alimentos. Los m�sculos del est�mago mezclan la comida con estos jugos digestivos.",
        "El intestino delgado produce un jugo digestivo, el cual se mezcla con la bilis y un jugo pancre�tico para completar la descomposici�n qu�mica de prote�nas, carbohidratos y grasas.",
        "En el intestino grueso, m�s agua se transporta desde el tracto gastrointestinal hasta el torrente sangu�neo. Las bacterias en el intestino grueso ayudan a descomponer qu�micamente los nutrientes restantes y producen vitamina K",
        "La laringe es el �rgano fonador, uno de los �rganos que nos permite hablar, ya que contiene las cuerdas vocales, est� localizada en el cuello y ayuda a evitar que los alimentos y los l�quidos entren a la tr�quea" };
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
