using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTowerGameManager : MonoBehaviour
{

    [Header("Ice Cube Parameters")]
    [SerializeField] IceCube[] iceCubePrefabs;
    [SerializeField] IceCube currentIceCube;
    [SerializeField] Transform targetSpawnLocation;
    [SerializeField] float time = 3f;

    Stack<IceCube> placedIceCubes;

    [Header("SpawnLocations")]
    [SerializeField] Transform parentSpawnLocation;
    [SerializeField] Transform leftSpawnLocation;
    [SerializeField] Transform rightSpawnLocation;

    bool rightside = true;


    [ContextMenu("get icecube")]
    void GetIceCube()
    {
        currentIceCube = SpawnIceCube();
        currentIceCube.Sway(targetSpawnLocation, time);
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
}
