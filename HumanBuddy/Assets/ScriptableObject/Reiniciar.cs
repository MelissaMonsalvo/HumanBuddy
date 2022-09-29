using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reiniciar : MonoBehaviour
{
    public PlayerProfile playerProfile;
    // Start is called before the first frame update
    public DataManager dt;
    public GameObject[] organos;

    public GameObject personaje;
    public GameObject personaje2;
    public GameObject inicio;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void reiniciar()
    {
        playerProfile.oSD = new bool[] { false, false, false, false, false };
        playerProfile.oSR = new bool[] { false, false, false, false, false };
        playerProfile.organosEncontrados = 0;
        playerProfile.organosEncontrados = 0;
        playerProfile.gemaLevel = 1;
        playerProfile.level = 1;
        for (int i =0; i < organos.Length; i++)
        {
            organos[i].SetActive(true);
        }
        dt.SaveData();
        personaje.transform.position = inicio.transform.position;
        personaje2.transform.position = inicio.transform.position;


    }
}
