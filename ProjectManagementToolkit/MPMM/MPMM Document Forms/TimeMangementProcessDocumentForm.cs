using ProjectManagementToolkit.MPMM.MPMM_Document_Models;
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
using System.Runtime.InteropServices;
using ProjectManagementToolkit.Utility;
using ProjectManagementToolkit.Properties;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class TimeMangementProcessDocumentForm : Form
    {

        VersionControl<TimeMangementProcessModel> versionControl;
        TimeMangementProcessModel newTimeMangementProcessModel;
        TimeMangementProcessModel currentTimeMangementProcessModel;

        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        ProjectModel projectModel = new ProjectModel();



        public void saveDocument()
        {
            newTimeMangementProcessModel.DocumentID = dgvDocumentInformation.Rows[0].Cells[1].Value.ToString();
            newTimeMangementProcessModel.DocumentOwner = dgvDocumentInformation.Rows[1].Cells[1].Value.ToString();
            newTimeMangementProcessModel.IssueDate = dgvDocumentInformation.Rows[2].Cells[1].Value.ToString();
            newTimeMangementProcessModel.LastSavedDate = dgvDocumentInformation.Rows[3].Cells[1].Value.ToString();
            newTimeMangementProcessModel.FileName = dgvDocumentInformation.Rows[4].Cells[1].Value.ToString();

            List<TimeMangementProcessModel.DocumentHistory> documentHistories = new List<TimeMangementProcessModel.DocumentHistory>();

            int versionRowsCount = dgvDocumentHistory.Rows.Count;

            for (int i = 0; i < versionRowsCount - 1; i++)
            {
                TimeMangementProcessModel.DocumentHistory documentHistoryModel = new TimeMangementProcessModel.DocumentHistory();
                var version = dgvDocumentHistory.Rows[i].Cells[0].Value?.ToString() ?? "";
                var issueDate = dgvDocumentHistory.Rows[i].Cells[1].Value?.ToString() ?? "";
                var changes = dgvDocumentHistory.Rows[i].Cells[2].Value?.ToString() ?? "";
                documentHistoryModel.Version = version;
                documentHistoryModel.IssueDate = issueDate;
                documentHistoryModel.Changes = changes;
                documentHistories.Add(documentHistoryModel);
            }
            newTimeMangementProcessModel.DocumentHistories = documentHistories;

            List<TimeMangementProcessModel.DocumentApproval> documentApprovalsModel = new List<TimeMangementProcessModel.DocumentApproval>();

            int approvalRowsCount = dgvDocumentApproval.Rows.Count;

            for (int i = 0; i < approvalRowsCount - 1; i++)
            {
                TimeMangementProcessModel.DocumentApproval documentApproval = new TimeMangementProcessModel.DocumentApproval();
                var role = dgvDocumentApproval.Rows[i].Cells[0].Value?.ToString() ?? "";
                var name = dgvDocumentApproval.Rows[i].Cells[1].Value?.ToString() ?? "";
                var signature = dgvDocumentApproval.Rows[i].Cells[2].Value?.ToString() ?? "";
                var date = dgvDocumentApproval.Rows[i].Cells[3].Value?.ToString() ?? "";
                documentApproval.Role = role;
                documentApproval.Name = name;
                documentApproval.Signature = signature;
                documentApproval.DateApproved = date;

                documentApprovalsModel.Add(documentApproval);
            }
            newTimeMangementProcessModel.DocumentApprovals = documentApprovalsModel;



            newTimeMangementProcessModel.TimemanagementprocessDescription = txttimemanagementprocessDescription.Text;

            newTimeMangementProcessModel.TimemanagementprocessOverview = txttimemanagementprocessOverview.Text;

            newTimeMangementProcessModel.TimemanagementprocessDocumentTimesheet = txttimemanagementprocessDocumentTimesheet.Text;

            newTimeMangementProcessModel.TimemanagementprocessApprovedTimesheet = txttimemanagementprocessApprovedTimesheet.Text;

            newTimeMangementProcessModel.TimemanagementprocessUpdateProcessPlan = txttimemanagementprocessUpdateProcessPlan.Text;

            newTimeMangementProcessModel.TimemanagementrolesDescription = txttimemanagementrolesDescription.Text;

            newTimeMangementProcessModel.TimemanagementrolesTeamMember = txttimemanagementrolesTeamMember.Text;

            newTimeMangementProcessModel.TimemanagementrolesProjectManager = txttimemanagementrolesProjectManager.Text;

            newTimeMangementProcessModel.TimemanagementrolesProjectAdminstratror = txttimemanagementrolesProjectAdminstratror.Text;

            newTimeMangementProcessModel.TimemanagementdocumentsDescription = txttimemanagementdocumentsDescription.Text;

            newTimeMangementProcessModel.TimemanagementdocumentsTimeSheet = txttimemanagementdocumentsTimeSheet.Text;

            newTimeMangementProcessModel.TimemanagementdocumentsTimeSheetRegister = txttimemanagementdocumentsTimeSheetRegister.Text;



            List<VersionControl<TimeMangementProcessModel>.DocumentModel> documentModels = versionControl.DocumentModels;

            if (!versionControl.isEqual(currentTimeMangementProcessModel, newTimeMangementProcessModel))
            {
                VersionControl<TimeMangementProcessModel>.DocumentModel documentModel = new VersionControl<TimeMangementProcessModel>.DocumentModel(newTimeMangementProcessModel, DateTime.Now, VersionControl<ProjectModel>.generateID());
                currentTimeMangementProcessModel = JsonConvert.DeserializeObject<TimeMangementProcessModel>(JsonConvert.SerializeObject(newTimeMangementProcessModel));
                documentModels.Add(documentModel);

                versionControl.DocumentModels = documentModels;

                string json = JsonConvert.SerializeObject(versionControl);
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "TimeMangement");
                MessageBox.Show("Time Management Process saved successfully", "save", MessageBoxButtons.OK);
            }

        }




        private void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "TimeMangement");
            List<string[]> documentInfo = new List<string[]>();
            newTimeMangementProcessModel = new TimeMangementProcessModel();
            currentTimeMangementProcessModel = new TimeMangementProcessModel();
            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<TimeMangementProcessModel>>(json);
                newTimeMangementProcessModel = JsonConvert.DeserializeObject<TimeMangementProcessModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentTimeMangementProcessModel = JsonConvert.DeserializeObject<TimeMangementProcessModel>(versionControl.getLatest(versionControl.DocumentModels));

                documentInfo.Add(new string[] { "Document ID", currentTimeMangementProcessModel.DocumentID });
                documentInfo.Add(new string[] { "Document Owner", currentTimeMangementProcessModel.DocumentOwner });
                documentInfo.Add(new string[] { "Issue Date", currentTimeMangementProcessModel.IssueDate });
                documentInfo.Add(new string[] { "Last Save Date", currentTimeMangementProcessModel.LastSavedDate });
                documentInfo.Add(new string[] { "File Name", currentTimeMangementProcessModel.FileName });

                foreach (var row in documentInfo)
                {
                    dgvDocumentInformation.Rows.Add(row);
                }
                dgvDocumentInformation.AllowUserToAddRows = false;

                //foreach (var row in documentInfo)
                //{
                //    dgvDocumentHistory.Rows.Add(row);
                //}
                //dgvDocumentHistory.AllowUserToAddRows = false;

                foreach (var row in currentTimeMangementProcessModel.DocumentHistories)
                {
                    dgvDocumentHistory.Rows.Add(new string[] { row.Version, row.IssueDate, row.Changes });
                }

                foreach (var row in currentTimeMangementProcessModel.DocumentApprovals)
                {
                    dgvDocumentApproval.Rows.Add(new string[] { row.Role, row.Name, "", row.DateApproved });
                }



                txttimemanagementprocessDescription.Text = currentTimeMangementProcessModel.TimemanagementprocessDescription ;

                txttimemanagementprocessOverview.Text = currentTimeMangementProcessModel.TimemanagementprocessOverview;

                txttimemanagementprocessDocumentTimesheet.Text = currentTimeMangementProcessModel.TimemanagementprocessDocumentTimesheet  ;

                txttimemanagementprocessApprovedTimesheet.Text = currentTimeMangementProcessModel.TimemanagementprocessApprovedTimesheet  ;

                txttimemanagementprocessUpdateProcessPlan.Text = currentTimeMangementProcessModel.TimemanagementprocessUpdateProcessPlan  ;

                txttimemanagementrolesDescription.Text = currentTimeMangementProcessModel.TimemanagementrolesDescription  ;

                txttimemanagementrolesTeamMember.Text = currentTimeMangementProcessModel.TimemanagementrolesTeamMember  ;

                txttimemanagementrolesProjectManager.Text = currentTimeMangementProcessModel.TimemanagementrolesProjectManager  ;

                txttimemanagementrolesProjectAdminstratror.Text = currentTimeMangementProcessModel.TimemanagementrolesProjectAdminstratror  ;

                txttimemanagementdocumentsDescription.Text = currentTimeMangementProcessModel.TimemanagementdocumentsDescription  ;

                txttimemanagementdocumentsTimeSheet.Text = currentTimeMangementProcessModel.TimemanagementdocumentsTimeSheet ;

                txttimemanagementdocumentsTimeSheetRegister.Text = currentTimeMangementProcessModel.TimemanagementdocumentsTimeSheetRegister ;
            }
            else
            {
                versionControl = new VersionControl<TimeMangementProcessModel>();
                versionControl.DocumentModels = new List<VersionControl<TimeMangementProcessModel>.DocumentModel>();
                documentInfo.Add(new string[] { "Document ID", "" });
                documentInfo.Add(new string[] { "Document Owner", "" });
                documentInfo.Add(new string[] { "Issue Date", "" });
                documentInfo.Add(new string[] { "Last Save Date", "" });
                documentInfo.Add(new string[] { "File Name", "" });
                newTimeMangementProcessModel = new TimeMangementProcessModel();
                foreach (var row in documentInfo)
                {
                    dgvDocumentInformation.Rows.Add(row);
                }
                dgvDocumentHistory.AllowUserToAddRows = false;
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

                        //Code for the Front page
                        document.InsertParagraph("Time Management Process \nFor " + projectModel.ProjectName)
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(22d).Alignment = Alignment.left;
                        document.InsertSectionPageBreak();
                        //Code for the Front page


                        //Code for the title of a page
                        document.InsertParagraph("Document Control\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;
                        //Code for the title of a page


                        //Code for a space
                        document.InsertParagraph("")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;
                        //Code for a space


                        //Code of a sentence
                        document.InsertParagraph("Document Information\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;
                        //Code of a sentence


                        //Code for a table
                        var documentInfoTable = document.AddTable(6, 2);
                        documentInfoTable.Rows[0].Cells[0].Paragraphs[0].Append("").Bold(true).Color(Color.White);
                        documentInfoTable.Rows[0].Cells[1].Paragraphs[0].Append("Information").Bold(true).Color(Color.White);
                        documentInfoTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentInfoTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;

                        documentInfoTable.Rows[1].Cells[0].Paragraphs[0].Append("Document ID");
                        documentInfoTable.Rows[1].Cells[1].Paragraphs[0].Append(currentTimeMangementProcessModel.DocumentID);

                        documentInfoTable.Rows[2].Cells[0].Paragraphs[0].Append("Document Owner");
                        documentInfoTable.Rows[2].Cells[1].Paragraphs[0].Append(currentTimeMangementProcessModel.DocumentOwner);

                        documentInfoTable.Rows[3].Cells[0].Paragraphs[0].Append("Issue Date");
                        documentInfoTable.Rows[3].Cells[1].Paragraphs[0].Append(currentTimeMangementProcessModel.IssueDate);

                        documentInfoTable.Rows[4].Cells[0].Paragraphs[0].Append("Last Saved Date");
                        documentInfoTable.Rows[4].Cells[1].Paragraphs[0].Append(currentTimeMangementProcessModel.LastSavedDate);

                        documentInfoTable.Rows[5].Cells[0].Paragraphs[0].Append("File Name");
                        documentInfoTable.Rows[5].Cells[1].Paragraphs[0].Append(currentTimeMangementProcessModel.FileName);
                        documentInfoTable.SetWidths(new float[] { 493, 1094 });
                        document.InsertTable(documentInfoTable);
                        //Code for a table


                        //Code of a sentence
                        document.InsertParagraph("\nDocument History\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;
                        //Code of a sentence


                        //Code for a table
                        var documentHistoryTable = document.AddTable(currentTimeMangementProcessModel.DocumentHistories.Count + 1, 3);
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
                        for (int i = 1; i < currentTimeMangementProcessModel.DocumentHistories.Count + 1; i++)
                        {
                            documentHistoryTable.Rows[i].Cells[0].Paragraphs[0].Append(currentTimeMangementProcessModel.DocumentHistories[i - 1].Version);
                            documentHistoryTable.Rows[i].Cells[1].Paragraphs[0].Append(currentTimeMangementProcessModel.DocumentHistories[i - 1].IssueDate);
                            documentHistoryTable.Rows[i].Cells[2].Paragraphs[0].Append(currentTimeMangementProcessModel.DocumentHistories[i - 1].Changes);

                        }

                        documentHistoryTable.SetWidths(new float[] { 190, 303, 1094 });
                        document.InsertTable(documentHistoryTable);
                        //Code for a table


                        //Code of a sentence
                        document.InsertParagraph("\nDocument Approvals\n")
                           .Font("Arial")
                           .Bold(true)
                           .FontSize(14d).Alignment = Alignment.left;
                        //Code of a sentence


                        //Code for a table
                        var documentApprovalTable = document.AddTable(currentTimeMangementProcessModel.DocumentApprovals.Count + 1, 4);
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

                        for (int i = 1; i < currentTimeMangementProcessModel.DocumentApprovals.Count + 1; i++)
                        {
                            documentApprovalTable.Rows[i].Cells[0].Paragraphs[0].Append(currentTimeMangementProcessModel.DocumentApprovals[i - 1].Role);
                            documentApprovalTable.Rows[i].Cells[1].Paragraphs[0].Append(currentTimeMangementProcessModel.DocumentApprovals[i - 1].Name);
                            documentApprovalTable.Rows[i].Cells[2].Paragraphs[0].Append(currentTimeMangementProcessModel.DocumentApprovals[i - 1].Signature);
                            documentApprovalTable.Rows[i].Cells[3].Paragraphs[0].Append(currentTimeMangementProcessModel.DocumentApprovals[i - 1].DateApproved);
                        }
                        documentApprovalTable.SetWidths(new float[] { 493, 332, 508, 254 });
                        document.InsertTable(documentApprovalTable);
                        //Code for a table


                        //Code for a page break
                        document.InsertParagraph().InsertPageBreakAfterSelf();
                        //Code for a page break


                        //Code for a table of contents
                        var p = document.InsertParagraph();
                        var title = p.InsertParagraphBeforeSelf("Table of Contents").Bold().FontSize(20);

                        var tocSwitches = new Dictionary<TableOfContentsSwitches, string>()
                        {
                            { TableOfContentsSwitches.O, "1-3"},
                            { TableOfContentsSwitches.U, ""},
                            { TableOfContentsSwitches.Z, ""},
                            { TableOfContentsSwitches.H, ""}
                        };

                        document.InsertTableOfContents(p, "", tocSwitches);
                        //Code for a table of contents


                        //Code for a page break
                        document.InsertParagraph().InsertPageBreakAfterSelf();
                        //Code for a page break


                        //Code for a heading 1
                        var TimeManagementProcessHeading = document.InsertParagraph("1 Time Management Process")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        TimeManagementProcessHeading.StyleId = "Heading1";
                        //Code for a heading 1

                        //Code for a heading 2
                        var DescriptionSubHeading = document.InsertParagraph("1.1 Description")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        DescriptionSubHeading.StyleId = "Heading2";
                        //Code for a heading 2


                        //Code for a sentence
                        document.InsertParagraph(currentTimeMangementProcessModel.TimemanagementprocessDescription)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence

                        //Code for a heading 2
                        var OverviewSubHeading = document.InsertParagraph("1.2 Overview")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        OverviewSubHeading.StyleId = "Heading2";
                        //Code for a heading 2


                        //Code for a sentence
                        document.InsertParagraph(currentTimeMangementProcessModel.TimemanagementprocessOverview)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence


                        //Code for a heading 2
                        var DocumentTimesheetHeading = document.InsertParagraph("1.3 Document Timesheet")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        DocumentTimesheetHeading.StyleId = "Heading2";
                        //Code for a heading 2


                        //Code for a sentence
                        document.InsertParagraph(currentTimeMangementProcessModel.TimemanagementprocessDocumentTimesheet)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence


                        //Code for a heading 2
                        var ApproveTimesheetHeading = document.InsertParagraph("1.4 Approve Timesheet")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        ApproveTimesheetHeading.StyleId = "Heading2";
                        //Code for a heading 2


                        //Code for a sentence
                        document.InsertParagraph(currentTimeMangementProcessModel.TimemanagementprocessApprovedTimesheet)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence


                        //Code for a heading 2
                        var UpdateProjectPlanHeading = document.InsertParagraph("1.5 Update Project Plan")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        UpdateProjectPlanHeading.StyleId = "Heading2";
                        //Code for a heading 2


                        //Code for a sentence
                        document.InsertParagraph(currentTimeMangementProcessModel.TimemanagementprocessUpdateProcessPlan)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence




                        //Code for a heading 1
                        var TimeManagementRolesHeading = document.InsertParagraph("2 Time Management Roles")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        TimeManagementRolesHeading.StyleId = "Heading1";
                        //Code for a heading 1


                        //Code for a heading 2
                        var DescriptionSubHeadingRoles = document.InsertParagraph("2.1 Description")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        DescriptionSubHeadingRoles.StyleId = "Heading2";
                        //Code for a heading 2


                        //Code for a sentence
                        document.InsertParagraph(currentTimeMangementProcessModel.TimemanagementrolesDescription)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence


                        //Code for a heading 2
                        var TeamMemberHeading = document.InsertParagraph("2.2 Team Member")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        TeamMemberHeading.StyleId = "Heading2";
                        //Code for a heading 2


                        //Code for a sentence
                        document.InsertParagraph(currentTimeMangementProcessModel.TimemanagementrolesTeamMember)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence


                        //Code for a heading 2
                        var ProjectManagerHeading = document.InsertParagraph("2.3 Project Manager")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        ProjectManagerHeading.StyleId = "Heading2";
                        //Code for a heading 2


                        //Code for a sentence
                        document.InsertParagraph(currentTimeMangementProcessModel.TimemanagementrolesProjectManager)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence


                        //Code for a heading 2
                        var ProjectAdministratorHeading = document.InsertParagraph("2.4 Project Administrator")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        ProjectAdministratorHeading.StyleId = "Heading2";
                        //Code for a heading 2


                        //Code for a sentence
                        document.InsertParagraph(currentTimeMangementProcessModel.TimemanagementrolesProjectAdminstratror)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence





                        //Code for a heading 1
                        var TimeManagementDocumentsHeading = document.InsertParagraph("3 Time Management Documents")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        TimeManagementDocumentsHeading.StyleId = "Heading1";
                        //Code for a heading 1
                        //Code for a heading 2
                        var DescriptionSubHeadingDocument = document.InsertParagraph("3.1 Description")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        DescriptionSubHeadingDocument.StyleId = "Heading2";
                        //Code for a heading 2


                        //Code for a sentence
                        document.InsertParagraph(currentTimeMangementProcessModel.TimemanagementdocumentsDescription)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence

                        //Code for a heading 2
                        var TimesheetHeading = document.InsertParagraph("3.2 Timesheet")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        TimesheetHeading.StyleId = "Heading2";
                        //Code for a heading 2


                        //Code for a sentence
                        document.InsertParagraph(currentTimeMangementProcessModel.TimemanagementdocumentsTimeSheet)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence


                        //Code for a heading 2
                        var TimesheetRegisterHeading = document.InsertParagraph("3.3 Timesheet Register")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        TimesheetRegisterHeading.StyleId = "Heading2";
                        //Code for a heading 2


                        //Code for a sentence
                        document.InsertParagraph(currentTimeMangementProcessModel.TimemanagementdocumentsTimeSheetRegister)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence


                        //Code for saving
                        try
                        {
                            document.Save();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("The selected File is open.", "Close File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        //Code for saving

                    }
                }
            }
        }





        public TimeMangementProcessDocumentForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveDocument();
        }

        private void TimeMangementProcessDocumentForm_Load(object sender, EventArgs e)
        {
            loadDocument();
            string json = JsonHelper.loadProjectInfo(Settings.Default.Username);
            List<ProjectModel> projectListModel = JsonConvert.DeserializeObject<List<ProjectModel>>(json);
            projectModel = projectModel.getProjectModel(Settings.Default.ProjectID, projectListModel);
        }

        private void btnExportWord_Click(object sender, EventArgs e)
        {
            exportToWord();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            saveDocument();
        }

        private void btnExportWord_Click_1(object sender, EventArgs e)
        {
            exportToWord();
        }

        private void TimeMangementProcessDocumentForm_Load_1(object sender, EventArgs e)
        {
            string jsoni = JsonHelper.loadProjectInfo(Settings.Default.Username);
            List<ProjectModel> projectListModel = JsonConvert.DeserializeObject<List<ProjectModel>>(jsoni);
            projectModel = projectModel.getProjectModel(Settings.Default.ProjectID, projectListModel);
            txtProjectName.Text = projectModel.ProjectName;
            loadDocument();

        }

        private void dgvDocumentInformation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
