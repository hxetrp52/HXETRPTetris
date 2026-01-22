public class Enemy : UnitBase
{
    public UnitRenderer enemyRender;

    private void Awake()
    {
        enemyRender = unitRenderer;
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        enemyRender.PlayAnimationOneShot(1);
    }

    public override void Death()
    {
        
    }
}
