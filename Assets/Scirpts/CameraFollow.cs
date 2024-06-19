using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform[] playerTransforms; // Los jugadores que la c�mara seguir�
    public Vector3 offset; // La posici�n offset de la c�mara respecto al jugador

    private int currentTargetIndex = 0;

    private void Start()
    {
        // Inicializar el objetivo actual
        if (playerTransforms.Length > 0)
        {
            currentTargetIndex = 0;
        }
    }

    private void LateUpdate()
    {
        if (playerTransforms.Length > 0)
        {
            // Mover la c�mara al objetivo actual con el offset
            transform.position = new Vector3(
                playerTransforms[currentTargetIndex].position.x + offset.x,
                playerTransforms[currentTargetIndex].position.y + offset.y,
                transform.position.z
            );
        }
    }

    // M�todo para cambiar el objetivo de la c�mara
    public void SwitchTarget(int targetIndex)
    {
        if (targetIndex >= 0 && targetIndex < playerTransforms.Length)
        {
            currentTargetIndex = targetIndex;
        }
    }
}