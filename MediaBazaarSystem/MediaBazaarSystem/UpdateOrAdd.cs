﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace MediaBazaarSystem
{
    public partial class UpdateOrAdd : Form
    {
        DatabaseHelper dataBase;
        Department department;
        Staff staffMember;
        String FirstName, LastName, address, email;
        DateTime birthDate;
        double salary;
        int hoursAvailable, roleID, DepartmentID, passcode;
        Position role;
        Contract contract;

        //This form is used by 3 different methods, Add employee, add manager and update employee/manager, for that reason the constructor is overloaded,
        //if a department alone is given, then the method will add a new person, if a department + a manager is given, a manager is to be updated, and if
        //a department and an employee are given, an employee is to be updated.

        /**
         * Constructor
         */
        public UpdateOrAdd(Department dep)
        {
            InitializeComponent();
            btnEditStaff.Enabled = false;
            btnEditStaff.Visible = false;
            this.Text = "Add new person";
            this.department = dep;
            dataBase = new DatabaseHelper();
        }

        /**
         * Method to check if Stock manager role is selected, if so..make passcode input writable, if not...keep it readable only
         */
        private void passcodeCheckerTimer_Tick( object sender, EventArgs e )
        {
            if( comBoxRole.SelectedIndex >= 0 )
            {
                if( comBoxRole.SelectedItem.ToString() != "StockManager" )
                {
                    txtBoxPasscode.Text = 0.ToString();
                    txtBoxPasscode.ReadOnly = true;
                }
                else
                {
                    txtBoxPasscode.ReadOnly = false;
                }
            }
        }

        /**
         * Jose? 
         */
        public UpdateOrAdd(Department dep, Staff staffMember)
        {
            InitializeComponent();
            btnAddStaff.Enabled = false;
            btnAddStaff.Visible = false;
            this.Text = "Update " + staffMember.FirstName + " " + staffMember.LastName;
            this.department = dep;
            this.staffMember = staffMember;
            SetUpForm();
            dataBase = new DatabaseHelper();
        }

        /**
         * Method to fill form inputs with data
         */
        private void SetUpForm()
        {
            txtBoxFirstName.Text = staffMember.FirstName;
            txtBoxLastName.Text = staffMember.LastName;
            tbBirthDate.Text = staffMember.dateOfBirth.ToString("dd/MM/yyyy");
            tbAddress.Text = staffMember.Address;
            comBoxRole.SelectedItem = staffMember.Role;
            txtBoxSalary.Text = staffMember.Salary.ToString();
            txtBoxHoursAvailable.Text = staffMember.HoursAvailable.ToString();
            txtBoxEmail.Text = staffMember.Email.ToString();
            comBoxRole.SelectedIndex = (int)staffMember.Role - 1;
            cmboBoxDepartment.SelectedIndex = this.department.DepartmentID - 1;
            cmboBoxContract.SelectedIndex = (int)staffMember.Contract - 1;
        }

        /**
         * Method to edit staff meber
         */
        private void btnEditStaff_Click(object sender, EventArgs e)
        {
            ReadInfoFromForm();
            //int passcode = Convert.ToInt32(txtBoxPasscode.Text);

            dataBase.managerUpdateProfile(staffMember, FirstName, LastName, birthDate, address, email, salary, hoursAvailable, roleID, DepartmentID, contract);
            staffMember.editStaffMember(FirstName, LastName, birthDate, address, email, salary, hoursAvailable, role, contract);

            MessageBox.Show("Staff member edited successfully");
            this.Close();
        }

        /**
         * JOSE WHY IS THIS NOT WORKING???
         * Method to add staff member
         */
        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            try
            {
                ReadInfoFromForm();
                int tempID = -1;


                Staff newStaffMember = null;

                if (role == Position.Employee)
                {
                    newStaffMember = new Employee(tempID, FirstName, LastName, birthDate, address, salary, hoursAvailable, email, contract);
                }
                else if (role == Position.HRManager)
                {
                    newStaffMember = new Manager(tempID, FirstName, LastName, birthDate, address, salary, hoursAvailable, email, contract);
                }
                else if (role == Position.StockManager)
                {
                    newStaffMember = new Manager(tempID, FirstName, LastName, birthDate, address, salary, hoursAvailable, email, contract, passcode);
                }

                dataBase.addStaffToDB(newStaffMember, DepartmentID);
               
                MessageBox.Show("Staff member added successfully");

                //newStaffMember.dbID = dataBase.getStaffID();

                if( this.department.DepartmentID == DepartmentID )
                {
                    
                    department.AddStaffMember( newStaffMember );
                }

                this.Close();
            }
            catch(Exception)
            {
                MessageBox.Show("Information not filled correctly");
            }
            
        }

        /**
         * Method to get data frm the form inputs
         */
        private void ReadInfoFromForm()
        {
            //try
            //{
                this.FirstName = txtBoxFirstName.Text.ToString(); //First name
                this.LastName = txtBoxLastName.Text.ToString(); //Last name
                this.birthDate = Convert.ToDateTime(tbBirthDate.Text); //Date of Birth
                this.address = tbAddress.Text.ToString(); //Address
                this.email = txtBoxEmail.Text.ToString(); //Email
                this.salary = Convert.ToDouble(txtBoxSalary.Text); //Salary
                this.hoursAvailable = Convert.ToInt32(txtBoxHoursAvailable.Text); //Hours available
                this.roleID = comBoxRole.SelectedIndex + 1;
                this.role = (Position)roleID; //Role (as a string instead of an ID for ease of use and clarity in a list of C#)
                this.DepartmentID = cmboBoxDepartment.SelectedIndex + 1;
                this.contract = (Contract)Enum.Parse(typeof(Contract), cmboBoxContract.SelectedItem.ToString());
                this.passcode = Convert.ToInt32( txtBoxPasscode.Text );
            //}
            //catch(Exception)
            //{
            //    MessageBox.Show( "Error, please contact your administrator" );
            //}
        }
    }
}
