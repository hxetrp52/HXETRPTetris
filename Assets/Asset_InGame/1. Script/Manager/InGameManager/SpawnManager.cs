using AddressableKeys;
using UnityEngine;

public class SpawnManager : InGameManagerBase
{
    private Player player;
    private AddressableLoadManager loadManager;
    public UnitData testData;
    public int EnemyCount;

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
        loadManager.InstantiatePrefab(UnitKey.PLAYER, transform, go =>
        {
            player = go.GetComponent<Player>();
            player.transform.SetParent(null);

        });
    }

    public void SpawnEnemy()
    {
        loadManager.InstantiatePrefab(UnitKey.ENEMY, transform, go =>
        {
            var enemy = go.GetComponent<Enemy>();
            enemy.SpawnUnit(testData);
            enemy.InitEnemy(player);
        });
    }
}
