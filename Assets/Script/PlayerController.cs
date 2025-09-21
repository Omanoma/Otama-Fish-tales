using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] List<MainSceneObject> mainSceneObjects;
    [SerializeField] List<SceneObject> endScene;

    [SerializeField] Transform minigameTransform;



    SceneObject currentScene;
    GameObject currentMiniGame;

    IMinigame minigame;
    int mainsceneObject = 0;
    int sceneObject = -1;

    private float trust = 0;
    private float romance = 0;
    private float surival = 3;

    public SceneObject NextScene()
    {
        if (surival == 0 && mainsceneObject < 5)
        {
            return GetEndingScene();
        }
        else if (sceneObject >= mainSceneObjects[mainsceneObject].scenes.Count - 1)
        {
            mainsceneObject++;
            sceneObject = 0;
            return (mainsceneObject != mainSceneObjects.Count) ? mainSceneObjects[mainsceneObject].scenes[0] : GetEndingScene();
        }

        sceneObject++;
        return mainSceneObjects[mainsceneObject].scenes[sceneObject];
    }
    public bool CheckifStartOfScene()
    {
        return sceneObject == 0;
    }

    public SceneObject GetEndingScene()
    {
        return new SceneObject();
    }

    public void UpdateStat(float t, float r, float s)
    {
        trust += t;
        romance += r;
        surival += s;
    }

    public string SceneTitle()
    {
        return mainSceneObjects[mainsceneObject].title;
    }

    public bool IsGameTime(int textIndex)
    {
        int count = sceneObject + textIndex;
        return count == 2;
    }

    private void SetupMiniGame()
    {
        currentMiniGame = Instantiate(mainSceneObjects[mainsceneObject].minigame, minigameTransform);
        minigame = currentMiniGame.GetComponent<IMinigame>();
        minigame.StartGame();
    }






}

