using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// States of the player
public enum PlayerState { NORMAL, DOUBLED, SUPER };
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] GameObject player;

    public int playerHealth = 1;
    public int playerScore;
    [SerializeField] GameObject scoreText;
    
    public PlayerState playerState;

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

        // At the start of the game the player state is normal
        playerState = PlayerState.NORMAL;
    }

    public void UpdateScore(Item item)
    {
        //if (item.isCoin)
        instance.playerScore += item.value;
    }

    public void DoubleSize()
    {
        player.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
        playerState = PlayerState.DOUBLED;
    }

    public void RemoveDoubleSize()
    {
        player.transform.localScale = Vector3.one;
        playerState = PlayerState.NORMAL;
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        rb.AddForce(-rb.velocity * 100.0f, ForceMode2D.Impulse);
    }
}
