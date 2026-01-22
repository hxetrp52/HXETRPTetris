using System;
using System.Collections.Generic;
using UnityEngine;

public class InGameCommander : MonoBehaviour
{
    public InGameManagerBase[] inGameManagers;
    private Dictionary<Type, InGameManagerBase> managerContainer = new Dictionary<Type, InGameManagerBase>();

    private void Awake()
    {
        for (int i = 0; i < inGameManagers.Length; i++)
        {
            inGameManagers[i].Init();
            managerContainer.Add(inGameManagers[i].GetType(), inGameManagers[i]);
        }
    }

    private void Update()
    {
        foreach(var manager in managerContainer.Values)
        {
            manager.ManagerUpdate();
        }
    }
}
