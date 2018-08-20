using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour {
    public bool mageGame = false;
    public TextMesh[] myScores;
	void Start () {

    }
	
	void Update () {
        //gets the highest score via a for function that also sets the other scores chronologically
        if (mageGame) {
            int highestScore = 0;
            for (int i = 0; i < myScores.Length; i++) {
                if (PlayerPrefs.GetInt("MageScore"+i) > highestScore) {
                    highestScore = PlayerPrefs.GetInt("MageScore", i);
                }
                if (PlayerPrefs.GetInt("MageScore"+i) == 0) {
                    myScores[i].gameObject.SetActive(false);
                }
                else {
                    myScores[i].gameObject.SetActive(true);
                    myScores[i].text = PlayerPrefs.GetInt("MageScore"+i).ToString();
                }
            }
            myScores[0].text = highestScore.ToString();
        }

        if (!mageGame) {
            int highestScore = 0;
            for (int i = 0; i < myScores.Length; i++) {
                if (PlayerPrefs.GetInt("KnightScore"+i) > highestScore) {
                    highestScore = PlayerPrefs.GetInt("KnightScore", i);
                }
                if (PlayerPrefs.GetInt("KnightScore"+i) == 0) {
                    myScores[i].gameObject.SetActive(false);
                }
                else {
                    myScores[i].gameObject.SetActive(true);
                    myScores[i].text = PlayerPrefs.GetInt("KnightScore"+i).ToString();
                }
            }
            myScores[0].text = highestScore.ToString();
        }
    }
}
