using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private Text coinTextScore;
    private AudioSource audioManager;
    private int scoreCount;

    void Awake()
    {
        audioManager = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        coinTextScore = GameObject.Find("CoinText").GetComponent<Text>();
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == MyTags.COIN_TAG)
        {
            target.gameObject.SetActive(false);
            scoreCount++;

            coinTextScore.text = "x" + scoreCount;
            PlayerPrefs.SetInt("CurrentScore", scoreCount);
            audioManager.Play();
        }
    }

    public void BonusBlock()
    {

        scoreCount = scoreCount + 1;

        coinTextScore.text = "x" + scoreCount;
        PlayerPrefs.SetInt("CurrentScore", scoreCount);

        audioManager.Play();

    }
}
