using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IceTowerMingameManager : MonoBehaviour
{
    [SerializeField] GameObject _iceCubePrefab;
    [SerializeField] Transform _iceCubeSpawnPoint;
    [SerializeField] float _iceCubeSpeedGainPerSpawn;

    [SerializeField] ScoreManager _scoreManager;

    public UnityEvent OnMiniGameEnds;

    bool _isMinigameActive = true;
    float _currIceCubeMovementSpeed;
    float _rngSeed;
    IceCubeController _currentIceCube;

    private void Awake()
    {
        //find the score manager in the scene
        _scoreManager ??= FindObjectOfType<ScoreManager>();
    }

    private void Start()
    {
        //Start the minigame
        _isMinigameActive = true;
        SpawnIceCube();
    }

    public GameObject SpawnIceCube()
    {
        if (!_isMinigameActive)
        {
            return null;
        }

        //if there is an ice cube active, we cannot spawn another one
        if (_currentIceCube != null)
        {
            return null;
        }

        GameObject iceCube = GameObject.Instantiate(_iceCubePrefab, _iceCubeSpawnPoint.position, Quaternion.identity);

        //Set up listeners
        IceCubeCollisionHandler collisionHandler = iceCube.GetComponent<IceCubeCollisionHandler>();
        collisionHandler.OnIceCubeCollision += OnIceCubeCollision;

        //when an ice cube had stopped, we spawn a new one
        collisionHandler.OnIceCubeStopped += () => SpawnIceCube();

        //setup it's movement speed
        TweenBackAndForthMovement movement = iceCube.GetComponent<TweenBackAndForthMovement>();

        //track the current ice cube
        _currentIceCube = iceCube.GetComponent<IceCubeController>();


        return iceCube;
    }

    void OnIceCubeCollision(Collision2D other)
    {
        //if we hit the floor, we end the minigame
        if (other.collider.CompareTag("minigame Floor"))
        {
            _isMinigameActive = false;
            OnMiniGameEnds?.Invoke();
            return;
        }

        if (other.collider.CompareTag("Ice Cube"))
        {
            //Stop tracking the ice cube
            _currentIceCube = null;

            //Add points
        }

    }
}
