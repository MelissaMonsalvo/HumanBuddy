using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class PlayerData : MonoBehaviour
{
    private int organosSD;

    public float liveLevel;
    
    public float gemaLevel;
    public float LiveLevel
    {
        get => liveLevel;
        set => liveLevel = value;
    }

    public float GemaLevel
    {
        get => gemaLevel;
        set => gemaLevel = value;
    }

    public int OrganosSD
    {
        get => organosSD;
        set => organosSD = value;
    }


    public static PlayerData Instance;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
            Instance = this;
    }

    void Start()
    {
        gemaLevel = 1.0f;
        liveLevel = 1.0f;
        organosSD = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
            ReduceLiveLevel();
        if (Input.GetKeyDown(KeyCode.P))
            ReduceGemaLevel();
    }

    public void ReduceLiveLevel()
    {
        if(liveLevel > 0)
        {
            liveLevel -= 0.1f;
        }
        else
        {
            //Llamar al panel de pregunta
        }
    }

    public void ReduceGemaLevel()
    {
        if (gemaLevel > 0)
        {
            gemaLevel -= 0.1f;
        }
        else
        {
            //Desactivar la gema
        }
    }

}
