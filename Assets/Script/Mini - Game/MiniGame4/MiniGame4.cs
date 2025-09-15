using System.Collections.Generic;
using TMPro;
using DG.Tweening;
using UnityEngine;
using NUnit.Framework.Interfaces;
using System.Collections;
//using Unity.VisualScripting;

public class MiniGame4 : IMinigame
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject water;
    [SerializeField] TextMeshProUGUI trafficLight;

    private int result = 0;
    private bool gameStart = false;
    private int round = 4;

    private bool onSurface = true;
    private bool reactOnTime = true;
    void OnEnable()
    {
        gameStart = true;
        StartCoroutine(UnderTimer());
    }

    public void OnClickBackground()
    {
        if (reactOnTime)
        {
            Debug.Log("Clicked");
            if (onSurface)
            {
                water.transform.DOMoveY(water.transform.position.y + 10f, 2f);
            }
            else
            {
                water.transform.DOMoveY(water.transform.position.y - 10f, 2f);
            }
            trafficLight.text = "Hold";
            reactOnTime = false;
            result++;
        }
        else
        {
            Debug.Log("Failed");
            gameStart = false;
        }

    }
    private IEnumerator UnderTimer()
    {
        float random = Random.Range(4, 6);
        while (gameStart && round > 0)
        {
            trafficLight.text = (onSurface) ? "DOWN" : "UP";
            reactOnTime = true;
            yield return new WaitForSeconds(random);
            if (reactOnTime) break;
            onSurface = !onSurface;
            random--;
            round--;

        }

        if (round <= 0 && result == 4)
        {
            trafficLight.text = "You Survive";
        }
        else
        {
            trafficLight.text = "You Failed";
        }

    }   
    
    public override List<float> Result()
    {
        // 0 - trust, 1 - romance, 2 - surival
        if (round <= 0 && result == 4)
        {
            return new List<float> { 0, 1, 0 };
        }
        else
        {
            return new List<float> { 0, 0, 0 };
        }

    }
}
