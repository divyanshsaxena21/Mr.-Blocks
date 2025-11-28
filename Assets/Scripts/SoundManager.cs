using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Audio sources and clips
    public AudioSource backgroundAudioSource;
    public AudioClip gameOverAudio;
    public AudioClip buttonClick;
    public AudioClip levelCompleteAudio;
    public AudioSource soundFXAudioSource;

    // Play the Game Over sound effect
    public void PlayGameOverAudio()
    {
        if (soundFXAudioSource != null && gameOverAudio != null)
        {
            soundFXAudioSource.PlayOneShot(gameOverAudio);
        }
        else
        {
            Debug.LogError("SoundFXAudioSource or GameOverAudio is not assigned!");
        }
    }

    // Play the button click sound effect
    public void PlayButtonClickAudio()
    {
        if (soundFXAudioSource != null && buttonClick != null)
        {
            soundFXAudioSource.PlayOneShot(buttonClick);
        }
        else
        {
            Debug.LogError("SoundFXAudioSource or ButtonClickAudio is not assigned!");
        }
    }

    // Start playing the background music
    public void PlayBackgroundMusic()
    {
        if (backgroundAudioSource != null && backgroundAudioSource.clip != null && !backgroundAudioSource.isPlaying)
        {
            backgroundAudioSource.Play();
        }
        else
        {
            Debug.LogError("BackgroundAudioSource or BackgroundMusic clip is missing!");
        }
    }

    // Play the level complete sound effect
    public void PlayLevelCompleteAudio()
    {
        if (soundFXAudioSource != null && levelCompleteAudio != null)
        {
            soundFXAudioSource.PlayOneShot(levelCompleteAudio);
        }
        else
        {
            Debug.LogError("SoundFXAudioSource or LevelCompleteAudio is not assigned!");
        }
    }

    // Called when the object is created, ensures the sound manager persists across scenes
    private void Awake()
    {
        DontDestroyOnLoad(gameObject); // Prevents the SoundManager from being destroyed when loading a new scene
        PlayBackgroundMusic(); // Start playing background music
    }

    // Optionally, you can destroy the SoundManager if it's no longer needed
    public void DestroySoundManager()
    {
        Destroy(gameObject);
    }
}
