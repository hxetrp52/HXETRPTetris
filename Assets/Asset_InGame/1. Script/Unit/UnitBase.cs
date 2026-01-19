using System;
using UnityEngine;

public abstract class UnitBase : MonoBehaviour
{
    #region 유닛 데이터 정보
    private string unitName;
    private float maxHP;
    private float currentHP;
    private float moveSpeed;
    private float dropEXP;
    private Sprite unitSprite;
    [SerializeField] private Material unitMaterial;
    #endregion 

    [SerializeField] private UnitData unitData;

    [SerializeField] private ParticleSystem ps;
    public void InitUnitData(UnitData data)
    {
        unitData = data;

        unitName = data.unitName;
        maxHP = data.maxHP;
        currentHP = data.currentHP;
        moveSpeed = data.moveSpeed;
        dropEXP = data.dropEXP;
        unitSprite = data.unitSprite;
        unitMaterial = data.unitMaterial;
    }
    
    public void SpawnUnit(UnitData data)
    {
        
    }

    public void TakeHelth(float helth)
    {
        currentHP += helth;
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHP -= MathF.Abs(damage);
        if (currentHP <= 0)
        {
            Death();
        }
    }
    public void Death() 
    {
        // 사망 코드
    }
}
