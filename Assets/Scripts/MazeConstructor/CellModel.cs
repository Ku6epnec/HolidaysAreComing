namespace MazeConstructor
{
    public class CellModel
    {
        #region Fields

        public int X;
        public int Z;

        public bool _wallLeft = true;
        public bool _wallBottom = true;
        public bool _floor = true;

        public bool _visited = false;

        #endregion
    }
}
