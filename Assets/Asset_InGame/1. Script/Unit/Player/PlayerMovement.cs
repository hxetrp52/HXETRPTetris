using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float speed = 3;
    [SerializeField] private Rigidbody2D rb;

    private float x;
    private float y;
    private Vector2 moveVector = Vector2.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void FixedUpdate()
    {
        Move();
        ControlAnimation();
    }

    private void Move()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        moveVector = new Vector2(x, y);

        rb.linearVelocity = moveVector.normalized * speed;
    }

    private void ControlAnimation()
    {
        if (x < 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (x > 0)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
