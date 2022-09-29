
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerProfile", menuName = "Player/Data")]
public class PlayerProfile : ScriptableObject
{
    public int organosSD;
    public bool[] oSD = new bool[] {false,false,false,false,false};

    public int organosSR;
    public bool[] oSR = new bool[] { false, false, false, false, false };

   
    public int organosEncontrados = 0;

    public float liveLevel=1;

    public float gemaLevel=1;

    public int level = 1;

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

    public int OrganosSR
    {
        get => organosSR;
        set => organosSR = value;
    }
    public int OrganosEncontrados
    {
        get => organosEncontrados;
        set => organosEncontrados = value;
    }

    public int Level
    {
        get => level;
        set => level = value;
    }

    public void IncraseLevel()
    {
        level++;
    }
    public void ReduceLiveLevel()
    {
        if (liveLevel > 0)
        {
            liveLevel -= 0.1f;
        }
        else
        {

            GameManager.Instance.ChangeState(GameState.QUIZ);

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

    public void AddOrgano(int nivel, int organo)
    {
        organosEncontrados++;
        switch (nivel)
        {
            case 1:
                oSD[organo] = true;
                if (organosEncontrados>=OrganosSD)
                    GameManager.Instance.ChangeState(GameState.WIN);
                break;
            case 2:
                oSR[organo] = true;
                break;
            default:
                break;
        }
     
    }

}
