using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameMenuManager : MonoBehaviour
{
    InputActions inputActions;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public GameObject gameStats;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI shieldText;
    public TextMeshProUGUI scoreMultiplierText;
    public TextMeshProUGUI speedText;
    public Toggle muteToggle;
    public PlayerController controller;
// Start is called before the first frame update
    void Awake()
    {
        inputActions = new InputActions();
        inputActions.UIController.GamePaused.started += ctx => { PauseUnpauseGame(); };
    }
    private void Update()
    {
        updateStats();
    }
    private void PauseUnpauseGame()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        controller.gamePaused = pauseMenu.activeSelf;
    }

    public void OnPauseMenuResumeButtonClicked()
    {   // button sound
        SoundManager.Instance.Play(SoundsNames.ButtonClick);
        // switch off the pause menu
        pauseMenu.SetActive(false);
        controller.gamePaused = pauseMenu.activeSelf;
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
        controller.ResetState();
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
    public void updateStats()
    {
        scoreText.text = "Score: " + controller.snake.Score;
        scoreMultiplierText.text = "Score Multiplier: " + controller.snake.ScoreBoostMultiplier;
        speedText.text = "Speed: " + controller.snake.MoveSpeed;
        shieldText.text = "Shield:" + (controller.snake.getIsImmune() ? "On" : "Off");

    }
    public void ShowGameOverMenu()
    {
        gameOverMenu.SetActive(true);
        gameStats.SetActive(false);
        
    }
    // Update is called once per frame
    private void OnEnable()
    {
        inputActions.UIController.Enable();
    }
    private void OnDisable()
    {
        inputActions.UIController.Disable();
    }
}
