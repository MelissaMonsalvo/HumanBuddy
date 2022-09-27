
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerProfile", menuName = "Player/Data")]
public class PlayerProfile : ScriptableObject
{
    public int organosSD;
    public bool[] oSD = new bool[] {false,false,false,false,false};

    public int organosSR;
    public bool[] oSR = new bool[] { false, false, false, false, false };

    private int organosEncontrados=0;

    public float liveLevel=1;

    public float gemaLevel=1;
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

    public void ReduceLiveLevel()
    {
        if (liveLevel > 0)
        {
            liveLevel -= 0.1f;
        }
        else
        {
            //Llamar al panel de pregunta
            /*si responde bien la pregunta
             * sigue jugando
             * si no
             *  GameManager.Instance.ChangeState(GameState.GAME_OVER);
             *  */
            GameManager.Instance.ChangeState(GameState.GAME_OVER);

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
        switch (nivel)
        {
            case 1:
                oSD[organo] = true;
                break;
            case 2:
                oSR[organo] = true;
                break;
            default:
                break;
        }
        organosEncontrados++;
    }

}
