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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddEdges = new System.Windows.Forms.Button();
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
            this.btnAddNodes.Location = new System.Drawing.Point(20, 41);
            this.btnAddNodes.Name = "btnAddNodes";
            this.btnAddNodes.Size = new System.Drawing.Size(142, 29);
            this.btnAddNodes.TabIndex = 1;
            this.btnAddNodes.Text = "Add Nodes";
            this.btnAddNodes.UseVisualStyleBackColor = true;
            this.btnAddNodes.Click += new System.EventHandler(this.btnAddNodes_Click);
            // 
            // groupMain
            // 
            this.groupMain.Controls.Add(this.btnSave);
            this.groupMain.Controls.Add(this.btnCancel);
            this.groupMain.Controls.Add(this.btnAddEdges);
            this.groupMain.Controls.Add(this.btnAddNodes);
            this.groupMain.Location = new System.Drawing.Point(12, 12);
            this.groupMain.Name = "groupMain";
            this.groupMain.Size = new System.Drawing.Size(1435, 96);
            this.groupMain.TabIndex = 2;
            this.groupMain.TabStop = false;
            this.groupMain.Text = "Mantenimiento";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1129, 41);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(142, 29);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1277, 41);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(142, 29);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAddEdges
            // 
            this.btnAddEdges.Location = new System.Drawing.Point(168, 41);
            this.btnAddEdges.Name = "btnAddEdges";
            this.btnAddEdges.Size = new System.Drawing.Size(142, 29);
            this.btnAddEdges.TabIndex = 2;
            this.btnAddEdges.Text = "Add Edges";
            this.btnAddEdges.UseVisualStyleBackColor = true;
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
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox picMap;
        private Button btnAddNodes;
        private GroupBox groupMain;
        private Button btnAddEdges;
        private Button btnSave;
        private Button btnCancel;
    }
}