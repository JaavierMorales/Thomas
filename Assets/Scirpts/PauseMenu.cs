using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // El panel que contiene los botones del men� de pausa
    public GameObject player; // El jugador que se pausar�

    private bool isPaused = false;

    private void Start()
    {
        // Inicialmente, el men� de pausa est� desactivado
        pauseMenuUI.SetActive(false);
    }

    private void Update()
    {
        // Pausar el juego con la tecla 'Escape'
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // Detener el tiempo del juego
        if (player != null)
        {
            player.GetComponent<PlayerController>().enabled = false; // Desactivar el controlador del jugador
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Reanudar el tiempo del juego
        if (player != null)
        {
            player.GetComponent<PlayerController>().enabled = true; // Reactivar el controlador del jugador
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reiniciar el nivel actual
    }

    public void GoToMainMenu()
    {
        // Cargar la escena del men� principal
        SceneManager.LoadScene("MainMenu"); // Aseg�rate de que el nombre de la escena sea correcto
    }
}