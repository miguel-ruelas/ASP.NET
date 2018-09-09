using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Lab1_Default2 : System.Web.UI.Page
{

    /// <summary>
    /// Loads the webpage
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {

        //on GET from client Initialize control state
        if (!IsPostBack)
        {
            //Create the list items and add them to the list
            ListItem tempItem = new ListItem("Gluten Free");
            RdBtnLstDietReqs.Items.Add(tempItem);
            tempItem = new ListItem("Vegeterian");
            RdBtnLstDietReqs.Items.Add(tempItem);
            tempItem = new ListItem("NA");
            RdBtnLstDietReqs.Items.Add(tempItem);
            RdBtnLstDietReqs.SelectedValue = "NA";  //Set the default list item
            Calendar1.SelectedDate = Calendar1.TodaysDate; // Set the default calendar selected date to todays date.
        }

    }

    /// <summary>
    /// btnAddReg Click event handler calls the validate method to ensure required user input then adds
    /// the information from a text box, calendar and radio button group to a listbox.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddReg_Click(object sender, EventArgs e)
    {
        //Only create the registration item if all input is valid
        if (validate())
        {
            //lblStatus.Text = "validated!";
            String regString = txtName.Text + ", " + RdBtnLstDietReqs.SelectedValue.ToString()
              + ", " + Calendar1.SelectedDate.ToShortDateString();

            //Create a list item with the string from user input.
            ListItem registration = new ListItem(regString);

            //Add the list item to the list
            lstbxRegs.Items.Add(registration);

            //Clear the calendar and text box upon successfull add.
            Calendar1.SelectedDate = Calendar1.TodaysDate;
            txtName.Text = "";
        }
        else
        {
            //Used for debuging purposes
            //lblStatus.Text = "Failed to validate!";
        }
    }

    /// <summary>
    /// txtName textbox TextChanged event handler, checks user input using postback to 
    /// update the error messages.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void txtName_TextChanged(object sender, EventArgs e)
    {
        validate(); //validates all user input

    }

    /// <summary>
    /// Calendar1 calendar item SelectionChanged event handler, checks user input using postback to 
    /// update the error messages.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        validate(); //validates all user input
    }

    /// <summary>
    /// validate() is called by event handlers to ensure user input is valid.
    /// 
    /// </summary>
    /// <returns>a boolean value, true if valid user input, false invalid user input.</returns>
    protected Boolean validate()
    {
        //Set flags for valid state of input
        Boolean cal = false;
        Boolean name = false;

        //Validate calendar
        //Enable the Calendar error message, only remove if valid input recived.
        lblTxtCalError.Visible = true;

        //Check valid calendar selection
        if (Calendar1.SelectedDate.DayOfWeek.ToString() == "Saturday" ||
            Calendar1.SelectedDate.DayOfWeek.ToString() == "Sunday")
        {
            //remove the error message and set valid state to true.
            lblTxtCalError.Visible = false;
            cal = true;
        }

        //Validate text box
        //Enable the Textbox error message, only remove if valid input recived.
        lbltxtNameError.Visible = true;

        //Change the color of the textbox using CSS
        txtName.CssClass = "error";

        //Check for a value in Textbox
        if (txtName.Text != "")
        {
            //Value in textbox, remove the flag, reset the CSS class to default
            lbltxtNameError.Visible = false;
            txtName.CssClass = "";
            //Set the textbox valid state to true.
            name = true;
        }

        //return true if cal and name are both valid, otherwise false.
        return cal && name;
    }

    /// <summary>
    /// lstbxRegs listbox SelectedIndexChanged changed event handler
    /// calls the hideCancel method to remove the cancel button if there
    /// are no items in the lstbxRegs listbox.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lstbxRegs_SelectedIndexChanged(object sender, EventArgs e)
    {
        hideCancel();
    }

    /// <summary>
    /// btnCancelReg button Click event handler removes a selected item from the 
    /// lstbxRegs listbox and adds it to the lstbxCancelRegs listbox. The button is
    /// only visable when there are items in the lstbxRegs and an item has been selected.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancelReg_Click(object sender, EventArgs e)
    {
        //get every selected item in the lstbxRegs, add it to a temp list
        //then remove them from the lstbxRegs listbox.Then use the
        //temp listbox to add the registration items to the lstbxCancelRegs
        //listbox.

        //Temp list to hold registrations being transferred
        List<ListItem> remove = new List<ListItem>();

        //Loop through all registrations and pull out the ones that are 
        //selected
        foreach (ListItem item in lstbxRegs.Items)
        {
            //add the selected registrations to the remove list
            if (item.Selected == true)
            {
                remove.Add(item);
            }
        }
        //remove the items from the registration list and add them to the canceled list.
        foreach (ListItem item in remove)
        {
            lstbxRegs.Items.Remove(item);
            lstbxCancelRegs.Items.Add(item);
        }
        //Remove the selecetd flag from all the registration items transfered
        lstbxCancelRegs.ClearSelection();
        //hide the cancel button
        hideCancel();
    }

    /// <summary>
    /// hideCancel checks if any items in the registrations list box are selected.
    /// if there are items selected, then the cancel button is shown, otherwise it
    /// is hidden.
    /// </summary>
    protected void hideCancel()
    {
        //Check if items are selected
        if (lstbxRegs.SelectedIndex >= 0)
        {
            btnCancelReg.Visible = true; //Show the cancel button
        }
        else
        {
            btnCancelReg.Visible = false; //Hide the cancel button
        }
    }
}