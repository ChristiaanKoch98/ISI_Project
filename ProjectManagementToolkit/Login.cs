﻿using ProjectManagementToolkit.MPMM.MPMM_Document_Forms;
using ProjectManagementToolkit.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagementToolkit
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            //Hide error text
            lblLoginError.Visible = false;

            //Get input values
            string username = txtUsername.Text,
                   password = txtPassword.Text;

            //Check if user exists
            if (!Validation.CheckIfUserExists(username))
            {
                lblLoginError.Text = "User does not exists";
                lblLoginError.Visible = true;
                return;
            }

            //Hash password
            string hashedPassword = Hashing.HashPassword(password);

            //Check login credentials
            if(!Validation.CheckLoginCredentials(username, hashedPassword))
            {
                lblLoginError.Text = "Incorrect password";
                lblLoginError.Visible = true;
                return;
            }
            else
            {
                ProjectSelection projectSetup = new ProjectSelection();
                this.Visible = false;
                Settings.Default.Username = username;
                projectSetup.Show();
            }
        }

        private void chkSeePassword_CheckedChanged(object sender, EventArgs e)
        {
            //Toggle password's visibility
            if (chkShowPassword.Checked)
                txtPassword.PasswordChar = '\0';
            else
                txtPassword.PasswordChar = '*';
        }

        private void lnkSignup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp signupForm = new SignUp();
            signupForm.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtUsername.Text = "Username";
            txtPassword.Text = "Password";
            txtUsername.BackColor = this.BackColor;
            txtPassword.BackColor = this.BackColor;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
