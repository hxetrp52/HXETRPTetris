using AddressableKeys;
using TMPro;
using UnityEngine;

public class SpawnManager : InGameManagerBase
{
    private Player player;
    private AddressableLoadManager loadManager;
    public UnitData testData;
    public int EnemyCount;
    public TMP_Text text;

    public override void Init()
    {
        loadManager = GameManager.Instance.GetManager<AddressableLoadManager>();
        SpawnPlayer();
    }

    public void TestEnemySpawn()
    {
        for (int i = 0; i < 1000; i++)
        {
            SpawnEnemy();
        }
        EnemyCount += 1000;
        text.text = $"Counter : {EnemyCount.ToString()}";
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
