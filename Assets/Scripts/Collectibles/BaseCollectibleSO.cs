using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Collectible", menuName = "Collectible")]
public class BaseCollectibleSO : ScriptableObject
{
    private UnityEvent onCollect;
    public string collectibleName;
    public Sprite collectibleSprite;
    public int energyAmount;

    public void CollectEvent()
    {
        onCollect?.Invoke();
    }
}
