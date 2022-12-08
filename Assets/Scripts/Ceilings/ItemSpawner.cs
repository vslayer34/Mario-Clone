using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] Item[] items;
    bool isCoin;
    bool isDoubleUp;

    [SerializeField] GameObject itemPlaceHolder;

    private void Start()
    {
        GenerateAnItem(items[0]);
    }


    void GenerateAnItem(Item desiredItem)
    {
        Instantiate(itemPlaceHolder);
        itemPlaceHolder.GetComponent<GameObjectData>().item = desiredItem;
    }

    //void SpawnItem(Item )
    //{

    //}
}
