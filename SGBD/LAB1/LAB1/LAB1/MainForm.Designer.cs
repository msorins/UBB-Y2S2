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
            this.showsDataGrid = new System.Windows.Forms.DataGridView();
            this.showsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.episodesDataGrid = new System.Windows.Forms.DataGridView();
            this.episodesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.daToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.showsDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.showsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.episodesDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.episodesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // showsDataGrid
            // 
            this.showsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.showsDataGrid.Location = new System.Drawing.Point(12, 37);
            this.showsDataGrid.Name = "showsDataGrid";
            this.showsDataGrid.ReadOnly = true;
            this.showsDataGrid.Size = new System.Drawing.Size(644, 231);
            this.showsDataGrid.TabIndex = 0;
            this.showsDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.showsDataGrid_CellClick);
            this.showsDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.showsDataGrid_CellContentClick_1);
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
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // episodesDataGrid
            // 
            this.episodesDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.episodesDataGrid.Location = new System.Drawing.Point(12, 329);
            this.episodesDataGrid.Name = "episodesDataGrid";
            this.episodesDataGrid.Size = new System.Drawing.Size(644, 254);
            this.episodesDataGrid.TabIndex = 4;
            this.episodesDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.episodesDataGrid_CellClick);
            this.episodesDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            this.episodesDataGrid.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.episodesDataGrid_UserAddedRow);
            this.episodesDataGrid.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.episodesDataGrid_UserDeletedRow);
            this.episodesDataGrid.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.episodesDataGrid_UserDeletingRow);
            // 
            // episodesBindingSource
            // 
            this.episodesBindingSource.DataMember = "Episodes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "Shows";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 304);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 22);
            this.label2.TabIndex = 6;
            this.label2.Text = "Episodes";
            this.label2.Click += new System.EventHandler(this.label2_Click);
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
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.episodesDataGrid);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.showsDataGrid);
            this.Name = "MainForm";
            this.Text = "2";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.showsDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.showsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.episodesDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.episodesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView showsDataGrid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView episodesDataGrid;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
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

