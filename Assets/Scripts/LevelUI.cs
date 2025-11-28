using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    public GameObject levelPanel;
    public TextMeshProUGUI levelText;
    public int levelNumber = 1;
    public GameObject gameOverPanel;
    public Button restartButton;
    public LevelManager levelManager;
    public TextMeshProUGUI gameOverText;
    public Button menuButton;
    private SoundManager soundManager;

    private void Start()
    {
        UpdateLevelText();
    }

    private void UpdateLevelText()
    {
        levelText.text = "Level: " + levelNumber;
    }

    private void HideLevelPanel()
    {
        levelPanel.SetActive(false);
    }

    private void SetGameOverPanel(bool isActive)
    {
        gameOverPanel.SetActive(isActive);
    }

    private void AddListeners()
    {
        menuButton.onClick.AddListener(MainMenuButton);
        restartButton.onClick.AddListener(RestartButton);
    }

    private void RestartButton()
    {
        soundManager.PlayButtonClickAudio();
        levelManager.RestartLevel();
    }

    public void ShowGameWinUI()
    {
        SetGameOverPanel(true);

        gameOverText.text = "Game Completed!!";
        gameOverText.color = Color.green;
        HideLevelPanel();
    }

    public void ShowGameLoseUI()
    {
        SetGameOverPanel(true);

        gameOverText.text = "Game Over!!";
        gameOverText.color = Color.red;
        HideLevelPanel();
    }

    private void MainMenuButton()
    {
        soundManager.PlayButtonClickAudio();
        soundManager.DestroySoundManager();  // Destroy the current SoundManager
        levelManager.LoadMainMenu();
    }
    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

}



