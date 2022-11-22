using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behaviour : MonoBehaviour
{
    [SerializeField] GameObject itemBlueprint;
    private Item item;

    private void Start()
    {
        item = GetComponent<GameObjectData>().item;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // For coins
        if (collision.gameObject.CompareTag("Player") && item.itemName == "Coin")
        {
            GameManager.instance.UpdateScore(item);
            Destroy(gameObject);
            Debug.Log($"Add {item.value}");
        }
    }
}
