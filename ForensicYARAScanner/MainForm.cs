using System;
using System.IO;
using System.Linq;
using System.Data;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using Microsoft.Data.ConnectionUI;
using Logging;

namespace ForensicYARAScanner
{
	public partial class MainForm : Form
	{
		private static TextBox OutputTextBox;
		private List<string> yaraMatchFiles = new List<string>();
		private List<YaraFilter> currentYaraFilters = new List<YaraFilter>();
		private static string AddYaraRuleErrorCaption = "Error adding YARA filter";

		public MainForm()
		{
			InitializeComponent();
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			BeginScanning();
		}

		private void textbox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				//if (ProcessingToggle.CurrentState == ToggleState.Ready)	{
				BeginScanning();
				//}
			}
		}

		private void BeginScanning()
		{
		}

		#region Misc Controls & Event Handlers

		public static void LogOutput(string message)
		{
			if (OutputTextBox != null)
			{
				if (OutputTextBox.InvokeRequired)
				{
					OutputTextBox.Invoke(new MethodInvoker(() => LogOutput(message)));
				}
				else
				{
					if (!string.IsNullOrWhiteSpace(message))
					{
						if (OutputTextBox.Lines.Length > 200)
						{
							string[] lines = OutputTextBox.Lines.Skip(OutputTextBox.Lines.Length - 50).ToArray();
							OutputTextBox.Lines = lines;
						}
						OutputTextBox.AppendText($"[{DateTime.Now.TimeOfDay.ToString()}] - " + message);
					}
					OutputTextBox.AppendText(Environment.NewLine);
				}
			}
		}

		private void btnBrowse_Click(object sender, EventArgs e)
		{
			string selectedFolder = DialogHelper.BrowseForFolderDialog(tbPath.Text);

			if (Directory.Exists(selectedFolder))
			{
				tbPath.Text = selectedFolder;
			}
		}

		private void tbOutput_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.Control)
			{
				if (e.KeyCode == Keys.A)
				{
					tbOutput.SelectAll();
				}
			}
		}

		private void linkGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(linkGitHub.Text);
		}

		#endregion

		private void radioButtonYara_HideFilterValue_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton control = (RadioButton)sender;
			if (control.Checked)
			{
				panelYaraFilterValue.Visible = false;
			}
		}

		private void radioButtonYara_ShowFilterValue_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton control = (RadioButton)sender;
			if (control.Checked)
			{
				panelYaraFilterValue.Visible = true;
			}
		}

		private void UpdateYaraFilterListbox()
		{
			listBoxYaraFilters.SuspendLayout();
			listBoxYaraFilters.Items.Clear();

			foreach (YaraFilter filter in currentYaraFilters)
			{
				listBoxYaraFilters.Items.Add(filter.ToString());
			}

			listBoxYaraFilters.ResumeLayout();
		}

		private void ClearAllYaraSettings()
		{
			tbYaraRuleMatchFiles.Text = "";
			tbYaraFilterValue.Text = "";

			currentYaraFilters.Clear();

			listBoxYaraFilters.SuspendLayout();
			listBoxYaraFilters.Items.Clear();
			listBoxYaraFilters.ResumeLayout();
		}


		#region Add/Remove Filters

		private void btnBrowseYaraMatch_Click(object sender, EventArgs e)
		{
			string[] selectedFiles = DialogHelper.BrowseForFilesDialog(DialogHelper.Filters.YaraFiles);

			if (selectedFiles.Any())
			{
				yaraMatchFiles = selectedFiles.ToList();
				tbYaraRuleMatchFiles.Text = string.Join(", ", yaraMatchFiles.Select(s => Path.GetFileName(s)));
			}
			else
			{
				yaraMatchFiles = new List<string>();
				tbYaraRuleMatchFiles.Text = "";
			}
		}

		private void btnAddYaraFilter_Click(object sender, EventArgs e)
		{
			if (!yaraMatchFiles.Any())
			{
				MessageBox.Show($"Must have at least one file selected under \"{labelYaraRulesToRun.Text}\" selected.\n\nFilter not added.", AddYaraRuleErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			YaraFilterType filterType = YaraFilterType.AlwaysRun;
			string filterValue = string.Empty;

			if (radioButtonYara_AlwaysRun.Checked)
			{
				filterType = YaraFilterType.AlwaysRun;
			}
			else if (radioButtonYara_IsPeFile.Checked)
			{
				filterType = YaraFilterType.IsPeFile;
			}
			else if (radioButtonYara_Extention.Checked)
			{
				filterType = YaraFilterType.FileExtension;
				if (string.IsNullOrWhiteSpace(tbYaraFilterValue.Text))
				{
					MessageBox.Show($"\"{labelYaraFilterValue.Text.Replace(":", "")}\" cannot be empty when \"{radioButtonYara_Extention.Text.Replace(":", "")}\" is selected.\n\nFilter not added.", AddYaraRuleErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				filterValue = tbYaraFilterValue.Text;

				if (filterValue.Any(c => char.IsWhiteSpace(c)))
				{
					MessageBox.Show("No whitespace is allowed in a file extension.\n\nFilter not added.", AddYaraRuleErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				if (!filterValue.Contains('.'))
				{
					if (filterValue.Contains('/'))
					{
						if (MessageBox.Show("You are attempting to add a file extension filter, yet the YARA filter value looks like a MIME type.\n\nDo you wish to add this as a MIME type filter instead?", AddYaraRuleErrorCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
						{
							return;
						}

						filterType = YaraFilterType.MimeType;
					}
					else
					{
						MessageBox.Show($"You are attempting to add a FILE EXTENSION filter, yet the YARA filter value does not contain the required character '.'.\n\nFilter not added.", AddYaraRuleErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				}
			}
			else if (radioButtonYara_MimeType.Checked)
			{
				filterType = YaraFilterType.MimeType;
				if (string.IsNullOrWhiteSpace(tbYaraFilterValue.Text))
				{
					MessageBox.Show($"\"{labelYaraFilterValue.Text.Replace(":", "")}\" cannot be empty when \"{radioButtonYara_MimeType.Text.Replace(":", "")}\" is selected.\n\nFilter not added.", AddYaraRuleErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				filterValue = tbYaraFilterValue.Text;

				if (filterValue.Any(c => char.IsWhiteSpace(c)))
				{
					MessageBox.Show("No whitespace is allowed in a MIME type.\n\nFilter not added.", AddYaraRuleErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				if (!filterValue.Contains('/'))
				{
					if (filterValue.Contains('.'))
					{
						if (MessageBox.Show("You are attempting to add a MIME type filter, yet the YARA filter value looks like a file extension.\n\nDo you wish to add this as a file extension filter type instead?", AddYaraRuleErrorCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
						{
							return;
						}

						filterType = YaraFilterType.FileExtension;
					}
					else
					{
						MessageBox.Show($"You are attempting to add a MIME type filter, yet the YARA filter value does not contain the required character '/'.\n\nFilter not added.", AddYaraRuleErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				}
			}
			else if (radioButtonYara_ElseNoMatch.Checked)
			{
				filterType = YaraFilterType.ElseNoMatch;
			}

			YaraFilter yaraFilter = new YaraFilter(filterType, filterValue, yaraMatchFiles);

			if (currentYaraFilters.Contains(yaraFilter))
			{
				MessageBox.Show("YARA filter already exists.\n\nDuplicate filter not added.", AddYaraRuleErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			currentYaraFilters.Add(yaraFilter);

			UpdateYaraFilterListbox();
		}

		private void btnRemoveYaraFilter_Click(object sender, EventArgs e)
		{
			listBoxYaraFilters_RemoveSelected();
		}

		private void listBoxYaraFilters_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
			{
				listBoxYaraFilters_RemoveSelected();
			}
		}

		private void listBoxYaraFilters_RemoveSelected()
		{
			var selectedIndices = listBoxYaraFilters.SelectedIndices.Cast<int>().ToList();

			List<YaraFilter> toRemove = new List<YaraFilter>();
			foreach (int index in selectedIndices)
			{
				toRemove.Add(currentYaraFilters[index]);
			}

			foreach (YaraFilter filter in toRemove)
			{
				currentYaraFilters.Remove(filter);
			}

			UpdateYaraFilterListbox();
		}

		#endregion

		#region Load/Save Yara Rules Filter Configuration

		private void btnYaraSave_Click(object sender, EventArgs e)
		{
			string selectedFile = DialogHelper.SaveFileDialog(DialogHelper.Filters.JsonFiles);

			if (!string.IsNullOrWhiteSpace(selectedFile))
			{
				JsonSerialization.Save.Object(currentYaraFilters, selectedFile);
			}
		}

		private void btnYaraLoad_Click(object sender, EventArgs e)
		{
			string selectedFile = DialogHelper.BrowseForFileDialog(DialogHelper.Filters.JsonFiles);

			if (!string.IsNullOrWhiteSpace(selectedFile) && File.Exists(selectedFile))
			{
				currentYaraFilters = JsonSerialization.Load.Generic<List<YaraFilter>>(selectedFile);
				UpdateYaraFilterListbox();
			}
		}

		#endregion

		#region Data persistence settings

		private void radioPersistenceCSV_CheckedChanged(object sender, EventArgs e)
		{
			labelTextBoxDescription.Text = "Path to CSV file:";
			btnPersistenceBrowse.Text = "Browse...";
			tbPersistenceParameter.Multiline = false;
		}

		private void radioPersistenceSqlite_CheckedChanged(object sender, EventArgs e)
		{
			labelTextBoxDescription.Text = "Path to DB file:";
			btnPersistenceBrowse.Text = "Browse...";
			tbPersistenceParameter.Multiline = false;
		}

		private void radioPersistenceSqlServer_CheckedChanged(object sender, EventArgs e)
		{
			labelTextBoxDescription.Text = "Connection string:";
			btnPersistenceBrowse.Text = "Connect...";
			tbPersistenceParameter.Multiline = true;
		}

		private void btnPersistenceBrowse_Click(object sender, EventArgs e)
		{
			if (radioPersistenceCSV.Checked || radioPersistenceSqlite.Checked)
			{
				string filter = radioPersistenceCSV.Checked ? DialogHelper.Filters.CsvFiles : DialogHelper.Filters.SqliteFiles;
				string initialDirectory = string.IsNullOrWhiteSpace(tbPersistenceParameter.Text) ? default(string) : tbPersistenceParameter.Text;

				string selectedFile = DialogHelper.SaveFileDialog(filter, initialDirectory);
				if (!string.IsNullOrWhiteSpace(selectedFile))
				{
					tbPersistenceParameter.Text = selectedFile;
				}
			}
			else if (radioPersistenceSqlServer.Checked)
			{
				DataConnectionDialog dataConnectionDialog = new DataConnectionDialog();
				DataSource.AddStandardDataSources(dataConnectionDialog);

				if (DataConnectionDialog.Show(dataConnectionDialog) == DialogResult.OK)
				{
					tbPersistenceParameter.Text = dataConnectionDialog.ConnectionString;
				}
			}
		}

		#endregion


	}
}
