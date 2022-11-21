using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

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
}
