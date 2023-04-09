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
    [SerializeField] private float speed = 5;

    private Rigidbody2D rb;
    private UnityEvent onEnergyChange;

    public int Energy
    {
        get => energy;
        set => energy = Math.Clamp(value, 0, 100);
    }

    public float Speed
    {
        get => speed;
        set => speed = Math.Clamp(value, 0, 10);
    }

    protected override void Awake()
    {
        base.Awake();

        onEnergyChange = new UnityEvent();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ChangeSpeedDependingOnEnergy();
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

    private void ChangeSpeedDependingOnEnergy()
    {
        if (Energy <= 20)
        {
            Speed = 5f;
        }
        else if (Energy > 20 && Energy <= 60)
        {
            Speed = 6f;
        }
        else if (Energy > 60)
        {
            Speed = 7f;
        }

        onEnergyChange?.Invoke();
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
