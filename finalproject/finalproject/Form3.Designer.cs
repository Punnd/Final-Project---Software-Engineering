namespace finalproject
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goodsDeliveryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.incomingoutgoingStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outgoingStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bestsellingProductsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.revenueReportMonthlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panelMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.DodgerBlue;
            this.panelMenu.Controls.Add(this.menuStrip1);
            this.panelMenu.Location = new System.Drawing.Point(-13, 1);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(1216, 50);
            this.panelMenu.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountToolStripMenuItem,
            this.gToolStripMenuItem,
            this.goodsDeliveryToolStripMenuItem,
            this.reportToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1216, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // accountToolStripMenuItem
            // 
            this.accountToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue;
            this.accountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePasswordToolStripMenuItem,
            this.cancelToolStripMenuItem});
            this.accountToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            this.accountToolStripMenuItem.Size = new System.Drawing.Size(93, 29);
            this.accountToolStripMenuItem.Text = "Account";
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(234, 30);
            this.changePasswordToolStripMenuItem.Text = "Change password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(234, 30);
            this.cancelToolStripMenuItem.Text = "Log out";
            this.cancelToolStripMenuItem.Click += new System.EventHandler(this.cancelToolStripMenuItem_Click);
            // 
            // gToolStripMenuItem
            // 
            this.gToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gToolStripMenuItem.Name = "gToolStripMenuItem";
            this.gToolStripMenuItem.Size = new System.Drawing.Size(157, 29);
            this.gToolStripMenuItem.Text = "Goods Received";
            this.gToolStripMenuItem.Click += new System.EventHandler(this.gToolStripMenuItem_Click);
            // 
            // goodsDeliveryToolStripMenuItem
            // 
            this.goodsDeliveryToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.goodsDeliveryToolStripMenuItem.Name = "goodsDeliveryToolStripMenuItem";
            this.goodsDeliveryToolStripMenuItem.Size = new System.Drawing.Size(156, 29);
            this.goodsDeliveryToolStripMenuItem.Text = "Goods Delivery ";
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.incomingoutgoingStockToolStripMenuItem,
            this.outgoingStockToolStripMenuItem,
            this.bestsellingProductsToolStripMenuItem,
            this.revenueReportMonthlyToolStripMenuItem});
            this.reportToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(79, 29);
            this.reportToolStripMenuItem.Text = "Report";
            // 
            // incomingoutgoingStockToolStripMenuItem
            // 
            this.incomingoutgoingStockToolStripMenuItem.Name = "incomingoutgoingStockToolStripMenuItem";
            this.incomingoutgoingStockToolStripMenuItem.Size = new System.Drawing.Size(286, 30);
            this.incomingoutgoingStockToolStripMenuItem.Text = "Incoming stock";
            // 
            // outgoingStockToolStripMenuItem
            // 
            this.outgoingStockToolStripMenuItem.Name = "outgoingStockToolStripMenuItem";
            this.outgoingStockToolStripMenuItem.Size = new System.Drawing.Size(286, 30);
            this.outgoingStockToolStripMenuItem.Text = "Outgoing stock";
            // 
            // bestsellingProductsToolStripMenuItem
            // 
            this.bestsellingProductsToolStripMenuItem.Name = "bestsellingProductsToolStripMenuItem";
            this.bestsellingProductsToolStripMenuItem.Size = new System.Drawing.Size(286, 30);
            this.bestsellingProductsToolStripMenuItem.Text = "Best-selling products";
            // 
            // revenueReportMonthlyToolStripMenuItem
            // 
            this.revenueReportMonthlyToolStripMenuItem.Name = "revenueReportMonthlyToolStripMenuItem";
            this.revenueReportMonthlyToolStripMenuItem.Size = new System.Drawing.Size(286, 30);
            this.revenueReportMonthlyToolStripMenuItem.Text = "Revenue report monthly";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.ControlBox = false;
            this.Controls.Add(this.panelMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelMenu;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem accountToolStripMenuItem;
        private ToolStripMenuItem gToolStripMenuItem;
        private ToolStripMenuItem goodsDeliveryToolStripMenuItem;
        private ToolStripMenuItem reportToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem changePasswordToolStripMenuItem;
        private ToolStripMenuItem cancelToolStripMenuItem;
        private ToolStripMenuItem incomingoutgoingStockToolStripMenuItem;
        private ToolStripMenuItem outgoingStockToolStripMenuItem;
        private ToolStripMenuItem bestsellingProductsToolStripMenuItem;
        private ToolStripMenuItem revenueReportMonthlyToolStripMenuItem;
    }
}