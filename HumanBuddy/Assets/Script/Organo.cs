using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Organo : MonoBehaviour
{
    public PlayerProfile playerProfile;
    string[] organostag = { "boca", "stomago", "laringe", "intestino_grueso" , "intestino_delgado" };

    List<string> lista = new List<string>() { "boca", "stomago", "laringe", "intestino_grueso", "intestino_delgado" };
    void Start()
    {
        int index = lista.IndexOf(this.gameObject.name);
        if (playerProfile.oSD[index])
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}
