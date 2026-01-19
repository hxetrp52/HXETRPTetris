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

    public UnitData unitData;
    public UnitRenderer unitRenderer;

    public void InitUnitData(UnitData data)
    {
        unitData = data;

        unitName = data.unitName;
        maxHP = data.maxHP;
        currentHP = data.currentHP;
        moveSpeed = data.moveSpeed;
        dropEXP = data.dropEXP;

        unitRenderer.InitAnimationData(data);
    } // SO로부터 데이터 가져오기


    public void SpawnUnit(UnitData data) // 유닛 생성 시 호출하는 함수
    {
        InitUnitData(data);
        unitRenderer.SetAnimation(0);
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
        // 사망 시 호출할 코드 플레이어면 게임 오버고 적이면 오브젝트 풀에 반환할 예정
    }
}
