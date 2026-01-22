using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private float moveSpeed;

    public void Init(Transform target, float speed)
    {
        this.target = target;
        this.moveSpeed = speed;
    }

    private void Update()
    {
        if (target == null) return;

        Vector2 dir = (target.position - transform.position).normalized;
        transform.position += (Vector3)(dir * moveSpeed * Time.deltaTime);
    }
}
