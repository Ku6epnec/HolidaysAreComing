using System.Collections.Generic;
using Interface;
using UnityEngine;

public class PlayerView : MonoBehaviour, IView
{
    public List<WheelCollider> throttleWheels;
    public List<WheelCollider> steeringWheels;
}
