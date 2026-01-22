using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : PlayerComponent
{
    [SerializeField] public float speed = 5f; // 속도를 조금 올렸습니다
    [SerializeField] private Rigidbody2D rb;

    private Player player;
    private Vector2 moveInput = Vector2.zero; // 입력 값 저장
    private bool isMoving = false;

    private int lastAnimationID = -1;

    public override void Init(Player player)
    {
        this.player = player;
    }

    public override void ComponentUpdate()
    {
        ControlAnimation();
    }

    // 물리 이동은 FixedUpdate에서 처리
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
            isMoving = moveInput.sqrMagnitude > 0.01f; // 미세한 떨림 방지
        }
        else if (context.canceled)
        {
            moveInput = Vector2.zero;
            isMoving = false;
        }
    }

    private void ControlAnimation()
    {
        // 좌우 반전 처리
        if (moveInput.x < 0) gameObject.transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput.x > 0) gameObject.transform.localScale = new Vector3(-1, 1, 1);

        // 애니메이션 ID 결정 (멈춤: 1, 이동: 0 가정) - 기존 로직 유지
        int nextID = (moveInput == Vector2.zero) ? 1 : 0;

        if (nextID != lastAnimationID)
        {
            player.playerRenderer.SetAnimation(nextID);
            lastAnimationID = nextID;
        }
    }
}