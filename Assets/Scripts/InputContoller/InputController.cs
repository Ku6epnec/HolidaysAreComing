using Interface;
using UnityEngine;


namespace InputContoller
{
    public class InputController : IUpdateExecute
    {
        #region Fields

        private float _vertical;
        private float _horizontal;

        public float Vertical => _vertical;

        public float Horizontal => _horizontal;

        #endregion


        #region Methods

        private void GetInput()
        { 
            _vertical = Input.GetAxis("Vertical");
            _horizontal = Input.GetAxis("Horizontal");
        }

        public void UpdateExecute()
        { 
            GetInput();
        }

        #endregion
    }
}
