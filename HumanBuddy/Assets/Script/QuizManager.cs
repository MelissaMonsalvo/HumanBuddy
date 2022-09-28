using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class QuizManager : MonoBehaviour
{
    public List<PreguntayRespuesta> QnA;
    public GameObject[] opciones;
    public int preguntaActual;
    public TextMeshProUGUI preguntaTxt;

    // Start is called before the first frame update
    void Start()
    {
        //generarPregunta();
        GameManager.Instance.QuizEvent += generarPregunta;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void correcto()
    {
        //generarPregunta();
    }
    void setRespuesta()
    {
        for(int i=0; i < opciones.Length; i++)
        {
            opciones[i].GetComponent<Respuesta>().isCorrect = false;
            opciones[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[preguntaActual].respuestas[i];
            if(QnA[preguntaActual].respuestaCorrecta == i)
            {
                opciones[i].GetComponent<Respuesta>().isCorrect = true;
            }
        }
    }
    void generarPregunta(object sender, EventArgs e)
    {
        preguntaActual = UnityEngine.Random.Range(0, QnA.Count);
        preguntaTxt.text = QnA[preguntaActual].pregunta;
        setRespuesta();
        
    }
}
