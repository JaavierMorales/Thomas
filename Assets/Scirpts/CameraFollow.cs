using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player1, player2, target;

    private void Start()
    {
        target = player1;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }

    public void SwitchTarget(int targetIndex)
    {
        if (targetIndex == 1)
        {
            target = player1;
        }
        else if (targetIndex == 2)
        {
            target = player2;
        }
    }
}