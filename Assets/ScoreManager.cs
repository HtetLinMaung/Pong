using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text player1ScoreText;
    public Text player2ScoreText;
    private int player1Score = 0;
    private int player2Score = 0;

    public GameObject ball;

    public void Player1Scores()
    {
        player1Score++;
        player1ScoreText.text = player1Score.ToString();
        ResetBall();
    }

    public void Player2Scores()
    {
        player2Score++;
        player2ScoreText.text = player2Score.ToString();
        ResetBall();
    }

    void ResetBall()
    {
        ball.transform.position = Vector2.zero;
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        ball.GetComponent<BallController>().LaunchBall();
    }
}
