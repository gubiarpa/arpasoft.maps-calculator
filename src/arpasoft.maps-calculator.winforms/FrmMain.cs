namespace arpasoft.maps_calculator.winforms
{
    public partial class FrmMain : Form
    {
        private const int FIX_POSITION_X = 16;
        private const int FIX_POSITION_Y = 44;

        #region Form-Mode
        private bool _addingNodes = false;
        #endregion

        #region Constructor
        public FrmMain()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void FrmMain_Load(object sender, EventArgs e)
        {
            _addingNodes = false;
            btnSave.Visible = btnCancel.Visible = _addingNodes;
        }

        private void picMap_Click(object sender, EventArgs e)
        {
            if (!_addingNodes)
                return;

            DrawMapNode();
        }

        private void btnAddNodes_Click(object sender, EventArgs e)
        {
            _addingNodes = !_addingNodes;
            btnSave.Visible = btnCancel.Visible = _addingNodes;
            btnAddEdges.Enabled = !_addingNodes;
            picMap.Cursor = _addingNodes ? Cursors.Cross : Cursors.Arrow;
        }
        #endregion


        #region Drawing
        private void DrawMapNode()
        {
            var mousePositionX = MousePosition.X;
            var mousePositionY = MousePosition.Y;
            var locationX = Location.X;
            var locationY = Location.Y;
            var mapLocationX = picMap.Location.X;
            var mapLocationY = picMap.Location.Y;

            var x = mousePositionX - locationX - mapLocationX - FIX_POSITION_X;
            var y = mousePositionY - locationY - mapLocationY - FIX_POSITION_Y;

            var myGraphics = picMap.CreateGraphics();
            var myPen = new Pen(Color.Red, 2);
            myGraphics.DrawEllipse(myPen, x, y, 10, 10);
        }
        #endregion
    }
}