using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndMenuController : MonoBehaviour
{
    public Text coinTextScore;

    private void Awake()
    {
        coinTextScore.text = "Score: " + PlayerPrefs.GetInt("CurrentScore").ToString();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
