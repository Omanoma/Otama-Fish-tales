using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;




[CreateAssetMenu(fileName = "Day", menuName = "ScriptableObjects/MainSceneObject", order = 1)]
public class MainSceneObject : ScriptableObject
{
    public string title;
    public List<SceneObject> scenes;
}