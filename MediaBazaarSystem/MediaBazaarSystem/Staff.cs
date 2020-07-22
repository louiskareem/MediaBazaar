﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarSystem
{
    public class Staff
    {
        protected String firstName, lastName, address, password, email;
        protected int ID, hoursWorked, hoursAvailable, personID, age;
        protected DateTime birthDate;
        protected Position role;
        protected double salary;
        protected Contract contract;

        public int dbID
        {
            get { return this.personID; }
            set { this.personID = value; }
        }

        public String Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public String FirstName
        {
            get { return firstName; }
            set { this.firstName = value; }
        }

        public String LastName
        {
            get { return lastName; }
            set { this.lastName = value; }
        }

        public String Address
        {
            get { return this.address; }
            set { this.address = value; }
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public DateTime dateOfBirth
        {
            get { return this.birthDate; }
            set { this.birthDate = value; }
        }

        public Position Role
        {
            get { return this.role; }
            set { this.role = value; }
        }

        public double Salary
        {
            get { return this.salary; }
            set { this.salary = value; }
        }

        public int HoursAvailable
        {
            get { return this.hoursAvailable; }
            set { this.hoursAvailable = value; }
        }

        public Contract Contract
        {
            get { return this.contract; }
            set { this.contract = value; }
        }

        public int PassCode
        {
            get;
            private set;
        }

        /**
         * Constructor for HR manager and employee
         */
        public Staff(int ID, String firstName, String lastName, DateTime birthDate, String address, double salary, int hoursAvailable, String email, Contract contract)
        {
            dbID = ID;
            FirstName = firstName;
            LastName = lastName;
            dateOfBirth = birthDate.Date;
            Address = address;
            Role = Position.Unknown;
            Salary = salary;
            HoursAvailable = hoursAvailable;
            Email = email;
            Contract = contract;

            //Calculate age
            int age = DateTime.Now.Year - birthDate.Year - 1;
            if (birthDate.Month > DateTime.Now.Month)
            {
                age++;
            }
            else if (birthDate.Month == DateTime.Now.Month)
            {
                if (birthDate.Day >= DateTime.Now.Day)
                {
                    age++;
                }
            }
            Age = age;
        }

        /**
         * Constructor for Stock Manager
         */
        public Staff( int ID, String firstName, String lastName, DateTime birthDate, String address, double salary, int hoursAvailable, String email, Contract contract, int passCode )
        {
            dbID = ID;
            FirstName = firstName;
            LastName = lastName;
            dateOfBirth = birthDate.Date;
            Address = address;
            Role = Position.Unknown;
            Salary = salary;
            HoursAvailable = hoursAvailable;
            Email = email;
            Contract = contract;
            PassCode = passCode;

            //Calculate age
            int age = DateTime.Now.Year - birthDate.Year - 1;
            if( birthDate.Month > DateTime.Now.Month )
            {
                age++;
            }
            else if( birthDate.Month == DateTime.Now.Month )
            {
                if( birthDate.Day >= DateTime.Now.Day )
                {
                    age++;
                }
            }
            Age = age;
        }

        /**
         * Method to update staff member (STAFF'S PROFILE)
         */
        public void editStaffMember(String firstName, String lastName, DateTime birthDate, String address, String email)
        {
            this.FirstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = birthDate;
            this.Address = address;
            this.Email = email;

            //Calculate age
            int age = DateTime.Now.Year - birthDate.Year - 1;
            if (birthDate.Month > DateTime.Now.Month)
            {
                age++;
            }
            else if (birthDate.Month == DateTime.Now.Month)
            {
                if (birthDate.Day >= DateTime.Now.Day)
                {
                    age++;
                }
            }
            Age = age;
        }

        /**
         * Method to update staff member
         */
        public void editStaffMember(String firstName, String lastName, DateTime birthDate, String address, String email, double salary, int hoursAvailable, Position role, Contract contract)
        {
            this.FirstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = birthDate;
            this.Address = address;
            this.Email = email;
            this.Salary = salary;
            this.HoursAvailable = hoursAvailable;
            this.Role = role;
            this.Contract = contract;
        }

        public override string ToString()
        {
            return "ID: " + this.ID + ", Name: " + this.firstName + this.lastName + ". Age: " + this.age + ". Address: " + this.address + this.role + this.password + this.email + this.salary + this.hoursWorked + this.hoursAvailable;
        }
    }
}
