using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    public Transform player1, player2,goalPlayer1, goalPlayer2;
    private bool player1ReachedGoal = false, player2ReachedGoal = false;

    void Start()
    {
        if (player2 == null || goalPlayer2 == null)
        {
            player2ReachedGoal = true;
        }
    }

    void Update()
    {
        CheckPlayerPositions();

        if (player1ReachedGoal && player2ReachedGoal)
        {
            LoadNextLevel();
        }
    }

    void CheckPlayerPositions()
    {
        if (Vector3.Distance(player1.position, goalPlayer1.position) < 1f)
        {
            player1ReachedGoal = true;
        }
        else
        {
            player1ReachedGoal = false;
        }

        if (player2 != null && goalPlayer2 != null)
        {
            if (Vector3.Distance(player2.position, goalPlayer2.position) < 1f)
            {
                player2ReachedGoal = true;
            }
            else
            {
                player2ReachedGoal = false;
            }
        }
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }
}