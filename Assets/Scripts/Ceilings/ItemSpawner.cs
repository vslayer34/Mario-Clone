using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    // Array of Items to spanw
    // Index 0: Glod Coin
    // Index 1: Double Size
    [SerializeField] Item[] items;

    // Dermine what Kind of item is if not random generated
    [SerializeField] bool isCoin;
    [SerializeField] bool isDoubleUp;

    // make sure the item is spawned before moving its transfom
    bool itemSpawned;


    // placeholder item and the position in instansiate int
    [SerializeField] GameObject itemPlaceHolder;
    [SerializeField] Transform itemTransform;


    // speed of the item poping up
    float speed = 1.0f;

    private void Update()
    {
        if (itemSpawned && itemTransform.localPosition.y < 0.5)
        {
            Debug.Log(itemTransform.position.y.ToString());
            itemTransform.Translate(0, speed * Time.deltaTime, 0);
        }
    }

    void GenerateAnItem(Item desiredItem)
    {
        if (!itemSpawned)
        {
            GameObject newItem;
            newItem = Instantiate(itemPlaceHolder, itemTransform.position, itemPlaceHolder.transform.rotation);
            newItem.transform.parent = itemTransform;
            newItem.GetComponent<GameObjectData>().item = desiredItem;
            itemSpawned = true;
            Debug.Log($"itme is spawned {itemSpawned}");
        }
    }

    // SpawnItem to be called when it hit by the player
    public void SpawnItem()
    {
        if (isCoin)
        {
            GenerateAnItem(items[0]);
        }
        else if (isDoubleUp)
        {
            GenerateAnItem(items[1]);
        }
    }
}
