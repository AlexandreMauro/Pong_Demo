using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

   
    public Transform PlayerPaddle;
    public Transform EnemeyPaddle;
    public int winPoints = 2;
    public BallController ballController;

    public int PlayerScore = 0;
    public int EnemyScore = 0;


    public TextMeshProUGUI TextPlayerPoint;
    public TextMeshProUGUI TextEnemyPoint;

    public GameObject EndGameScreen;
    public TextMeshProUGUI textEndGame;
    void Start()
    {
        ResetGame();
    }

    public void ResetGame()
    {
        //colocar os paddles nas posições iniciais
        PlayerPaddle.position = new Vector3(7f, 0f, 0f);
        EnemeyPaddle.position = new Vector3(-7f, 0f, 0f);
        //resetar a posição da bola para o ponto zero
        ballController.ResetBall();

        PlayerScore = 0;
        EnemyScore = 0;

        TextPlayerPoint.text = PlayerScore.ToString();
        TextEnemyPoint.text = EnemyScore.ToString();

        EndGameScreen.SetActive(false);
    }

    public void CheckWin()
    {
        if (EnemyScore >= winPoints || PlayerScore >= winPoints)
        {
            //ResetGame();
            EndGame();
            
        }
    }

   
    public void EndGame()
    {
        EndGameScreen.SetActive(true);
        string winner = SavedController.Instance.GetName(PlayerScore > EnemyScore);
        textEndGame.text = "Winner: " + winner;
        SavedController.Instance.SaveWinner(winner);
        Invoke("LoadMenu", 4f);

    }
    private void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ScorePlayer()
    {
        PlayerScore++;
        TextPlayerPoint.text = PlayerScore.ToString();
        CheckWin();
    }

    public void ScoreEnemy()
    {
        EnemyScore++;
        TextEnemyPoint.text = EnemyScore.ToString();
        CheckWin();

    }
}
