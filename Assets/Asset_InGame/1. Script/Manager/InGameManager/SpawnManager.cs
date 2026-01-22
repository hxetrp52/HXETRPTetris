using UnityEngine;
using AddressableKeys;

public class SpawnManager : InGameManagerBase
{
    private Player player;
    private AddressableLoadManager loadManager;

    public override void Init()
    {
        loadManager = GameManager.Instance.GetManager<AddressableLoadManager>();
        SpawnPlayer();
    }

    public override void ManagerUpdate()
    {
        
    }

    public void SpawnPlayer()
    {
        loadManager.InstantiatePrefab(UnitKey.PLAYER, this.transform , Player =>
        {
            player = Player.GetComponent<Player>();
            player.transform.SetParent(null);
        });
    }

    
}
