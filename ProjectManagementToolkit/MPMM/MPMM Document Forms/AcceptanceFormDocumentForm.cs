using ProjectManagementToolkit.Classes;
using ProjectManagementToolkit.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using ProjectManagementToolkit.Properties;
using Xceed.Words.NET;
using Xceed.Document.NET;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class AcceptanceFormDocumentForm : Form
    {
        VersionControl<AcceptanceFormModel> versionControl;
        AcceptanceFormModel newAcceptanceFormModel;
        AcceptanceFormModel currentAcceptanceFormModel;

        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        AcceptanceFormModel AcceptanceModel = new AcceptanceFormModel();


        public AcceptanceFormDocumentForm()
        {
            InitializeComponent();
            LoadDocument();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveDocument();
        }
        public void SaveDocument()
        {
            newAcceptanceFormModel.AcceptanceFormFor = Acceptance_Form_Name_tbx.Text;

            newAcceptanceFormModel.ProjectName = Project_Name_tbx.Text;
            newAcceptanceFormModel.ProjectManager = Project_Manager_tbx.Text;

            newAcceptanceFormModel.AcceptanceId = Acceptance_ID_tbx.Text;
            newAcceptanceFormModel.RequestedBy = Requested_By_tbx.Text;
            newAcceptanceFormModel.DateRequired = Date_Requested_tbx.Text;
            newAcceptanceFormModel.Description = Description_tbx.Text;

            newAcceptanceFormModel.Criteria = Criteria_tbx.Text;
            newAcceptanceFormModel.Standards = Standards_tbx.Text;

            List<Acceptance> acceptances = new List<Acceptance>();
            int ResultsrowCount = ACCEPTANCE_RESULTS_dgv.RowCount;
            for (int i = 0; i < ResultsrowCount - 1; i++)
            {
                Acceptance acceptanceFormModel = new Acceptance();
                var Acceptance = ACCEPTANCE_RESULTS_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                var Method = ACCEPTANCE_RESULTS_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                var Reviewer = ACCEPTANCE_RESULTS_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                var Date = ACCEPTANCE_RESULTS_dgv.Rows[i].Cells[3].Value?.ToString() ?? "";
                var Result = ACCEPTANCE_RESULTS_dgv.Rows[i].Cells[4].Value?.ToString() ?? "";

                acceptanceFormModel.AcceptanceResults = Acceptance;
                acceptanceFormModel.Method = Method;
                acceptanceFormModel.Reviewer = Reviewer;
                acceptanceFormModel.Date = Date;
                acceptanceFormModel.Result = Result;
                acceptances.Add(acceptanceFormModel);
            }
            newAcceptanceFormModel.acceptances = acceptances;

            newAcceptanceFormModel.SupportingDocumentation = Supporting_Documentation_tbx.Text;


            List<VersionControl<AcceptanceFormModel>.DocumentModel> documentModels = versionControl.DocumentModels;

            //MessageBox.Show(JsonConvert.SerializeObject(newAcceptanceFormModel), "save", MessageBoxButtons.OK);

            if (!versionControl.isEqual(currentAcceptanceFormModel, newAcceptanceFormModel))
            {
                VersionControl<AcceptanceFormModel>.DocumentModel documentModel = new VersionControl<AcceptanceFormModel>.DocumentModel(newAcceptanceFormModel, DateTime.Now, VersionControl<AcceptanceFormModel>.generateID());

                documentModels.Add(documentModel);

                versionControl.DocumentModels = documentModels;

                string json = JsonConvert.SerializeObject(versionControl);
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "AcceptanceForm");
                MessageBox.Show("Acceptance form saved successfully", "save", MessageBoxButtons.OK);
            }
        }
        public void LoadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "AcceptanceForm");
            List<string[]> documentInfo = new List<string[]>();
            newAcceptanceFormModel = new AcceptanceFormModel();
            currentAcceptanceFormModel = new AcceptanceFormModel();

            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<AcceptanceFormModel>>(json);
                newAcceptanceFormModel = JsonConvert.DeserializeObject<AcceptanceFormModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentAcceptanceFormModel = JsonConvert.DeserializeObject<AcceptanceFormModel>(versionControl.getLatest(versionControl.DocumentModels));

                foreach (var row in currentAcceptanceFormModel.acceptances)
                {
                    ACCEPTANCE_RESULTS_dgv.Rows.Add(new string[] { row.AcceptanceResults, row.Method, row.Reviewer, row.Date, row.Result });
                }

                Acceptance_Form_Name_tbx.Text = currentAcceptanceFormModel.AcceptanceFormFor;

                Project_Name_tbx.Text = currentAcceptanceFormModel.ProjectName;
                Project_Manager_tbx.Text = currentAcceptanceFormModel.ProjectManager;

                Acceptance_ID_tbx.Text = currentAcceptanceFormModel.AcceptanceId;
                Requested_By_tbx.Text = currentAcceptanceFormModel.RequestedBy;
                Date_Requested_tbx.Text = currentAcceptanceFormModel.DateRequired;
                Description_tbx.Text = currentAcceptanceFormModel.Description;

                Criteria_tbx.Text = currentAcceptanceFormModel.Criteria;
                Standards_tbx.Text = currentAcceptanceFormModel.Standards;
                Supporting_Documentation_tbx.Text = currentAcceptanceFormModel.SupportingDocumentation;
            }
            else
            {
                versionControl = new VersionControl<AcceptanceFormModel>();
                versionControl.DocumentModels = new List<VersionControl<AcceptanceFormModel>.DocumentModel>();
                newAcceptanceFormModel = new AcceptanceFormModel();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExportToWord();
        }

        public void ExportToWord()
        {
            string path;
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                saveFileDialog.Filter = "Word 97-2003 Documents (*.doc)|*.doc|Word 2007 Documents (*.docx)|*.docx";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = saveFileDialog.FileName;
                    using (var document = DocX.Create(path))
                    {
                        for (int i = 0; i < 11; i++)
                        {
                            document.InsertParagraph("")
                                .Font("Arial")
                                .Bold(true)
                                .FontSize(22d).Alignment = Alignment.left;
                        }
                        document.InsertParagraph("Acceptance Form \nFor " + currentAcceptanceFormModel.ProjectName)
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(22d).Alignment = Alignment.left;
                        document.InsertSectionPageBreak();

                        document.InsertParagraph("Acceptance Form\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;

                        var projectDetailsTable = document.AddTable(3, 2);
                        projectDetailsTable.Rows[0].Cells[0].Paragraphs[0].Append("PROJECT DETAILS").Bold(true).Color(Color.White);
                        projectDetailsTable.Rows[0].Cells[1].Paragraphs[0].Append("").Bold(true).Color(Color.White);
                        projectDetailsTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        projectDetailsTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;

                        projectDetailsTable.Rows[1].Cells[0].Paragraphs[0].Append("Project Name:");
                        projectDetailsTable.Rows[1].Cells[1].Paragraphs[0].Append(currentAcceptanceFormModel.ProjectName);
                        projectDetailsTable.Rows[2].Cells[0].Paragraphs[0].Append("Project Manager:");
                        projectDetailsTable.Rows[2].Cells[1].Paragraphs[0].Append(currentAcceptanceFormModel.ProjectName);

                        projectDetailsTable.SetWidths(new float[] { 493, 1094 });
                        document.InsertTable(projectDetailsTable);

                        var acceptanceDetailsTable = document.AddTable(5, 2);
                        acceptanceDetailsTable.Rows[0].Cells[0].Paragraphs[0].Append("ACCEPTANCE DETAILS").Bold(true).Color(Color.White);
                        acceptanceDetailsTable.Rows[0].Cells[1].Paragraphs[0].Append("").Bold(true).Color(Color.White);
                        acceptanceDetailsTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        acceptanceDetailsTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;

                        acceptanceDetailsTable.Rows[1].Cells[0].Paragraphs[0].Append("Acceptance ID:");
                        acceptanceDetailsTable.Rows[1].Cells[1].Paragraphs[0].Append(currentAcceptanceFormModel.AcceptanceId);
                        acceptanceDetailsTable.Rows[2].Cells[0].Paragraphs[0].Append("Requested By:");
                        acceptanceDetailsTable.Rows[2].Cells[1].Paragraphs[0].Append(currentAcceptanceFormModel.RequestedBy);
                        acceptanceDetailsTable.Rows[3].Cells[0].Paragraphs[0].Append("Date Requested:");
                        acceptanceDetailsTable.Rows[3].Cells[1].Paragraphs[0].Append(currentAcceptanceFormModel.DateRequired);
                        acceptanceDetailsTable.Rows[4].Cells[0].Paragraphs[0].Append("Description:");
                        acceptanceDetailsTable.Rows[4].Cells[1].Paragraphs[0].Append(currentAcceptanceFormModel.Description);

                        acceptanceDetailsTable.SetWidths(new float[] {  493, 1094});
                        document.InsertTable(acceptanceDetailsTable);

                        var acceptanceCriteriaTable = document.AddTable(3, 2);
                        acceptanceCriteriaTable.Rows[0].Cells[0].Paragraphs[0].Append("ACCEPTANCE CRITERIA").Bold(true).Color(Color.White);
                        acceptanceCriteriaTable.Rows[0].Cells[1].Paragraphs[0].Append("").Bold(true).Color(Color.White);
                        acceptanceCriteriaTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        acceptanceCriteriaTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;

                        acceptanceCriteriaTable.Rows[1].Cells[0].Paragraphs[0].Append("Criteria:");
                        acceptanceCriteriaTable.Rows[1].Cells[1].Paragraphs[0].Append(currentAcceptanceFormModel.Criteria);
                        acceptanceCriteriaTable.Rows[2].Cells[0].Paragraphs[0].Append("Standards:");
                        acceptanceCriteriaTable.Rows[2].Cells[1].Paragraphs[0].Append(currentAcceptanceFormModel.Standards);

                        acceptanceCriteriaTable.SetWidths(new float[] { 493, 1094 });
                        document.InsertTable(acceptanceCriteriaTable);

                        document.InsertParagraph("\nACCEPTANCE RESULTS\n")
                           .Font("Arial")
                           .Bold(true)
                           .FontSize(14d).Alignment = Alignment.left;

                        var acceptanceResultsTable = document.AddTable(currentAcceptanceFormModel.acceptances.Count + 1, 5);
                        acceptanceResultsTable.Rows[0].Cells[0].Paragraphs[0].Append("Acceptance")
                            .Bold(true)
                            .Color(Color.White);
                        acceptanceResultsTable.Rows[0].Cells[1].Paragraphs[0].Append("Method")
                            .Bold(true)
                            .Color(Color.White);
                        acceptanceResultsTable.Rows[0].Cells[2].Paragraphs[0].Append("Reviewer")
                            .Bold(true)
                            .Color(Color.White);
                        acceptanceResultsTable.Rows[0].Cells[3].Paragraphs[0].Append("Date")
                            .Bold(true)
                            .Color(Color.White);
                        acceptanceResultsTable.Rows[0].Cells[4].Paragraphs[0].Append("Date")
                        .Bold(true)
                        .Color(Color.White);

                        acceptanceResultsTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        acceptanceResultsTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        acceptanceResultsTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        acceptanceResultsTable.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;
                        acceptanceResultsTable.Rows[0].Cells[4].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentAcceptanceFormModel.acceptances.Count + 1; i++)
                        {
                            acceptanceResultsTable.Rows[i].Cells[0].Paragraphs[0].Append(currentAcceptanceFormModel.acceptances[i - 1].AcceptanceResults);
                            acceptanceResultsTable.Rows[i].Cells[1].Paragraphs[0].Append(currentAcceptanceFormModel.acceptances[i - 1].Method);
                            acceptanceResultsTable.Rows[i].Cells[2].Paragraphs[0].Append(currentAcceptanceFormModel.acceptances[i - 1].Reviewer);
                            acceptanceResultsTable.Rows[i].Cells[3].Paragraphs[0].Append(currentAcceptanceFormModel.acceptances[i - 1].Date);
                            acceptanceResultsTable.Rows[i].Cells[4].Paragraphs[0].Append(currentAcceptanceFormModel.acceptances[i - 1].Result);

                        }

                        //acceptanceResultsTable.SetWidths(new float[] { 190, 303, 1094 });
                        document.InsertTable(acceptanceResultsTable);

                        var caustomerApproval = document.AddTable(2, 2);
                        caustomerApproval.Rows[0].Cells[0].Paragraphs[0].Append("\nCUSTOMER APPROVAL\n").Bold(true).Color(Color.White);
                        caustomerApproval.Rows[0].Cells[1].Paragraphs[0].Append("").Bold(true).Color(Color.White);
                        caustomerApproval.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        caustomerApproval.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;

                        caustomerApproval.Rows[1].Cells[0].Paragraphs[0].Append("Supporting Documentation:");
                        caustomerApproval.Rows[1].Cells[1].Paragraphs[0].Append(currentAcceptanceFormModel.SupportingDocumentation);

                        caustomerApproval.SetWidths(new float[] { 493, 1094 });
                        document.InsertTable(caustomerApproval);

                        try
                        {
                            document.Save();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("The selected File is open.", "Close File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }


                    }
                }
            }
        }
    }
}
