using UnityEngine;

[CreateAssetMenu(fileName = "UnitData", menuName = "Scriptable Objects/UnitData")]
public class UnitData : ScriptableObject
{
    public string unitName;
    public float maxHP;
    public float moveSpeed;

    public float dropEXP;

    
    public AnimatiomData[] animatiomDatas;

    [System.Serializable] 
    public struct AnimatiomData
    {
        public string animationName;
        public Material animationMaterial;
        public int animationSheetSizeX;
        public int animationSheetSizeY;
        public float animationDataDuration;
        public bool isLoop;
    }
}
