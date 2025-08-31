using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGame1Food : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] public bool poisonsFood;
    [SerializeField] Image image;
    [SerializeField] List<Sprite> foodSprite;

    private void OnEnable()
    {
        image.sprite = foodSprite[Random.Range(0, foodSprite.Count)];
    }
    



}
