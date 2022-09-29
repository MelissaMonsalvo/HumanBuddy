using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerProfile playerProfile;
    public string filePath;

    private StreamReader sreader;
    private StreamWriter swriter;

    private string fileContent;

    private Player player;
    //public GameEvent loadEvent;


    void Start()
    {
        if (File.Exists(Application.persistentDataPath + "/" + filePath))
        {
            sreader = new StreamReader(Application.persistentDataPath + "/" + filePath);
            fileContent = sreader.ReadToEnd();
            sreader.Close();
            player = new Player();
            player = JsonUtility.FromJson<Player>(fileContent);
            playerProfile.organosSD = player.organosSD;
            playerProfile.oSD = player.oSD;
            playerProfile.organosSR = player.organosSR;
            playerProfile.oSR = player.oSR;
            playerProfile.organosEncontrados= player.organosEncontrados;
            playerProfile.liveLevel = player.liveLevel;
            playerProfile.gemaLevel = player.gemaLevel;
            playerProfile.level = player.level;

        }


    }
    public void SaveData()
    {
        Debug.Log("FilePath: " + Application.persistentDataPath + "/" + filePath);
        swriter = new StreamWriter(Application.persistentDataPath + "/" + filePath, false);
        player = new Player();
        player.organosSD = playerProfile.organosSD;
        player.oSD = playerProfile.oSD;
        player.organosSR = playerProfile.organosSR;
        player.oSR = playerProfile.oSR;
        player.organosEncontrados = playerProfile.organosEncontrados;
        player.liveLevel = playerProfile.liveLevel;
        player.gemaLevel = playerProfile.gemaLevel;
        player.level = playerProfile.level;
        swriter.Write(JsonUtility.ToJson(player));
        swriter.Close();
    }
    
}
[System.Serializable]
class Player
{
    public int organosSD;
    public bool[] oSD = new bool[] { false, false, false, false, false };

    public int organosSR;
    public bool[] oSR = new bool[] { false, false, false, false, false };

    public int organosEncontrados = 0;

    public float liveLevel = 1;

    public float gemaLevel = 1;

    public int level = 1;
}