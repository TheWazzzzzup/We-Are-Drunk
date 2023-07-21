using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

public class IceTowerGameManager : MonoBehaviour
{
    [SerializeField] Camera mainCamera;

    [Header("Game parameters")]
    [SerializeField] int targetScore = 10;
    int currentScore = 0;

    [Header("Ice Cube Parameters")]
    [SerializeField] IceCube[] iceCubePrefabs;
    [SerializeField] IceCube currentIceCube;
    [SerializeField] float time = 3f;
    [SerializeField] float scale = 1f;


    [Header("SpawnLocations")]
    [SerializeField] Transform leftSpawnLocation;
    [SerializeField] Transform rightSpawnLocation;
    [SerializeField] Transform targetSpawnLocation;

    [Space]
    [SerializeField] MinigameEvent IceGameEnded;

    Stack<IceCube> placedIceCubes = new();

    bool rightside = true;
    float nextCubeTimer = 3f;
    float timer = 4f;
    bool isGameOver = false;

    public IceCube CurrentIceCube { get => currentIceCube;}

    private void OnMouseDown()
    {
        if(currentIceCube == null) 
            return;

        if(currentIceCube.CurrentState == IceCube.IceCubeState.Swaying)
        {
            currentIceCube.Drop();
        }
    }

    private void Start()
    {
        StartGame();
    }

    private void Update()
    {
        if(isGameOver)
        {
            return;
        }

        if(currentScore >= targetScore)
        {
            print("You win");
            GameOver();
            return;
        }

        //check if null
        if (currentIceCube == null)
            return;

        //check if dropping
        if (currentIceCube.CurrentState != IceCube.IceCubeState.Dropping)
            return;

        if (timer <= 0)
        {
            //add ice cube to stack, get next ice cube
            placedIceCubes.Push(currentIceCube);
            PrepareForNextIceCube();
        }
        else
        {
            timer -= Time.deltaTime;
        }

    }

    public void StartGame()
    {
        PrepareForNextIceCube();
    }

    [ContextMenu("get icecube")]
    void GetNextIceCube()
    {
        currentIceCube = SpawnIceCube();
        scale = RandomScale();
        currentIceCube.Initialize(targetSpawnLocation, time, scale);
        timer = nextCubeTimer;
    }

    void PrepareForNextIceCube()
    {
        if (currentIceCube == null)
        {
            GetNextIceCube();
        }
        else
        {
            currentIceCube.SetIceCubeStable();
            time *= 0.9f;
            GainPoints();
            MoveGameUp();
        }
    }

    void GainPoints()
    {
        currentScore++;
    }

    void MoveGameUp()
    {
        Vector3 upPosition = new Vector3(transform.position.x, transform.position.y + (2 * scale), transform.position.z);
        mainCamera.transform.DOMoveY(mainCamera.transform.position.y + 2 * scale, 0.3f).SetEase(Ease.OutSine).OnComplete(() => {
            transform.position = upPosition;
            GetNextIceCube();
            });
    }

    public IceCube SpawnIceCube()
    {
        IceCube newIceCube;

        if(RandomSpawnSide())
        {
            //spawn right side
            newIceCube = Instantiate(iceCubePrefabs[Random.Range(0,iceCubePrefabs.Length)], rightSpawnLocation.position, Quaternion.identity);
        }
        else
        {
            //spawn left side
            newIceCube = Instantiate(iceCubePrefabs[Random.Range(0, iceCubePrefabs.Length)], leftSpawnLocation.position, Quaternion.identity);
        }

        return newIceCube;
    }

    public void GameOver()
    {
        if (isGameOver)
            return;
        IceGameEnded.Raise(this.gameObject, MinigameType.Ice);
        isGameOver = true;
        print("GameOver");
        //game over logic - show score, send score, start timer to send back to main scene
    }

    #region GetRandom
    bool RandomSpawnSide()
    {
        if (Random.Range(0, 2) == 1)
        {
            rightside = true;
            targetSpawnLocation = leftSpawnLocation;
        }
        else
        {
            rightside= false;
            targetSpawnLocation = rightSpawnLocation;
        }

        return rightside;
    }

    float RandomScale()
    {
        return Random.Range(0.8f, 1.2f);
    }
    #endregion
}
