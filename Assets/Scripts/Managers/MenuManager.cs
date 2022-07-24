using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Script Purpose: Functions to be invoked when Main Menu UI Buttons are clicked
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
        // Play button sound
        PlayButtonClickSound();
        // Switch off the Main Menu
        mainMenu.SetActive(false);
        // Switch on the Play Menu
        playMenu.SetActive(true);
    }

    public void OnQuitButtonClicked()
    {
        PlayButtonClickSound();
        // close the game or stop play mode
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    // back button clicked from the Play Mode Select Menu
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

    // Method to play the sound of button click
    private void PlayButtonClickSound()
    {
        SoundManager.Instance.Play(SoundsNames.ButtonClick);
    }

    // called every time we come back to main menu scene
    private void OnEnable()
    {
        // when the script is loaded set state of Mute = state of mute from previous scene
        muteToggle.isOn = SoundManager.Instance.IsMute;
    }
}