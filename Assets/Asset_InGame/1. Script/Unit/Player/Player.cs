using UnityEngine;

public class Player : UnitBase
{
    [SerializeField] private PlayerMovement playerMovement;

    private void Start()
    {
        SpawnUnit(unitData);
        
    }




    public override void Death()
    {
        
    }
}
