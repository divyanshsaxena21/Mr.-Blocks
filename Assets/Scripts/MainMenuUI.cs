using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;
    private SoundManager soundManager;

    private const int firstLevel = 1;  // Define the first level to load

    private void Awake()
    {
        // Find SoundManager in the scene
        soundManager = FindObjectOfType<SoundManager>();
        if (soundManager == null)
            Debug.LogError("SoundManager not found in the scene!");

        // Add listeners after checking button assignments
        AddListeners();
    }

    private void AddListeners()
    {
        if (playButton != null)
            playButton.onClick.AddListener(Play);
        else
            Debug.LogError("Play Button not assigned in the Inspector!");

        if (quitButton != null)
            quitButton.onClick.AddListener(Quit);
        else
            Debug.LogError("Quit Button not assigned in the Inspector!");
    }

    private void Play()
    {
        if (soundManager != null)
            soundManager.PlayButtonClickAudio();
        else
            Debug.LogWarning("SoundManager not found! Button click audio won't play.");

        // Load the first level when play button is clicked
        SceneManager.LoadScene(firstLevel);
    }

    private void Quit()
    {
        if (soundManager != null)
            soundManager.PlayButtonClickAudio();
        else
            Debug.LogWarning("SoundManager not found! Button click audio won't play.");

        // Quit the game when quit button is clicked
        Application.Quit();
        Debug.Log("Game quit");  // Log message for editor (since quit doesn't work in the editor)
    }
}
