using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respuesta : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quiz;
    public PlayerProfile playerProfile;
    public IUManager iUManager;
    public void answer()
    {
        if (isCorrect)
        {
            //es correcto
            //quiz.correctPlayerProfile.
            playerProfile.LiveLevel = 1;
            Debug.Log("Correcto");
            iUManager.ShowHUD();
            GameManager.Instance.ChangeState(GameState.PLAYING);
        }
        else
        {
            //no es correcto
            //quiz.correcto();
            Debug.Log("Inorrecto");
            GameManager.Instance.ChangeState(GameState.GAME_OVER);

        }
    }
}
