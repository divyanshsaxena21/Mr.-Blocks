using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class LevelManager : MonoBehaviour
{
    private int currentSceneIndex;
    public LevelUI levelUI;
    private const int mainMenuIndex = 0;

    public void LoadMainMenu() => SceneManager.LoadScene(mainMenuIndex);

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void OnLevelComplete() => LoadNextLevel();

    private void LoadNextLevel()
    {
        int nextSceneIndex = currentSceneIndex + 1;
        int totalNumberOfScenes = SceneManager.sceneCountInBuildSettings;

        if (nextSceneIndex < totalNumberOfScenes)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("You've completed all levels!");
            if (levelUI != null) levelUI.ShowGameWinUI();
        }
    }

    public void OnPlayerDeath()
    {
        if (levelUI != null)
            levelUI.ShowGameLoseUI();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }
}
