using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;
    private ScoreManager scoreManager;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scoreManager = FindObjectOfType<ScoreManager>();
        audioSource = GetComponent<AudioSource>();
        LaunchBall();
    }

    public void LaunchBall()
    {
        // Launch the ball in a random direction
        float xDirection = Random.Range(0, 2) == 0 ? -1 : 1;
        float yDirection = Random.Range(0, 2) == 0 ? -1 : 1;
        Vector2 direction = new Vector2(xDirection, yDirection).normalized;
        rb.velocity = direction * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // You can add logic here for what happens when the ball collides with something
        // For example, you might want to play a sound, change direction, etc.
        // Play the bounce sound
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Left Trigger")
        {
            scoreManager.Player2Scores();
        }
        else if (other.gameObject.name == "Right Trigger")
        {
            scoreManager.Player1Scores();
        }
    }
}
