using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : UnitBase
{
    public UnitRenderer playerRenderer;

    public PlayerComponent[] playerComponents;
    private Dictionary<Type, PlayerComponent> componentContainer = new Dictionary<Type, PlayerComponent>();

    private void Awake()
    {
        SpawnUnit(unitData);
        InitializePlayerComponent();
    }

    private void Update()
    {
        UpdatePlayerComponent();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRenderer.PlayAnimationOneShot(2);
        }
    }

    private void InitializePlayerComponent()
    {
        for (int i = 0; i < playerComponents.Length; i++)
        {
            componentContainer.Add(playerComponents[i].GetType(), playerComponents[i]);
            playerComponents[i].Init(this);
        }
    }

    private void UpdatePlayerComponent()
    {
        foreach(var component in componentContainer.Values)
        {
            component.ComponentUpdate();
        }
    }

    public T GetPlayerComponent<T>() where T : PlayerComponent 
    {
        if (componentContainer.TryGetValue(typeof(T), out var comp))
            return (T)comp;

        return default;
    }

    public override void Death()
    {
        
    }
}
