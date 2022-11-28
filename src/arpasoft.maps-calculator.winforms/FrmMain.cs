namespace arpasoft.maps_calculator.winforms
{
    public partial class FrmMain : Form
    {
        private const int FIX_POSITION_X = 26;
        private const int FIX_POSITION_Y = 55;

        private bool _addingNodes = false;

        public FrmMain()
        {
            InitializeComponent();
        }

        #region Events
        private void picMap_Click(object sender, EventArgs e)
        {
            if (!_addingNodes)
                return;

            DrawMapNode();
        }

        private void btnAddNodes_Click(object sender, EventArgs e)
        {
            _addingNodes = !_addingNodes;
            btnAddEdges.Enabled = !_addingNodes;
        }
        #endregion


        #region Drawing
        private void DrawMapNode()
        {
            var mousePositionX = MousePosition.X;
            var mousePositionY = MousePosition.Y;
            var locationX = Location.X;
            var locationY = Location.Y;

            var x = mousePositionX - locationX - FIX_POSITION_X;
            var y = mousePositionY - locationY - FIX_POSITION_Y;

            var myGraphics = picMap.CreateGraphics();
            var myPen = new Pen(Color.Red, 2);
            myGraphics.DrawEllipse(myPen, x, y, 10, 10);
        }
        #endregion
    }
}