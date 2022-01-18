using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Personal_Adress_Book_DanielTran
{
    public partial class formAddressBook : Form
    {
        public formAddressBook()
        {
           
            InitializeComponent();
            dtpBirthdayEdit.MaxDate = DateTime.Now;//make sure the input dates can not be set to a date in the future
            dtpBirthdayAdd.MaxDate = DateTime.Now;
        }
        //initalize array
        ContactInfo[] Contact_Organizer = new ContactInfo[100];
        int iCurrentIndex = 0;
        //declare contactinfo structure
        public struct ContactInfo
        {
            public string FirstName;
            public string LastName;
            public string Email;
            public string Phone;
            public int month;
            public int day;
            public int year;
        }
        public int FindPerson(string FirstName, string LastName)
        {        
            //search array for specific person
            for (int i = 0; i < iCurrentIndex; i = i + 1)
            {
                if (Contact_Organizer[i].FirstName.ToLower() == FirstName.ToLower() && Contact_Organizer[i].LastName.ToLower() == LastName.ToLower())
                {
                    return i;//returns their position in the array
                }
            }
            return -1;//person not in array
        }
        //calculate the age of the person inside that index
        public int CalculateAge(DateTime DateOfBirth)
        {
            int age = 0;
            age = DateTime.Now.Year - DateOfBirth.Year;
            return age;
        }
        public string CapitalizeFirstLetter(string FirstName, string LastName)
        {
            //for displaying names, capitalize first and last name
            return FirstName.Substring(0, 1).ToUpper() + FirstName.Substring(1).ToLower() + " " + LastName.Substring(0, 1).ToUpper() + LastName.Substring(1).ToLower();
        }
        //clear all the textboxes and resets birtday date time pickers
        public void ClearAll()
        {
            txtFirstNameAdd.Clear();
            txtFirstNameShow.Clear();
            txtFirstNameEdit.Clear();
            txtLastNameAdd.Clear();
            txtLastNameShow.Clear();
            txtLastNameEdit.Clear();
            txtEmailAdd.Clear();
            txtEmailShow.Clear();
            txtEmailEdit.Clear();
            txtPhoneAdd.Clear();
            txtPhoneShow.Clear();
            txtPhoneEdit.Clear();
            dtpBirthdayEdit.MaxDate = DateTime.Now;
            dtpBirthdayAdd.MaxDate = DateTime.Now;
            dtpBirthdayAdd.ResetText();
            dtpBirthdayShow.ResetText();
            dtpBirthdayEdit.ResetText();
            dtpBirthdayShow.Visible = false;
            txtEmailEdit.Enabled = false;
            txtPhoneEdit.Enabled = false;
            dtpBirthdayEdit.Enabled = false;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            btnDelete.Visible = false;
            txtFirstNameEdit.Enabled = true;
            txtLastNameEdit.Enabled = true; 
            txtFirstNameEdit.TabStop = true;
            txtLastNameEdit.TabStop = true; 
            txtEmailEdit.TabStop = false;
            txtPhoneEdit.TabStop = false;
            btnVerify.TabStop = true;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string strFirstName, strLastName, strEmail, strPhone, strFullName;
                int index;
                CapitalizeFirstLetter(txtFirstNameAdd.Text, txtLastNameAdd.Text);
                if (iCurrentIndex >= 100) //array is full
                {
                    MessageBox.Show("Database is full!");
                    return;
                }
                else //if not full
                {
                    strFirstName = txtFirstNameAdd.Text.Trim();
                    strLastName = txtLastNameAdd.Text.Trim();
                    strEmail = txtEmailAdd.Text.Trim();
                    strPhone = txtPhoneAdd.Text.Trim();
                    if (strFirstName == "" || strLastName == "" || strEmail == "" || strPhone == "") //if textboxes are empty 
                    {
                        MessageBox.Show("Please provide information in the textbox(es)!");
                        return;
                    }
                    index = FindPerson(strFirstName, strLastName);
                    if (index == -1) //if person not in contacts
                    {
                        Contact_Organizer[iCurrentIndex].FirstName = strFirstName;
                        Contact_Organizer[iCurrentIndex].LastName = strLastName;
                        Contact_Organizer[iCurrentIndex].Email = strEmail;
                        Contact_Organizer[iCurrentIndex].Phone = strPhone;
                        Contact_Organizer[iCurrentIndex].day = dtpBirthdayAdd.Value.Day;
                        Contact_Organizer[iCurrentIndex].month = dtpBirthdayAdd.Value.Month;
                        Contact_Organizer[iCurrentIndex].year = dtpBirthdayAdd.Value.Year;
                        iCurrentIndex = iCurrentIndex + 1;
                        MessageBox.Show(CapitalizeFirstLetter(strFirstName, strLastName) + " added to contacts.");
                        ClearAll();
                    }
                    else //person already in contacts, same first and last name
                    {
                        MessageBox.Show("This person is already your contacts!");
                        ClearAll();
                    }
                    lbDisplayAll.Items.Clear(); //display contacts to contact list
                    for (int i = 0; i < iCurrentIndex; i++)
                    {
                        strFullName = CapitalizeFirstLetter(Contact_Organizer[i].FirstName, Contact_Organizer[i].LastName);
                        lbDisplayAll.Items.Add(strFullName);
                        lbDisplayAll.Items.Add(Contact_Organizer[i].Email);
                        lbDisplayAll.Items.Add(Contact_Organizer[i].Phone);
                        lbDisplayAll.Items.Add(Contact_Organizer[i].month + "/" + Contact_Organizer[i].day + "/" + Contact_Organizer[i].year);
                        lbDisplayAll.Items.Add("");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please provide information in the textbox(es)!");
            }
        }
        private void btnReset1_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        private void btnContactInfo_Click(object sender, EventArgs e)
        {

            string strFirstName, strLastName, strEmail, strPhone;
            int index, day, month, year;
            strFirstName = txtFirstNameShow.Text.Trim();
            strLastName = txtLastNameShow.Text.Trim();
            if (strFirstName == "" || strLastName == "") //need to fill first and last name in order to see info
            {
                MessageBox.Show("Please provide both First Name and Last Name!");
                return;
            }
            index = FindPerson(strFirstName, strLastName);
            if (index == -1) //person not in contacts
            {
                dtpBirthdayShow.Visible = false;
                MessageBox.Show(" This person does not exist in your Contacts!");
                ClearAll();
            }
            else//person is in contacts
            //find what position they are in array and display their info
            {
                strEmail = Contact_Organizer[index].Email;
                strPhone = Contact_Organizer[index].Phone;
                day = Contact_Organizer[index].day;
                month = Contact_Organizer[index].month;
                year = Contact_Organizer[index].year;
                txtPhoneShow.Text = strPhone;
                txtEmailShow.Text = strEmail;
                dtpBirthdayShow.Visible = true;
                dtpBirthdayShow.Value = new DateTime(year, month, day);
            }
        }
        private void btnReset_Click(object sender, EventArgs e)//reset your show contact info tab to show a new contact
        {
            ClearAll();
            dtpBirthdayShow.Visible = false;
        }
        private void btnTodaysBirthday_Click(object sender, EventArgs e)
        {
            string strFullName;
            int age, year, month, day;
            int iCounter = 0;
            DateTime dob;
            lbBirthdays.Items.Clear();
            for (int i = 0; i < iCurrentIndex; i = i + 1)
            {
                if (Contact_Organizer[i].day == DateTime.Now.Day && Contact_Organizer[i].month == DateTime.Now.Month)//search array for any person with the same birthday
                {
                    iCounter++;//counts each birthday that is today
                    year = Contact_Organizer[i].year;
                    month = Contact_Organizer[i].month;
                    day = Contact_Organizer[i].day;
                    dob = new DateTime(year, month, day);
                    age = CalculateAge(dob);
                    strFullName = CapitalizeFirstLetter(Contact_Organizer[i].FirstName, Contact_Organizer[i].LastName);
                    lbBirthdays.Items.Add(strFullName + " turns " + age + " today");
                }
            }
            if (iCounter == 0)//since there are no birthdays today, display message
            {
                lbBirthdays.Items.Add("There are no birthdays today");
            }
        }
        private void btnSpecific_Click(object sender, EventArgs e) //show specific birthdays
        {
            string strFullName;
            int age, year, month, day;
            int iCounter = 0;
            DateTime dob;
            lbBirthdays.Items.Clear();
            for (int i = 0; i < iCurrentIndex; i = i + 1)
            {
                if (Contact_Organizer[i].day == dtpSpecific.Value.Day && Contact_Organizer[i].month == dtpSpecific.Value.Month)//search array for any person with the same birthday
                {
                    iCounter++;//tracks the amount of birthdays, so having mulitple lines to dinstinct them
                    year = Contact_Organizer[i].year;
                    month = Contact_Organizer[i].month;
                    day = Contact_Organizer[i].day;
                    dob = new DateTime(year, month, day);//date of birth of the person in that index
                    age = CalculateAge(dob);//calculate the age of the person inside that index
                    strFullName = CapitalizeFirstLetter(Contact_Organizer[i].FirstName, Contact_Organizer[i].LastName);
                    lbBirthdays.Items.Add(strFullName + " turns " + age + " that day");//display
                }
            }
            if (iCounter == 0)//if there is none, only need one line
                {
                    lbBirthdays.Items.Add("There are no birthdays today");
                }
        }
        private void btnVerify_Click(object sender, EventArgs e)
        {
            string strFirstName, strLastName, strEmail, strPhone;
            int index, day, month, year;
            strFirstName = txtFirstNameEdit.Text.Trim();
            strLastName = txtLastNameEdit.Text.Trim();
            if (strFirstName == "" || strLastName == "")//empty textboxes
            {
                MessageBox.Show("Please provide both First Name and Last Name!");
                return;
            }
            index = FindPerson(strFirstName, strLastName);
            if (index == -1)//since they're not in contacts list, they don't have info
            {
                dtpBirthdayEdit.Enabled = false;
                MessageBox.Show(" This person does not exist in your Contacts!");
                ClearAll();
            }
            else//if they are in, execute
            {
                txtFirstNameEdit.Enabled = false;//cannot change first and last name
                txtLastNameEdit.Enabled = false;
                txtFirstNameEdit.TabStop = false;
                txtLastNameEdit.TabStop = false;
                btnVerify.TabStop = false;
                btnUpdate.Visible = true;//can not edit, delete, or cancel any changes
                btnCancel.Visible = true;
                btnDelete.Visible = true;
                strEmail = Contact_Organizer[index].Email;//display the info of the person they typed
                strPhone = Contact_Organizer[index].Phone;
                day = Contact_Organizer[index].day;
                month = Contact_Organizer[index].month;
                year = Contact_Organizer[index].year;
                txtPhoneEdit.Text = strPhone;
                txtEmailEdit.Text = strEmail;
                dtpBirthdayEdit.Value = new DateTime(year, month, day);
                txtEmailEdit.Enabled = true;//edit the email, phone, birthday
                txtPhoneEdit.Enabled = true;
                txtEmailEdit.TabStop = true;
                txtPhoneEdit.TabStop = true;
                dtpBirthdayEdit.Enabled = true;
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to update contact?", "Update Contact Confirmation", MessageBoxButtons.YesNo);//makes sure the user wants to make changes
            if (dr == DialogResult.Yes)
            {
                string strEmail, strPhone, strFirstName, strLastName, strFullName;
                int index;
                strEmail = txtEmailEdit.Text.Trim();
                strPhone = txtPhoneEdit.Text.Trim();
                strFirstName = txtFirstNameEdit.Text.Trim();
                strLastName = txtLastNameEdit.Text.Trim();
                index = FindPerson(strFirstName, strLastName);
                if (index != -1)//if they are in the contact list
                {
                    Contact_Organizer[index].Email = strEmail;//go to that specif person's spot in the array, and change their info to the new info
                    Contact_Organizer[index].Phone = strPhone;
                    Contact_Organizer[index].day = dtpBirthdayEdit.Value.Day;
                    Contact_Organizer[index].month = dtpBirthdayEdit.Value.Month;
                    Contact_Organizer[index].year = dtpBirthdayEdit.Value.Year;
                    MessageBox.Show("Contact Updated");
                    ClearAll();
                }
                lbDisplayAll.Items.Clear();//updates the contact list
                for (int i = 0; i < iCurrentIndex; i++)
                {
                    strFullName = CapitalizeFirstLetter(Contact_Organizer[i].FirstName, Contact_Organizer[i].LastName);
                    lbDisplayAll.Items.Add(strFullName);
                    lbDisplayAll.Items.Add(Contact_Organizer[i].Email);
                    lbDisplayAll.Items.Add(Contact_Organizer[i].Phone);
                    lbDisplayAll.Items.Add(Contact_Organizer[i].month + "/" + Contact_Organizer[i].day + "/" + Contact_Organizer[i].year);
                    lbDisplayAll.Items.Add("");
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to cancel changes? This will discard all changes typed", "Cancel Update Confirmation", MessageBoxButtons.YesNo);//makes sure the user wants to make changes
            if (dr == DialogResult.Yes)
            {
                ClearAll();
                MessageBox.Show("No changes made");//reset any changes made in the edit
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to delete contact?", "Delete Contact Confirmation", MessageBoxButtons.YesNo);//makes sure the user wants to delete the contact
            if (dr == DialogResult.Yes)//if they want to delete, execute
            {
                string strFirstName, strLastName, strFullName;
                int index;
                strFirstName = txtFirstNameEdit.Text.Trim();
                strLastName = txtLastNameEdit.Text.Trim();
                index = FindPerson(strFirstName, strLastName);
                for (int i = index; i < iCurrentIndex; i++)//search in the array for that person's spot
                {
                    Contact_Organizer[i].FirstName = Contact_Organizer[i + 1].FirstName;//the person after the person you want to delete will now take their spot
                    Contact_Organizer[i].LastName = Contact_Organizer[i + 1].LastName;
                    Contact_Organizer[i].Email = Contact_Organizer[i + 1].Email;
                    Contact_Organizer[i].Phone = Contact_Organizer[i + 1].Phone;
                    Contact_Organizer[i].day = Contact_Organizer[i + 1].day;
                    Contact_Organizer[i].month = Contact_Organizer[i + 1].month;
                    Contact_Organizer[i].year = Contact_Organizer[i + 1].year;
                }
                iCurrentIndex = iCurrentIndex - 1;//one less in the array, so mark in the current index
                ClearAll();
                lbDisplayAll.Items.Clear();//updates the contact list
                for (int i = 0; i < iCurrentIndex; i++)
                {
                    strFullName = CapitalizeFirstLetter(Contact_Organizer[i].FirstName, Contact_Organizer[i].LastName);
                    lbDisplayAll.Items.Add(strFullName);
                    lbDisplayAll.Items.Add(Contact_Organizer[i].Email);
                    lbDisplayAll.Items.Add(Contact_Organizer[i].Phone);
                    lbDisplayAll.Items.Add(Contact_Organizer[i].month + "/" + Contact_Organizer[i].day + "/" + Contact_Organizer[i].year);
                    lbDisplayAll.Items.Add("");
                }
            }
        }

        private void saveTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string strFileName;
                    strFileName = sfd.FileName;

                    TextWriter tw = new StreamWriter(strFileName);

                    for (int i = 0; i < iCurrentIndex; i++)
                    {
                        tw.Write(Contact_Organizer[i].FirstName + ",");
                        tw.Write(Contact_Organizer[i].LastName + ",");
                        tw.Write(Contact_Organizer[i].Email + ",");
                        tw.Write(Contact_Organizer[i].Phone + ",");
                        tw.Write(Contact_Organizer[i].day.ToString() + ",");
                        tw.Write(Contact_Organizer[i].month.ToString() + ",");
                        tw.WriteLine(Contact_Organizer[i].year.ToString() + ",");
                    }

                    tw.Close();
                    MessageBox.Show("File saved succesfully");
                }
            }
            catch
            {
                MessageBox.Show("File could not save");//if could not save for any reason
            }
        }

        private void openTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
                if (iCurrentIndex > 0)//if the array has contacts in it already, opens a messagebox to confirm if they want to open another 
                {
                    DialogResult dr = MessageBox.Show("Are you sure you want to open another address book? Any unsaved work will be lost", "Open File Confirmation", MessageBoxButtons.YesNo);//makes sure the user knows that unsaved work will be deleted
                    if (dr == DialogResult.Yes)//if they are sure they want to move on, execute
                    {
                        string strInput, strFullName;
                        string[] splittedInput;
                        OpenFileDialog ofd = new OpenFileDialog();
                        ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                        if (ofd.ShowDialog() == DialogResult.OK)
                        {
                            string FileName;
                            FileName = ofd.FileName;
                            TextReader tr = new StreamReader(FileName);
                            iCurrentIndex = 0;
                            while ((strInput = tr.ReadLine()) != null)
                            {
                                splittedInput = strInput.Split(',');
                                Contact_Organizer[iCurrentIndex].FirstName = splittedInput[0];
                                Contact_Organizer[iCurrentIndex].LastName = splittedInput[1];
                                Contact_Organizer[iCurrentIndex].Email = splittedInput[2];
                                Contact_Organizer[iCurrentIndex].Phone = splittedInput[3];
                                Contact_Organizer[iCurrentIndex].day = Convert.ToInt32(splittedInput[4]);
                                Contact_Organizer[iCurrentIndex].month = Convert.ToInt32(splittedInput[5]);
                                Contact_Organizer[iCurrentIndex].year = Convert.ToInt32(splittedInput[6]);
                                iCurrentIndex = iCurrentIndex + 1;
                            }
                            tr.Close();
                            lbDisplayAll.Items.Clear();//update contact list
                            ClearAll();
                            for (int i = 0; i < iCurrentIndex; i++)
                            {
                                strFullName = CapitalizeFirstLetter(Contact_Organizer[i].FirstName, Contact_Organizer[i].LastName);
                                lbDisplayAll.Items.Add(strFullName);
                                lbDisplayAll.Items.Add(Contact_Organizer[i].Email);
                                lbDisplayAll.Items.Add(Contact_Organizer[i].Phone);
                                lbDisplayAll.Items.Add(Contact_Organizer[i].month + "/" + Contact_Organizer[i].day + "/" + Contact_Organizer[i].year);
                                lbDisplayAll.Items.Add("");
                            }
                            MessageBox.Show(FileName + " has been opened succesfully");
                        }
                    }
                }
                else//if there are no contacts in the array, there's no need to check for unsaved work
                {
                    string strInput, strFullName;
                    string[] splittedInput;
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        string FileName;
                        FileName = ofd.FileName;
                        TextReader tr = new StreamReader(FileName);
                        iCurrentIndex = 0;
                        while ((strInput = tr.ReadLine()) != null)
                        {
                            splittedInput = strInput.Split(',');
                            Contact_Organizer[iCurrentIndex].FirstName = splittedInput[0];
                            Contact_Organizer[iCurrentIndex].LastName = splittedInput[1];
                            Contact_Organizer[iCurrentIndex].Email = splittedInput[2];
                            Contact_Organizer[iCurrentIndex].Phone = splittedInput[3];
                            Contact_Organizer[iCurrentIndex].day = Convert.ToInt32(splittedInput[4]);
                            Contact_Organizer[iCurrentIndex].month = Convert.ToInt32(splittedInput[5]);
                            Contact_Organizer[iCurrentIndex].year = Convert.ToInt32(splittedInput[6]);
                            iCurrentIndex = iCurrentIndex + 1;
                        }
                        tr.Close();
                        lbDisplayAll.Items.Clear();//update contact list
                        ClearAll();
                        for (int i = 0; i < iCurrentIndex; i++)
                        {
                            strFullName = CapitalizeFirstLetter(Contact_Organizer[i].FirstName, Contact_Organizer[i].LastName);
                            lbDisplayAll.Items.Add(strFullName);
                            lbDisplayAll.Items.Add(Contact_Organizer[i].Email);
                            lbDisplayAll.Items.Add(Contact_Organizer[i].Phone);
                            lbDisplayAll.Items.Add(Contact_Organizer[i].month + "/" + Contact_Organizer[i].day + "/" + Contact_Organizer[i].year);
                            lbDisplayAll.Items.Add("");
                        }
                        MessageBox.Show(FileName + " has been opened succesfully");
                    }
                }
        }

            private void saveBinariToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog1 = new SaveFileDialog();
                string FileName;
                saveDialog1.Filter = "Contact Organizer files (*.co)|*.co|All files (*.*)|*.*";
                if (saveDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileName = saveDialog1.FileName;
                    FileStream fs = new FileStream(FileName, FileMode.Create);
                    BinaryWriter binWriter = new BinaryWriter(fs);
                    for (int i = 0; i < iCurrentIndex; i = i + 1)
                    {
                        binWriter.Write(Contact_Organizer[i].FirstName);
                        binWriter.Write(Contact_Organizer[i].LastName);
                        binWriter.Write(Contact_Organizer[i].Email);
                        binWriter.Write(Contact_Organizer[i].Phone);
                        binWriter.Write(Contact_Organizer[i].day);
                        binWriter.Write(Contact_Organizer[i].month);
                        binWriter.Write(Contact_Organizer[i].year);
                    }
                    binWriter.Flush();
                    binWriter.Close();
                }
            }
            catch
            {
                MessageBox.Show("Binary file could not save");//if could not save for any reason
            }
        }
        private void openBinaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (iCurrentIndex > 0)//if the array has contacts in it already, opens a messagebox to confirm if they want to open another
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to open another address book? Any unsaved work will be lost", "Open File Confirmation", MessageBoxButtons.YesNo);//makes sure the user knows that unsaved work will be deleted
                if (dr == DialogResult.Yes)//if they are sure they want to move on, execute
                {
                    OpenFileDialog openDialog1 = new OpenFileDialog();
                    string FileName, strFullName;
                    long length;
                    openDialog1.Filter = "Contact Organizer (*.co)|*.co|All files (*.*)|*.*";
                    if (openDialog1.ShowDialog() == DialogResult.OK)
                    {
                        FileName = openDialog1.FileName;
                        FileStream fs = new FileStream(FileName, FileMode.Open);
                        BinaryReader binReader = new BinaryReader(fs);
                        iCurrentIndex = 0;
                        length = binReader.BaseStream.Length;
                        while (fs.Position < length)
                        {
                            Contact_Organizer[iCurrentIndex].FirstName = binReader.ReadString();
                            Contact_Organizer[iCurrentIndex].LastName = binReader.ReadString();
                            Contact_Organizer[iCurrentIndex].Email = binReader.ReadString();
                            Contact_Organizer[iCurrentIndex].Phone = binReader.ReadString();
                            Contact_Organizer[iCurrentIndex].day = binReader.ReadInt32();
                            Contact_Organizer[iCurrentIndex].month = binReader.ReadInt32();
                            Contact_Organizer[iCurrentIndex].year = binReader.ReadInt32();
                            iCurrentIndex = iCurrentIndex + 1;
                        }
                        binReader.Close();
                        lbDisplayAll.Items.Clear();//update contact list
                        ClearAll();
                        for (int i = 0; i < iCurrentIndex; i++)
                        {
                            strFullName = CapitalizeFirstLetter(Contact_Organizer[i].FirstName, Contact_Organizer[i].LastName);
                            lbDisplayAll.Items.Add(strFullName);
                            lbDisplayAll.Items.Add(Contact_Organizer[i].Email);
                            lbDisplayAll.Items.Add(Contact_Organizer[i].Phone);
                            lbDisplayAll.Items.Add(Contact_Organizer[i].month + "/" + Contact_Organizer[i].day + "/" + Contact_Organizer[i].year);
                            lbDisplayAll.Items.Add("");
                        }
                        MessageBox.Show(FileName + " has been opened succesfully");
                    }
                }
            }
            else//if there are no contacts in the array, there's no need to check for unsaved work
            {
                OpenFileDialog openDialog1 = new OpenFileDialog();
                string FileName, strFullName;
                long length;
                openDialog1.Filter = "Contact Organizer (*.co)|*.co|All files (*.*)|*.*";
                if (openDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileName = openDialog1.FileName;
                    FileStream fs = new FileStream(FileName, FileMode.Open);
                    BinaryReader binReader = new BinaryReader(fs);
                    iCurrentIndex = 0;
                    length = binReader.BaseStream.Length;
                    while (fs.Position < length)
                    {
                        Contact_Organizer[iCurrentIndex].FirstName = binReader.ReadString();
                        Contact_Organizer[iCurrentIndex].LastName = binReader.ReadString();
                        Contact_Organizer[iCurrentIndex].Email = binReader.ReadString();
                        Contact_Organizer[iCurrentIndex].Phone = binReader.ReadString();
                        Contact_Organizer[iCurrentIndex].day = binReader.ReadInt32();
                        Contact_Organizer[iCurrentIndex].month = binReader.ReadInt32();
                        Contact_Organizer[iCurrentIndex].year = binReader.ReadInt32();
                        iCurrentIndex = iCurrentIndex + 1;
                    }
                    binReader.Close();
                    lbDisplayAll.Items.Clear();//update contact list
                    ClearAll();
                    for (int i = 0; i < iCurrentIndex; i++)
                    {
                        strFullName = CapitalizeFirstLetter(Contact_Organizer[i].FirstName, Contact_Organizer[i].LastName);
                        lbDisplayAll.Items.Add(strFullName);
                        lbDisplayAll.Items.Add(Contact_Organizer[i].Email);
                        lbDisplayAll.Items.Add(Contact_Organizer[i].Phone);
                        lbDisplayAll.Items.Add(Contact_Organizer[i].month + "/" + Contact_Organizer[i].day + "/" + Contact_Organizer[i].year);
                        lbDisplayAll.Items.Add("");
                    }
                    MessageBox.Show(FileName + " has been opened succesfully");
                }
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to create a new address book? Any unsaved work will be lost", "New File Confirmation", MessageBoxButtons.YesNo);//makes sure the user knows that unsaved work will be deleted
            if (dr == DialogResult.Yes)//if they confirm they want to start a new one, execute
            {
                string strFullName;
                iCurrentIndex = 0;//resets the array since you want no contacts
                lbDisplayAll.Items.Clear();//update the contact list
                for (int i = 0; i < iCurrentIndex; i++)
                {
                    strFullName = CapitalizeFirstLetter(Contact_Organizer[i].FirstName, Contact_Organizer[i].LastName);
                    lbDisplayAll.Items.Add(strFullName);
                    lbDisplayAll.Items.Add(Contact_Organizer[i].Email);
                    lbDisplayAll.Items.Add(Contact_Organizer[i].Phone);
                    lbDisplayAll.Items.Add(Contact_Organizer[i].month + "/" + Contact_Organizer[i].day + "/" + Contact_Organizer[i].year);
                    lbDisplayAll.Items.Add("");
                }
                ClearAll();
            }
        }
    }
}
