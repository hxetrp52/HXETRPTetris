using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public string weaponName;
    public float damage;
    public int stackCount = 1;
    public float skillCollTime;

    public virtual void OnApply()
    {
           
    }

    public virtual void OnStack()
    {
        stackCount++;
    }

    public abstract void OnUpdate();

}
