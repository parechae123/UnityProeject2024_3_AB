using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExDataLoad : MonoBehaviour
{
    public ExGameData gameData;
    void Start()
    {
        Debug.Log("Game Name : " + gameData.gameName);
        Debug.Log("game Score : " + gameData.gameScore);
        Debug.Log("is Game Active : " + gameData.isGameActive);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Debug.Log("Game Name : " + gameData.gameName);
            Debug.Log("game Score : " + gameData.gameScore);
            Debug.Log("is Game Active : " + gameData.isGameActive);
        }
    }
}
