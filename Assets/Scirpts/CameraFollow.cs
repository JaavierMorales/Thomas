using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform[] playerTransforms; // Los jugadores que la cámara seguirá
    public Vector3 offset; // La posición offset de la cámara respecto al jugador

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
            // Mover la cámara al objetivo actual con el offset
            transform.position = new Vector3(
                playerTransforms[currentTargetIndex].position.x + offset.x,
                playerTransforms[currentTargetIndex].position.y + offset.y,
                transform.position.z
            );
        }
    }

    // Método para cambiar el objetivo de la cámara
    public void SwitchTarget(int targetIndex)
    {
        if (targetIndex >= 0 && targetIndex < playerTransforms.Length)
        {
            currentTargetIndex = targetIndex;
        }
    }
}