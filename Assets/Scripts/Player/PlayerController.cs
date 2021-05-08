

using InputContoller;
using Interface;
using UnityEngine;

namespace Player
{
    public class PlayerController : IStartExecute, IUpdateExecute
    {
        private PlayerModel _model;
        private Vector3 _startPosition;
        private PlayerView _view;
        private InputController _inputController;
        private float _torqueCoefficient = 10000.0f;
        private float _maxSteer = 20.0f;
        
        public PlayerController(PlayerModel playerModel, Vector3 startPosition)
        {
            _model = playerModel;
            _startPosition = startPosition;
        }
        
        
        
        
        public void StartExecute()
        { 
            _inputController = new InputController();
            _view = Object.FindObjectOfType<PlayerView>().GetComponent<PlayerView>();
        }

        public void UpdateExecute()
        {
            _inputController.UpdateExecute();
            foreach (var throttleWheel in _view.throttleWheels)
            {
                throttleWheel.motorTorque = _torqueCoefficient * Time.fixedDeltaTime * _inputController.Vertical;
            }

            foreach (var steeringWheel in _view.steeringWheels)
            {
                steeringWheel.brakeTorque = 0.0f;
                steeringWheel.steerAngle = _maxSteer * _inputController.Horizontal;
            }
        }
    }
}
