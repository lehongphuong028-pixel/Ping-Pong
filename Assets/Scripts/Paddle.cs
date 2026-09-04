using UnityEngine;

public class Paddle : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float id;
    public float moveSpeed = 2f;

    private void Update()
    {
        float movement = ProcessInput();
        Move(movement);
    }
    private float ProcessInput()
    {
        float movement = 0f;
        switch (id)
        {
            case 1:
                movement = Input.GetAxis("MoveP1");
                break;
            case 2:
                movement = Input.GetAxis("MoveP2");
                break;
        }
        return movement;
    }
    private void Move(float movement)
    {
        Vector2 velo = rb2d.linearVelocity;
        velo.y = moveSpeed * movement;
        rb2d.linearVelocity = velo;
    }
}
