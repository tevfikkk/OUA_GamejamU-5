using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBar;

    public void SetMaxHealth(int health)
    {
        healthBar.fillAmount = health;
    }

    public void SetHealth(int health)
    {
        healthBar.fillAmount = (float)health / 100f;
    }
}
