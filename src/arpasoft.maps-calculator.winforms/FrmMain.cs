using arpasoft.maps_calculator.winforms.Utils;

namespace arpasoft.maps_calculator.winforms
{
    public partial class FrmMain : Form
    {
        private const int FIX_POSITION_X = 16;
        private const int FIX_POSITION_Y = 44;
        private const int RADIUS = 10;

        #region Form-Mode
        private Graphics? _myGraphics;
        private FormMode _formMode = FormMode.ReadOnly;
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

            _formMode =  _formMode == FormMode.ReadOnly ? FormMode.AddingNodes : FormMode.ReadOnly;
        }

        private void btnAddEdges_Click(object sender, EventArgs e)
        {
            if (AbortAddingEdgeAction())
                return;

            btnAddEdges.Text = _formMode == FormMode.AddingEdges ? "Add Edges" : "Exit";
            btnAddNodes.Enabled = _formMode == FormMode.AddingEdges;
            picMap.Cursor = _formMode == FormMode.AddingEdges ? Cursors.Arrow : Cursors.Hand;

            _formMode =  _formMode == FormMode.ReadOnly ? FormMode.AddingEdges : FormMode.ReadOnly;
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

            _myGraphics!.DrawEllipse(new Pen(Color.Red, 2), x, y, RADIUS, RADIUS);
        }
        #endregion

        #region Utils
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