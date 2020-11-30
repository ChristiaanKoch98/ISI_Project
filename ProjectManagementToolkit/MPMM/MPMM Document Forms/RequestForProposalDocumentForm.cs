using System;
using ProjectManagementToolkit.MPMM.MPMM_Document_Models;
using ProjectManagementToolkit.Properties;
using ProjectManagementToolkit.Utility;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class RequestForProposalDocumentForm : Form
    {
        VersionControl<RequestForProposalModel> versionControl;
        RequestForProposalModel newRequestForProposalModel;
        RequestForProposalModel currentRequestForProposalModel;
        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        ProjectModel projectModel = new ProjectModel();

        public RequestForProposalDocumentForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveDocument();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            exportToWord();
        }

        public void saveDocument()
        {
            newRequestForProposalModel.projectName = projectModel.ProjectName;
            
            newRequestForProposalModel.documentInformations = new List<RequestForProposalModel.DocumentInformation>();
            foreach (DataGridViewRow row in dataGridViewDocumentInformation.Rows)
            {
                if(row.Index != dataGridViewDocumentInformation.Rows.Count)
                {
                    RequestForProposalModel.DocumentInformation newInfo = new RequestForProposalModel.DocumentInformation();
                    newInfo.type = row.Cells[0].Value?.ToString() ?? "";
                    newInfo.information = row.Cells[1].Value?.ToString() ?? "";
                    newRequestForProposalModel.documentInformations.Add(newInfo);
                }
            }

            newRequestForProposalModel.documentHistories = new List<RequestForProposalModel.DocumentHistory>();
            foreach (DataGridViewRow row in dataGridViewDocumentHistory.Rows)
            {
                if(row.Index != dataGridViewDocumentHistory.Rows.Count)
                {
                    RequestForProposalModel.DocumentHistory newHistory = new RequestForProposalModel.DocumentHistory();
                    newHistory.version = row.Cells[0].Value?.ToString() ?? "";
                    newHistory.issueDate = row.Cells[1].Value?.ToString() ?? "";
                    newHistory.changes = row.Cells[2].Value?.ToString() ?? "";
                    newRequestForProposalModel.documentHistories.Add(newHistory);
                }
            }

            newRequestForProposalModel.documentApprovals = new List<RequestForProposalModel.DocumentApproval>();
            foreach (DataGridViewRow row in dataGridViewDocumentApprovals.Rows)
            {
                if(row.Index != dataGridViewDocumentApprovals.Rows.Count)
                {
                    RequestForProposalModel.DocumentApproval newApproval = new RequestForProposalModel.DocumentApproval();
                    newApproval.role = row.Cells[0].Value?.ToString() ?? "";
                    newApproval.name = row.Cells[1].Value?.ToString() ?? "";
                    newApproval.signature = row.Cells[2].Value?.ToString() ?? "";
                    newApproval.approvalDate = row.Cells[3].Value?.ToString() ?? "";
                    newRequestForProposalModel.documentApprovals.Add(newApproval);
                }
            }

            newRequestForProposalModel.introductionDescription = txtChangeProcess.Text;
            newRequestForProposalModel.introductionOverview = txtOverview.Text;
            newRequestForProposalModel.introductionPurpose = txtPurpose.Text;
            newRequestForProposalModel.introductionAcknowledgement = txtAcknowledgement.Text;
            newRequestForProposalModel.introductionRecipients = txtRecipients.Text;
            newRequestForProposalModel.introductionProcess = txtProcess.Text;
            newRequestForProposalModel.introductionRules = txtRules.Text;
            newRequestForProposalModel.introductionQuestions = txtQuestions.Text;

            newRequestForProposalModel.companyDescription = txtCompany.Text;
            newRequestForProposalModel.companyVisionObjectivesSizeLocation = txtVisionObjectivesSizeLocation.Text;
            newRequestForProposalModel.companyTypeAndNumberOfCustomers = txtTypeAndNumberOfCustomers.Text;
            newRequestForProposalModel.companyMarketSegment = txtMarketSegment.Text;
            newRequestForProposalModel.companyKnowledgeOfIndustryAndExpertise = txtKnowledgeOfIndustryAndExpertise.Text;

            newRequestForProposalModel.solutions = new List<RequestForProposalModel.Solution>();
            foreach (DataGridViewRow row  in dataGridViewSolution.Rows)
            {
                RequestForProposalModel.Solution newSolution = new RequestForProposalModel.Solution();
                newSolution.solutionAndComponents = row.Cells[0].Value?.ToString() ?? "";
                newSolution.quantity = row.Cells[1].Value?.ToString() ?? "";
                newSolution.price = row.Cells[2].Value?.ToString() ?? "";
                newRequestForProposalModel.solutions.Add(newSolution);
            }

            newRequestForProposalModel.implementationDescription = txtImplementation.Text;

            newRequestForProposalModel.otherInformationDescription = txtOtherInformation.Text;
            newRequestForProposalModel.otherInformationConfidentiality = txtConfidentiality.Text;
            newRequestForProposalModel.otherInformationDocumentation = txtDocumentation.Text;

            List<VersionControl<RequestForProposalModel>.DocumentModel> documentModels = versionControl.DocumentModels;

            if (!versionControl.isEqual(currentRequestForProposalModel, newRequestForProposalModel))
            {
                VersionControl<RequestForProposalModel>.DocumentModel documentModel = new VersionControl<RequestForProposalModel>
                    .DocumentModel(newRequestForProposalModel, DateTime.Now, VersionControl<RequestForProposalModel>.generateID());

                documentModels.Add(documentModel);

                versionControl.DocumentModels = documentModels;
                string json = JsonConvert.SerializeObject(versionControl);
                currentRequestForProposalModel = JsonConvert.DeserializeObject<RequestForProposalModel>(JsonConvert.SerializeObject(newRequestForProposalModel));
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "RequestForProposal");
                MessageBox.Show("Request for Proposal saved successfully", "save", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("No changes were made!", "save", MessageBoxButtons.OK);
            }
        }

        public void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "RequestForProposal");
            List<string[]> documentInfo = new List<string[]>();
            newRequestForProposalModel = new RequestForProposalModel();
            currentRequestForProposalModel = new RequestForProposalModel();

            if(json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<RequestForProposalModel>>(json);
                newRequestForProposalModel = JsonConvert.DeserializeObject<RequestForProposalModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentRequestForProposalModel = JsonConvert.DeserializeObject<RequestForProposalModel>(versionControl.getLatest(versionControl.DocumentModels));

                foreach (var row in currentRequestForProposalModel.documentInformations)
                {
                    dataGridViewDocumentInformation.Rows.Add(new string[] { row.type, row.information });
                }

                foreach (RequestForProposalModel.DocumentHistory row in currentRequestForProposalModel.documentHistories)
                {
                    dataGridViewDocumentHistory.Rows.Add(new string[] { row.version, row.issueDate.ToString(), row.changes });
                }

                foreach (RequestForProposalModel.DocumentApproval row in currentRequestForProposalModel.documentApprovals)
                {
                    dataGridViewDocumentApprovals.Rows.Add(new string[] { row.role, row.name, "", row.approvalDate.ToString() });
                }

                txtRequestForProposalProcessProject.Text = projectModel.ProjectName;

                txtChangeProcess.Text = currentRequestForProposalModel.introductionDescription;
                txtOverview.Text = currentRequestForProposalModel.introductionOverview;
                txtPurpose.Text = currentRequestForProposalModel.introductionPurpose;
                txtAcknowledgement.Text = currentRequestForProposalModel.introductionAcknowledgement;
                txtRecipients.Text = currentRequestForProposalModel.introductionRecipients;
                txtProcess.Text = currentRequestForProposalModel.introductionProcess;
                txtRules.Text = currentRequestForProposalModel.introductionRules;
                txtQuestions.Text = currentRequestForProposalModel.introductionQuestions;

                txtCompany.Text = currentRequestForProposalModel.companyDescription;
                txtVisionObjectivesSizeLocation.Text = currentRequestForProposalModel.companyVisionObjectivesSizeLocation;
                txtTypeAndNumberOfCustomers.Text = currentRequestForProposalModel.companyTypeAndNumberOfCustomers;
                //txtMarketSegment.Text = currentRequestForProposalModel.companyMarketSegment;
                txtKnowledgeOfIndustryAndExpertise.Text = currentRequestForProposalModel.companyKnowledgeOfIndustryAndExpertise;

                foreach (RequestForProposalModel.Solution row in currentRequestForProposalModel.solutions)
                {
                    dataGridViewSolution.Rows.Add(new string[] { row.solutionAndComponents, row.quantity, "", row.price });
                }

                txtImplementation.Text = currentRequestForProposalModel.implementationDescription;
                txtOtherInformation.Text = currentRequestForProposalModel.otherInformationDescription;
                txtConfidentiality.Text = currentRequestForProposalModel.otherInformationConfidentiality;
                txtDocumentation.Text = currentRequestForProposalModel.otherInformationDocumentation;
            }
            else
            {
                versionControl = new VersionControl<RequestForProposalModel>();
                versionControl.DocumentModels = new List<VersionControl<RequestForProposalModel>.DocumentModel>();
                documentInfo.Add(new string[] { "Document ID", "" });
                documentInfo.Add(new string[] { "Document Owner", "" });
                documentInfo.Add(new string[] { "Issue Date", "" });
                documentInfo.Add(new string[] { "Last Save Date", "" });
                documentInfo.Add(new string[] { "File Name", "" });
                foreach (var row in documentInfo)
                {
                    dataGridViewDocumentInformation.Rows.Add(row);
                }
                dataGridViewDocumentInformation.AllowUserToAddRows = false;
            }
        }

        private void exportToWord()
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
                        document.InsertParagraph("Request for Proposal \nFor " + projectModel.ProjectName)
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(22d).Alignment = Alignment.left;
                        document.InsertSectionPageBreak();
                        document.InsertParagraph("Document Control\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;
                        document.InsertParagraph("Document Information\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;

                        var documentInfoTable = document.AddTable(6, 2);
                        documentInfoTable.Rows[0].Cells[0].Paragraphs[0].Append("").Bold(true).Color(Color.White);
                        documentInfoTable.Rows[0].Cells[1].Paragraphs[0].Append("Information").Bold(true).Color(Color.White);
                        documentInfoTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentInfoTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;

                        documentInfoTable.Rows[1].Cells[0].Paragraphs[0].Append(currentRequestForProposalModel.documentInformations[0].type);
                        documentInfoTable.Rows[1].Cells[1].Paragraphs[0].Append(currentRequestForProposalModel.documentInformations[0].information);

                        documentInfoTable.Rows[2].Cells[0].Paragraphs[0].Append(currentRequestForProposalModel.documentInformations[1].type);
                        documentInfoTable.Rows[2].Cells[1].Paragraphs[0].Append(currentRequestForProposalModel.documentInformations[1].information);

                        documentInfoTable.Rows[3].Cells[0].Paragraphs[0].Append(currentRequestForProposalModel.documentInformations[2].type);
                        documentInfoTable.Rows[3].Cells[1].Paragraphs[0].Append(currentRequestForProposalModel.documentInformations[2].information);

                        documentInfoTable.Rows[4].Cells[0].Paragraphs[0].Append(currentRequestForProposalModel.documentInformations[3].type);
                        documentInfoTable.Rows[4].Cells[1].Paragraphs[0].Append(currentRequestForProposalModel.documentInformations[3].information);

                        documentInfoTable.Rows[5].Cells[0].Paragraphs[0].Append(currentRequestForProposalModel.documentInformations[4].type);
                        documentInfoTable.Rows[5].Cells[1].Paragraphs[0].Append(currentRequestForProposalModel.documentInformations[4].information);
                        documentInfoTable.SetWidths(new float[] { 493, 1094 });
                        document.InsertTable(documentInfoTable);

                        document.InsertParagraph("\nDocument History\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;

                        var documentHistoryTable = document.AddTable(currentRequestForProposalModel.documentHistories.Count + 1, 3);
                        documentHistoryTable.Rows[0].Cells[0].Paragraphs[0].Append("Version")
                            .Bold(true)
                            .Color(Color.White);
                        documentHistoryTable.Rows[0].Cells[1].Paragraphs[0].Append("Issue Date")
                            .Bold(true)
                            .Color(Color.White);
                        documentHistoryTable.Rows[0].Cells[2].Paragraphs[0].Append("Changes")
                            .Bold(true)
                            .Color(Color.White);
                        documentHistoryTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentHistoryTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        documentHistoryTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        for (int i = 1; i < currentRequestForProposalModel.documentHistories.Count + 1; i++)
                        {
                            documentHistoryTable.Rows[i].Cells[0].Paragraphs[0].Append(currentRequestForProposalModel.documentHistories[i - 1].version);
                            documentHistoryTable.Rows[i].Cells[1].Paragraphs[0].Append(currentRequestForProposalModel.documentHistories[i - 1].issueDate);
                            documentHistoryTable.Rows[i].Cells[2].Paragraphs[0].Append(currentRequestForProposalModel.documentHistories[i - 1].changes);

                        }

                        documentHistoryTable.SetWidths(new float[] { 190, 303, 1094 });
                        document.InsertTable(documentHistoryTable);

                        document.InsertParagraph("\nDocument Approvals\n")
                           .Font("Arial")
                           .Bold(true)
                           .FontSize(14d).Alignment = Alignment.left;

                        var documentApprovalTable = document.AddTable(currentRequestForProposalModel.documentApprovals.Count + 1, 4);
                        documentApprovalTable.Rows[0].Cells[0].Paragraphs[0].Append("Role")
                            .Bold(true)
                            .Color(Color.White);
                        documentApprovalTable.Rows[0].Cells[1].Paragraphs[0].Append("Name")
                            .Bold(true)
                            .Color(Color.White);
                        documentApprovalTable.Rows[0].Cells[2].Paragraphs[0].Append("Signature")
                            .Bold(true)
                            .Color(Color.White);
                        documentApprovalTable.Rows[0].Cells[3].Paragraphs[0].Append("Date")
                            .Bold(true)
                            .Color(Color.White);
                        documentApprovalTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentApprovalTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        documentApprovalTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        documentApprovalTable.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentRequestForProposalModel.documentApprovals.Count + 1; i++)
                        {
                            documentApprovalTable.Rows[i].Cells[0].Paragraphs[0].Append(currentRequestForProposalModel.documentApprovals[i - 1].role);
                            documentApprovalTable.Rows[i].Cells[1].Paragraphs[0].Append(currentRequestForProposalModel.documentApprovals[i - 1].name);
                            documentApprovalTable.Rows[i].Cells[2].Paragraphs[0].Append(currentRequestForProposalModel.documentApprovals[i - 1].signature);
                            documentApprovalTable.Rows[i].Cells[3].Paragraphs[0].Append(currentRequestForProposalModel.documentApprovals[i - 1].approvalDate);
                        }
                        documentApprovalTable.SetWidths(new float[] { 493, 332, 508, 254 });
                        document.InsertTable(documentApprovalTable);
                        document.InsertParagraph().InsertPageBreakAfterSelf();

                        var p = document.InsertParagraph();
                        var title = p.InsertParagraphBeforeSelf("Table of Contents").Bold().FontSize(20);

                        var tocSwitches = new Dictionary<TableOfContentsSwitches, string>()
                        {
                            { TableOfContentsSwitches.O, "1-3"},
                            { TableOfContentsSwitches.U, ""},
                            { TableOfContentsSwitches.Z, ""},
                            { TableOfContentsSwitches.H, ""}
                        };

                        
                        document.InsertParagraph().InsertPageBreakAfterSelf();

                        var RequestForProposalHeading = document.InsertParagraph("1\tIntroduction")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        RequestForProposalHeading.StyleId = "Heading1";
                        document.InsertParagraph(currentRequestForProposalModel.introductionDescription)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        var overview = document.InsertParagraph("1.1\tOverview")
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        overview.StyleId = "Heading2";
                        document.InsertParagraph(currentRequestForProposalModel.introductionOverview)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial");


                        var purpose = document.InsertParagraph("1.2\tPurpose")
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        purpose.StyleId = "Heading2";
                        document.InsertParagraph(currentRequestForProposalModel.introductionPurpose)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial");


                        var acknowledgement = document.InsertParagraph("1.3\tAcknowledgement")
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        acknowledgement.StyleId = "Heading2";
                        document.InsertParagraph(currentRequestForProposalModel.introductionAcknowledgement)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial");


                        var recipients = document.InsertParagraph("1.4\tRecipients")
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        recipients.StyleId = "Heading2";
                        document.InsertParagraph(currentRequestForProposalModel.introductionRecipients)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial");


                        var process = document.InsertParagraph("1.5\tProcess")
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        process.StyleId = "Heading2";
                        document.InsertParagraph(currentRequestForProposalModel.introductionProcess)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial");


                        var rules = document.InsertParagraph("1.6\tRules")
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        rules.StyleId = "Heading2";
                        document.InsertParagraph(currentRequestForProposalModel.introductionRules)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial");


                        var questions = document.InsertParagraph("1.7\tQuestions")
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        questions.StyleId = "Heading2";
                        document.InsertParagraph(currentRequestForProposalModel.introductionQuestions)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial");


                        var company = document.InsertParagraph("2\tCompany")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        company.StyleId = "Heading1";
                        document.InsertParagraph(currentRequestForProposalModel.companyDescription)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;


                        var vision = document.InsertParagraph("2.1\tVision, objectives, size, location")
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        vision.StyleId = "Heading2";
                        document.InsertParagraph(currentRequestForProposalModel.companyVisionObjectivesSizeLocation)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial");

                        var typeAndNumber = document.InsertParagraph("2.2\tType and number of customers")
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        typeAndNumber.StyleId = "Heading2";
                        document.InsertParagraph(currentRequestForProposalModel.companyTypeAndNumberOfCustomers)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial");


                        var marketSegments = document.InsertParagraph("2.3\tMarket segments within which it operates")
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        marketSegments.StyleId = "Heading2";
                        document.InsertParagraph(currentRequestForProposalModel.companyMarketSegment)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial");

                        var knowledge = document.InsertParagraph("2.4\tKnowledge of industry and expertise")
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Font("Arial");

                        knowledge.StyleId = "Heading2";
                        document.InsertParagraph(currentRequestForProposalModel.companyKnowledgeOfIndustryAndExpertise)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial");

                        

                        var solutionHeading = document.InsertParagraph("3\tSolution")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        solutionHeading.StyleId = "Heading1";

                        var documentSolutions = document.AddTable(currentRequestForProposalModel.solutions.Count + 1, 3);
                        documentSolutions.Rows[0].Cells[0].Paragraphs[0].Append("Solution and Components")
                            .Bold(true)
                            .Color(Color.White);
                        documentSolutions.Rows[0].Cells[1].Paragraphs[0].Append("Quantity")
                            .Bold(true)
                            .Color(Color.White);
                        documentSolutions.Rows[0].Cells[2].Paragraphs[0].Append("Price")
                            .Bold(true)
                            .Color(Color.White);
                        documentSolutions.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentSolutions.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        documentSolutions.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        for (int i = 1; i < currentRequestForProposalModel.solutions.Count + 1; i++)
                        {
                            documentSolutions.Rows[i].Cells[0].Paragraphs[0].Append(currentRequestForProposalModel.solutions[i - 1].solutionAndComponents);
                            documentSolutions.Rows[i].Cells[1].Paragraphs[0].Append(currentRequestForProposalModel.solutions[i - 1].quantity);
                            documentSolutions.Rows[i].Cells[2].Paragraphs[0].Append(currentRequestForProposalModel.solutions[i - 1].price);
                        }

                        documentSolutions.SetWidths(new float[] { 1094, 190, 303 });
                        document.InsertTable(documentSolutions);

                        var implementationHeading = document.InsertParagraph("4\tImplementation")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        implementationHeading.StyleId = "Heading1";
                        document.InsertParagraph(currentRequestForProposalModel.implementationDescription)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial");


                        var otherInformationHeading = document.InsertParagraph("5\tOther Information")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        otherInformationHeading.StyleId = "Heading1";
                        document.InsertParagraph(currentRequestForProposalModel.otherInformationDescription)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial");

                        var confidentialityHeading = document.InsertParagraph("5.1\tConfidentiality")
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        confidentialityHeading.StyleId = "Heading2";
                        document.InsertParagraph(currentRequestForProposalModel.otherInformationConfidentiality)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial");

                        var documentationHeading = document.InsertParagraph("5.2\tDocumentation")
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        documentationHeading.StyleId = "Heading2";
                        document.InsertParagraph(currentRequestForProposalModel.otherInformationDocumentation)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial");

                        document.InsertTableOfContents(p, "", tocSwitches);

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

        private void RequestForProposalDocumentForm_Load(object sender, EventArgs e)
        {
            loadDocument();
            string json = JsonHelper.loadProjectInfo(Settings.Default.Username);
            List<ProjectModel> projectListModel = JsonConvert.DeserializeObject<List<ProjectModel>>(json);
            projectModel = projectModel.getProjectModel(Settings.Default.ProjectID, projectListModel);
        }
    }
}
