
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{

    public GameState currentState;
    public static GameManager Instance;

    public event EventHandler PauseEvent;
    public event EventHandler PlayingEvent;
    public event EventHandler GameOverEvent;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (Instance != null)
            Destroy(this.gameObject);
        else
            Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        ChangeState(GameState.PLAYING);
    }


    public void ChangeState(GameState newState)
    {
        currentState = newState;

        switch (currentState)
        {
            case GameState.MAIN_MENU:
                break;
            case GameState.START:
                break;
            case GameState.PLAYING:
                Time.timeScale = 1f;
                PlayingEvent?.Invoke(this, EventArgs.Empty);
                break;
            case GameState.PAUSE:
                Time.timeScale = 0f;
                PauseEvent?.Invoke(this, EventArgs.Empty);
                break;
            case GameState.GAME_OVER:
                GameOverEvent?.Invoke(this, EventArgs.Empty);
                break;
        }
    }
    private void OnPlaying()
    {
        //Debug.Log("On Playing");
    }
}
public enum GameState
{
    MAIN_MENU,
    START,
    PLAYING,
    PAUSE,
    GAME_OVER
}