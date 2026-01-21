using UnityEngine;

public abstract class PlayerComponent : MonoBehaviour
{

    public abstract void Init(Player player);
    public abstract void ComponentUpdate();
}
