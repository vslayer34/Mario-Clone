using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] Item[] items;
    bool isCoin;
    bool isDoubleUp;

    bool itemSpawned;

    [SerializeField] GameObject itemPlaceHolder;
    [SerializeField] Transform itemTransform;

    float speed = 1.0f;

    private void Start()
    {
        GenerateAnItem(items[0]);
    }

    private void Update()
    {
        if (itemSpawned && itemTransform.localPosition.y < 0.5)
            itemTransform.Translate(0, speed * Time.deltaTime, 0);
    }

    void GenerateAnItem(Item desiredItem)
    {
        GameObject newItem;
        newItem = Instantiate(itemPlaceHolder, itemTransform.position, itemPlaceHolder.transform.rotation);
        newItem.transform.parent = itemTransform;
        newItem.GetComponent<GameObjectData>().item = desiredItem;
        itemSpawned = true;
    }

    //void SpawnItem(Item )
    //{

    //}
}
