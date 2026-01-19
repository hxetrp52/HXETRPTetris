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
    #endregion 

    public UnitData unitData;

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
    } // SO로부터 데이터 가져오기


    public void SpawnUnit(UnitData data) // 유닛 생성 시 호출하는 함수
    {
        InitUnitData(data);
        SetParticleMaterial(unitData);
    }

    public void SetParticleMaterial(UnitData data) // 파티클 시스템 머테리얼 변경 및 나중에 애니메이션 시트 분리하는 것 까지 담당?
    {
        // 머테리얼 적용
        var renderer = ps.GetComponent<ParticleSystemRenderer>();
        renderer.material = data.unitMaterial;

        // 애니메이션 시트 적용
        var sheet = ps.textureSheetAnimation;
        sheet.numTilesX = data.animationSheetSizeX;
        sheet.numTilesY = data.animationSheetSizeY;
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
