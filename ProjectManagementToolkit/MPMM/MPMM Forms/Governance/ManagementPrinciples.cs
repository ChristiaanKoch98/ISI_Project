using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagementToolkit.MPMM.MPMM_Forms.Governance
{
    public partial class ManagementPrinciples : Form
    {
        public ManagementPrinciples()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMP1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This principle is the same as Adam Smith's 'division of labour' and Taylor's 'scientific management'. Specialization increases output by making employees more efficient. Division is still important, but modern trends lean towards teams and self-managed work groups");
        }

        private void btnMP2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Managers must be able to give orders. Authority gives them this right and flows from their position in the hierarchy. Responsibility arises whenever authority is exercised and effective leadership reinforces authroity.");
        }

        private void btnMP3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Employees must respect and obey the rules that govern an organization. Good discipline is a result of effective leadership, a clear understanding between management and workers regarding the organizations rules and the use of penalties for infractions of the rules");
        }

        private void btnMP4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Every employee should recieve orders from only one superior from top to bottom in an organization. This is not practical in matrix organization and allowance needs to be made for the increased complexity of the working environment.");
        }

        private void btnMP5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Each group of organizational activities that have the same objective should be directed by one manager using one plan.");
        }

        private void btnMP6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The interests of any one employee or group of employees should not take precedence over the interests of the organization as a whole. One outcome of effective leadership is the willingness of people to co oporate for the greater good.");

        }

        private void btnMP7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Workers must be paid a fair wage for their services. This picks up one of the key tenets of Henry Gannt's work.");
        }

        private void btnMP8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The degree to which subordinates are involved in decision making. Whether decision making is centralized or decentralized is a question of proper proporation. The task is to find the optimum degree of centralization for each situation.");
        }

        private void btnMP9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The line of authority from top management to the lowest rank represents the scalar chain. Communications should follow this chain. However if following the chain causes delays, cross communications can be allowed if agreed to by all parties and superiors are kept informed. This picks up the concepts of the school of management.");
        }

        private void btnMP10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("People and materials should be in the right place at the right time. Another key tenant of Henry Gantt's work.");
        }

        private void btnMP11_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Managers should be kind and fair to their suboordinates. This picks up the concepts of the humanistic school of management.");
        }

        private void btnMP12_Click(object sender, EventArgs e)
        {
            MessageBox.Show("High employee turnover is inefficient. Management should provide orderly personnal planning and ensure that replacements are avaliable to fill vacancies");
        }

        private void btnMP13_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Employees who are allowed to originate and carry out plans will exert high levels of effort. The concept of 'bounded initiative' can be traded to concept of 'auftragstaktik' or directive command.");
        }

        private void btnMP14_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Promoting team spirit will buld harmony and unity within the organization. This picks up on Karol Adamiecki's focus on harmonization and team work.");
        }
    }
}
