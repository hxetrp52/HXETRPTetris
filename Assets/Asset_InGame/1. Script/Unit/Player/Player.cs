using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : UnitBase
{
    [HideInInspector] public UnitRenderer playerRenderer;

    private Dictionary<Type, PlayerComponent> componentContainer = new Dictionary<Type, PlayerComponent>();

    private void Awake()
    {
        SpawnUnit(unitData);
        InitializePlayerComponent();
        playerRenderer = unitRenderer;
    }

    private void Update()
    {
        UpdatePlayerComponent();
    }
    
    private void InitializePlayerComponent()
    {
        var components = GetComponentsInChildren<PlayerComponent>();

        foreach (var component in components)
        {
            component.Init(this);
            componentContainer.Add(component.GetType(), component);
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


    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        playerRenderer.PlayAnimationOneShot(2);
    }

    public override void Death()
    {
        
    }
}
