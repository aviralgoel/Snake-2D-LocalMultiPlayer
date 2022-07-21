using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject playMenu;
    public Toggle muteToggle;
    private int sceneIndexOfSinglePlayer;
    private int sceneIndexOfMultiPlayer;
    

    private void Awake()
    {
        sceneIndexOfSinglePlayer = 1;
        sceneIndexOfMultiPlayer = 2;
    }

    public void OnPlayButtonClicked()
    {
        PlayButtonClickSound();
        // Switch off the Main Menu
        mainMenu.SetActive(false);
        // Switch on the Play Menu
        playMenu.SetActive(true);
    }
    public void OnQuitButtonClicked()
    {
        PlayButtonClickSound();
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
        Application.Quit();
    }
    public void PlayMenuBackButtonClicked()
    {  
        // set play menu inactive
        playMenu.SetActive(false);
        // set main menu active
        mainMenu.SetActive(true);
        // play sound
        PlayButtonClickSound();

    }
    public void SinglePlayerButtonClicked()
    {
        PlayButtonClickSound();
        SceneManager.LoadScene(sceneIndexOfSinglePlayer);
    }
    public void MultiPlayerButtonClicked()
    {
        PlayButtonClickSound();
        SceneManager.LoadScene(sceneIndexOfMultiPlayer);
    }
    public void MuteToggleClicked(bool _isMute)
    {
        PlayButtonClickSound();
        SoundManager.Instance.SetIsMute(muteToggle.isOn);
    }
    private void PlayButtonClickSound()
    {
        SoundManager.Instance.Play(SoundsNames.ButtonClick);
    }
    private void OnEnable()
    {
        
        muteToggle.isOn = SoundManager.Instance.IsMute;


    }
}
