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
        pauseMenu.SetActive(!pauseMenu.activeSelf); // show / hide pause menu depending on its current status
        controller.gamePaused = pauseMenu.activeSelf; // pause or unpause game depending on pause menu hidden or not
    }
    public void OnPauseMenuResumeButtonClicked()
    {   
        // button sound
        SoundManager.Instance.Play(SoundsNames.ButtonClick);
        // switch off the pause menu
        pauseMenu.SetActive(false);
        controller.gamePaused = false;
    }
    public void OnPauseMenuMenuButtonClicked()
    {   
        // button sound
        SoundManager.Instance.Play(SoundsNames.ButtonClick);
        //change scene to main menu
        SceneManager.LoadScene(0);
    }
    public void OnGameOverPlayAgainButtonClicked()
    {
        controller.PlayerSpawn();
        gameOverMenu.SetActive(false);
        gameStats.SetActive(true);
       
    }
    public void OnGameOverMainMenuButtonClicked()
    {
        SoundManager.Instance.Play(SoundsNames.ButtonClick);
        //change scene to main menu
        SceneManager.LoadScene(0);
    }
    public void MuteToggleClicked(bool _t)
    {   
        SoundManager.Instance.Play(SoundsNames.ButtonClick);
        SoundManager.Instance.IsMute = (muteToggle.isOn);
    }
 
    public void ShowGameOverMenu()
    {
        gameOverMenu.SetActive(true);
        gameStats.SetActive(false);  
    }
    private void OnEnable()
    {
        inputActions.UIController.Enable();
    }
    private void OnDisable()
    {
        inputActions.UIController.Disable();
    }
}