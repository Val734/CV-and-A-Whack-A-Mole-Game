using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreTextPlayer;
    [SerializeField] string scorePlayer;
    int score = 0;

    public void AddScore()
    {
        score++;
        UpdateScoreText();
    }

    public int GetCurrentScore()
    {
        return score;
    }

    private void UpdateScoreText()
    {
        scoreTextPlayer.text = $"{scorePlayer} {score}";
    }
}
