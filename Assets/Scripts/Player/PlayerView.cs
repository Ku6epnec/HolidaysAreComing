using System.Collections.Generic;
using Interface;
using UnityEngine;


public class PlayerView : MonoBehaviour, IView
{
    #region Fields

    public List<WheelCollider> throttleWheels;
    public List<WheelCollider> steeringWheels;

    #endregion
}
