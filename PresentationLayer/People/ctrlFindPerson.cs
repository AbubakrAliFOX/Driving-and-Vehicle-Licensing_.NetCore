﻿using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class ctrlFindPerson : UserControl
    {
        public ctrlFindPerson()
        {
            InitializeComponent();

            cbFilterList.SelectedIndex = 0;
        }

        public clsPerson PersonInfo
        {
            get { return ctrlPersonCard1.PersonInfo; }
            set
            {
                ctrlPersonCard1.PersonInfo = value;
            }
        }

        public int OnlyForPerson
        {
            set
            {
                ctrlPersonCard1.PersonInfo= clsPerson.Find(value);
                gbFilter.Enabled = false;
            }
        }

        private string SearchColumn;

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (tbSearch.Text != "")
            {
                clsPerson GetPerson;

                if (SearchColumn == "PersonID")
                {
                    int SearchTerm;
                    int.TryParse(tbSearch.Text, out SearchTerm);
                    GetPerson = clsPerson.Find(SearchTerm);

                }
                else
                {
                    GetPerson = clsPerson.Find(tbSearch.Text);
                }

                if (GetPerson != null)
                {
                    PersonInfo = GetPerson;
                }
                else
                {
                    PersonInfo = null;
                    MessageBox.Show("Person Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddEditPerson NewPerson = new frmAddEditPerson();

            NewPerson.DataBack += GetPersonID;

            NewPerson.ShowDialog();
        }

        private void GetPersonID (object sender, int PersonID)
        {
            this.PersonInfo = clsPerson.Find(PersonID);
        }

        private void cbFilterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchColumn = cbFilterList.SelectedItem.ToString().Replace(" ", "");
        }

        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {

                btnSearch.PerformClick();
            }

            //this will allow only digits if person id is selected
            if (cbFilterList.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
