namespace test_ModelDesigner
{
    partial class Form1
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node6");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Node7");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Node8");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Node1", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Node9");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Node10");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Node2", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Node3");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Node4");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Node5");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Root", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10});
            this.tvwModel = new System.Windows.Forms.TreeView();
            this.btnAddFolder = new System.Windows.Forms.Button();
            this.btnAddObject = new System.Windows.Forms.Button();
            this.btnAddVariable = new System.Windows.Forms.Button();
            this.btnAddProperty = new System.Windows.Forms.Button();
            this.txtSymbolicName = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtDesType = new System.Windows.Forms.TextBox();
            this.txtDesName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tvwModel
            // 
            this.tvwModel.Location = new System.Drawing.Point(31, 39);
            this.tvwModel.Name = "tvwModel";
            treeNode1.Name = "Node6";
            treeNode1.Text = "Node6";
            treeNode2.Name = "Node7";
            treeNode2.Text = "Node7";
            treeNode3.Name = "Node8";
            treeNode3.Text = "Node8";
            treeNode4.Name = "Node1";
            treeNode4.Text = "Node1";
            treeNode5.Name = "Node9";
            treeNode5.Text = "Node9";
            treeNode6.Name = "Node10";
            treeNode6.Text = "Node10";
            treeNode7.Name = "Node2";
            treeNode7.Text = "Node2";
            treeNode8.Name = "Node3";
            treeNode8.Text = "Node3";
            treeNode9.Name = "Node4";
            treeNode9.Text = "Node4";
            treeNode10.Name = "Node5";
            treeNode10.Text = "Node5";
            treeNode11.Name = "Node0";
            treeNode11.Text = "Root";
            this.tvwModel.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode11});
            this.tvwModel.Size = new System.Drawing.Size(198, 273);
            this.tvwModel.TabIndex = 0;
            this.tvwModel.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwModel_AfterSelect);
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.Location = new System.Drawing.Point(337, 113);
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Size = new System.Drawing.Size(119, 23);
            this.btnAddFolder.TabIndex = 1;
            this.btnAddFolder.Text = "Add Folder";
            this.btnAddFolder.UseVisualStyleBackColor = true;
            this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);
            // 
            // btnAddObject
            // 
            this.btnAddObject.Location = new System.Drawing.Point(334, 69);
            this.btnAddObject.Name = "btnAddObject";
            this.btnAddObject.Size = new System.Drawing.Size(119, 23);
            this.btnAddObject.TabIndex = 1;
            this.btnAddObject.Text = "Add Object";
            this.btnAddObject.UseVisualStyleBackColor = true;
            this.btnAddObject.Click += new System.EventHandler(this.btnAddObject_Click);
            // 
            // btnAddVariable
            // 
            this.btnAddVariable.Location = new System.Drawing.Point(334, 163);
            this.btnAddVariable.Name = "btnAddVariable";
            this.btnAddVariable.Size = new System.Drawing.Size(119, 23);
            this.btnAddVariable.TabIndex = 1;
            this.btnAddVariable.Text = "Add Variable";
            this.btnAddVariable.UseVisualStyleBackColor = true;
            this.btnAddVariable.Click += new System.EventHandler(this.btnAddVariable_Click);
            // 
            // btnAddProperty
            // 
            this.btnAddProperty.Location = new System.Drawing.Point(334, 207);
            this.btnAddProperty.Name = "btnAddProperty";
            this.btnAddProperty.Size = new System.Drawing.Size(119, 23);
            this.btnAddProperty.TabIndex = 1;
            this.btnAddProperty.Text = "Add Property";
            this.btnAddProperty.UseVisualStyleBackColor = true;
            this.btnAddProperty.Click += new System.EventHandler(this.btnAddProperty_Click);
            // 
            // txtSymbolicName
            // 
            this.txtSymbolicName.Location = new System.Drawing.Point(504, 69);
            this.txtSymbolicName.Name = "txtSymbolicName";
            this.txtSymbolicName.Size = new System.Drawing.Size(100, 20);
            this.txtSymbolicName.TabIndex = 2;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(334, 252);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(119, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnAddProperty_Click);
            // 
            // txtDesType
            // 
            this.txtDesType.Location = new System.Drawing.Point(356, 13);
            this.txtDesType.Name = "txtDesType";
            this.txtDesType.Size = new System.Drawing.Size(100, 20);
            this.txtDesType.TabIndex = 3;
            // 
            // txtDesName
            // 
            this.txtDesName.Location = new System.Drawing.Point(583, 13);
            this.txtDesName.Name = "txtDesName";
            this.txtDesName.Size = new System.Drawing.Size(100, 20);
            this.txtDesName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(312, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(501, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "symbolic name";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDesName);
            this.Controls.Add(this.txtDesType);
            this.Controls.Add(this.txtSymbolicName);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAddProperty);
            this.Controls.Add(this.btnAddVariable);
            this.Controls.Add(this.btnAddObject);
            this.Controls.Add(this.btnAddFolder);
            this.Controls.Add(this.tvwModel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvwModel;
        private System.Windows.Forms.Button btnAddFolder;
        private System.Windows.Forms.Button btnAddObject;
        private System.Windows.Forms.Button btnAddVariable;
        private System.Windows.Forms.Button btnAddProperty;
        private System.Windows.Forms.TextBox txtSymbolicName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtDesType;
        private System.Windows.Forms.TextBox txtDesName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

