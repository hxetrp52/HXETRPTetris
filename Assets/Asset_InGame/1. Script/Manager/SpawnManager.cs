using UnityEngine;

public class SpawnManager : ManagerBase
{
    public GameObject testUnit;
    public UnitData testData;

    public override void Init() // 대충 파티클 시스템 잘 적용되는지 테스트
    {
        GameObject Tunit = Instantiate(testUnit, Vector3.zero, Quaternion.identity);
        Tunit.GetComponent<UnitBase>().SpawnUnit(testData);
    }

    public override void ManagerUpdate()
    {
        
    }



}
