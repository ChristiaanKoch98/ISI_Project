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
    public partial class ProjectPlanVC : Form
    {
        VersionControl<ProjectPlanModel> versionControl;
        ProjectModel projectModel = new ProjectModel();
        public ProjectPlanVC()
        {
            InitializeComponent();
        }



        private void ProjectPlanDocumentForm_Load(object sender, EventArgs e)
        {
           
            string json = JsonHelper.loadProjectInfo(Settings.Default.Username);
            List<ProjectModel> projectListModel = JsonConvert.DeserializeObject<List<ProjectModel>>(json);
            projectModel = projectModel.getProjectModel(Settings.Default.ProjectID, projectListModel);
            string projectPlanJson = JsonHelper.loadDocument(Settings.Default.ProjectID, "ProjectPlan");
            versionControl = JsonConvert.DeserializeObject<VersionControl<ProjectPlanModel>>(projectPlanJson);
            for (int i = 0; i < versionControl.DocumentModels.Count; i++)
            {
                cmbVersions.Items.Add("Version" + (i + 1));
            }
            cmbVersions.SelectedIndex = 0;

            //tabControl collor
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl1.SizeMode = TabSizeMode.Fixed;
            Size tab_size = tabControl1.ItemSize;
            tab_size.Width = 100;
            tab_size.Height += 15;
            tabControl1.ItemSize = tab_size;

            tabControl3.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl3.SizeMode = TabSizeMode.Fixed;
            Size tab_size2 = tabControl3.ItemSize;
            tab_size2.Width = 100;
            tab_size2.Height += 15;
            tabControl3.ItemSize = tab_size2;
        }

        private int Xwid = 8;
        private const int tab_margin = 3;

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Brush txt_brush, box_brush;
            Pen box_pen;

            Rectangle tab_rect = tabControl1.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(209,237,242)), tab_rect);
                e.DrawFocusRectangle();

                txt_brush = Brushes.Black;
                box_brush = Brushes.Black;
                box_pen = Pens.DarkBlue;
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(73, 173, 252)), tab_rect);

                txt_brush = Brushes.Black;
                box_brush = Brushes.Black;
                box_pen = Pens.DarkBlue;
            }

            RectangleF layout_rect = new RectangleF(
            tab_rect.Left + tab_margin,
            tab_rect.Y + tab_margin,
            tab_rect.Width - 2 * tab_margin,
            tab_rect.Height - 2 * tab_margin);

            using (StringFormat string_format = new StringFormat())
            {
                using (System.Drawing.Font big_font = new System.Drawing.Font(this.Font, FontStyle.Bold))
                {
                    string_format.Alignment = StringAlignment.Center;
                    string_format.LineAlignment = StringAlignment.Center;
                    e.Graphics.DrawString(
                        tabControl1.TabPages[e.Index].Text,
                        big_font,
                        txt_brush,
                        layout_rect,
                        string_format);
                }
            }
        }

        private void tabControl3_DrawItem(object sender, DrawItemEventArgs e)
        {
            Brush txt_brush, box_brush;
            Pen box_pen;

            Rectangle tab_rect = tabControl3.GetTabRect(e.Index);

           

            if (e.State == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(209, 237, 242)), tab_rect);
                e.DrawFocusRectangle();

                txt_brush = Brushes.Black;
                box_brush = Brushes.Black;
                box_pen = Pens.DarkBlue;
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(73, 173, 252)), tab_rect);

                txt_brush = Brushes.Black;
                box_brush = Brushes.Black;
                box_pen = Pens.DarkBlue;
            }

            RectangleF layout_rect = new RectangleF(
            tab_rect.Left + tab_margin,
            tab_rect.Y + tab_margin,
            tab_rect.Width - 2 * tab_margin,
            tab_rect.Height - 2 * tab_margin);


            using (StringFormat string_format = new StringFormat())
            {
                using (System.Drawing.Font big_font = new System.Drawing.Font(this.Font, FontStyle.Bold))
                {
                    string_format.Alignment = StringAlignment.Center;
                    string_format.LineAlignment = StringAlignment.Center;
                    e.Graphics.DrawString(
                        tabControl3.TabPages[e.Index].Text,
                        big_font,
                        txt_brush,
                        layout_rect,
                        string_format);
                }
            }
        }

        private void cmbVersions_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProjectPlanModel currentVersion = versionControl.DocumentModels[cmbVersions.SelectedIndex].DocumentObject;
            loadDocument(currentVersion);
        }

        private void loadDocument(ProjectPlanModel projectPlanModel)
        {

            List<string[]> documentInfo = new List<string[]>();
            documentInfo.Add(new string[] { "Document ID", projectPlanModel.DocumentID });
            documentInfo.Add(new string[] { "Document Owner", projectPlanModel.DocumentOwner });
            documentInfo.Add(new string[] { "Issue Date", projectPlanModel.IssueDate });
            documentInfo.Add(new string[] { "Last Save Date", projectPlanModel.LastSavedDate });
            documentInfo.Add(new string[] { "File Name", projectPlanModel.FileName });

            documentInformation.Rows.Clear();
            foreach (var row in documentInfo)
            {
                documentInformation.Rows.Add(row);
            }
            documentInformation.AllowUserToAddRows = false;

            documentHistoryDataGridView.Rows.Clear();
            foreach (var row in projectPlanModel.DocumentHistories)
            {
                documentHistoryDataGridView.Rows.Add(new string[] { row.Version, row.IssueDate, row.Changes });
            }

            documentApprovalsDataGridView.Rows.Clear();
            foreach (var row in projectPlanModel.DocumentApprovals)
            {
                documentApprovalsDataGridView.Rows.Add(new string[] { row.Role, row.Name, "", row.DateApproved });
            }

            phasesDataGridView.Rows.Clear();
            foreach (var row in projectPlanModel.Phases)
            {
                phasesDataGridView.Rows.Add(new string[] { row.PhaseTitle, row.PhaseDescription, row.PhaseSequence });
            }

            activitiesDataGridView.Rows.Clear();
            foreach (var row in projectPlanModel.Activities)
            {
                activitiesDataGridView.Rows.Add(new string[] { row.PhaseTitle, row.ActivityTitle, row.ActivityDescription, row.ActivitySequence });
            }

            tasksDataGridView.Rows.Clear();
            foreach (var row in projectPlanModel.Tasks)
            {
                tasksDataGridView.Rows.Add(new string[] { row.ActivityTitle, row.TaskTitle, row.TaskDescription, row.TaskSequence });
            }

            milestonesDataGridView.Rows.Clear();
            foreach (var row in projectPlanModel.Milestones)
            {
                milestonesDataGridView.Rows.Add(new string[] { row.MilestoneTitle, row.MilestoneDescription, row.MilestoneDate });
            }

            effortDataGridView.Rows.Clear();
            foreach (var row in projectPlanModel.Efforts)
            {
                effortDataGridView.Rows.Add(new string[] { row.TaskTitle, row.Resource, row.EffortMade });
            }

            dependenciesDataGridView.Rows.Clear();
            foreach (var row in projectPlanModel.Dependencies)
            {
                dependenciesDataGridView.Rows.Add(new string[] { row.ActivityTitle, row.DependsOn, row.DependencyType });
            }

            assumptionsTxt.Text = projectPlanModel.Asssumptions;
            constrainsTxt.Text = projectPlanModel.Constraints;
        }
    }
}
