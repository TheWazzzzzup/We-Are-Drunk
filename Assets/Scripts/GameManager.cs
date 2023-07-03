using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Singelton
    public static GameManager Instance;

    int customer;

    #region Services

    [SerializeField, BoxGroup("Costumers")] CostumerManager _costumerManager;

    public CostumerManager CostumerManager { get => _costumerManager; private set => _costumerManager = value; }

    #endregion

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }


        // False after playtest
#if true
    private void Update()
    {
        // This update loop will reset the hint 
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (customer == 0)
            {
                CostumerManager.SpawnCostumer();
                customer++;
            }
            else
            {
                customer--;
                CostumerManager.RemoveCurrentCostumer();
            }
        }

    }
#endif

    void Start()
    {
        FindServices();

        //spawn the first costumer

        CostumerManager.SpawnCostumer();
        customer++;
    }

    /// <summary>
    /// This method is used to find all the services in the scene for the GameManager to use
    /// </summary>
    private void FindServices()
    {
        //Find the costumer manager
        CostumerManager ??= gameObject.GetComponentInChildren<CostumerManager>();
    }
}
