using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAudio : MonoBehaviour
{
    public string[] myPrefNames;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))

        {
            for (int i = 0; i < myPrefNames.Length; i++)
            {
                PlayerPrefs.SetInt(myPrefNames[i], 0);
            }
        }
    }
    private void OnApplicationQuit()
    {
        for (int i = 0; i < myPrefNames.Length; i++)
        {
            PlayerPrefs.SetInt(myPrefNames[i], 0);
        }
        /*
MageSceneInstructions
KnightSceneSpeech
MageSpeak
KnightSpeak
DwarfIntro
DwarfSpeak
    */
    }
}
