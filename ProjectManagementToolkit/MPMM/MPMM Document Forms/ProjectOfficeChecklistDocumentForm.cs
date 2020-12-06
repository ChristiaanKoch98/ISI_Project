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
    public partial class ProjectOfficeChecklistDocumentForm : Form
    {
        VersionControl<ProjectOfficeChecklistModel> versionControl;
        ProjectOfficeChecklistModel newProjectOfficeChecklistModel;
        ProjectOfficeChecklistModel currentProjectOfficeChecklistModel;
        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        ProjectModel projectModel = new ProjectModel();
        string serviceText = "";

        public ProjectOfficeChecklistDocumentForm()
        {
            InitializeComponent();
        }


        public void saveDocument()
        {
            newProjectOfficeChecklistModel.ProjectName = txtProjectName.Text;
            newProjectOfficeChecklistModel.ProjectManager = txtProjectManager.Text;
            newProjectOfficeChecklistModel.ProjectOfficeManager = txtProjectOfficeManager.Text;

            newProjectOfficeChecklistModel.Premises = new List<ProjectOfficeChecklistModel.Questionare>();
            int premisesCount = dataGridViewPremises.Rows.Count-1;

            for (int i = 0; i < premisesCount; i++)
            {
                var question = dataGridViewPremises.Rows[i].Cells[0].Value?.ToString() ?? "";
                bool answer = Convert.ToBoolean(dataGridViewPremises.Rows[i].Cells[1].Value);
                newProjectOfficeChecklistModel.Premises.Add(new ProjectOfficeChecklistModel.Questionare(question, answer));
            }

            newProjectOfficeChecklistModel.Equipment = new List<ProjectOfficeChecklistModel.Questionare>();
            int equipmentCount = dataGridViewEquipment.Rows.Count - 1;

            for (int i = 0; i < equipmentCount; i++)
            {
                var question = dataGridViewEquipment.Rows[i].Cells[0].Value?.ToString() ?? "";
                bool answer = Convert.ToBoolean(dataGridViewEquipment.Rows[i].Cells[1].Value);
                newProjectOfficeChecklistModel.Equipment.Add(new ProjectOfficeChecklistModel.Questionare(question, answer));
            }

            newProjectOfficeChecklistModel.Roles = new List<ProjectOfficeChecklistModel.Questionare>();

            int rolesCount = dataGridViewRoles.Rows.Count - 1;

            for (int i = 0; i < rolesCount; i++)
            {
                var question = dataGridViewRoles.Rows[i].Cells[0].Value?.ToString() ?? "";
                bool answer = Convert.ToBoolean(dataGridViewRoles.Rows[i].Cells[1].Value);
                newProjectOfficeChecklistModel.Roles.Add(new ProjectOfficeChecklistModel.Questionare(question, answer));
            }


            newProjectOfficeChecklistModel.StandardsProcesses = new List<ProjectOfficeChecklistModel.Questionare>();

            int standardsProcessesCount = dataGridViewStandardsProcesses.Rows.Count - 1;

            for (int i = 0; i < standardsProcessesCount; i++)
            {
                var question = dataGridViewStandardsProcesses.Rows[i].Cells[0].Value?.ToString() ?? "";
                bool answer = Convert.ToBoolean(dataGridViewStandardsProcesses.Rows[i].Cells[1].Value);
                newProjectOfficeChecklistModel.StandardsProcesses.Add(new ProjectOfficeChecklistModel.Questionare(question, answer));
            }

            newProjectOfficeChecklistModel.TemplatesInitiation = new List<ProjectOfficeChecklistModel.Questionare>();
            int initiationProcessesCount = dataGridViewInit.Rows.Count - 1;

            for (int i = 0; i < initiationProcessesCount; i++)
            {
                var question = dataGridViewInit.Rows[i].Cells[0].Value?.ToString() ?? "";
                bool answer = Convert.ToBoolean(dataGridViewInit.Rows[i].Cells[1].Value);
                newProjectOfficeChecklistModel.TemplatesInitiation.Add(new ProjectOfficeChecklistModel.Questionare(question, answer));
            }

            newProjectOfficeChecklistModel.TemplatesPlanning = new List<ProjectOfficeChecklistModel.Questionare>();
            int planningRowCount = dataGridViewPlanning.Rows.Count - 1;

            for (int i = 0; i < planningRowCount; i++)
            {
                var question = dataGridViewPlanning.Rows[i].Cells[0].Value?.ToString() ?? "";
                bool answer = Convert.ToBoolean(dataGridViewPlanning.Rows[i].Cells[1].Value);
                newProjectOfficeChecklistModel.TemplatesPlanning.Add(new ProjectOfficeChecklistModel.Questionare(question, answer));
            }

            newProjectOfficeChecklistModel.TemplatesExecution= new List<ProjectOfficeChecklistModel.Questionare>();
            int executionRowCount = dataGridViewExecution.Rows.Count - 1;

            for (int i = 0; i < executionRowCount; i++)
            {
                var question = dataGridViewExecution.Rows[i].Cells[0].Value?.ToString() ?? "";
                bool answer = Convert.ToBoolean(dataGridViewExecution.Rows[i].Cells[1].Value);
                newProjectOfficeChecklistModel.TemplatesExecution.Add(new ProjectOfficeChecklistModel.Questionare(question, answer));
            }

            newProjectOfficeChecklistModel.TemplatesClosure = new List<ProjectOfficeChecklistModel.Questionare>();
            int closureRowCount = dataGridViewClosure.Rows.Count - 1;

            for (int i = 0; i < closureRowCount; i++)
            {
                var question = dataGridViewClosure.Rows[i].Cells[0].Value?.ToString() ?? "";
                bool answer = Convert.ToBoolean(dataGridViewClosure.Rows[i].Cells[1].Value);
                newProjectOfficeChecklistModel.TemplatesClosure.Add(new ProjectOfficeChecklistModel.Questionare(question, answer));
            }

            List<VersionControl<ProjectOfficeChecklistModel>.DocumentModel> documentModels = versionControl.DocumentModels;

            if (!versionControl.isEqual(currentProjectOfficeChecklistModel, newProjectOfficeChecklistModel))
            {
                VersionControl<ProjectOfficeChecklistModel>.DocumentModel documentModel = new VersionControl<ProjectOfficeChecklistModel>.DocumentModel(newProjectOfficeChecklistModel, DateTime.Now, VersionControl<ProjectOfficeChecklistModel>.generateID());

                documentModels.Add(documentModel);

                versionControl.DocumentModels = documentModels;
                string json = JsonConvert.SerializeObject(versionControl);
                currentProjectOfficeChecklistModel = JsonConvert.DeserializeObject<ProjectOfficeChecklistModel>(JsonConvert.SerializeObject(newProjectOfficeChecklistModel));
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "ProjectOfficeCheckList");
                MessageBox.Show("Project Office Checklist saved successfully", "save", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("No changes was made!", "save", MessageBoxButtons.OK);
            }


        }
        public void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "ProjectOfficeChecklist");
            newProjectOfficeChecklistModel = new ProjectOfficeChecklistModel();
            currentProjectOfficeChecklistModel = new ProjectOfficeChecklistModel();

            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<ProjectOfficeChecklistModel>>(json);
                newProjectOfficeChecklistModel = JsonConvert.DeserializeObject<ProjectOfficeChecklistModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentProjectOfficeChecklistModel = JsonConvert.DeserializeObject<ProjectOfficeChecklistModel>(versionControl.getLatest(versionControl.DocumentModels));

                for (int i = 0; i < currentProjectOfficeChecklistModel.Premises.Count; i++)
                {
                    dataGridViewPremises.Rows.Add();
                    dataGridViewPremises.Rows[i].Cells[0].Value = currentProjectOfficeChecklistModel.Premises[i].Question;
                    dataGridViewPremises.Rows[i].Cells[1].Value = currentProjectOfficeChecklistModel.Premises[i].Answer;
                }


                for (int i = 0; i < currentProjectOfficeChecklistModel.Equipment.Count; i++)
                {
                    dataGridViewEquipment.Rows.Add();
                    dataGridViewEquipment.Rows[i].Cells[0].Value = currentProjectOfficeChecklistModel.Equipment[i].Question;
                    dataGridViewEquipment.Rows[i].Cells[1].Value = currentProjectOfficeChecklistModel.Equipment[i].Answer;
                }

                for (int i = 0; i < currentProjectOfficeChecklistModel.Roles.Count; i++)
                {
                    dataGridViewRoles.Rows.Add();
                    dataGridViewRoles.Rows[i].Cells[0].Value = currentProjectOfficeChecklistModel.Roles[i].Question;
                    dataGridViewRoles.Rows[i].Cells[1].Value = currentProjectOfficeChecklistModel.Roles[i].Answer;
                }

                for (int i = 0; i < currentProjectOfficeChecklistModel.StandardsProcesses.Count; i++)
                {
                    dataGridViewStandardsProcesses.Rows.Add();
                    dataGridViewStandardsProcesses.Rows[i].Cells[0].Value = currentProjectOfficeChecklistModel.StandardsProcesses[i].Question;
                    dataGridViewStandardsProcesses.Rows[i].Cells[1].Value = currentProjectOfficeChecklistModel.StandardsProcesses[i].Answer;
                }

                for (int i = 0; i < currentProjectOfficeChecklistModel.TemplatesInitiation.Count; i++)
                {
                    dataGridViewInit.Rows.Add();
                    dataGridViewInit.Rows[i].Cells[0].Value = currentProjectOfficeChecklistModel.TemplatesInitiation[i].Question;
                    dataGridViewInit.Rows[i].Cells[1].Value = currentProjectOfficeChecklistModel.TemplatesInitiation[i].Answer;
                }

                for (int i = 0; i < currentProjectOfficeChecklistModel.TemplatesPlanning.Count; i++)
                {
                    dataGridViewPlanning.Rows.Add();
                    dataGridViewPlanning.Rows[i].Cells[0].Value = currentProjectOfficeChecklistModel.TemplatesPlanning[i].Question;
                    dataGridViewPlanning.Rows[i].Cells[1].Value = currentProjectOfficeChecklistModel.TemplatesPlanning[i].Answer;
                }

                for (int i = 0; i < currentProjectOfficeChecklistModel.TemplatesExecution.Count; i++)
                {
                    dataGridViewExecution.Rows.Add();
                    dataGridViewExecution.Rows[i].Cells[0].Value = currentProjectOfficeChecklistModel.TemplatesExecution[i].Question;
                    dataGridViewExecution.Rows[i].Cells[1].Value = currentProjectOfficeChecklistModel.TemplatesExecution[i].Answer;
                }

                for (int i = 0; i < currentProjectOfficeChecklistModel.TemplatesClosure.Count; i++)
                {
                    dataGridViewClosure.Rows.Add();
                    dataGridViewClosure.Rows[i].Cells[0].Value = currentProjectOfficeChecklistModel.TemplatesClosure[i].Question;
                    dataGridViewClosure.Rows[i].Cells[1].Value = currentProjectOfficeChecklistModel.TemplatesClosure[i].Answer;
                }

            }
            else
            {
                versionControl = new VersionControl<ProjectOfficeChecklistModel>();
                versionControl.DocumentModels = new List<VersionControl<ProjectOfficeChecklistModel>.DocumentModel>();
                List<string> premisesQuestion = new List<string>();
                premisesQuestion.Add("Were the Project Office requirements documented?");
                premisesQuestion.Add("Have the Project Office premises been procured?");
                premisesQuestion.Add("Are the premises in a practical location?");
                premisesQuestion.Add("Do the premises meet the requirements documented?");
                premisesQuestion.Add("Is there a formal contract for the lease / purchase / use of the premises?");
                premisesQuestion.Add("Do the premises provide sufficient space for the project team?");
                premisesQuestion.Add("Will the premises continue to be available if the project is delayed?");
                premisesQuestion.Add("Do the premises require additional fit-out (e.g. partitions, cabling, air conditioning)?");
                premisesQuestion.Add("Are the on-site facilities sufficient (e.g. number of meeting rooms, bathrooms)?");
                for (int i = 0; i < premisesQuestion.Count; i++)
                {
                    dataGridViewPremises.Rows.Add();
                    dataGridViewPremises.Rows[i].Cells[0].Value = premisesQuestion[i];
                    dataGridViewPremises.Rows[i].Cells[1].Value = false;
                }

                List<string> equipmentQuestion = new List<string>();
                equipmentQuestion.Add("Does the project team have the required office equipment and application software available to manage the project (e.g. computer hardware, project planning and financial software, projectors, fax machines, printers, scanners, copiers)?");
                equipmentQuestion.Add("Is spare equipment available in case of a shortage?");
                equipmentQuestion.Add("Is office equipment functioning as required?");
                equipmentQuestion.Add("Are sufficient communications technologies available (e.g. computer networks, email, internet access, remote network dial-up software, mobile phones, laptops and hand-held devices)?");
                equipmentQuestion.Add("Is video conferencing equipment available?");
                equipmentQuestion.Add("Is the equipment functioning as required?");
                for (int i = 0; i < equipmentQuestion.Count; i++)
                {
                    dataGridViewEquipment.Rows.Add();
                    dataGridViewEquipment.Rows[i].Cells[0].Value = equipmentQuestion[i];
                    dataGridViewEquipment.Rows[i].Cells[1].Value = false;
                }

                List<string> rolesQuestion = new List<string>();
                rolesQuestion.Add("Have the Project Sponsor been established?");
                rolesQuestion.Add("Have the Project Manager been appointed?");
                rolesQuestion.Add("Have the Project Office Manager been appointed?");
                rolesQuestion.Add("Have the Procurement Manager been appointed?");
                rolesQuestion.Add("Have the Communications Manager been appointed?");
                rolesQuestion.Add("Have the Quality Manager been appointed?");
                rolesQuestion.Add("Have the Risk Manager been appointed?");
                rolesQuestion.Add("Have the Team Leader(s) been appointed?");
                rolesQuestion.Add("Have Job Descriptions been documented for all the project roles?");
                rolesQuestion.Add("Do all Job Descriptions describe the responsibilities and performance criteria?");
                rolesQuestion.Add("Were suitably skilled people appointed to all the project roles?");

                for (int i = 0; i < rolesQuestion.Count; i++)
                {
                    dataGridViewRoles.Rows.Add();
                    dataGridViewRoles.Rows[i].Cells[0].Value = rolesQuestion[i];
                    dataGridViewRoles.Rows[i].Cells[1].Value = false;
                }

                List<string> standardsProcesses = new List<string>();
                standardsProcesses.Add("Have the required Industry standards (ISO) been identified?");
                standardsProcesses.Add("Have the required Health & Safety Standards been identified?");
                standardsProcesses.Add("Have the required Project Planning & Reporting Standards been identified?");
                standardsProcesses.Add("Have PMI® & PMBOK® been established?");
                standardsProcesses.Add("Has a suitable Project Management methodology been implemented?");

                standardsProcesses.Add("Have the Time Management Process been defined?");
                standardsProcesses.Add("Have the Cost Management Process been defined?");
                standardsProcesses.Add("Have the Quality Management Process been defined?");
                standardsProcesses.Add("Have the Change Management Process been defined?");
                standardsProcesses.Add("Have the Risk Management Process been defined?");
                standardsProcesses.Add("Have the Issue Management Process been defined?");
                standardsProcesses.Add("Have the Procurement Management Process been defined?");
                standardsProcesses.Add("Have the Acceptance Management Process been defined?");
                standardsProcesses.Add("Have the Communications Management Process been defined?");

                for (int i = 0; i < standardsProcesses.Count; i++)
                {
                    dataGridViewStandardsProcesses.Rows.Add();
                    dataGridViewStandardsProcesses.Rows[i].Cells[0].Value = standardsProcesses[i];
                    dataGridViewStandardsProcesses.Rows[i].Cells[1].Value = false;
                }

                List<string> templatesInit = new List<string>();
                templatesInit.Add("Is the Business Case template available?");
                templatesInit.Add("Is the Feasibility Study template available?");
                templatesInit.Add("Is the Terms of Reference template available?");
                templatesInit.Add("Is the Job Description template available?");
                templatesInit.Add("Is the Stage Gate Review Form template available?");
                for (int i = 0; i < templatesInit.Count; i++)
                {
                    dataGridViewInit.Rows.Add();
                    dataGridViewInit.Rows[i].Cells[0].Value = templatesInit[i];
                    dataGridViewInit.Rows[i].Cells[1].Value = false;
                }

                List<string> templatesPlans = new List<string>();
                templatesPlans.Add("Is the Project Plan template available?");
                templatesPlans.Add("Is the Resource Plan template available?");
                templatesPlans.Add("Is the Financial Plan template available?");
                templatesPlans.Add("Is the Quality Plan template available?");
                templatesPlans.Add("Is the Risk Plan template available?");
                templatesPlans.Add("Is the Acceptance Plan template available?");
                templatesPlans.Add("Is the Communications Plan template available?");
                templatesPlans.Add("Is the Procurement Plan template available?");
                templatesPlans.Add("Is the Supplier Contract template available?");
                templatesPlans.Add("Is the Tender Register template available?");
                for (int i = 0; i < templatesPlans.Count; i++)
                {
                    dataGridViewPlanning.Rows.Add();
                    dataGridViewPlanning.Rows[i].Cells[0].Value = templatesPlans[i];
                    dataGridViewPlanning.Rows[i].Cells[1].Value = false;
                }

                List<string> templatesExecution = new List<string>();
                templatesExecution.Add("Is the Acceptance Register template available?");
                templatesExecution.Add("Is the Timesheet Form and Timesheet Register template available?");
                templatesExecution.Add("Is the Expense Form and Expense Register template available?");
                templatesExecution.Add("Is the Quality Form and Deliverables Register template available?");
                templatesExecution.Add("Is the Change Form and Change Register template available?");
                templatesExecution.Add("Is the Risk Form and Risk Register template available?");
                templatesExecution.Add("Is the Issue Form and Issue Register template available?");
                templatesExecution.Add("Is the Purchase Order Form template available?");
                templatesExecution.Add("Is the Procurement Register template available?");
                templatesExecution.Add("Is the Project Status Report template available?");
                templatesExecution.Add("Is the Communications Register template available?");
                templatesExecution.Add("Is the Acceptance Form template available?");
                for (int i = 0; i < templatesExecution.Count; i++)
                {
                    dataGridViewExecution.Rows.Add();
                    dataGridViewExecution.Rows[i].Cells[0].Value = templatesExecution[i];
                    dataGridViewExecution.Rows[i].Cells[1].Value = false;
                }

                List<string> templatesClosure = new List<string>();
                templatesClosure.Add("Is the Project Closure Report template available?");
                templatesClosure.Add("Is the Post Implementation Review© template available?");
                for (int i = 0; i < templatesClosure.Count; i++)
                {
                    dataGridViewClosure.Rows.Add();
                    dataGridViewClosure.Rows[i].Cells[0].Value = templatesClosure[i];
                    dataGridViewClosure.Rows[i].Cells[1].Value = false;
                }
            }
        }

        private void ProjectOfficeChecklistDocumentForm_Load(object sender, EventArgs e)
        {   
            serviceText = "Time Management\n" +
            "	Monitoring the project progress by identifying time and effort spent vs. budgeted\n" +
            "	Keeping the Project Plan up-to-date and identifying any delivery date slippage\n" +
            "	Keeping the Timesheet Register up-to-date at all times\n" +
            "Cost Management\n" +
            "	Monitoring the project progress by identifying the budget spent vs. forecast\n" +
            "	Keeping the Project Plan up-to-date and identifying any overspending\n" +
            "	Keeping the Expense Register up-to-date at all times\n" +
            "Quality Management\n" +
            "	Performing Quality Assurance to improve the chances of delivering quality\n" +
            "	Ensuring that Quality Control is implemented to measure the actual level of quality\n" +
            "	Keeping the Deliverables Register up-to-date at all times\n" +
            "Change Management\n" +
            "	Receiving Change Requests and managing the change approval process\n" +
            "	Scheduling Change Requests and measuring the impact of changes implemented\n" +
            "	Keeping the Change Register up-to-date at all times\n" +
            "Risk Management\n" +
            "	Receiving Risk Forms and managing the risk review process\n" +
            "	Scheduling actions to mitigate risks and measuring the impact of such actions\n" +
            "	Keeping the Risk Register up-to-date at all times\n" +
            "Issue Management\n" +
            "	Receiving Issue Forms and managing the issue review process\n" +
            "	Scheduling actions to resolve issues and measuring the impact of such actions\n" +
            "	Keeping the Issue Register up-to-date at all times\n" +
            "Procurement Management\n" +
            "	Issuing Purchase Orders for the provision of goods and services from suppliers\n" +
            "	Receiving and accepting goods and services ordered from suppliers\n" +
            "	Keeping the Procurement Register up-to-date at all times\n" +
            "	Making payment to suppliers for goods and services delivered\n" +
            "	Managing the overall performance of suppliers to ensure that they complete their responsibilities as contracted\n" +
            "Acceptance Management\n" +
            "	Initiating Acceptance Reviews, as scheduled in the Acceptance Plan\n" +
            "	Documenting the results of each review by completing Acceptance Forms\n" +
            "	Gaining final acceptance from the customer for each deliverable produced\n" +
            "	Keeping the Acceptance Register up-to-date at all times\n" +
            "Communications Management\n" +
            "	Undertaking the communications tasks and events as listed in the Communications Plan\n" +
            "	Creating and releasing regular Project Status Reports\n" +
            "	Distributing press releases and managing Public Relations\n" +
            "	Keeping the Communications Register up-to-date at all times\n" +
            "Stage Gate Reviews\n" +
            "	Identifying the point in time when a Stage Gate must be undertaken\n" +
            "	Organizing the Stage Gate and recording the results on a Stage Gate Form\n" +
            "Auditing and Compliance\n" +
            "	Ensuring that the project conforms to appropriate industry and business policies, processes, standards and guidelines\n" +
            "	Informing the Project Manager of any deviations and monitoring the results of any actions taken to correct them\n" +
            "Supporting Staff\n" +
            "	Assisting the Project Manager with the recruitment of new staff\n" +
            "	Supporting and advising staff, resolving staff issues and providing staff training\n" +
            "	Paying staff in accordance with their contracts and administering leave\n" +
            "Providing Tools\n" +
            "	Procuring a suitable Project Management methodology\n" +
            "	Procuring tools for project planning, monitoring, controlling and reporting\n" +
            "	Training staff in the use of these tools and methodology Filing Documents\n" +
            "	Keeping a library of all project documents, reports, job descriptions, correspondence, standards, processes, registers, forms and templates\n" +
            "	Implementing an indexing method to ensure that project documentation may be easily sourced when required\n" +
             "Performing Administration\n" +
            "	Providing administration services such as the organization of travel bookings, room bookings, photocopying, secretarial, mail and correspondence\n" +
            "	Purchasing all office equipment and materials needed by the project\n" +
            "Undertaking Closure Reviews\n" +
            "	Organizing the completion of a Post Implementation Review after Project Closure\n" +
            "	Communicating the results of the review to the appropriate project stakeholders\n";
            string json = JsonHelper.loadProjectInfo(Settings.Default.Username);
            List<ProjectModel> projectListModel = JsonConvert.DeserializeObject<List<ProjectModel>>(json);
            projectModel = projectModel.getProjectModel(Settings.Default.ProjectID, projectListModel);
            richTextBoxServices.Text = serviceText;
            txtProjectName.Text = projectModel.ProjectName;
            txtProjectManager.Text = projectModel.ProjectManager;
            txtProjectOfficeManager.Text = projectModel.QualityManager;
            textBox1.Text = projectModel.ProjectName;

            loadDocument();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveDocument();
        }

        private void btnExportWord_Click(object sender, EventArgs e)
        {
            exportToWord();
        }

        public string returnYesNo(bool answer) 
        {
            if (answer)
            {
                return "Yes";
            }
            else
            {
                return "No";
            }
        }
        public void exportToWord()
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
                        document.InsertParagraph("Project Office Checklist \nFor " + projectModel.ProjectName)
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(22d).Alignment = Alignment.left;
                        document.InsertSectionPageBreak();

                        document.InsertParagraph("Project Office Checklist\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;

                        var documentTable = document.AddTable(18, 1);

                        documentTable.Rows[0].Cells[0].Paragraphs[0]
                            .Append("Project Details")
                            .Bold(true)
                            .Font("Arial")
                            .FontSize(11d)
                            .Color(Color.White)
                            .SpacingBefore(6d)
                            .SpacingAfter(6d);
                        documentTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;

                        documentTable.Rows[1].Cells[0].Paragraphs[0]
                          .Append("Project Name: " + projectModel.ProjectName + "\nProject Manager: " + currentProjectOfficeChecklistModel.ProjectManager +
                          "\nProject Office Manager: "+currentProjectOfficeChecklistModel.ProjectOfficeManager)
                          .Font("Arial")
                          .FontSize(11d)
                          .SpacingBefore(12d)
                          .SpacingAfter(12d);

                        documentTable.Rows[2].Cells[0].Paragraphs[0]
                            .Append("Premises")
                            .Bold(true)
                            .Font("Arial")
                            .FontSize(11d)
                            .Color(Color.White)
                            .SpacingBefore(6d)
                            .SpacingAfter(6d);
                        documentTable.Rows[2].Cells[0].FillColor = TABLE_HEADER_COLOR;

                       
                       

                        var premisesTable = document.AddTable(currentProjectOfficeChecklistModel.Premises.Count, 2);
                        for (int i = 0; i < currentProjectOfficeChecklistModel.Premises.Count; i++)
                        {
                            premisesTable.Rows[i].Cells[0].Paragraphs[0]
                                .Append(currentProjectOfficeChecklistModel.Premises[i].Question)
                                .Font("Arial")
                                .FontSize(11d)
                                .SpacingBefore(12d)
                                .SpacingAfter(12d);
                            premisesTable.Rows[i].Cells[1].Paragraphs[0]
                                .Append(returnYesNo(currentProjectOfficeChecklistModel.Premises[i].Answer))
                                .Font("Arial")
                                .FontSize(11d)
                                .SpacingBefore(12d)
                                .SpacingAfter(12d);
                        }
                        premisesTable.SetWidths(new float [] {1399, 125}); 
                        documentTable.Rows[3].Cells[0].InsertTable(premisesTable);


                        documentTable.SetWidths(new float[] { 1690 });

                        documentTable.Rows[4].Cells[0].Paragraphs[0]
                            .Append("Equipment")
                            .Bold(true)
                            .Font("Arial")
                            .FontSize(11d)
                            .Color(Color.White)
                            .SpacingBefore(6d)
                            .SpacingAfter(6d);
                        documentTable.Rows[4].Cells[0].FillColor = TABLE_HEADER_COLOR;

                        var EquipmentTable = document.AddTable(currentProjectOfficeChecklistModel.Equipment.Count, 2);
                        for (int i = 0; i < currentProjectOfficeChecklistModel.Equipment.Count; i++)
                        {
                            EquipmentTable.Rows[i].Cells[0].Paragraphs[0]
                                .Append(currentProjectOfficeChecklistModel.Equipment[i].Question)
                                .Font("Arial")
                                .FontSize(11d)
                                .SpacingBefore(12d)
                                .SpacingAfter(12d);
                            EquipmentTable.Rows[i].Cells[1].Paragraphs[0]
                                .Append(returnYesNo(currentProjectOfficeChecklistModel.Equipment[i].Answer))
                                .Font("Arial")
                                .FontSize(11d)
                                .SpacingBefore(12d)
                                .SpacingAfter(12d);
                        }
                        EquipmentTable.SetWidths(new float[] { 1399, 125 });
                        documentTable.Rows[5].Cells[0].InsertTable(EquipmentTable);

                        documentTable.Rows[6].Cells[0].Paragraphs[0]
                           .Append("Standards & Processes")
                           .Bold(true)
                           .Font("Arial")
                           .FontSize(11d)
                           .Color(Color.White)
                           .SpacingBefore(6d)
                           .SpacingAfter(6d);
                        documentTable.Rows[6].Cells[0].FillColor = TABLE_HEADER_COLOR;

                        var StandardsTable = document.AddTable(currentProjectOfficeChecklistModel.StandardsProcesses.Count, 2);
                        for (int i = 0; i < currentProjectOfficeChecklistModel.StandardsProcesses.Count; i++)
                        {
                            StandardsTable.Rows[i].Cells[0].Paragraphs[0]
                                .Append(currentProjectOfficeChecklistModel.StandardsProcesses[i].Question)
                                .Font("Arial")
                                .FontSize(11d)
                                .SpacingBefore(12d)
                                .SpacingAfter(12d);
                            StandardsTable.Rows[i].Cells[1].Paragraphs[0]
                                .Append(returnYesNo(currentProjectOfficeChecklistModel.StandardsProcesses[i].Answer))
                                .Font("Arial")
                                .FontSize(11d)
                                .SpacingBefore(12d)
                                .SpacingAfter(12d);
                        }
                        StandardsTable.SetWidths(new float[] { 1399, 125 });
                        documentTable.Rows[7].Cells[0].InsertTable(StandardsTable);

                        documentTable.Rows[8].Cells[0].Paragraphs[0]
                          .Append("Templates - Initiation")
                          .Bold(true)
                          .Font("Arial")
                          .FontSize(11d)
                          .Color(Color.White)
                          .SpacingBefore(6d)
                          .SpacingAfter(6d);
                        documentTable.Rows[8].Cells[0].FillColor = TABLE_HEADER_COLOR;

                        var initTable = document.AddTable(currentProjectOfficeChecklistModel.TemplatesInitiation.Count, 2);
                        for (int i = 0; i < currentProjectOfficeChecklistModel.TemplatesInitiation.Count; i++)
                        {
                            initTable.Rows[i].Cells[0].Paragraphs[0]
                                .Append(currentProjectOfficeChecklistModel.TemplatesInitiation[i].Question)
                                .Font("Arial")
                                .FontSize(11d)
                                .SpacingBefore(12d)
                                .SpacingAfter(12d);
                            initTable.Rows[i].Cells[1].Paragraphs[0]
                                .Append(returnYesNo(currentProjectOfficeChecklistModel.TemplatesInitiation[i].Answer))
                                .Font("Arial")
                                .FontSize(11d)
                                .SpacingBefore(12d)
                                .SpacingAfter(12d);
                        }
                        initTable.SetWidths(new float[] { 1399, 125 });
                        documentTable.Rows[9].Cells[0].InsertTable(initTable);

                        documentTable.Rows[10].Cells[0].Paragraphs[0]
                           .Append("Templates - Planning")
                           .Bold(true)
                           .Font("Arial")
                           .FontSize(11d)
                           .Color(Color.White)
                           .SpacingBefore(6d)
                           .SpacingAfter(6d);
                        documentTable.Rows[10].Cells[0].FillColor = TABLE_HEADER_COLOR;

                        var planningTable = document.AddTable(currentProjectOfficeChecklistModel.TemplatesPlanning.Count, 2);
                        for (int i = 0; i < currentProjectOfficeChecklistModel.TemplatesPlanning.Count; i++)
                        {
                            planningTable.Rows[i].Cells[0].Paragraphs[0]
                                .Append(currentProjectOfficeChecklistModel.TemplatesPlanning[i].Question)
                                .Font("Arial")
                                .FontSize(11d)
                                .SpacingBefore(12d)
                                .SpacingAfter(12d);
                            planningTable.Rows[i].Cells[1].Paragraphs[0]
                                .Append(returnYesNo(currentProjectOfficeChecklistModel.TemplatesPlanning[i].Answer))
                                .Font("Arial")
                                .FontSize(11d)
                                .SpacingBefore(12d)
                                .SpacingAfter(12d);
                        }
                        planningTable.SetWidths(new float[] { 1399, 125 });
                        documentTable.Rows[11].Cells[0].InsertTable(planningTable);

                        documentTable.Rows[12].Cells[0].Paragraphs[0]
                           .Append("Templates - Execution")
                           .Bold(true)
                           .Font("Arial")
                           .FontSize(11d)
                           .Color(Color.White)
                           .SpacingBefore(6d)
                           .SpacingAfter(6d);
                        documentTable.Rows[12].Cells[0].FillColor = TABLE_HEADER_COLOR;

                        var executionTable = document.AddTable(currentProjectOfficeChecklistModel.TemplatesExecution.Count, 2);
                        for (int i = 0; i < currentProjectOfficeChecklistModel.TemplatesExecution.Count; i++)
                        {
                            executionTable.Rows[i].Cells[0].Paragraphs[0]
                                .Append(currentProjectOfficeChecklistModel.TemplatesExecution[i].Question)
                                .Font("Arial")
                                .FontSize(11d)
                                .SpacingBefore(12d)
                                .SpacingAfter(12d);
                            executionTable.Rows[i].Cells[1].Paragraphs[0]
                                .Append(returnYesNo(currentProjectOfficeChecklistModel.TemplatesExecution[i].Answer))
                                .Font("Arial")
                                .FontSize(11d)
                                .SpacingBefore(12d)
                                .SpacingAfter(12d);
                        }
                        executionTable.SetWidths(new float[] { 1399, 125 });
                        documentTable.Rows[13].Cells[0].InsertTable(executionTable);

                        documentTable.Rows[14].Cells[0].Paragraphs[0]
                           .Append("Templates - Closure")
                           .Bold(true)
                           .Font("Arial")
                           .FontSize(11d)
                           .Color(Color.White)
                           .SpacingBefore(6d)
                           .SpacingAfter(6d);
                        documentTable.Rows[14].Cells[0].FillColor = TABLE_HEADER_COLOR;

                        var closureTable = document.AddTable(currentProjectOfficeChecklistModel.TemplatesClosure.Count, 2);
                        for (int i = 0; i < currentProjectOfficeChecklistModel.TemplatesClosure.Count; i++)
                        {
                            closureTable.Rows[i].Cells[0].Paragraphs[0]
                                .Append(currentProjectOfficeChecklistModel.TemplatesClosure[i].Question)
                                .Font("Arial")
                                .FontSize(11d)
                                .SpacingBefore(12d)
                                .SpacingAfter(12d);
                            closureTable.Rows[i].Cells[1].Paragraphs[0]
                                .Append(returnYesNo(currentProjectOfficeChecklistModel.TemplatesClosure[i].Answer))
                                .Font("Arial")
                                .FontSize(11d)
                                .SpacingBefore(12d)
                                .SpacingAfter(12d);
                        }
                        closureTable.SetWidths(new float[] { 1399, 125 });
                        documentTable.Rows[15].Cells[0].InsertTable(closureTable);

                        documentTable.Rows[16].Cells[0].Paragraphs[0]
                           .Append("Services")
                           .Bold(true)
                           .Font("Arial")
                           .FontSize(11d)
                           .Color(Color.White)
                           .SpacingBefore(6d)
                           .SpacingAfter(6d);
                        documentTable.Rows[16].Cells[0].FillColor = TABLE_HEADER_COLOR;


                        documentTable.Rows[17].Cells[0].Paragraphs[0].Append(serviceText)
                           .FontSize(11d)
                           .Color(Color.Black)
                           .Font("Arial").Alignment = Alignment.left;





                        document.InsertTable(documentTable);
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
