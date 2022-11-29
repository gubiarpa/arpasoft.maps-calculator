using arpasoft.maps_calculator.core.Services;
using arpasoft.maps_calculator.winforms.Utils;

namespace arpasoft.maps_calculator.winforms
{
    public partial class FrmMain : Form
    {
        #region Config
        private const int FIX_POSITION_X = 16;
        private const int FIX_POSITION_Y = 44;
        private const int RADIUS = 10;
        /// ERROR
        private const int ERROR_LINE_X1 = 5;
        private const int ERROR_LINE_Y1 = 5;
        private const int ERROR_LINE_X2 = 5;
        private const int ERROR_LINE_Y2 = 5;
        #endregion

        #region Map
        private IMapService<Coordinate> _mapService;
        #endregion

        #region Form-Mode
        private Graphics? _myGraphics;
        private FormMode _formMode = FormMode.ReadOnly;
        private Coordinate? _lastNodeMatched = null;
        #endregion

        #region Constructor
        public FrmMain(IMapService<Coordinate> mapService)
        {
            InitializeComponent();
            _mapService = mapService;
        }
        #endregion

        #region Events
        private void FrmMain_Load(object sender, EventArgs e)
        {
            _myGraphics = picMap.CreateGraphics();
        }

        private void picMap_Click(object sender, EventArgs e)
        {
            switch (_formMode)
            {
                case FormMode.AddingNodes:
                    DrawMapNode();
                    break;
                case FormMode.AddingEdges:
                    DrawMapEdge();
                    break;
            }
        }

        private void btnAddNodes_Click(object sender, EventArgs e)
        {
            if (AbortAddingNodeAction())
                return;

            btnAddNodes.Text = _formMode == FormMode.AddingNodes ? "Add Nodes" : "Exit";
            btnAddEdges.Enabled = _formMode == FormMode.AddingNodes;
            picMap.Cursor = _formMode == FormMode.AddingNodes ? Cursors.Arrow : Cursors.Cross;

            _formMode = _formMode == FormMode.ReadOnly ? FormMode.AddingNodes : FormMode.ReadOnly;
        }

        private void btnAddEdges_Click(object sender, EventArgs e)
        {
            if (AbortAddingEdgeAction())
                return;

            btnAddEdges.Text = _formMode == FormMode.AddingEdges ? "Add Edges" : "Exit";
            btnAddNodes.Enabled = _formMode == FormMode.AddingEdges;
            picMap.Cursor = _formMode == FormMode.AddingEdges ? Cursors.Arrow : Cursors.Hand;

            if (_formMode == FormMode.AddingEdges)
                _lastNodeMatched = null; // Release last node matched

            _formMode = _formMode == FormMode.ReadOnly ? FormMode.AddingEdges : FormMode.ReadOnly;
        }
        #endregion


        #region Drawing
        private void DrawMapNode()
        {
            var coordinate = GetCoordinate();
            _mapService.AddNode(coordinate);
            _myGraphics!.DrawEllipse(new Pen(Color.Red, 2), coordinate.X, coordinate.Y, RADIUS, RADIUS);
        }

        private void DrawMapEdge()
        {
            var coordinate = GetCoordinate();
            var matchedNode = _mapService.GetNodeByValue(coordinate);

            if (matchedNode != null && _lastNodeMatched != null)
            {
                _mapService.AddEdge(_lastNodeMatched.ID, matchedNode.ID);
                _myGraphics!.DrawLine(new Pen(Color.Red, 2),
                    _lastNodeMatched!.X + ERROR_LINE_X1, _lastNodeMatched!.Y + ERROR_LINE_Y1,
                    matchedNode.X + ERROR_LINE_X2, matchedNode.Y + ERROR_LINE_Y2);
            }

            _lastNodeMatched = matchedNode;

        }
        #endregion

        #region Utils
        private Coordinate GetCoordinate()
        {
            var mousePositionX = MousePosition.X;
            var mousePositionY = MousePosition.Y;
            var locationX = Location.X;
            var locationY = Location.Y;
            var mapLocationX = picMap.Location.X;
            var mapLocationY = picMap.Location.Y;

            var x = mousePositionX - locationX - mapLocationX - FIX_POSITION_X;
            var y = mousePositionY - locationY - mapLocationY - FIX_POSITION_Y;

            var nodesCount = _mapService.GetNodesCount();
            var coordinate = new Coordinate(nodesCount + 1) { X = x, Y = y };
            return coordinate;
        }

        private bool AbortAddingNodeAction()
        {
            return
                _formMode == FormMode.ReadOnly &&
                MessageBox.Show(
                    this,
                    "Esta opción no es reversible, ¿Está seguro que desea agregar nodos?",
                    "Adding Nodes",
                    MessageBoxButtons.YesNo) == DialogResult.No;
        }

        private bool AbortAddingEdgeAction()
        {
            return
                _formMode == FormMode.ReadOnly &&
                MessageBox.Show(
                    this,
                    "Esta opción no es reversible, ¿Está seguro que desea agregar aristas?",
                    "Adding Edges",
                    MessageBoxButtons.YesNo) == DialogResult.No;
        }
        #endregion
    }
}