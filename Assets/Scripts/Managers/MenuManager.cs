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
        // Switch off the Main Menu
        mainMenu.SetActive(false);
        // Switch on the Play Menu
        playMenu.SetActive(true);
        // Play some sound
        SoundManager.Instance.Play(SoundsNames.ButtonClick);

    }
    public void OnQuitButtonClicked()
    {
        SoundManager.Instance.Play(SoundsNames.ButtonClick);
        Debug.Log("Quit Game!");
    }
    public void PlayMenuBackButtonClicked()
    {   

        // set play menu inactive
        playMenu.SetActive(false);
        // set main menu active
        mainMenu.SetActive(true);
        // play sound
        SoundManager.Instance.Play(SoundsNames.ButtonClick);
    }
    public void SinglePlayerButtonClicked()
    {
        SoundManager.Instance.Play(SoundsNames.ButtonClick);
        SceneManager.LoadScene(sceneIndexOfSinglePlayer);
    }
    public void MultiPlayerButtonClicked()
    {
        SoundManager.Instance.Play(SoundsNames.ButtonClick);
        SceneManager.LoadScene(sceneIndexOfMultiPlayer);
    }
    public void MuteToggleClicked(bool _isMute)
    {
        SoundManager.Instance.Play(SoundsNames.ButtonClick);
        SoundManager.Instance.IsMute = (muteToggle.isOn);
    }

}
