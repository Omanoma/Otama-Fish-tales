using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


public class MiniGame3 : MonoBehaviour
{
    [SerializeField] List<GameObject> stars;
    [SerializeField] List<Image> starsGlow;
    List<int> starIndex = new List<int>();
    int touchcount = 0;
    private bool touchStar = false;
    void OnEnable()
    {
        SetUp();
        StartCoroutine(GlowingPatterning());
    }


    private void SetUp()
    {
        for (int i = 0; i < stars.Count; i++)
        {
            starIndex.Add(i);
        }

        Shuffle(starIndex);

    }


    public static void Shuffle(List<int> list)
    {
        System.Random rng = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            int value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }


    public void Glowing(Image glow)
    {
        Sequence squence = DOTween.Sequence();
        squence
        .Append(glow.DOFade(0.8f, 2f))
        .Join(glow.transform.DOScale(1.3f, 2f))
        .Append(glow.DOFade(0.0f, 2f))
        .Join(glow.transform.DOScale(1f, 2f));
    }
    public void GlowingClickButton(int item)
    {
        if (touchStar)
        {
            if (item == starIndex[touchcount])
            {
                Glowing(starsGlow[item]);
                touchcount++;
                if (touchcount == starIndex.Count) Debug.Log("True");
            }
            else
            {
                touchStar = false;
                Debug.Log("False");
            }
        }
    }
    public IEnumerator GlowingPatterning()
    {
        float time = 0;
        foreach (int item in starIndex)
        {
            yield return new WaitForSeconds(time);
            Glowing(starsGlow[item]);
            time = 3f;
        }
        yield return new WaitForEndOfFrame();
        touchStar = true;

    }
}
