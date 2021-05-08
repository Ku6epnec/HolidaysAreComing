using Interface;
using UnityEngine;

namespace MazeConstructor
{
    public class CellView : MonoBehaviour, IView
    {
        public GameObject wallLeft, floor, wallBottom;
    }
}
