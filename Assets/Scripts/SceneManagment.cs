using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Scene",fileName = nameof(SceneManagment))]
public class SceneManagment : ScriptableObject
{
    [SerializeField] int MainSceneIndex;
    List<MinigameSceneData> sceneDatas;

    public void MinigameCompleted(MinigameSceneData minigameSceneData)
    {
        sceneDatas.Add(minigameSceneData);
    }

}

public struct MinigameSceneData
{
    public int SceneNumber;
    public MinigameType MinigameType;
    public ScoreManager ScoreManager;

    public MinigameSceneData(int sceneNumber, MinigameType type, ScoreManager scoreManager )
    {
        this.SceneNumber = sceneNumber;
        this.ScoreManager = scoreManager;
        this.MinigameType = type;
    }
}
