using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI player1ScoreText;
    [SerializeField] TextMeshProUGUI player2ScoreText;

    public ScoreController player1ScoreController;
    public ScoreController player2ScoreController;

    public GameObject holesMagment1;
    public GameObject holesMagment2;


    public void Start()
    {
        player1ScoreText.gameObject.SetActive(false);
        player2ScoreText.gameObject.SetActive(false);
    }

    public void EndGame()
    {
        int player1Score = player1ScoreController.GetCurrentScore();
        int player2Score = player2ScoreController.GetCurrentScore();
        StartCoroutine(RestartAll());

        if (player1Score > player2Score)
        {
            player1ScoreText.text = "¡Congratulations, you've won!";
            player2ScoreText.text = "Sorry, you've lose";

        }
        else if (player1Score < player2Score)
        {
            player1ScoreText.text = "Sorry, you've lose";
            player2ScoreText.text = "¡Congratulations, you've won!";

        }
        else
        {
            player1ScoreText.text = "¡TIE!";
            player2ScoreText.text = "¡TIE!";

        }
    }
    IEnumerator RestartAll()
    {
        player1ScoreText.gameObject.SetActive(true);
        player2ScoreText.gameObject.SetActive(true);

        holesMagment1.gameObject.SetActive(false);
        holesMagment2.gameObject.SetActive(false);

        Time.timeScale = 1; 

        yield return new WaitForSeconds(5f);

        Debug.Log("han pasado 5segundoooooos");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 

  
    }
}
