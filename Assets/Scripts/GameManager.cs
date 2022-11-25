using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerState { NORMAL, DOUBLED, SUPER };
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] GameObject player;

    public int playerHealth = 1;
    public int playerScore;
    [SerializeField] GameObject scoreText;
    

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Debug.LogWarning("Game Manager instance failed to be created");
    }

    private void Start()
    {
        playerScore = 0;
    }

    public void UpdateScore(Item item)
    {
        if (item.isCoin)
            instance.playerScore += item.value;
    }

    public void DoubleSize()
    {
        player.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
        
    }
}
