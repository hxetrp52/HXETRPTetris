public class Enemy : UnitBase
{
    public UnitRenderer enemyRender;
    public EnemyMovement enemyMovement;

    private void Awake()
    {
        enemyRender = unitRenderer;
    }

    public void InitEnemy(Player player)
    {
        enemyMovement.Init(player.transform, moveSpeed);
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        enemyRender.PlayAnimationOneShot(1);
    }

    public override void Death()
    {
        // 나중에 풀로 반환
    }
}
