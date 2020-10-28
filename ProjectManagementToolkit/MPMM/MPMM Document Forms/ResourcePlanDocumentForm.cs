using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class ResourcePlanDocumentForm : Form
    {
        public ResourcePlanDocumentForm()
        {
            InitializeComponent();
        }

        private void ResourcePlanDocumentForm_Load(object sender, EventArgs e)
        {
            
                List<string[]> rows = new List<string[]>();
                rows.Add(new string[] { "Document ID", "" });
                rows.Add(new string[] { "Document Owner", "" });
                rows.Add(new string[] { "Issue Date", "" });
                rows.Add(new string[] { "Last Save Date", "" });
                rows.Add(new string[] { "File Name", "" });
                foreach (var row in rows)
                {
                    docInfoGridData.Rows.Add(row);
                }
                docInfoGridData.AllowUserToAddRows = false;

            }

        
    }
    }

