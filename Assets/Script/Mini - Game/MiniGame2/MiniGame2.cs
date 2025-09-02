using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;

public class MiniGame2 : MonoBehaviour
{
    [SerializeField] List<GameObject> fireItems;
    [SerializeField] Transform place;
    [SerializeField] Transform orderOfFire;
    [SerializeField] TextMeshProUGUI timer;

    List<GameObject> userInput = new List<GameObject>();
    List<GameObject> correctOrder = new List<GameObject>();


    float time = 30;
    bool timerStart = false;

    int countPress = 0;
    int round = 0;
    

    private void OnEnable()
    {
        //Debug.Log("DDDDDDDDD");
        timerStart = true;
        SetupGame();
    }
    private void Update()
    {
        if (time > 0 && round < 4)
        {
            time -= Time.deltaTime;
            timer.text = $"{Math.Round(time)}";
        }
        else
        {
            timerStart = false;
            
        }

        if (timerStart && time >= 0 && countPress == 3 && round <= 3)
        {

            Debug.Log($"Result Round {round} : {CheckResult()}");
            time += 7;
            countPress = 0;
            RestartGame();
        }

    }
    private void SetupGame()
    {
        foreach (var item in fireItems)
        {
            correctOrder.Add(Instantiate(item, orderOfFire));
        }
        ShuffleGameObjects(correctOrder);
        round++;
    }
    public void ShuffleGameObjects(List<GameObject> gameObjects)
    {
        System.Random random = new System.Random();
        for (int i = gameObjects.Count - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1);
            // Swap elements
            GameObject temp = gameObjects[i];
            gameObjects[i] = gameObjects[j];
            gameObjects[j] = temp;
        }

        for (int i = 0; i < gameObjects.Count; i++)
        {
            gameObjects[i].transform.SetSiblingIndex(i);
        }

    }


    public void UserInputFood(GameObject item)
    {
        if (timerStart)
        {
            userInput.Add(Instantiate(item, place));
            countPress++;
        }

    }

    public void RestartGame()
    {
        foreach (var item in correctOrder)
        {
            Destroy(item);
        }

        correctOrder.Clear();

        foreach (var item in userInput)
        {
            Destroy(item);
        }
        userInput.Clear();
        SetupGame();
        countPress = 0;
    }

    public bool CheckResult()
    {
        for (int i = 0; i < userInput.Count; i++)
        {
            if (userInput[i].name != correctOrder[i].name) return false;
        }
        return true;
    }
}
  