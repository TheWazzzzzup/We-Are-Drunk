using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Singelton
    public static GameManager Instance;


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

    void Start()
    {
        FindServices();

        //spawn the first costumer

        CostumerManager.SpawnCostumer();
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
