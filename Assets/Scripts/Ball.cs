using UnityEngine;

public class Ball : MonoBehaviour
{

    public GameManager gameManager;
    public Rigidbody2D rb2d;
    public float moveSpeed;
    public float maxIntialAngle = 0.67f;
    public float maxStartY = 4f;
    private float startX = 0f;
    public float SpeedUp = 1.1f;

    private void Start()
    {
        InitialPush();
        gameManager.onReset += ResetBall;
    }
    private void ResetBall()
    {
        ResetBallPosition();
        InitialPush();
    }
    private void InitialPush()
    {
        Vector2 dir = Random.value < 0.5f ? Vector2.left : Vector2.right;
        dir.y = Random.Range(-maxIntialAngle, maxIntialAngle);

        rb2d.linearVelocity = dir * moveSpeed;

    }
    // Hàm để reset vị trí của quả bóng về vị trí ban đầu
    private void ResetBallPosition()
    {
        float posY = UnityEngine.Random.Range(-maxStartY, maxStartY);
        Vector2 startPosition = new Vector2(startX, posY);
        transform.position = startPosition;
    }
    // Hàm xử lý va chạm với các đối tượng khác
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Gọi hàm của ScoreZone khi va chạm với nó
        ScoreZone scoreZone = collision.GetComponent<ScoreZone>();
        if (scoreZone != null)
        {
            // Gọi hàm OnScoreZoneReached của GameManager để cập nhật điểm số
            GameManager.instance.OnScoreZoneReached(scoreZone.id);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Paddle paddle = collision.gameObject.GetComponent<Paddle>();
        if (paddle != null)
        {
            // Tăng tốc độ của quả bóng khi va chạm với paddle
            rb2d.linearVelocity *= SpeedUp;
        }
    }
}
