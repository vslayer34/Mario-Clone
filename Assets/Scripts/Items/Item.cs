using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName ="Item")]
public class Item : ScriptableObject
{
    public Sprite sprite;
    public AnimatorController animator;
    public CoinBCoinBehaviour behaviour;


    public string itemName;
    public string description;
    public int value;

    public bool isPowerUp;
    public bool isCoin;

    public GameObject gameObject;
}
