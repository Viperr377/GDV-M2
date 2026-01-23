using UnityEngine;
using TMPro;

public class UIScoreBoard : MonoBehaviour
{
    public TMP_Text scoreField;

    void Update()
    {
        scoreField.text = "SCORE: " + ScoreManager.Instance.score;
    }
}
