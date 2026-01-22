using System.Collections; // IEnumerator 사용을 위해 필수
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : PlayerComponent
{
    [Header("Movement Settings")]
    [SerializeField] public float speed = 5f;
    [SerializeField] private Rigidbody2D rb;

    [Header("Dash Settings")]
    [SerializeField] private float dashSpeed = 15f;    
    [SerializeField] private float dashDuration = 0.3f; 
    [SerializeField] private float dashCoolTime = 8f;   

    private Player player;
    private Vector2 moveInput = Vector2.zero;

    private bool isMoving = false;
    private bool isDashing = false; 
    private bool canDash = true;

    public GameTimer dashTimer; 
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

        if (isMoving)
        {
            rb.linearVelocity = moveInput * speed;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            moveInput = context.ReadValue<Vector2>();
            isMoving = moveInput.sqrMagnitude > 0.01f;
        }
        else if (context.canceled)
        {
            moveInput = Vector2.zero;
            isMoving = false;
        }
    }

    public void OnDash()
    {
        if (!isMoving || !canDash || isDashing) return;

        StartCoroutine(DashRoutine());
    }

    private IEnumerator DashRoutine()
    { 
        canDash = false;

        rb.linearVelocity = moveInput.normalized * dashSpeed;

        player.playerRenderer.PlayAnimationOneShot(3);

        yield return new WaitForSeconds(dashDuration);

        rb.linearVelocity = Vector2.zero; 

        dashTimer = GameManager.Instance.GetManager<TimeManager>().StartTimer(dashCoolTime, false, () =>
        {
            canDash = true;
        });
    }

    private void ControlAnimation()
    {
        if (moveInput.x < 0) gameObject.transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput.x > 0) gameObject.transform.localScale = new Vector3(-1, 1, 1);

        if (isDashing) return;

        int nextID = (moveInput == Vector2.zero) ? 1 : 0;

        if (nextID != lastAnimationID)
        {
            player.playerRenderer.SetAnimation(nextID);
            lastAnimationID = nextID;
        }
    }
}