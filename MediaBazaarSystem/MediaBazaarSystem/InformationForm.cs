﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaBazaarSystem
{
    public partial class InformationForm : Form
    {
        /**
         * Constructor
         */
        public InformationForm(String info)
        {
            InitializeComponent();

            txtBoxInformation.Text = info;
        }
    }
}
