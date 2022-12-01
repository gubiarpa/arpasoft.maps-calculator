using arpasoft.maps_calculator.core.Services;
using arpasoft.maps_calculator.winforms.Utils;
using System.Text;

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

        #region Path
        private Coordinate? _pathNodeStart = null;
        private Coordinate? _pathNodeEnd = null;
        #endregion

        #region Map
        private IMapService<Coordinate> _mapService;
        #endregion

        #region Form-Mode
        private Graphics? _myGraphics;
        private bool _dirty = false;
        private FormMode _formMode = FormMode.ReadOnly;
        private AddingEdgeType _addingEdgeType = AddingEdgeType.Single;
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
            /// Load Controls
            _myGraphics = picMap.CreateGraphics();
            rbtSingleEdge.Visible = rbtDoubleEdge.Visible = (_formMode == FormMode.AddingEdges);
            btnAddNodes.Enabled = btnAddEdges.Enabled = btnCalculate.Enabled = false;
        }

        private void picMap_Click(object sender, EventArgs e)
        {
            switch (_formMode)
            {
                case FormMode.AddingNodes:
                    AddNodeAndDrawInMap();
                    break;
                case FormMode.AddingEdges:
                    DrawMapEdgeFromLastNodeMatched();
                    break;
                case FormMode.CalculatePath:
                    SetAndPaintExtremeNodes();
                    break;
                case FormMode.ReadOnly:
                    if (!_dirty)
                    {
                        FirstLoadAndPrintNodes();
                        FirstLoadAndPrintEdges();
                        btnAddNodes.Enabled = btnAddEdges.Enabled = btnCalculate.Enabled = true;
                        _dirty = true;
                    }
                    break;
            }
        }

        private void btnAddNodes_Click(object sender, EventArgs e)
        {
            if (AbortAddingNodeAction())
                return;

            switch (_formMode)
            {
                case FormMode.AddingNodes:
                    btnAddNodes.Text = "Add Nodes";
                    btnAddEdges.Enabled = btnCalculate.Enabled = true;
                    picMap.Cursor = Cursors.Arrow;
                    SaveNodes();
                    _formMode = FormMode.ReadOnly;
                    break;
                case FormMode.ReadOnly:
                    btnAddNodes.Text = "Exit";
                    btnAddEdges.Enabled = btnCalculate.Enabled = false;
                    picMap.Cursor = Cursors.Cross;
                    _formMode = FormMode.AddingNodes;
                    break;
            }
        }

        private void btnAddEdges_Click(object sender, EventArgs e)
        {
            if (AbortAddingEdgeAction())
                return;

            switch (_formMode)
            {
                case FormMode.AddingEdges:
                    btnAddEdges.Text = "Add Edges";
                    btnAddNodes.Enabled = btnCalculate.Enabled = true;
                    picMap.Cursor = Cursors.Arrow;
                    _lastNodeMatched = null;
                    rbtSingleEdge.Visible = rbtDoubleEdge.Visible = false;
                    SaveEdges();
                    _formMode = FormMode.ReadOnly;
                    break;
                case FormMode.ReadOnly:
                    btnAddEdges.Text = "Exit";
                    btnAddNodes.Enabled = btnCalculate.Enabled = false;
                    picMap.Cursor = Cursors.Hand;
                    rbtSingleEdge.Checked = (_addingEdgeType == AddingEdgeType.Single);
                    rbtDoubleEdge.Checked = (_addingEdgeType == AddingEdgeType.Double);
                    rbtSingleEdge.Visible = rbtDoubleEdge.Visible = true;
                    _formMode = FormMode.AddingEdges;
                    break;
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            switch (_formMode)
            {
                case FormMode.CalculatePath:
                    btnCalculate.Text = "Calculate Path";
                    btnAddNodes.Enabled = btnAddEdges.Enabled = true;
                    picMap.Cursor = Cursors.Arrow;
                    _formMode = FormMode.ReadOnly;
                    break;
                case FormMode.ReadOnly:
                    btnCalculate.Text = "Exit";
                    btnAddNodes.Enabled = btnAddEdges.Enabled = false;
                    picMap.Cursor = Cursors.Hand;
                    _formMode = FormMode.CalculatePath;
                    break;
                default:
                    break;
            }
        }

        private void rbtSingleEdge_CheckedChanged(object sender, EventArgs e)
        {
            _addingEdgeType = AddingEdgeType.Single;
        }

        private void rbtDoubleEdge_CheckedChanged(object sender, EventArgs e)
        {
            _addingEdgeType = AddingEdgeType.Double;
        }
        #endregion

        #region DataIO
        private void FirstLoadAndPrintNodes()
        {
            try
            {
                /// 1. Read file
                var path = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Data\\");
                var nodesCsv = File.ReadAllText(Path.Combine(path, "Nodes.csv"));
                var nodeLines = nodesCsv.Split('\n');

                /// 2. Load and print nodes
                foreach (var nodeLine in nodeLines)
                {
                    try
                    {
                        var fields = nodeLine.Split(',');
                        var nodesCount = _mapService.GetNodesCount();
                        var newNode = new Coordinate(nodesCount + 1)
                        {
                            X = int.Parse(fields[0]),
                            Y = int.Parse(fields[1]),
                        };
                        AddNodeAndDrawInMap(newNode);
                    }
                    catch
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveNodes()
        {
            try
            {
                /// 1. Get file and structure
                var path = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Data\\");
                var strBuilder = new StringBuilder();
                var nodes = _mapService.GetAllNodes()?.ToList();

                if (nodes == null)
                    return;

                /// 2. Build content
                foreach (var node in nodes)
                {
                    strBuilder.AppendLine($"{node.X},{node.Y}");
                }

                /// 3. Write content
                File.WriteAllText(Path.Combine(path, "Nodes.csv"), strBuilder.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FirstLoadAndPrintEdges()
        {
            try
            {
                /// 1. Read file
                var path = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Data\\");
                var edgesCsv = File.ReadAllText(Path.Combine(path, "Edges.csv"));
                var edgeLines = edgesCsv.Split('\n');

                /// 2. Load and print edges
                foreach (var edgeLine in edgeLines)
                {
                    try
                    {
                        var fields = edgeLine.Split(',');
                        var nodeStart = new Coordinate(0) { X = int.Parse(fields[0]), Y = int.Parse(fields[1]) };
                        var nodeEnd = new Coordinate(0) { X = int.Parse(fields[2]), Y = int.Parse(fields[3]) };
                        var matchedNodeStart = _mapService.GetNodeByValue(nodeStart);
                        var matchedNodeEnd = _mapService.GetNodeByValue(nodeEnd);

                        if (matchedNodeStart == null || matchedNodeEnd == null)
                            continue;

                        AddEdgeAndDrawInMap(matchedNodeStart, matchedNodeEnd);
                    }
                    catch
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveEdges()
        {
            try
            {
                /// 1. Get file and structure
                var path = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Data\\");
                var strBuilder = new StringBuilder();
                var edges = _mapService.GetAllEdges()?.ToList();

                if (edges == null)
                    return;

                /// 2. Build content
                foreach (var edge in edges)
                {
                    strBuilder.AppendLine($"{edge.NodeStart!.X},{edge.NodeStart!.Y},{edge.NodeEnd!.X},{edge.NodeEnd!.Y}");
                }

                /// 3. Write content
                File.WriteAllText(Path.Combine(path, "Edges.csv"), strBuilder.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Drawing
        private void AddNodeAndDrawInMap(Coordinate? coordinate = null)
        {
            Coordinate coordinateTarget = coordinate ?? GetCoordinate();
            _mapService.AddNode(coordinateTarget);
            _myGraphics!.DrawEllipse(new Pen(Color.Red, 2), coordinateTarget.X, coordinateTarget.Y, RADIUS, RADIUS);
        }

        private void DrawMapEdgeFromLastNodeMatched()
        {
            var coordinateEnd = GetCoordinate();
            var matchedNode = _mapService.GetNodeByValue(coordinateEnd);

            if (matchedNode != null)
            {
                if (_lastNodeMatched != null)
                {
                    var edgeAdded = false;
                    var color = Color.Red;

                    switch (_addingEdgeType)
                    {
                        case AddingEdgeType.Single:
                            edgeAdded =
                                _mapService.AddEdge(_lastNodeMatched.ID, matchedNode.ID);
                            color = Color.Red;
                            break;
                        case AddingEdgeType.Double:
                            var edgeAdded1 = _mapService.AddEdge(_lastNodeMatched.ID, matchedNode.ID);
                            var edgeAdded2 = _mapService.AddEdge(matchedNode.ID, _lastNodeMatched.ID);
                            edgeAdded = edgeAdded1 && edgeAdded2;
                            color = Color.Blue;
                            break;
                    }

                    if (edgeAdded)
                    {
                        color = _addingEdgeType == AddingEdgeType.Single ? Color.Red : Color.Blue;
                        _myGraphics!.DrawLine(new Pen(color, 2),
                            _lastNodeMatched!.X + ERROR_LINE_X1, _lastNodeMatched!.Y + ERROR_LINE_Y1,
                            matchedNode.X + ERROR_LINE_X2, matchedNode.Y + ERROR_LINE_Y2);
                    }
                }

                _lastNodeMatched = matchedNode;
            }
        }

        private void AddEdgeAndDrawInMap(Coordinate coordinateStart, Coordinate coordinateEnd)
        {
            var edgeAdded = false;
            var color = Color.Red;

            switch (_addingEdgeType)
            {
                case AddingEdgeType.Single:
                    edgeAdded =
                        _mapService.AddEdge(coordinateStart.ID, coordinateEnd.ID);
                    color = Color.Red;
                    break;
                case AddingEdgeType.Double:
                    var edgeAdded1 = _mapService.AddEdge(coordinateStart.ID, coordinateEnd.ID);
                    var edgeAdded2 = _mapService.AddEdge(coordinateEnd.ID, coordinateStart.ID);
                    edgeAdded = edgeAdded1 && edgeAdded2;
                    color = Color.Blue;
                    break;
            }

            if (edgeAdded)
                _myGraphics!.DrawLine(new Pen(color, 2),
                    coordinateStart.X + ERROR_LINE_X1, coordinateStart.Y + ERROR_LINE_Y1,
                    coordinateEnd.X + ERROR_LINE_X2, coordinateEnd.Y + ERROR_LINE_Y2);
        }

        /// <summary>
        /// Establece el punto inicial o final, dependiendo de cuándo se presione
        /// </summary>
        private void SetAndPaintExtremeNodes()
        {
            var coordinate = GetCoordinate();
            var matchedNode = _mapService.GetNodeByValue(coordinate);

            if (matchedNode == null)
                return;

            _myGraphics!.DrawEllipse(new Pen(Color.DarkCyan, 2), matchedNode.X, matchedNode.Y, RADIUS, RADIUS);

            if (_pathNodeStart == null)
                _pathNodeStart = _mapService.GetNodeByValue(matchedNode);
            else if (_pathNodeEnd == null)
                _pathNodeEnd = _mapService.GetNodeByValue(matchedNode);

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
