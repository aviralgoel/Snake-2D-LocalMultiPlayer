using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;



public class GameMenuManager : MonoBehaviour
{
    [Header("UI Prefabs")]
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public GameObject gameStats;
    public Toggle muteToggle;
    public PlayerController controller;
    InputActions inputActions;
    string currentSceneName;
    // Start is called before the first frame update
    void Awake()
    {
        inputActions = new InputActions();
        inputActions.UIController.GamePaused.started += ctx => { PauseUnpauseGame(); };
        currentSceneName = SceneManager.GetActiveScene().name;
        if(currentSceneName == "SinglePlayerGame")
        {
            GetComponent<MultiplayerGameStats>().enabled = false;      
        }
        if(currentSceneName == "MultiPlayerGame")
        {
            GetComponent<SinglePlayerStats>().enabled = false;
        }
    }
    
    private void PauseUnpauseGame()
    {   
        // pause menu only accessible as long as Game Over Menu not visible
        if(gameOverMenu.activeSelf == false)
        {
            PlayButtonClickSound();
            pauseMenu.SetActive(!pauseMenu.activeSelf); // show / hide pause menu depending on its current status
            controller.gamePaused = pauseMenu.activeSelf; // pause or unpause game depending on pause menu hidden or not
        }
        
    }
    public void OnPauseMenuResumeButtonClicked()
    {
        //Debug.Log("Resume Button Clicked");
        // button sound
        PlayButtonClickSound();
        pauseMenu.SetActive(false);
        controller.gamePaused = false;
    }
    public void OnPauseMenuMenuButtonClicked()
    {
        //Debug.Log("Menu Button Clicked");
        // button sound
        PlayButtonClickSound();
        //change scene to main menu
        SceneManager.LoadScene(0);

    }
    public void OnGameOverPlayAgainButtonClicked()
    {
        PlayButtonClickSound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void OnGameOverMainMenuButtonClicked()
    {
        PlayButtonClickSound();
        SceneManager.LoadScene(0);
    }
    public void MuteToggleClicked(bool _t)
    {
       
        Debug.Log("Menu UI MUTE Button Clicked");

        SoundManager.Instance.SetIsMute(muteToggle.isOn);
    }
 
    public void ShowGameOverMenu()
    {
        gameOverMenu.SetActive(true);
        gameStats.SetActive(false);
        
    }
    private void OnEnable()
    {
        inputActions.UIController.Enable();
        muteToggle.isOn = SoundManager.Instance.IsMute;
       

    }
    private void OnDisable()
    {
        inputActions.UIController.Disable();
    }
    private void PlayButtonClickSound()
    {
        SoundManager.Instance.Play(SoundsNames.ButtonClick);
    }
}
