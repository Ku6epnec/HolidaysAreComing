using System;
using InputContoller;
using MazeConstructor;
using Player;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private CellView cell;
    [SerializeField] private int mazeWidth;
    [SerializeField] private int mazeHeight;
    [SerializeField] private Transform placeForLevel;
    [SerializeField] private Vector3 startPosition;

    private PlayerModel _playerModel;

    private MazeController _mazeController;
    private PlayerController _playerController;

    void Start()
    {
        _playerModel = new PlayerModel();
        _mazeController = new MazeController(cell, mazeWidth, mazeHeight, placeForLevel);
        _playerController = new PlayerController(_playerModel, startPosition);
        _mazeController.StartExecute();
        _playerController.StartExecute();
    }
    
    
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        _playerController.UpdateExecute();
    }
}
