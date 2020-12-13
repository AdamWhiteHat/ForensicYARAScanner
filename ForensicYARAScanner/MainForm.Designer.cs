
namespace ForensicYARAScanner
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
			this.btnBrowse = new System.Windows.Forms.Button();
			this.tbPath = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.labelTextBoxDescription = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnPersistenceBrowse = new System.Windows.Forms.Button();
			this.tbPersistenceParameter = new System.Windows.Forms.TextBox();
			this.radioPersistenceCSV = new System.Windows.Forms.RadioButton();
			this.radioPersistenceSqlite = new System.Windows.Forms.RadioButton();
			this.radioPersistenceSqlServer = new System.Windows.Forms.RadioButton();
			this.tbOutput = new System.Windows.Forms.TextBox();
			this.linkGitHub = new System.Windows.Forms.LinkLabel();
			this.btnSearch = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panelYara = new System.Windows.Forms.Panel();
			this.radioButtonYara_ElseNoMatch = new System.Windows.Forms.RadioButton();
			this.radioButtonYara_AlwaysRun = new System.Windows.Forms.RadioButton();
			this.radioButtonYara_IsPeFile = new System.Windows.Forms.RadioButton();
			this.radioButtonYara_Extention = new System.Windows.Forms.RadioButton();
			this.radioButtonYara_MimeType = new System.Windows.Forms.RadioButton();
			this.panelYaraMatchRules = new System.Windows.Forms.Panel();
			this.tbYaraRuleMatchFiles = new System.Windows.Forms.TextBox();
			this.btnBrowseYaraMatch = new System.Windows.Forms.Button();
			this.labelYaraRulesToRun = new System.Windows.Forms.Label();
			this.panelYaraFilterValue = new System.Windows.Forms.Panel();
			this.tbYaraFilterValue = new System.Windows.Forms.TextBox();
			this.labelYaraFilterValue = new System.Windows.Forms.Label();
			this.btnAddYaraFilter = new System.Windows.Forms.Button();
			this.btnRemoveYaraFilter = new System.Windows.Forms.Button();
			this.btnYaraSave = new System.Windows.Forms.Button();
			this.btnYaraLoad = new System.Windows.Forms.Button();
			this.panelListBox = new System.Windows.Forms.Panel();
			this.listBoxYaraFilters = new System.Windows.Forms.ListBox();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panelYara.SuspendLayout();
			this.panelYaraMatchRules.SuspendLayout();
			this.panelYaraFilterValue.SuspendLayout();
			this.panelListBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnBrowse
			// 
			this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBrowse.Location = new System.Drawing.Point(657, 10);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(95, 23);
			this.btnBrowse.TabIndex = 3;
			this.btnBrowse.Text = "Browse...";
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// tbPath
			// 
			this.tbPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbPath.Location = new System.Drawing.Point(12, 12);
			this.tbPath.Name = "tbPath";
			this.tbPath.Size = new System.Drawing.Size(639, 20);
			this.tbPath.TabIndex = 2;
			this.tbPath.Text = "C:\\";
			this.tbPath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textbox_KeyDown);
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.labelTextBoxDescription);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.btnPersistenceBrowse);
			this.panel1.Controls.Add(this.tbPersistenceParameter);
			this.panel1.Controls.Add(this.radioPersistenceCSV);
			this.panel1.Controls.Add(this.radioPersistenceSqlite);
			this.panel1.Controls.Add(this.radioPersistenceSqlServer);
			this.panel1.Location = new System.Drawing.Point(3, 196);
			this.panel1.Margin = new System.Windows.Forms.Padding(0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(757, 96);
			this.panel1.TabIndex = 11;
			// 
			// labelTextBoxDescription
			// 
			this.labelTextBoxDescription.AutoSize = true;
			this.labelTextBoxDescription.Location = new System.Drawing.Point(94, 11);
			this.labelTextBoxDescription.Name = "labelTextBoxDescription";
			this.labelTextBoxDescription.Size = new System.Drawing.Size(94, 13);
			this.labelTextBoxDescription.TabIndex = 6;
			this.labelTextBoxDescription.Text = "Connection String:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 7);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(82, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Save results as:";
			// 
			// btnPersistenceBrowse
			// 
			this.btnPersistenceBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPersistenceBrowse.Location = new System.Drawing.Point(659, 25);
			this.btnPersistenceBrowse.Name = "btnPersistenceBrowse";
			this.btnPersistenceBrowse.Size = new System.Drawing.Size(95, 23);
			this.btnPersistenceBrowse.TabIndex = 4;
			this.btnPersistenceBrowse.Text = "Browse...";
			this.btnPersistenceBrowse.UseVisualStyleBackColor = true;
			this.btnPersistenceBrowse.Click += new System.EventHandler(this.btnPersistenceBrowse_Click);
			// 
			// tbPersistenceParameter
			// 
			this.tbPersistenceParameter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbPersistenceParameter.Location = new System.Drawing.Point(111, 27);
			this.tbPersistenceParameter.Multiline = true;
			this.tbPersistenceParameter.Name = "tbPersistenceParameter";
			this.tbPersistenceParameter.Size = new System.Drawing.Size(543, 38);
			this.tbPersistenceParameter.TabIndex = 3;
			// 
			// radioPersistenceCSV
			// 
			this.radioPersistenceCSV.AutoSize = true;
			this.radioPersistenceCSV.Location = new System.Drawing.Point(15, 26);
			this.radioPersistenceCSV.Name = "radioPersistenceCSV";
			this.radioPersistenceCSV.Size = new System.Drawing.Size(65, 17);
			this.radioPersistenceCSV.TabIndex = 0;
			this.radioPersistenceCSV.Text = "CSV File";
			this.radioPersistenceCSV.UseVisualStyleBackColor = true;
			this.radioPersistenceCSV.CheckedChanged += new System.EventHandler(this.radioPersistenceCSV_CheckedChanged);
			// 
			// radioPersistenceSqlite
			// 
			this.radioPersistenceSqlite.AutoSize = true;
			this.radioPersistenceSqlite.Location = new System.Drawing.Point(15, 48);
			this.radioPersistenceSqlite.Name = "radioPersistenceSqlite";
			this.radioPersistenceSqlite.Size = new System.Drawing.Size(75, 17);
			this.radioPersistenceSqlite.TabIndex = 1;
			this.radioPersistenceSqlite.Text = "SQLite DB";
			this.radioPersistenceSqlite.UseVisualStyleBackColor = true;
			this.radioPersistenceSqlite.CheckedChanged += new System.EventHandler(this.radioPersistenceSqlite_CheckedChanged);
			// 
			// radioPersistenceSqlServer
			// 
			this.radioPersistenceSqlServer.AutoSize = true;
			this.radioPersistenceSqlServer.Location = new System.Drawing.Point(15, 70);
			this.radioPersistenceSqlServer.Name = "radioPersistenceSqlServer";
			this.radioPersistenceSqlServer.Size = new System.Drawing.Size(98, 17);
			this.radioPersistenceSqlServer.TabIndex = 2;
			this.radioPersistenceSqlServer.Text = "SQL Server DB";
			this.radioPersistenceSqlServer.UseVisualStyleBackColor = true;
			this.radioPersistenceSqlServer.CheckedChanged += new System.EventHandler(this.radioPersistenceSqlServer_CheckedChanged);
			// 
			// tbOutput
			// 
			this.tbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOutput.Location = new System.Drawing.Point(1, 324);
			this.tbOutput.Margin = new System.Windows.Forms.Padding(1);
			this.tbOutput.Multiline = true;
			this.tbOutput.Name = "tbOutput";
			this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbOutput.Size = new System.Drawing.Size(762, 87);
			this.tbOutput.TabIndex = 12;
			this.tbOutput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbOutput_KeyUp);
			// 
			// linkGitHub
			// 
			this.linkGitHub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.linkGitHub.AutoSize = true;
			this.linkGitHub.Location = new System.Drawing.Point(474, 308);
			this.linkGitHub.Name = "linkGitHub";
			this.linkGitHub.Size = new System.Drawing.Size(286, 13);
			this.linkGitHub.TabIndex = 14;
			this.linkGitHub.TabStop = true;
			this.linkGitHub.Text = "https://github.com/AdamWhiteHat/ForensicYARAScanner";
			this.linkGitHub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkGitHub_LinkClicked);
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(3, 294);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(198, 27);
			this.btnSearch.TabIndex = 13;
			this.btnSearch.Text = "Search";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.panelYara);
			this.panel2.Controls.Add(this.btnAddYaraFilter);
			this.panel2.Controls.Add(this.btnRemoveYaraFilter);
			this.panel2.Controls.Add(this.btnYaraSave);
			this.panel2.Controls.Add(this.btnYaraLoad);
			this.panel2.Controls.Add(this.panelListBox);
			this.panel2.Location = new System.Drawing.Point(3, 39);
			this.panel2.Margin = new System.Windows.Forms.Padding(0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(757, 154);
			this.panel2.TabIndex = 15;
			// 
			// panelYara
			// 
			this.panelYara.Controls.Add(this.radioButtonYara_ElseNoMatch);
			this.panelYara.Controls.Add(this.radioButtonYara_AlwaysRun);
			this.panelYara.Controls.Add(this.radioButtonYara_IsPeFile);
			this.panelYara.Controls.Add(this.radioButtonYara_Extention);
			this.panelYara.Controls.Add(this.radioButtonYara_MimeType);
			this.panelYara.Controls.Add(this.panelYaraMatchRules);
			this.panelYara.Controls.Add(this.panelYaraFilterValue);
			this.panelYara.Location = new System.Drawing.Point(0, 2);
			this.panelYara.Margin = new System.Windows.Forms.Padding(0);
			this.panelYara.Name = "panelYara";
			this.panelYara.Size = new System.Drawing.Size(513, 128);
			this.panelYara.TabIndex = 11;
			this.panelYara.TabStop = true;
			// 
			// radioButtonYara_ElseNoMatch
			// 
			this.radioButtonYara_ElseNoMatch.AutoSize = true;
			this.radioButtonYara_ElseNoMatch.Location = new System.Drawing.Point(4, 98);
			this.radioButtonYara_ElseNoMatch.Name = "radioButtonYara_ElseNoMatch";
			this.radioButtonYara_ElseNoMatch.Size = new System.Drawing.Size(118, 17);
			this.radioButtonYara_ElseNoMatch.TabIndex = 4;
			this.radioButtonYara_ElseNoMatch.TabStop = true;
			this.radioButtonYara_ElseNoMatch.Text = "ELSE (No matches)";
			this.radioButtonYara_ElseNoMatch.UseVisualStyleBackColor = true;
			this.radioButtonYara_ElseNoMatch.CheckedChanged += new System.EventHandler(this.radioButtonYara_HideFilterValue_CheckedChanged);
			// 
			// radioButtonYara_AlwaysRun
			// 
			this.radioButtonYara_AlwaysRun.AutoSize = true;
			this.radioButtonYara_AlwaysRun.Location = new System.Drawing.Point(4, 76);
			this.radioButtonYara_AlwaysRun.Name = "radioButtonYara_AlwaysRun";
			this.radioButtonYara_AlwaysRun.Size = new System.Drawing.Size(115, 17);
			this.radioButtonYara_AlwaysRun.TabIndex = 3;
			this.radioButtonYara_AlwaysRun.TabStop = true;
			this.radioButtonYara_AlwaysRun.Text = "IF true (Always run)";
			this.radioButtonYara_AlwaysRun.UseVisualStyleBackColor = true;
			this.radioButtonYara_AlwaysRun.CheckedChanged += new System.EventHandler(this.radioButtonYara_HideFilterValue_CheckedChanged);
			// 
			// radioButtonYara_IsPeFile
			// 
			this.radioButtonYara_IsPeFile.AutoSize = true;
			this.radioButtonYara_IsPeFile.Location = new System.Drawing.Point(4, 54);
			this.radioButtonYara_IsPeFile.Name = "radioButtonYara_IsPeFile";
			this.radioButtonYara_IsPeFile.Size = new System.Drawing.Size(153, 17);
			this.radioButtonYara_IsPeFile.TabIndex = 2;
			this.radioButtonYara_IsPeFile.TabStop = true;
			this.radioButtonYara_IsPeFile.Text = "IF file is an executable (PE)";
			this.radioButtonYara_IsPeFile.UseVisualStyleBackColor = true;
			this.radioButtonYara_IsPeFile.CheckedChanged += new System.EventHandler(this.radioButtonYara_HideFilterValue_CheckedChanged);
			// 
			// radioButtonYara_Extention
			// 
			this.radioButtonYara_Extention.AutoSize = true;
			this.radioButtonYara_Extention.Location = new System.Drawing.Point(4, 32);
			this.radioButtonYara_Extention.Name = "radioButtonYara_Extention";
			this.radioButtonYara_Extention.Size = new System.Drawing.Size(109, 17);
			this.radioButtonYara_Extention.TabIndex = 1;
			this.radioButtonYara_Extention.TabStop = true;
			this.radioButtonYara_Extention.Text = "IF file extention is:";
			this.radioButtonYara_Extention.UseVisualStyleBackColor = true;
			this.radioButtonYara_Extention.CheckedChanged += new System.EventHandler(this.radioButtonYara_ShowFilterValue_CheckedChanged);
			// 
			// radioButtonYara_MimeType
			// 
			this.radioButtonYara_MimeType.AutoSize = true;
			this.radioButtonYara_MimeType.Location = new System.Drawing.Point(4, 10);
			this.radioButtonYara_MimeType.Name = "radioButtonYara_MimeType";
			this.radioButtonYara_MimeType.Size = new System.Drawing.Size(101, 17);
			this.radioButtonYara_MimeType.TabIndex = 0;
			this.radioButtonYara_MimeType.TabStop = true;
			this.radioButtonYara_MimeType.Text = "IF MIME type is:";
			this.radioButtonYara_MimeType.UseVisualStyleBackColor = true;
			this.radioButtonYara_MimeType.CheckedChanged += new System.EventHandler(this.radioButtonYara_ShowFilterValue_CheckedChanged);
			// 
			// panelYaraMatchRules
			// 
			this.panelYaraMatchRules.Controls.Add(this.tbYaraRuleMatchFiles);
			this.panelYaraMatchRules.Controls.Add(this.btnBrowseYaraMatch);
			this.panelYaraMatchRules.Controls.Add(this.labelYaraRulesToRun);
			this.panelYaraMatchRules.Location = new System.Drawing.Point(124, 75);
			this.panelYaraMatchRules.Name = "panelYaraMatchRules";
			this.panelYaraMatchRules.Size = new System.Drawing.Size(384, 45);
			this.panelYaraMatchRules.TabIndex = 6;
			// 
			// tbYaraRuleMatchFiles
			// 
			this.tbYaraRuleMatchFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbYaraRuleMatchFiles.Location = new System.Drawing.Point(48, 22);
			this.tbYaraRuleMatchFiles.Name = "tbYaraRuleMatchFiles";
			this.tbYaraRuleMatchFiles.Size = new System.Drawing.Size(253, 20);
			this.tbYaraRuleMatchFiles.TabIndex = 0;
			// 
			// btnBrowseYaraMatch
			// 
			this.btnBrowseYaraMatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBrowseYaraMatch.Location = new System.Drawing.Point(306, 20);
			this.btnBrowseYaraMatch.Name = "btnBrowseYaraMatch";
			this.btnBrowseYaraMatch.Size = new System.Drawing.Size(74, 23);
			this.btnBrowseYaraMatch.TabIndex = 1;
			this.btnBrowseYaraMatch.Text = "Browse...";
			this.btnBrowseYaraMatch.UseVisualStyleBackColor = true;
			this.btnBrowseYaraMatch.Click += new System.EventHandler(this.btnBrowseYaraMatch_Click);
			// 
			// labelYaraRulesToRun
			// 
			this.labelYaraRulesToRun.AutoSize = true;
			this.labelYaraRulesToRun.Location = new System.Drawing.Point(3, 5);
			this.labelYaraRulesToRun.Margin = new System.Windows.Forms.Padding(3);
			this.labelYaraRulesToRun.Name = "labelYaraRulesToRun";
			this.labelYaraRulesToRun.Size = new System.Drawing.Size(94, 13);
			this.labelYaraRulesToRun.TabIndex = 23;
			this.labelYaraRulesToRun.Text = "YARA rules to run:";
			// 
			// panelYaraFilterValue
			// 
			this.panelYaraFilterValue.Controls.Add(this.tbYaraFilterValue);
			this.panelYaraFilterValue.Controls.Add(this.labelYaraFilterValue);
			this.panelYaraFilterValue.Location = new System.Drawing.Point(124, 5);
			this.panelYaraFilterValue.Name = "panelYaraFilterValue";
			this.panelYaraFilterValue.Size = new System.Drawing.Size(384, 44);
			this.panelYaraFilterValue.TabIndex = 5;
			// 
			// tbYaraFilterValue
			// 
			this.tbYaraFilterValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbYaraFilterValue.Location = new System.Drawing.Point(48, 20);
			this.tbYaraFilterValue.Name = "tbYaraFilterValue";
			this.tbYaraFilterValue.Size = new System.Drawing.Size(253, 20);
			this.tbYaraFilterValue.TabIndex = 0;
			// 
			// labelYaraFilterValue
			// 
			this.labelYaraFilterValue.AutoSize = true;
			this.labelYaraFilterValue.Location = new System.Drawing.Point(3, 5);
			this.labelYaraFilterValue.Margin = new System.Windows.Forms.Padding(3);
			this.labelYaraFilterValue.Name = "labelYaraFilterValue";
			this.labelYaraFilterValue.Size = new System.Drawing.Size(90, 13);
			this.labelYaraFilterValue.TabIndex = 18;
			this.labelYaraFilterValue.Text = "YARA filter value:";
			// 
			// btnAddYaraFilter
			// 
			this.btnAddYaraFilter.Location = new System.Drawing.Point(519, 28);
			this.btnAddYaraFilter.Name = "btnAddYaraFilter";
			this.btnAddYaraFilter.Size = new System.Drawing.Size(87, 23);
			this.btnAddYaraFilter.TabIndex = 12;
			this.btnAddYaraFilter.Text = "Add ->";
			this.btnAddYaraFilter.UseVisualStyleBackColor = true;
			this.btnAddYaraFilter.Click += new System.EventHandler(this.btnAddYaraFilter_Click);
			// 
			// btnRemoveYaraFilter
			// 
			this.btnRemoveYaraFilter.Location = new System.Drawing.Point(519, 54);
			this.btnRemoveYaraFilter.Name = "btnRemoveYaraFilter";
			this.btnRemoveYaraFilter.Size = new System.Drawing.Size(87, 23);
			this.btnRemoveYaraFilter.TabIndex = 13;
			this.btnRemoveYaraFilter.Text = "<- Remove";
			this.btnRemoveYaraFilter.UseVisualStyleBackColor = true;
			this.btnRemoveYaraFilter.Click += new System.EventHandler(this.btnRemoveYaraFilter_Click);
			// 
			// btnYaraSave
			// 
			this.btnYaraSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnYaraSave.Location = new System.Drawing.Point(621, 104);
			this.btnYaraSave.Name = "btnYaraSave";
			this.btnYaraSave.Size = new System.Drawing.Size(122, 22);
			this.btnYaraSave.TabIndex = 15;
			this.btnYaraSave.Text = "Export filters";
			this.btnYaraSave.UseVisualStyleBackColor = true;
			this.btnYaraSave.Click += new System.EventHandler(this.btnYaraSave_Click);
			// 
			// btnYaraLoad
			// 
			this.btnYaraLoad.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnYaraLoad.Location = new System.Drawing.Point(621, 125);
			this.btnYaraLoad.Name = "btnYaraLoad";
			this.btnYaraLoad.Size = new System.Drawing.Size(122, 22);
			this.btnYaraLoad.TabIndex = 16;
			this.btnYaraLoad.Text = "Load filter";
			this.btnYaraLoad.UseVisualStyleBackColor = true;
			this.btnYaraLoad.Click += new System.EventHandler(this.btnYaraLoad_Click);
			// 
			// panelListBox
			// 
			this.panelListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelListBox.Controls.Add(this.listBoxYaraFilters);
			this.panelListBox.Location = new System.Drawing.Point(612, 2);
			this.panelListBox.Name = "panelListBox";
			this.panelListBox.Size = new System.Drawing.Size(140, 101);
			this.panelListBox.TabIndex = 14;
			// 
			// listBoxYaraFilters
			// 
			this.listBoxYaraFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBoxYaraFilters.FormattingEnabled = true;
			this.listBoxYaraFilters.Location = new System.Drawing.Point(2, 2);
			this.listBoxYaraFilters.Name = "listBoxYaraFilters";
			this.listBoxYaraFilters.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.listBoxYaraFilters.Size = new System.Drawing.Size(134, 95);
			this.listBoxYaraFilters.TabIndex = 0;
			this.listBoxYaraFilters.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listBoxYaraFilters_KeyUp);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(764, 412);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.tbOutput);
			this.Controls.Add(this.linkGitHub);
			this.Controls.Add(this.btnSearch);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.btnBrowse);
			this.Controls.Add(this.tbPath);
			this.MinimumSize = new System.Drawing.Size(780, 450);
			this.Name = "MainForm";
			this.Text = "Forensic YARA Scanner";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panelYara.ResumeLayout(false);
			this.panelYara.PerformLayout();
			this.panelYaraMatchRules.ResumeLayout(false);
			this.panelYaraMatchRules.PerformLayout();
			this.panelYaraFilterValue.ResumeLayout(false);
			this.panelYaraFilterValue.PerformLayout();
			this.panelListBox.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.TextBox tbPath;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label labelTextBoxDescription;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnPersistenceBrowse;
		private System.Windows.Forms.TextBox tbPersistenceParameter;
		private System.Windows.Forms.RadioButton radioPersistenceCSV;
		private System.Windows.Forms.RadioButton radioPersistenceSqlite;
		private System.Windows.Forms.RadioButton radioPersistenceSqlServer;
		private System.Windows.Forms.TextBox tbOutput;
		private System.Windows.Forms.LinkLabel linkGitHub;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panelYara;
		private System.Windows.Forms.RadioButton radioButtonYara_ElseNoMatch;
		private System.Windows.Forms.RadioButton radioButtonYara_AlwaysRun;
		private System.Windows.Forms.RadioButton radioButtonYara_IsPeFile;
		private System.Windows.Forms.RadioButton radioButtonYara_Extention;
		private System.Windows.Forms.RadioButton radioButtonYara_MimeType;
		private System.Windows.Forms.Panel panelYaraMatchRules;
		private System.Windows.Forms.TextBox tbYaraRuleMatchFiles;
		private System.Windows.Forms.Button btnBrowseYaraMatch;
		private System.Windows.Forms.Label labelYaraRulesToRun;
		private System.Windows.Forms.Panel panelYaraFilterValue;
		private System.Windows.Forms.TextBox tbYaraFilterValue;
		private System.Windows.Forms.Label labelYaraFilterValue;
		private System.Windows.Forms.Button btnAddYaraFilter;
		private System.Windows.Forms.Button btnRemoveYaraFilter;
		private System.Windows.Forms.Button btnYaraSave;
		private System.Windows.Forms.Button btnYaraLoad;
		private System.Windows.Forms.Panel panelListBox;
		private System.Windows.Forms.ListBox listBoxYaraFilters;
	}
}

