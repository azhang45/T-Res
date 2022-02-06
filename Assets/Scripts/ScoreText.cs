using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreText : MonoBehaviour
{
    public Text pointsText;

    public void Setup(int score) {
        pointsText.text = "Score: " + score.ToString();
    }

    public void End(){
        gameObject.SetActive(false);
    }
}
