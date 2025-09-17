 using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SceneManagers : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] PlayerController playerController;
    [SerializeField] GameObject sceneGame;

    [SerializeField] GameObject startScene;

    [Header("Scene Section")]
    [SerializeField] List<Button> buttonChoose;
    [SerializeField] Image background;
    [SerializeField] Image character1;
    [SerializeField] Image character2;
    [SerializeField] TextMeshProUGUI textsection;
    [SerializeField] TextMeshProUGUI character;
    [SerializeField] ChangeScene changeScene;

    private SceneObject currentScene;

    int indextextScene = 0;

    public void startGame()
    {
        sceneGame.SetActive(true);
        startScene.SetActive(false);
        currentScene = playerController.NextScene();

        SetScene(currentScene, 0);
        indextextScene++;
    }


    public void SetScene(SceneObject scene, int index)
    {
        // Show dialogue
        background.sprite = (scene.backgroundScene != null) ? scene.backgroundScene : background.sprite;

        // When dialogue ends in a choice scene
        if (scene.chooseScene && index == scene.textScene.Count)
        {
            var other = scene as ChoooseSceneObject;
            int count = 0;
            //textsection.text = scene.textScene[index].speech;
            //character.text = scene.textScene[index].character.ToString();
            foreach (var item in other.buttonChooses)
            {
                var choice = item; // prevent closure bug
                buttonChoose[count].gameObject.SetActive(true);
                TextMeshProUGUI text = buttonChoose[count].transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                text.text = choice.choice;
                buttonChoose[count].onClick.RemoveAllListeners();
                buttonChoose[count].onClick.AddListener(() => { UpdateStat(choice); });
                count++;
            }
        }
        else
        {
            textsection.text = scene.textScene[index].speech;
            character.text = scene.textScene[index].character.ToString();
            background.sprite = (scene.backgroundScene != null) ? scene.backgroundScene : background.sprite;
            foreach (var item in buttonChoose)
            {
                item.gameObject.SetActive(false);
            }
        }

    }

    private void CheckIfSceneFinish()
    {
    
        if (currentScene.chooseScene && currentScene.textScene.Count + 1 <= indextextScene)
        {
            currentScene = playerController.NextScene();
            indextextScene = 0;

        }
        else if (!currentScene.chooseScene && currentScene.textScene.Count <= indextextScene)
        {
            currentScene = playerController.NextScene();
            indextextScene = 0;
        }
    
    }

    private void GetButtonScene(SceneObject sceneObject)
    {
        currentScene = sceneObject;
        indextextScene = 0;
    }


    public void UpdateStat(ButtonChoose buttonChoose)
    {
        playerController.UpdateStat(buttonChoose.trust, buttonChoose.romance, buttonChoose.surival);
        GetButtonScene(buttonChoose.specialFeature);
        nextScene();

    }

    public void nextScene()
    {
        CheckIfSceneFinish();
        SetScene(currentScene, indextextScene);
        indextextScene++;
       
    }
}
