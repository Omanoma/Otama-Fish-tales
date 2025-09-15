using System;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;




[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ChooseSceneObject", order = 1)]
public class ChoooseSceneObject : SceneObject
{
    public List<ButtonChoose> buttonChooses;
}
[Serializable]
public struct ButtonChoose
{
    public string choice;

    public SceneObject specialFeature;

    public float  trust;
    public float romance;
    public float surival;
}