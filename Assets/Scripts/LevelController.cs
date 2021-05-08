using MazeConstructor;
using Player;
using UnityEngine;


public class LevelController : MonoBehaviour
{
    #region Fields

    [SerializeField] private CellView cell;
    [SerializeField] private Transform placeForLevel;
    [SerializeField] private Vector3 startPosition;

    [SerializeField] private int mazeWidth;
    [SerializeField] private int mazeHeight;

    private PlayerModel _playerModel;

    private MazeController _mazeController;
    private PlayerController _playerController;

    #endregion


    #region UnityMethods

    void Start()
    {
        _playerModel = new PlayerModel();
        _mazeController = new MazeController(cell, mazeWidth, mazeHeight, placeForLevel);
        _playerController = new PlayerController(_playerModel, startPosition);

        _mazeController.StartExecute();
        _playerController.StartExecute();
    }

    private void FixedUpdate()
    {
        _playerController.UpdateExecute();
    }

    #endregion
}
