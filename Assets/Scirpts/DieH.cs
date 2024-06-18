using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieH : MonoBehaviour
{
    public float health = 1f;
    public float deathThreshold = 0f;
    public Transform respawnPoint; 

    private void Start()
    {
        if (respawnPoint == null)
        {
            respawnPoint = transform;
        }

        Debug.Log("Player " + gameObject.name + " respawnPoint: " + (respawnPoint != null ? respawnPoint.position.ToString() : "null"));
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= deathThreshold)
        {
            Die();
        }
    }

    private void Die()
    {
        if (respawnPoint != null)
        {
            transform.position = respawnPoint.position;
            transform.rotation = respawnPoint.rotation;
            health = 1f;
            PlayerDeathSound soundManager = Object.FindAnyObjectByType<PlayerDeathSound>();
            if (soundManager != null)
            {
                soundManager.PlayDeathSound();
            }

            Debug.Log("Player " + gameObject.name + " respawned at: " + transform.position.ToString());
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            Debug.Log("Player " + gameObject.name + " respawned by reloading the scene.");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Killer"))
        {
            Die();
        }
    }
}
