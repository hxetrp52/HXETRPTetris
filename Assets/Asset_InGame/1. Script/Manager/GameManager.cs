using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    private Dictionary<Type, ManagerBase> managerContainer = new Dictionary<Type, ManagerBase>();

    public List<ManagerBase> managers;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        AddManagers();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var manager in managerContainer.Values)
        {
            manager.ManagerUpdate();
        }
    }

    private void AddManagers() // 매니저 추가
    {
        foreach (var manager in managers) 
        {
            managerContainer.Add(manager.GetType(), manager);
            manager.Init();
        }
    }

    public T GetManager<T>() where T : ManagerBase // 매니저 외부에서 가져오기
    {
        if (managerContainer.TryGetValue(typeof(T), out var comp))
            return (T)comp;

        return default;
    }
}
