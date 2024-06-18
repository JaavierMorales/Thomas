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
        if (playerController != null && player2Controller != null)
        {
            playerController.enabled = true;
            player2Controller.enabled = false;
        }
        else
        {
            Debug.LogError("PlayerController or player2Controller is not assigned in the inspector.");
        }
    }

    // Update is called once per frame
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
            playerController.enabled = false;
            player2Controller.enabled = true;
            player1Active = false;
            cameraFollow.SwitchTarget(2);
        }
        else
        {
            playerController.enabled = true;
            player2Controller.enabled = false;
            player1Active = true;
            cameraFollow.SwitchTarget(1);
        }
    }
}
