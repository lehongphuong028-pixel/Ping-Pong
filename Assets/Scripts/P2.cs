using UnityEngine;

public class P2 : MonoBehaviour
{
    public float moveSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         bool isPressingUp = Input.GetKey(KeyCode.UpArrow);
        bool isPressingDown = Input.GetKey(KeyCode.DownArrow);

        if (isPressingUp)
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        }
        else if (isPressingDown)
        {
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        }
    }
}
