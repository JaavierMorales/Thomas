using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player1; // Asigna el primer jugador
    public Transform player2; // Asigna el segundo jugador

    private Transform currentTarget; // Almacena el objetivo actual

    private void Start()
    {
        // Asegúrate de que al menos uno de los jugadores esté asignado
        if (player1 != null)
        {
            currentTarget = player1;
        }
        else if (player2 != null)
        {
            currentTarget = player2;
        }
        else
        {
            Debug.LogError("No players assigned to CameraFollow script.");
        }
    }

    private void LateUpdate()
    {
        if (currentTarget != null)
        {
            transform.position = new Vector3(currentTarget.position.x, currentTarget.position.y, transform.position.z);
        }
    }

    public void SwitchTarget(int playerNumber)
    {
        if (playerNumber == 1)
        {
            currentTarget = player1;
        }
        else if (playerNumber == 2)
        {
            currentTarget = player2;
        }
        else
        {
            Debug.LogError("Invalid player number: " + playerNumber);
        }
    }
}