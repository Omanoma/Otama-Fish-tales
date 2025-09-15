using System.Collections.Generic;
using UnityEngine;

public class IMinigame : MonoBehaviour
{
    // 0 - trust, 1 - romance, 2 - surival
    public virtual List<float> Result()
    {
        return new List<float> { 0, 0, 0 };
    }

    public virtual void StartGame()
    {
        this.gameObject.SetActive(true);
    }

    public virtual void FinishGame()
    {
        this.gameObject.SetActive(false);
    }
}
