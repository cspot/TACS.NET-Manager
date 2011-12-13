namespace TACS.NET_Manager.Documents
{
    partial class Events
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
            this.toolBar1 = new TD.SandBar.ToolBar();
            this.btnRefresh = new TD.SandBar.ButtonItem();
            this.btnClear = new TD.SandBar.ButtonItem();
            this.eventLogDs1 = new iCampaign.TACS.Data.EventLogDs();
            this.eventGrid = new System.Windows.Forms.DataGridView();
            this.logIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventSourceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.messageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventLogBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.eventLogDs1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLogBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBar1
            // 
            this.toolBar1.Guid = new System.Guid("2e5d43b7-62c5-4fae-aa58-af853a7ad826");
            this.toolBar1.Items.AddRange(new TD.SandBar.ToolbarItemBase[] {
            this.btnRefresh,
            this.btnClear});
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.Size = new System.Drawing.Size(550, 24);
            this.toolBar1.TabIndex = 0;
            this.toolBar1.Text = "toolBar1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::TACS.NET_Manager.Properties.Resources.refresh;
            this.btnRefresh.ToolTipText = "Refresh log";
            this.btnRefresh.Activate += new System.EventHandler(this.btnRefresh_Activate);
            // 
            // btnClear
            // 
            this.btnClear.Image = global::TACS.NET_Manager.Properties.Resources.table_delete;
            this.btnClear.ToolTipText = "Clear log";
            this.btnClear.Activate += new System.EventHandler(this.btnClear_Activate);
            // 
            // eventLogDs1
            // 
            this.eventLogDs1.DataSetName = "EventLogDs";
            this.eventLogDs1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // eventGrid
            // 
            this.eventGrid.AllowUserToAddRows = false;
            this.eventGrid.AutoGenerateColumns = false;
            this.eventGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.eventGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eventGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.logIdDataGridViewTextBoxColumn,
            this.eventTimeDataGridViewTextBoxColumn,
            this.eventSourceDataGridViewTextBoxColumn,
            this.eventTypeDataGridViewTextBoxColumn,
            this.messageDataGridViewTextBoxColumn});
            this.eventGrid.DataSource = this.eventLogBindingSource;
            this.eventGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventGrid.Location = new System.Drawing.Point(0, 24);
            this.eventGrid.Name = "eventGrid";
            this.eventGrid.ReadOnly = true;
            this.eventGrid.Size = new System.Drawing.Size(550, 376);
            this.eventGrid.TabIndex = 1;
            // 
            // logIdDataGridViewTextBoxColumn
            // 
            this.logIdDataGridViewTextBoxColumn.DataPropertyName = "LogId";
            this.logIdDataGridViewTextBoxColumn.HeaderText = "LogId";
            this.logIdDataGridViewTextBoxColumn.Name = "logIdDataGridViewTextBoxColumn";
            this.logIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // eventTimeDataGridViewTextBoxColumn
            // 
            this.eventTimeDataGridViewTextBoxColumn.DataPropertyName = "EventTime";
            this.eventTimeDataGridViewTextBoxColumn.HeaderText = "EventTime";
            this.eventTimeDataGridViewTextBoxColumn.Name = "eventTimeDataGridViewTextBoxColumn";
            this.eventTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // eventSourceDataGridViewTextBoxColumn
            // 
            this.eventSourceDataGridViewTextBoxColumn.DataPropertyName = "EventSource";
            this.eventSourceDataGridViewTextBoxColumn.HeaderText = "EventSource";
            this.eventSourceDataGridViewTextBoxColumn.Name = "eventSourceDataGridViewTextBoxColumn";
            this.eventSourceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // eventTypeDataGridViewTextBoxColumn
            // 
            this.eventTypeDataGridViewTextBoxColumn.DataPropertyName = "EventType";
            this.eventTypeDataGridViewTextBoxColumn.HeaderText = "EventType";
            this.eventTypeDataGridViewTextBoxColumn.Name = "eventTypeDataGridViewTextBoxColumn";
            this.eventTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // messageDataGridViewTextBoxColumn
            // 
            this.messageDataGridViewTextBoxColumn.DataPropertyName = "Message";
            this.messageDataGridViewTextBoxColumn.HeaderText = "Message";
            this.messageDataGridViewTextBoxColumn.Name = "messageDataGridViewTextBoxColumn";
            this.messageDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // eventLogBindingSource
            // 
            this.eventLogBindingSource.DataMember = "EventLog";
            this.eventLogBindingSource.DataSource = this.bindingSource1;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = this.eventLogDs1;
            this.bindingSource1.Position = 0;
            // 
            // Events
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.eventGrid);
            this.Controls.Add(this.toolBar1);
            this.Name = "Events";
            this.TabImage = global::TACS.NET_Manager.Properties.Resources.table;
            this.Text = "Event Log Viewer";
            this.Closing += new TD.SandDock.DockControlClosingEventHandler(this.Events_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.eventLogDs1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLogBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TD.SandBar.ToolBar toolBar1;
        private iCampaign.TACS.Data.EventLogDs eventLogDs1;
        private System.Windows.Forms.DataGridView eventGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn logIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventSourceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn messageDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource eventLogBindingSource;
        private System.Windows.Forms.BindingSource bindingSource1;
        private TD.SandBar.ButtonItem btnRefresh;
        private TD.SandBar.ButtonItem btnClear;
    }
}