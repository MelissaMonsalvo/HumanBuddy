using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class IUManager : MonoBehaviour
{

    public int nivelNum;
    public int organoNum;

    public GameObject HUDPanel;
    public GameObject pausePanel;
    public GameObject personajePanel;
    public GameObject gameOverPanel;
    public GameObject settingsPanel;
    public GameObject qnaPanel;
    public GameObject winPanel;

    public GameObject personaje1;
    public GameObject personaje2;
    public Sprite p1;
    public Sprite p2;
    public Button btn_personaje;

    public AudioMixer audioMixer;
    public Slider masterSlider;
    public Slider sfxSlider;
    public Slider musicSlider;

    public Image liveBar;
    public Image gemaImg;

    public PlayerProfile playerProfile;

    public GameObject[] organosContainer;
    public static IUManager Instance;

    //private PlayerData playerData;


    // Start is called before the first frame update
    void Start()
    {

        
        GameManager.Instance.GameOverEvent += ShowGameOver;
        GameManager.Instance.QuizEvent+= ShowQna;
        GameManager.Instance.WinEvent += ShowWin;


        ShowHUD();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
            playerProfile.ReduceLiveLevel();
        if (Input.GetKeyDown(KeyCode.P))
            playerProfile.ReduceGemaLevel();
        if (Input.GetKeyDown(KeyCode.T))
            playerProfile.AddOrgano(nivelNum, organoNum);


        OnReduceLiveLevel();
        OnReduceGemaLevel();
        OnFindOrgans(nivelNum);


    }

    public void ShowHUD()
    {
        ClearPanels();
        HUDPanel.SetActive(true);
        GameManager.Instance.ChangeState(GameState.PLAYING);
    }
    public void ShowPause()
    {
        ClearPanels();
        pausePanel.SetActive(true);
        GameManager.Instance.ChangeState(GameState.PAUSE);
    }
    public void ShowSettings()
    {
        ClearPanels();
        ApplyAudioMixerSettings();
        settingsPanel.SetActive(true);
    }
    public void ShowQna(object sender, EventArgs e)
    {
        ClearPanels();
        qnaPanel.SetActive(true);
    }
    public void ShowPersonajePanel()
    {
        ClearPanels();
        personajePanel.SetActive(true);
        GameManager.Instance.ChangeState(GameState.PAUSE);
    }

    public void ShowGameOver(object sender, EventArgs e)
    {
        ClearPanels();
        gameOverPanel.SetActive(true);
    }
    public void ShowWin(object sender, EventArgs e)
    {
        ClearPanels();
        winPanel.SetActive(true);
    }

    public void cambioPersonaje(int opcion)
    {

        if (opcion == 1)
        {
           
            personaje1.SetActive(true);
            personaje1.transform.position = personaje2.transform.position;
            personaje1.transform.rotation = personaje2.transform.rotation;
            personaje2.SetActive(false);
            btn_personaje.image.sprite = p1;
        }
        else
        {
            personaje2.SetActive(true);
            personaje2.transform.position = personaje1.transform.position;
            personaje2.transform.rotation = personaje1.transform.rotation;
            personaje1.SetActive(false);
            btn_personaje.image.sprite = p2;
        }
        personajePanel.SetActive(false);
        ShowHUD();
    }

    private void ClearPanels()
    {
        HUDPanel.SetActive(false);
        pausePanel.SetActive(false);
        personajePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        settingsPanel.SetActive(false);
        qnaPanel.SetActive(false);
        winPanel.SetActive(false);
    }


    public void OnReduceLiveLevel()
    {
        
        liveBar.fillAmount = playerProfile.liveLevel;
    }
    public void OnReduceGemaLevel()
    {
        
        gemaImg.fillAmount = playerProfile.gemaLevel;
    }


    public void OnFindOrgans(int nivel)
    {
        int numOrganos;
        CleanOrganosContainers();
        switch (nivel)
        {
            case 1:
                numOrganos = playerProfile.OrganosSD;

                for (int i = 0; i < numOrganos; i++)
                {
                    if (playerProfile.oSD[i])
                        organosContainer[i].SetActive(true);
                }
                break;
            case 2:
                numOrganos = playerProfile.OrganosSR;
                for (int i = 0; i < numOrganos; i++)
                {
                    if (playerProfile.oSR[i])
                        organosContainer[i].SetActive(true);
                }
                break;
            default:
                numOrganos = 0;
                break;
        }

        

    }
    private void CleanOrganosContainers()
    {
        for (int i = 0; i < organosContainer.Length; i++)
        {
            organosContainer[i].SetActive(false);
        }
    }

    public void ApplyAudioMixerSettings()
    {
        float masterVolume = 0f;
        if (audioMixer.GetFloat("GeneralVolume", out masterVolume))
            masterSlider.value = masterVolume;
        if (audioMixer.GetFloat("MusicVolume", out masterVolume))
            musicSlider.value = masterVolume;
        if (audioMixer.GetFloat("SFXVolume", out masterVolume))
            sfxSlider.value = masterVolume;
    }
    public void OnGlobalVolumeChange(float gVolume)
    {
        audioMixer.SetFloat("GeneralVolume", gVolume);
    }
    public void OnGlobalVolumeChange(int gVolume)
    {
        audioMixer.SetFloat("GeneralVolume", (float)gVolume);
    }
    public void OnMusicVolumeChange(float mVolume)
    {
        audioMixer.SetFloat("MusicVolume", mVolume);
    }
    public void OnSFxVolumeChange(float sfxVolume)
    {
        audioMixer.SetFloat("SFXVolume", sfxVolume);
    }

    public void DrawItems()
    {
        int numOrganos;

        liveBar.fillAmount = playerProfile.liveLevel;
        gemaImg.fillAmount = playerProfile.gemaLevel;
        CleanOrganosContainers();

        switch (playerProfile.level)
        {
            case 1:
                numOrganos = playerProfile.OrganosSD;

                for (int i = 0; i < numOrganos; i++)
                {
                    if (playerProfile.oSD[i])
                        organosContainer[i].SetActive(true);
                }
                break;
            case 2:
                numOrganos = playerProfile.OrganosSR;
                for (int i = 0; i < numOrganos; i++)
                {
                    if (playerProfile.oSR[i])
                        organosContainer[i].SetActive(true);
                }
                break;
            default:
                numOrganos = 0;
                break;
        }
    }

}
