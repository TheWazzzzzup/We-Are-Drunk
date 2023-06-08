using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostumerManager : MonoBehaviour
{
    [SerializeField] GameObject costumerPrefab;
    [SerializeField] Transform spawnPoint, standingPoint;

    [Button]
    public CostumerController SpawnCostumer()
    {
        CostumerController costumer = CreateCostumer();
        MoveCostumerToStandingPoint(costumer);
        costumer.ShowDialogue("Hello");
        return costumer;
    }

    private CostumerController CreateCostumer()
    {
        GameObject costumer = Instantiate(costumerPrefab, spawnPoint.position, Quaternion.identity);
        costumer.transform.SetParent(transform);
        return costumer.GetComponent<CostumerController>();
    }

    private void MoveCostumerToStandingPoint(CostumerController costumer)
    {
        costumer.MoveTo(standingPoint.position);
    }
}
