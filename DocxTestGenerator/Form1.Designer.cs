namespace DocxTestGenerator
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.documentTree = new System.Windows.Forms.TreeView();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.copyContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblXml = new System.Windows.Forms.Label();
            this.lblPath = new System.Windows.Forms.Label();
            this.copyContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // documentTree
            // 
            this.documentTree.Location = new System.Drawing.Point(12, 66);
            this.documentTree.Name = "documentTree";
            this.documentTree.Size = new System.Drawing.Size(302, 496);
            this.documentTree.TabIndex = 0;
            this.documentTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.documentTree_AfterSelect);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(12, 23);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 1;
            this.btnOpenFile.Text = "Open File";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // copyContextMenu
            // 
            this.copyContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem});
            this.copyContextMenu.Name = "copyContextMenu";
            this.copyContextMenu.Size = new System.Drawing.Size(103, 26);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // lblXml
            // 
            this.lblXml.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblXml.Location = new System.Drawing.Point(453, 106);
            this.lblXml.Name = "lblXml";
            this.lblXml.Size = new System.Drawing.Size(428, 446);
            this.lblXml.TabIndex = 3;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(453, 66);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(0, 15);
            this.lblPath.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 727);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.lblXml);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.documentTree);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.copyContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TreeView documentTree;
        private Button btnOpenFile;
        private ContextMenuStrip copyContextMenu;
        private ToolStripMenuItem copyToolStripMenuItem;
        private Label lblXml;
        private Label lblPath;
    }
}