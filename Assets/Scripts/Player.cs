using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    private float horizontalInput, verticalInput;
    public LevelManager levelManager;
    private SoundManager soundManager;

    void Start()
    {
        // Initialize the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();

        // Ensure the LevelManager is assigned, if not, try to find it in the scene
        if (levelManager == null)
        {
            levelManager = FindObjectOfType<LevelManager>();
            if (levelManager == null)
            {
                Debug.LogError("LevelManager not found in the scene!");
            }
        }

        // Get the SoundManager from the scene
        soundManager = FindObjectOfType<SoundManager>();

        // If SoundManager is not found, log an error
        //if (soundManager == null)
        //{
        //    Debug.LogError("SoundManager not found in the scene.");
        //}
        //else
        //{
        //    Debug.Log("SoundManager found in the scene.");
        //}
    }

    void Update()
    {
        // Get player input for movement
        GetInput();
    }

    void FixedUpdate()
    {
        // Move the player
        MovePlayer();
    }

    private void GetInput()
    {
        // Read horizontal and vertical input (e.g., arrow keys, WASD)
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        // Calculate and apply the player's movement velocity
        Vector2 newVelocity = new Vector2(horizontalInput, verticalInput).normalized * speed;
        rb.velocity = newVelocity;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the player collided with an obstacle
        if (other.gameObject.CompareTag("Obstacle"))
        {
            PlayerDied();
        }
    }

    private void PlayerDied()
    {
        // Play the game over sound and handle player death
        if (soundManager != null)
        {
            soundManager.PlayGameOverAudio();
        }

        if (levelManager != null)
        {
            levelManager.OnPlayerDeath();
        }

        // Destroy the player object (or deactivate it)
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player reached the finish line
        if (other.gameObject.CompareTag("Finish"))
        {
            LevelComplete();
        }
    }

    private void LevelComplete()
    {
        // Play level complete sound and handle level completion
        if (soundManager != null)
        {
            soundManager.PlayLevelCompleteAudio();
        }

        if (levelManager != null)
        {
            levelManager.OnLevelComplete();
        }
        else
        {
            Debug.LogError("LevelManager is not assigned!");
        }

        // Deactivate the player object
        gameObject.SetActive(false);
    }
}
