using UnityEngine;
using UnityEngine.InputSystem;

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

    public void Move()
    {
        
        moveVector = new Vector2(x, y);

        rb.linearVelocity = moveVector.normalized * speed;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed || context.canceled)
        {
            Vector2 moveInput = context.ReadValue<Vector2>();
            x = moveInput.x;
            y = moveInput.y;
        }
    }

    private void ControlAnimation()
    {
        if (x < 0) gameObject.transform.localScale = new Vector3(1, 1, 1);
        else if (x > 0) gameObject.transform.localScale = new Vector3(-1, 1, 1);

        int nextID = (moveVector == Vector2.zero) ? 1 : 0; 

        if (nextID != lastAnimationID)
        {
            player.playerRenderer.SetAnimation(nextID);
            lastAnimationID = nextID; // 현재 ID 갱신
        }
    }
}
