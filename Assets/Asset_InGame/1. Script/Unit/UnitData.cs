using UnityEngine;

[CreateAssetMenu(fileName = "UnitData", menuName = "Scriptable Objects/UnitData")]
public class UnitData : ScriptableObject
{
    public string unitName;
    public float maxHP;
    public float currentHP;
    public float moveSpeed;

    public float dropEXP;

    public Sprite unitSprite;
    public Material unitMaterial;


}
