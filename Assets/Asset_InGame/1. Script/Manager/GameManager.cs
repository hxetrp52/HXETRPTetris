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
            manager.ManagerUpdate(); // 매니저에서 생명주기 함수 호출 비용 알뜰살뜰하게 절약하기 위해 상위 매니저에서 관리
        }
    }

    private void AddManagers() // 매니저 추가 + for문 사용해서 순서대로 넣기 가! 능!
    {
        for (int i = 0; i < managers.Count; i++)
        {
            managerContainer.Add(managers[i].GetType(), managers[i]);
            managers[i].Init();
        }
    }

    public T GetManager<T>() where T : ManagerBase // 매니저 외부에서 가져오기
    {
        if (managerContainer.TryGetValue(typeof(T), out var comp))
            return (T)comp;

        return default;
    }
}
