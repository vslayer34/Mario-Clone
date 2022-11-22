using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] GameObject scoreGameObject;
    TextMeshProUGUI textField;

    // Start is called before the first frame update
    void Start()
    {
        textField = scoreGameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textField.text = $"score: {GameManager.instance.playerScore.ToString("D4")}";
    }
}
