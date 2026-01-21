using UnityEngine;

public class PlayerMovement : PlayerComponent
{
    [SerializeField] public float speed = 3;
    [SerializeField] private Rigidbody2D rb;

    private Player player;

    private float x;
    private float y;
    private Vector2 moveVector = Vector2.zero;

    private int lastAnimationID = -1;

    public override void Init(Player player)
    {
        this.player = player;
    }

    public override void ComponentUpdate()
    {
        ControlAnimation();
    }

    private void FixedUpdate()
    {
        Move();
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
        if (x < 0) gameObject.transform.localScale = new Vector3(-1, 1, 1);
        else if (x > 0) gameObject.transform.localScale = new Vector3(1, 1, 1);

        int nextID = (moveVector == Vector2.zero) ? 1 : 0; 

        if (nextID != lastAnimationID)
        {
            player.playerRenderer.SetAnimation(nextID);
            lastAnimationID = nextID; // 현재 ID 갱신
        }
    }
}
