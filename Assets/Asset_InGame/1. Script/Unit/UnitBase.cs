using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitBase : MonoBehaviour
{
    #region 유닛 데이터 정보
    private string unitName;
    private float maxHP;
    private float currentHP;
    private float moveSpeed;
    private float dropEXP;
    #endregion 

    [SerializeField] protected UnitData unitData;
    public UnitRenderer unitRenderer;

    public virtual void InitUnitData(UnitData data)
    {
        unitData = data;

        unitName = data.unitName;
        maxHP = data.maxHP;
        currentHP = maxHP;
        moveSpeed = data.moveSpeed;
        dropEXP = data.dropEXP;

        unitRenderer.InitAnimationData(data);
    } // SO로부터 데이터 가져오기


    public virtual void SpawnUnit(UnitData data) // 유닛 생성 시 호출하는 함수
    {
        InitUnitData(data);
        unitRenderer.SetAnimation(0);
    }

    public virtual void TakeHelth(float helth)
    {
        currentHP += helth;
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }

    public virtual void TakeDamage(float damage)
    {
        currentHP -= MathF.Abs(damage);
        if (currentHP <= 0)
        {
            Death();
        }
    }
    public abstract void Death();
}
