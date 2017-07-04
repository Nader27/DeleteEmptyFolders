namespace Delete_Empty_Folders_No_Background_worker
{
    partial class Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label = new System.Windows.Forms.Label();
            this.path = new System.Windows.Forms.TextBox();
            this.browse_button = new System.Windows.Forms.Button();
            this.treeView = new System.Windows.Forms.TreeView();
            this.search_button = new System.Windows.Forms.Button();
            this.clean_button = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.Select_all_checkBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialog.SelectedPath = "C:\\Users\\nader";
            this.folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(9, 9);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(83, 16);
            this.label.TabIndex = 0;
            this.label.Text = "Folder Path :";
            // 
            // path
            // 
            this.path.Location = new System.Drawing.Point(12, 41);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(397, 20);
            this.path.TabIndex = 1;
            this.path.Text = "C:\\Users\\nader";
            // 
            // browse_button
            // 
            this.browse_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browse_button.Location = new System.Drawing.Point(415, 38);
            this.browse_button.Name = "browse_button";
            this.browse_button.Size = new System.Drawing.Size(75, 23);
            this.browse_button.TabIndex = 2;
            this.browse_button.Text = "Browse";
            this.browse_button.UseVisualStyleBackColor = true;
            this.browse_button.Click += new System.EventHandler(this.browse_button_Click);
            // 
            // treeView
            // 
            this.treeView.CheckBoxes = true;
            this.treeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView.Location = new System.Drawing.Point(12, 91);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(478, 158);
            this.treeView.TabIndex = 3;
            // 
            // search_button
            // 
            this.search_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_button.Location = new System.Drawing.Point(112, 255);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(75, 23);
            this.search_button.TabIndex = 5;
            this.search_button.Text = "Search";
            this.search_button.UseVisualStyleBackColor = true;
            this.search_button.Click += new System.EventHandler(this.search_button_Click);
            // 
            // clean_button
            // 
            this.clean_button.Enabled = false;
            this.clean_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clean_button.Location = new System.Drawing.Point(334, 255);
            this.clean_button.Name = "clean_button";
            this.clean_button.Size = new System.Drawing.Size(75, 23);
            this.clean_button.TabIndex = 6;
            this.clean_button.Text = "Clean";
            this.clean_button.UseVisualStyleBackColor = true;
            this.clean_button.Click += new System.EventHandler(this.clean_button_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 284);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(478, 23);
            this.progressBar.TabIndex = 7;
            // 
            // Select_all_checkBox
            // 
            this.Select_all_checkBox.AutoSize = true;
            this.Select_all_checkBox.Enabled = false;
            this.Select_all_checkBox.Location = new System.Drawing.Point(12, 68);
            this.Select_all_checkBox.Name = "Select_all_checkBox";
            this.Select_all_checkBox.Size = new System.Drawing.Size(70, 17);
            this.Select_all_checkBox.TabIndex = 8;
            this.Select_all_checkBox.Text = "Select All";
            this.Select_all_checkBox.UseVisualStyleBackColor = true;
            this.Select_all_checkBox.CheckStateChanged += new System.EventHandler(this.CheckBox_CheckStateChanged);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 319);
            this.Controls.Add(this.Select_all_checkBox);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.clean_button);
            this.Controls.Add(this.search_button);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.browse_button);
            this.Controls.Add(this.path);
            this.Controls.Add(this.label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form";
            this.Text = "Delete Empty Folders";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox path;
        private System.Windows.Forms.Button browse_button;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.Button clean_button;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.CheckBox Select_all_checkBox;
    }
}

