using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : Singleton<Player>
{
    [Header("Player Settings")]
    [SerializeField] private int energy = 40;
    [SerializeField] private int speed = 5;

    private Rigidbody2D rb;
    private UnityEvent onEnergyChange;

    public int Energy
    {
        get => energy;
        set => energy = Math.Clamp(value, 0, 100);
    }

    public int Speed
    {
        get => speed;
        set => speed = Math.Clamp(value, 0, 10);
    }

    protected override void Awake()
    {
        base.Awake();

        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Replenish the player's energy by the amount passed.
    /// </summary>
    public void ReplenishEnergy(int amount)
    {
        Energy += amount;
        onEnergyChange?.Invoke();
    }

    /// <summary>
    /// Take damage from the player's energy by the amount passed.
    /// </summary>
    public void TakeDamage(int amount)
    {
        Energy -= amount;
        Die();
        onEnergyChange?.Invoke();

        print("Damage taken!");
    }

    private void Die()
    {
        if (Energy <= 0)
        {
            print("Player died!");
            Destroy(gameObject);
        }
    }
}
