using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : PlayerComponent
{
    private Dictionary<string, WeaponBase> weaponList = new Dictionary<string, WeaponBase>();
    
    public override void Init(Player player)
    {

    }

    public override void ComponentUpdate()
    {
        
    }
    
    public void AddWeapon(WeaponBase weaponBase)
    {
        if (weaponList.ContainsKey(weaponBase.weaponName) == false)
        {
            weaponList.Add(weaponBase.weaponName, weaponBase);
            weaponBase.OnApply();
        }
        else
        {
            weaponList.TryGetValue(weaponBase.weaponName, out var weapon);
            weapon.OnStack();
        }
    }

}
