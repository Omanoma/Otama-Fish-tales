using System;
using System.Collections.Generic;
using UnityEngine;

public class IMinigame : MonoBehaviour
{

    private GameObject miniGamePlaceHolder;
    public Action OnGameOver;

    public GameObject MiniGamePlaceHolder
    {
        set { miniGamePlaceHolder = value; }
    }


    // 0 - trust, 1 - romance, 2 - surival
    public virtual List<float> Result()
    {
        return new List<float> { 0, 0, 0 };
    }

    public virtual void StartGame()
    {
        miniGamePlaceHolder.SetActive(true);
        this.gameObject.SetActive(true);
    }

    public virtual void FinishGame()
    {
        miniGamePlaceHolder.SetActive(false);
        this.gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
