﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectManagementToolkit.MPMM.MPMM_Document_Models;
using ProjectManagementToolkit.Utility;
using ProjectManagementToolkit.Properties;
using Newtonsoft.Json;
using MoreLinq;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class TermOfReferenceDocumentForm : Form
    {
        VersionControl<TermsOfReferenceModel> versionControl;
        TermsOfReferenceModel newTermsOfReferenceModel;
        TermsOfReferenceModel currentTermsOfReferenceModel;

        public TermOfReferenceDocumentForm()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void tabAppendix_Click(object sender, EventArgs e)
        {

        }

        private void TermOfReferenceDocumentForm_Load(object sender, EventArgs e)
        {
            loadDocument();
        }

        public void saveDocument()
        {
            List<TermsOfReferenceModel.Deliverables> Deliv = new List<TermsOfReferenceModel.Deliverables>();

            int delivRowsCount = dgvDeliverables.Rows.Count;

            for (int i = 0; i < delivRowsCount - 1; i++)
            {
                TermsOfReferenceModel.Deliverables deliv = new TermsOfReferenceModel.Deliverables();
                var Deliverable = dgvDeliverables.Rows[i].Cells[0].Value?.ToString() ?? "";
                var Components = dgvDeliverables.Rows[i].Cells[1].Value?.ToString() ?? "";
                var Description = dgvDeliverables.Rows[i].Cells[2].Value?.ToString() ?? "";

                deliv.Deliverable = Deliverable;
                deliv.Components = Components;
                deliv.Description = Description;

                Deliv.Add(deliv);
            }
            newTermsOfReferenceModel.Deliv = Deliv;

            List<TermsOfReferenceModel.Customers> Cust = new List<TermsOfReferenceModel.Customers>();

            int cusRowsCount = dgvDeliverables.Rows.Count;

            for (int i = 0; i < delivRowsCount - 1; i++)
            {
                TermsOfReferenceModel.Customers custo = new TermsOfReferenceModel.Customers();
                var CustomerGroup = dgvDeliverables.Rows[i].Cells[0].Value?.ToString() ?? "";
                var CustomerRepresentative = dgvDeliverables.Rows[i].Cells[1].Value?.ToString() ?? "";

                custo.CustomerGroup = CustomerGroup;
                custo.CustomerRepresentative = CustomerRepresentative;
                

                Cust.Add(custo);
            }
            newTermsOfReferenceModel.Cust = Cust;

            List<TermsOfReferenceModel.Stakeholders> Stake = new List<TermsOfReferenceModel.Stakeholders>();

            int stakeRowsCount = dgvDeliverables.Rows.Count;

            for (int i = 0; i < stakeRowsCount - 1; i++)
            {
                TermsOfReferenceModel.Stakeholders stak = new TermsOfReferenceModel.Stakeholders();
                var StakeholdersGroup = dgvDeliverables.Rows[i].Cells[0].Value?.ToString() ?? "";
                var StakeholderInterest = dgvDeliverables.Rows[i].Cells[1].Value?.ToString() ?? "";

                stak.StakeholdersGroup = StakeholdersGroup;
                stak.StakeholderInterest = StakeholderInterest;


                Stake.Add(stak);
            }
            newTermsOfReferenceModel.Stake = Stake;

            List<TermsOfReferenceModel.Roles> Rol = new List<TermsOfReferenceModel.Roles>();

            int roleRowsCount = dgvDeliverables.Rows.Count;

            for (int i = 0; i < roleRowsCount - 1; i++)
            {
                TermsOfReferenceModel.Roles rolls = new TermsOfReferenceModel.Roles();
                var Role = dgvDeliverables.Rows[i].Cells[0].Value?.ToString() ?? "";
                var ResourceName = dgvDeliverables.Rows[i].Cells[1].Value?.ToString() ?? "";
                var Organization = dgvDeliverables.Rows[i].Cells[0].Value?.ToString() ?? "";
                var AssignmentStatus = dgvDeliverables.Rows[i].Cells[1].Value?.ToString() ?? "";
                var AssignmentDate = dgvDeliverables.Rows[i].Cells[1].Value?.ToString() ?? "";

                rolls.Role = Role;
                rolls.ResourceName = ResourceName;
                rolls.Organization = Organization;
                rolls.AssignmentStatus = AssignmentStatus;
                rolls.AssignmentDate = AssignmentDate;


                Rol.Add(rolls);
            }
            newTermsOfReferenceModel.Rol = Rol;

            List<TermsOfReferenceModel.Approach> Appr = new List<TermsOfReferenceModel.Approach>();

            int apprRowsCount = dgvDeliverables.Rows.Count;

            for (int i = 0; i < apprRowsCount - 1; i++)
            {
                TermsOfReferenceModel.Approach app = new TermsOfReferenceModel.Approach();
                var Phase = dgvDeliverables.Rows[i].Cells[0].Value?.ToString() ?? "";
                var OverallApproach = dgvDeliverables.Rows[i].Cells[1].Value?.ToString() ?? "";
                
                app.Phase = Phase;
                app.OverallApproach = OverallApproach;

                Appr.Add(app);
            }
            newTermsOfReferenceModel.Appr = Appr;

            List<TermsOfReferenceModel.Milestones> Mile = new List<TermsOfReferenceModel.Milestones>();

            int milRowsCount = dgvDeliverables.Rows.Count;

            for (int i = 0; i < milRowsCount - 1; i++)
            {
                TermsOfReferenceModel.Milestones mil = new TermsOfReferenceModel.Milestones();
                var Milestone = dgvDeliverables.Rows[i].Cells[0].Value?.ToString() ?? "";
                var Date = dgvDeliverables.Rows[i].Cells[1].Value?.ToString() ?? "";
                var Description = dgvDeliverables.Rows[i].Cells[0].Value?.ToString() ?? "";
                
                mil.Milestone = Milestone;
                mil.Date = Date;
                mil.Description = Description;

                Mile.Add(mil);
            }
            newTermsOfReferenceModel.Mile = Mile;

            List<TermsOfReferenceModel.Dependencies> Dep = new List<TermsOfReferenceModel.Dependencies>();

            int depRowsCount = dgvDeliverables.Rows.Count;

            for (int i = 0; i < depRowsCount - 1; i++)
            {
                TermsOfReferenceModel.Dependencies depe = new TermsOfReferenceModel.Dependencies();
                var ProjectActivity = dgvDeliverables.Rows[i].Cells[0].Value?.ToString() ?? "";
                var Impacts = dgvDeliverables.Rows[i].Cells[1].Value?.ToString() ?? "";
                var ImpactedBy = dgvDeliverables.Rows[i].Cells[0].Value?.ToString() ?? "";
                var Critically = dgvDeliverables.Rows[i].Cells[1].Value?.ToString() ?? "";
                var Date = dgvDeliverables.Rows[i].Cells[1].Value?.ToString() ?? "";

                depe.ProjectActivity = ProjectActivity;
                depe.Impacts = Impacts;
                depe.ImpactedBy = ImpactedBy;
                depe.Critically = Critically;
                depe.Date = Date;

                Dep.Add(depe);
            }
            newTermsOfReferenceModel.Dep = Dep;

            List<TermsOfReferenceModel.ResourcePlan> ResP = new List<TermsOfReferenceModel.ResourcePlan>();

            int resRowsCount = dgvDeliverables.Rows.Count;

            for (int i = 0; i < resRowsCount - 1; i++)
            {
                TermsOfReferenceModel.ResourcePlan resou = new TermsOfReferenceModel.ResourcePlan();
                var Role = dgvDeliverables.Rows[i].Cells[0].Value?.ToString() ?? "";
                var StartDate = dgvDeliverables.Rows[i].Cells[1].Value?.ToString() ?? "";
                var EndDate = dgvDeliverables.Rows[i].Cells[0].Value?.ToString() ?? "";
                var Effort = dgvDeliverables.Rows[i].Cells[1].Value?.ToString() ?? "";
          
                resou.Role = Role;
                resou.StartDate = StartDate;
                resou.EndDate = EndDate;
                resou.Effort = Effort;

                ResP.Add(resou);
            }
            newTermsOfReferenceModel.ResP = ResP;

            List<TermsOfReferenceModel.FinancialPlan> FinP = new List<TermsOfReferenceModel.FinancialPlan>();

            int finRowsCount = dgvDeliverables.Rows.Count;

            for (int i = 0; i < finRowsCount - 1; i++)
            {
                TermsOfReferenceModel.FinancialPlan fin = new TermsOfReferenceModel.FinancialPlan();
                var ExpenditureCategory = dgvDeliverables.Rows[i].Cells[0].Value?.ToString() ?? "";
                var ExpenditureItem = dgvDeliverables.Rows[i].Cells[1].Value?.ToString() ?? "";
                var ExpenditureValue = dgvDeliverables.Rows[i].Cells[1].Value?.ToString() ?? "";

                fin.ExpenditureCategory = ExpenditureCategory;
                fin.ExpenditureItem = ExpenditureItem;
                fin.ExpenditureValue = ExpenditureValue;

                FinP.Add(fin);
            }
            newTermsOfReferenceModel.FinP = FinP;

            List<TermsOfReferenceModel.QualityPlan> QuaP = new List<TermsOfReferenceModel.QualityPlan>();

            int quaRowsCount = dgvDeliverables.Rows.Count;

            for (int i = 0; i < quaRowsCount - 1; i++)
            {
                TermsOfReferenceModel.QualityPlan qua = new TermsOfReferenceModel.QualityPlan();
                var ExpenditureCategory = dgvDeliverables.Rows[i].Cells[0].Value?.ToString() ?? "";
                var ExpenditureItem = dgvDeliverables.Rows[i].Cells[1].Value?.ToString() ?? "";

                qua.Process = ExpenditureCategory;
                qua.Description = ExpenditureItem;

                QuaP.Add(qua);
            }
            newTermsOfReferenceModel.QuaP = QuaP;

            List<TermsOfReferenceModel.CompletionCriteria> CompC = new List<TermsOfReferenceModel.CompletionCriteria>();

            int comRowsCount = dgvDeliverables.Rows.Count;

            for (int i = 0; i < quaRowsCount - 1; i++)
            {
                TermsOfReferenceModel.CompletionCriteria com = new TermsOfReferenceModel.CompletionCriteria();
                var Process = dgvDeliverables.Rows[i].Cells[0].Value?.ToString() ?? "";
                var Description = dgvDeliverables.Rows[i].Cells[1].Value?.ToString() ?? "";

                com.Process = Process;
                com.Description = Description;

                CompC.Add(com);
            }
            newTermsOfReferenceModel.CompC = CompC;

            List<TermsOfReferenceModel.Risks> Risk = new List<TermsOfReferenceModel.Risks>();

            int risRowsCount = dgvDeliverables.Rows.Count;

            for (int i = 0; i < risRowsCount - 1; i++)
            {
                TermsOfReferenceModel.Risks ris = new TermsOfReferenceModel.Risks();
                var Role = dgvDeliverables.Rows[i].Cells[0].Value?.ToString() ?? "";
                var StartDate = dgvDeliverables.Rows[i].Cells[1].Value?.ToString() ?? "";
                var EndDate = dgvDeliverables.Rows[i].Cells[0].Value?.ToString() ?? "";
                var Effort = dgvDeliverables.Rows[i].Cells[1].Value?.ToString() ?? "";

                ris.RiskDesc = Role;
                ris.RiskLikelihood = StartDate;
                ris.RiskImpact = EndDate;
                ris.Action = Effort;

                Risk.Add(ris);
            }
            newTermsOfReferenceModel.Risk = Risk;

            List<TermsOfReferenceModel.Issues> Issuess = new List<TermsOfReferenceModel.Issues>();

            int issRowsCount = dgvDeliverables.Rows.Count;

            for (int i = 0; i < issRowsCount - 1; i++)
            {
                TermsOfReferenceModel.Issues iss = new TermsOfReferenceModel.Issues();
                var IssueDescription = dgvDeliverables.Rows[i].Cells[0].Value?.ToString() ?? "";
                var IssuePriority = dgvDeliverables.Rows[i].Cells[1].Value?.ToString() ?? "";
                var Action = dgvDeliverables.Rows[i].Cells[0].Value?.ToString() ?? "";

                iss.IssueDescription = IssueDescription;
                iss.IssuePriority = IssuePriority;
                iss.Action = Action;

                Issuess.Add(iss);
            }
            newTermsOfReferenceModel.Risk = Risk;
        }

         

        private void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "TermsOfReference");
            List<string[]> documentInfo = new List<string[]>();
            newTermsOfReferenceModel = new TermsOfReferenceModel();
            currentTermsOfReferenceModel = new TermsOfReferenceModel();

            if (json != "")
            {
                newTermsOfReferenceModel.DocumentID = dgvDocumentInformation.Rows[0].Cells[1].Value.ToString();
                newTermsOfReferenceModel.DocumentOwner = dgvDocumentInformation.Rows[1].Cells[1].Value.ToString();
                newTermsOfReferenceModel.IssueDate = dgvDocumentInformation.Rows[2].Cells[1].Value.ToString();
                newTermsOfReferenceModel.LastSavedDate = dgvDocumentInformation.Rows[3].Cells[1].Value.ToString();
                newTermsOfReferenceModel.FileName = dgvDocumentInformation.Rows[4].Cells[1].Value.ToString();

                List<TermsOfReferenceModel.DocumentHistory> documentHistories = new List<TermsOfReferenceModel.DocumentHistory>();

                int versionRowsCount = dgvDocumentHistory.Rows.Count;

                for (int i = 0; i < versionRowsCount - 1; i++)
                {
                    TermsOfReferenceModel.DocumentHistory documentHistoryModel = new TermsOfReferenceModel.DocumentHistory();
                    var version = dgvDocumentHistory.Rows[i].Cells[0].Value?.ToString() ?? "";
                    var issueDate = dgvDocumentHistory.Rows[i].Cells[1].Value?.ToString() ?? "";
                    var changes = dgvDocumentHistory.Rows[i].Cells[2].Value?.ToString() ?? "";
                    documentHistoryModel.Version = version;
                    documentHistoryModel.IssueDate = issueDate;
                    documentHistoryModel.Changes = changes;
                    documentHistories.Add(documentHistoryModel);
                }
                newTermsOfReferenceModel.DocumentHistories = documentHistories;

                List<TermsOfReferenceModel.DocumentApproval> documentApprovalsModel = new List<TermsOfReferenceModel.DocumentApproval>();

                int approvalRowsCount = dgvDocumentApprovals.Rows.Count;

                for (int i = 0; i < approvalRowsCount - 1; i++)
                {
                    TermsOfReferenceModel.DocumentApproval documentApproval = new TermsOfReferenceModel.DocumentApproval();
                    var role = dgvDocumentApprovals.Rows[i].Cells[0].Value?.ToString() ?? "";
                    var name = dgvDocumentApprovals.Rows[i].Cells[1].Value?.ToString() ?? "";
                    var signature = dgvDocumentApprovals.Rows[i].Cells[2].Value?.ToString() ?? "";
                    var date = dgvDocumentApprovals.Rows[i].Cells[3].Value?.ToString() ?? "";
                    documentApproval.Role = role;
                    documentApproval.Name = name;
                    documentApproval.Signature = signature;
                    documentApproval.DateApproved = date;

                    documentApprovalsModel.Add(documentApproval);
                }
                newTermsOfReferenceModel.DocumentApprovals = documentApprovalsModel;

                txtExecutiveSummary.Text = currentTermsOfReferenceModel.ExecutiveSummary;

                txtProjectDefinition.Text = currentTermsOfReferenceModel.ProjDefinition;
                txtVision.Text = currentTermsOfReferenceModel.Vision;
                txtObjectives.Text = currentTermsOfReferenceModel.Objectives;
                txtScope.Text = currentTermsOfReferenceModel.Scope;

                txtResponsibilities.Text = currentTermsOfReferenceModel.Responsibilities;
                txtStructure.Text = currentTermsOfReferenceModel.Structure;

                txtSchedule.Text = currentTermsOfReferenceModel.Schedule;

                txtAssumptions.Text = currentTermsOfReferenceModel.Assumptions;
                txtConstraints.Text = currentTermsOfReferenceModel.Constraints;

            }
            else
            {
                versionControl = new VersionControl<TermsOfReferenceModel>();
                versionControl.DocumentModels = new List<VersionControl<TermsOfReferenceModel>.DocumentModel>();
                documentInfo.Add(new string[] { "Document ID", "" });
                documentInfo.Add(new string[] { "Document Owner", "" });
                documentInfo.Add(new string[] { "Issue Date", "" });
                documentInfo.Add(new string[] { "Last Save Date", "" });
                documentInfo.Add(new string[] { "File Name", "" });
                newTermsOfReferenceModel = new TermsOfReferenceModel();
                foreach (var row in documentInfo)
                {
                    dgvDocumentInformation.Rows.Add(row);
                }
                dgvDocumentInformation.AllowUserToAddRows = false;
            }
        }
    }
}
