using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private BaseCollectibleSO collectibleSO;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    private void Start()
    {
        collectibleSO = Instantiate(collectibleSO);
        // spriteRenderer.sprite = collectibleSO.collectibleSprite;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            player.ReplenishEnergy(collectibleSO.energyAmount);
            collectibleSO.CollectEvent();
            Destroy(gameObject);
        }
    }
}
