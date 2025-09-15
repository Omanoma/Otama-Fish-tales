using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Mini_Game1 : IMinigame
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject poisonsFood;
    [SerializeField] GameObject editorFood;
    [SerializeField] Transform List;

    [SerializeField] GameObject ESide;
    [SerializeField] GameObject PSide;


    List<GameObject> kielGathering = new List<GameObject>();

    int indexFood = 0;
    int result = 0;

    bool resultBool = true;

    void OnEnable()
    {
        resultBool = true;
        int amount = Random.Range(10, 18);
        indexFood = amount - 1;
        for (int i = 0; i < amount; i++)
        {
            bool poisonsFoodBool = Random.Range(0, 2) == 0;
            GameObject kielGatheringFood = (poisonsFoodBool) ? Instantiate<GameObject>(poisonsFood, List) : Instantiate<GameObject>(editorFood, List);
            kielGatheringFood.SetActive(true);
            kielGathering.Add(kielGatheringFood);
        }

    }

    void OnDisable()
    {
        for (int i = 0; i < kielGathering.Count; i++)
        {
            Destroy(kielGathering[i]);
        }
        kielGathering.Clear();
    }

    public void clickButtonForCorrectItem(bool poisonsFoodBool)
    {
        if (indexFood < 0 && !resultBool) return;
        MiniGame1Food food = kielGathering[indexFood].GetComponent<MiniGame1Food>();
        if (poisonsFoodBool)
        {
            kielGathering[indexFood].transform.DOMove(PSide.transform.position, 2f);
        }
        else
        {
            kielGathering[indexFood].transform.DOMove(ESide.transform.position, 2f);
        }

        result = (food.poisonsFood == poisonsFoodBool) ? result + 1 : result - 1;
        Debug.Log($"Item:{indexFood}      {food.poisonsFood == poisonsFoodBool}");
        indexFood--;
        resultBool = (food.poisonsFood == poisonsFoodBool);
        //food.poisonsFood;

    }

    public override List<float> Result()
    {
        if (resultBool)
        {
            return new List<float> { 0, 0, 1 };
        }
        else
        {
            return new List<float> { 0, 0, -1 };
        }

    }

}
