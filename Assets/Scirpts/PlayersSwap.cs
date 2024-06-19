using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersSwap : MonoBehaviour
{
    public CameraFollow cameraFollow;
    public PlayerController playerController;
    public PlayerController player2Controller;
    private bool player1Active = true;

    void Start()
    {
        if (playerController == null || player2Controller == null)
        {
            Debug.LogError("PlayerController or player2Controller is not assigned in the inspector.");
            return;
        }

        playerController.enabled = true;
        player2Controller.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SwitchPlayer();
        }
    }

    public void SwitchPlayer()
    {
        if (player1Active)
        {
            if (player2Controller != null)
            {
                playerController.enabled = false;
                player2Controller.enabled = true;
                player1Active = false;
                if (cameraFollow != null)
                {
                    cameraFollow.SwitchTarget(1); // Cambiar a player2Controller
                }
                else
                {
                    Debug.LogError("CameraFollow is not assigned in the inspector.");
                }
            }
        }
        else
        {
            if (playerController != null)
            {
                playerController.enabled = true;
                player2Controller.enabled = false;
                player1Active = true;
                if (cameraFollow != null)
                {
                    cameraFollow.SwitchTarget(0); // Cambiar a playerController
                }
                else
                {
                    Debug.LogError("CameraFollow is not assigned in the inspector.");
                }
            }
        }
    }
}