using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float flapForce = 5f;
    public GameObject gameOverPanel;

    private Rigidbody2D rb;
    private bool isGamePaused = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isGamePaused)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Flap();
            }
        }
    }

    void Flap()
    {
        rb.velocity = new Vector2(0, flapForce);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Vector2 obstacleDirection = collision.transform.position - transform.position;
            float angle = Vector2.Angle(obstacleDirection, Vector2.up);

        
            Debug.Log($"Collision Angle: {angle}");

            GameOver();
        }
    }


    void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}

