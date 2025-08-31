using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;




[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SceneObject", order = 1)]
public class SceneObject : ScriptableObject
{
    public string sceneName;
    public bool chooseScene;
    public Sprite backgroundScene;
    public List<TextSection> textScene;
}



