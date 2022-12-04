namespace arpasoft.maps_calculator.winforms
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picMap = new System.Windows.Forms.PictureBox();
            this.btnAddNodes = new System.Windows.Forms.Button();
            this.groupMain = new System.Windows.Forms.GroupBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.rbtDoubleEdge = new System.Windows.Forms.RadioButton();
            this.rbtSingleEdge = new System.Windows.Forms.RadioButton();
            this.btnAddEdges = new System.Windows.Forms.Button();
            this.txtDistance = new System.Windows.Forms.TextBox();
            this.lblDistance = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).BeginInit();
            this.groupMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // picMap
            // 
            this.picMap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picMap.Image = global::arpasoft.maps_calculator.winforms.Properties.Resources.Mapa_General;
            this.picMap.Location = new System.Drawing.Point(12, 114);
            this.picMap.Name = "picMap";
            this.picMap.Size = new System.Drawing.Size(1435, 851);
            this.picMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMap.TabIndex = 0;
            this.picMap.TabStop = false;
            this.picMap.Click += new System.EventHandler(this.picMap_Click);
            // 
            // btnAddNodes
            // 
            this.btnAddNodes.Location = new System.Drawing.Point(26, 41);
            this.btnAddNodes.Name = "btnAddNodes";
            this.btnAddNodes.Size = new System.Drawing.Size(142, 29);
            this.btnAddNodes.TabIndex = 1;
            this.btnAddNodes.Text = "Add Nodes";
            this.btnAddNodes.UseVisualStyleBackColor = true;
            this.btnAddNodes.Click += new System.EventHandler(this.btnAddNodes_Click);
            // 
            // groupMain
            // 
            this.groupMain.Controls.Add(this.lblDistance);
            this.groupMain.Controls.Add(this.txtDistance);
            this.groupMain.Controls.Add(this.btnCalculate);
            this.groupMain.Controls.Add(this.rbtDoubleEdge);
            this.groupMain.Controls.Add(this.rbtSingleEdge);
            this.groupMain.Controls.Add(this.btnAddEdges);
            this.groupMain.Controls.Add(this.btnAddNodes);
            this.groupMain.Location = new System.Drawing.Point(12, 12);
            this.groupMain.Name = "groupMain";
            this.groupMain.Size = new System.Drawing.Size(1435, 96);
            this.groupMain.TabIndex = 2;
            this.groupMain.TabStop = false;
            this.groupMain.Text = "Mantenimiento";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(346, 41);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(142, 29);
            this.btnCalculate.TabIndex = 5;
            this.btnCalculate.Text = "Calculate Path";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // rbtDoubleEdge
            // 
            this.rbtDoubleEdge.AutoSize = true;
            this.rbtDoubleEdge.Location = new System.Drawing.Point(1329, 43);
            this.rbtDoubleEdge.Name = "rbtDoubleEdge";
            this.rbtDoubleEdge.Size = new System.Drawing.Size(79, 24);
            this.rbtDoubleEdge.TabIndex = 4;
            this.rbtDoubleEdge.TabStop = true;
            this.rbtDoubleEdge.Text = "Double";
            this.rbtDoubleEdge.UseVisualStyleBackColor = true;
            this.rbtDoubleEdge.CheckedChanged += new System.EventHandler(this.rbtDoubleEdge_CheckedChanged);
            // 
            // rbtSingleEdge
            // 
            this.rbtSingleEdge.AutoSize = true;
            this.rbtSingleEdge.Location = new System.Drawing.Point(1238, 43);
            this.rbtSingleEdge.Name = "rbtSingleEdge";
            this.rbtSingleEdge.Size = new System.Drawing.Size(71, 24);
            this.rbtSingleEdge.TabIndex = 3;
            this.rbtSingleEdge.TabStop = true;
            this.rbtSingleEdge.Text = "Single";
            this.rbtSingleEdge.UseVisualStyleBackColor = true;
            this.rbtSingleEdge.CheckedChanged += new System.EventHandler(this.rbtSingleEdge_CheckedChanged);
            // 
            // btnAddEdges
            // 
            this.btnAddEdges.Location = new System.Drawing.Point(186, 41);
            this.btnAddEdges.Name = "btnAddEdges";
            this.btnAddEdges.Size = new System.Drawing.Size(142, 29);
            this.btnAddEdges.TabIndex = 2;
            this.btnAddEdges.Text = "Add Edges";
            this.btnAddEdges.UseVisualStyleBackColor = true;
            this.btnAddEdges.Click += new System.EventHandler(this.btnAddEdges_Click);
            // 
            // txtDistance
            // 
            this.txtDistance.Location = new System.Drawing.Point(710, 41);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.ReadOnly = true;
            this.txtDistance.Size = new System.Drawing.Size(153, 27);
            this.txtDistance.TabIndex = 6;
            // 
            // lblDistance
            // 
            this.lblDistance.AutoSize = true;
            this.lblDistance.Location = new System.Drawing.Point(638, 44);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(66, 20);
            this.lblDistance.TabIndex = 7;
            this.lblDistance.Text = "Distance";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1459, 988);
            this.Controls.Add(this.groupMain);
            this.Controls.Add(this.picMap);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.Text = "Map Reader";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).EndInit();
            this.groupMain.ResumeLayout(false);
            this.groupMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox picMap;
        private Button btnAddNodes;
        private GroupBox groupMain;
        private Button btnAddEdges;
        private RadioButton rbtDoubleEdge;
        private RadioButton rbtSingleEdge;
        private Button btnCalculate;
        private Label lblDistance;
        private TextBox txtDistance;
    }
}