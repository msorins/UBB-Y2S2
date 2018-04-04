namespace LAB1
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.parentDataGrid = new System.Windows.Forms.DataGridView();
            this.showsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.childrenDataGrid = new System.Windows.Forms.DataGridView();
            this.episodesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.labelParent = new System.Windows.Forms.Label();
            this.labelChildren = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.daToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.parentDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.showsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.childrenDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.episodesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // parentDataGrid
            // 
            this.parentDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.parentDataGrid.Location = new System.Drawing.Point(12, 37);
            this.parentDataGrid.Name = "parentDataGrid";
            this.parentDataGrid.ReadOnly = true;
            this.parentDataGrid.Size = new System.Drawing.Size(644, 231);
            this.parentDataGrid.TabIndex = 0;
            this.parentDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.showsDataGrid_CellClick);
            this.parentDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.showsDataGrid_CellContentClick_1);
            // 
            // showsBindingSource
            // 
            this.showsBindingSource.DataMember = "Shows";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 598);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(644, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Delete Selected";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.deleteSelectedButton_Click);
            // 
            // childrenDataGrid
            // 
            this.childrenDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.childrenDataGrid.Location = new System.Drawing.Point(12, 329);
            this.childrenDataGrid.Name = "childrenDataGrid";
            this.childrenDataGrid.Size = new System.Drawing.Size(644, 254);
            this.childrenDataGrid.TabIndex = 4;
            this.childrenDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.episodesDataGrid_CellClick);
            this.childrenDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            this.childrenDataGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.episodesDataGrid_CellEndEdit);
            this.childrenDataGrid.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.episodesDataGrid_UserAddedRow);
            this.childrenDataGrid.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.episodesDataGrid_UserDeletedRow);
            this.childrenDataGrid.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.episodesDataGrid_UserDeletingRow);
            // 
            // episodesBindingSource
            // 
            this.episodesBindingSource.DataMember = "Episodes";
            // 
            // labelParent
            // 
            this.labelParent.AutoSize = true;
            this.labelParent.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelParent.Location = new System.Drawing.Point(12, 9);
            this.labelParent.Name = "labelParent";
            this.labelParent.Size = new System.Drawing.Size(39, 22);
            this.labelParent.TabIndex = 5;
            this.labelParent.Text = "text";
            this.labelParent.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelChildren
            // 
            this.labelChildren.AutoSize = true;
            this.labelChildren.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChildren.Location = new System.Drawing.Point(12, 304);
            this.labelChildren.Name = "labelChildren";
            this.labelChildren.Size = new System.Drawing.Size(39, 22);
            this.labelChildren.TabIndex = 6;
            this.labelChildren.Text = "text";
            this.labelChildren.Click += new System.EventHandler(this.label2_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.daToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(88, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // daToolStripMenuItem
            // 
            this.daToolStripMenuItem.Name = "daToolStripMenuItem";
            this.daToolStripMenuItem.Size = new System.Drawing.Size(87, 22);
            this.daToolStripMenuItem.Text = "da";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 632);
            this.Controls.Add(this.labelChildren);
            this.Controls.Add(this.labelParent);
            this.Controls.Add(this.childrenDataGrid);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.parentDataGrid);
            this.Name = "MainForm";
            this.Text = "2";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.parentDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.showsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.childrenDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.episodesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView parentDataGrid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView childrenDataGrid;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label labelParent;
        private System.Windows.Forms.Label labelChildren;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem daToolStripMenuItem;
        private System.Windows.Forms.BindingSource showsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn showsIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn genresIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource episodesBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn episodesIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn seasonDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn episodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn showsIdDataGridViewTextBoxColumn1;
    }
}

