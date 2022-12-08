using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behaviour : MonoBehaviour
{
    private Item item;

    private void Start()
    {
        item = GetComponent<GameObjectData>().item;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // For coins
        if (item.itemName == "Coin")
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                GameManager.instance.UpdateScore(item);
                Destroy(gameObject);
                Debug.Log($"Add {item.value}");

                AudioManager.instance.Play(SoundNames.coinPickup);
            }
        }


        // For apple
        if (item.itemName == "Apple")
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                GameManager.instance.UpdateScore(item);
                GameManager.instance.DoubleSize();
                Debug.Log($"Player state: {GameManager.instance.playerState}");
                AudioManager.instance.Play(SoundNames.doubledPickup);
                Destroy(gameObject);
            }
        }
    }
}
