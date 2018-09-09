using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ticketing;
/// <summary>
/// User Management Page to be able to add users to the system.
/// </summary>
public partial class Lab2_Default : System.Web.UI.Page
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {

        loadUserList();


    }
    /// <summary>
    /// Validate input and add users to the system.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddUser_Click(object sender, EventArgs e)
    {
        if (validate())
        {
            UserUtility.Instance.SaveUser(txtBxFirstName.Text, txtBxLastName.Text, txtBxEmail.Text);
            addUserTable(txtBxFirstName.Text, txtBxLastName.Text, txtBxEmail.Text);
            txtBxFirstName.Text = "";
            txtBxLastName.Text = "";
            txtBxEmail.Text = "";
            lblAddUserStatus.Text = "User added!";

        }
        else
        {
            inputError();
        }

    }
    /// <summary>
    /// Validate input on text changed. Simple message should show PRIOR to adding the the user.
    /// FirstName (1 to 20 characters) 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void txtBxFirstName_TextChanged(object sender, EventArgs e)
    {
        if (!validate())
        {
            inputError();
        }
        else
        {
            lblAddUserStatus.Text = "";
        }


    }
    /// <summary>
    /// Validate input on text changed. Simple message should show PRIOR to adding the the user.
    /// LastName (1 to 20 characters)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void txtBxLastName_TextChanged(object sender, EventArgs e)
    {
        if (!validate())
        {
            inputError();
        }
        else
        {
            lblAddUserStatus.Text = "";
        }

    }
    /// <summary>
    /// Validate input on text changed. Simple message should show PRIOR to adding the the user.
    /// Email (must not be blank)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void txtBxEmail_TextChanged(object sender, EventArgs e)
    {
        if (!validate())
        {
            inputError();
        }
        else
        {
            lblAddUserStatus.Text = "";
        }

    }
    /// <summary>
    /// simple message should show prior to adding the the user.
    /// </summary>
    private void inputError()
    {
        lblAddUserStatus.Text = "Invalid entry, Input areas cannot be blank, FirstName/LastName must be between 1 and 20 characters and Email address must be unique.";
    }
    /// <summary>
    /// User will have the following fields with specified validations:
    /// FirstName (1 to 20 characters)
    /// LastName(1 to 20 characters)
    /// Email(must not be blank)
    /// </summary>
    /// <returns></returns>
    protected bool validate()
    {
        return validateString(txtBxFirstName.Text) && validateString(txtBxLastName.Text) && validateEmail(txtBxEmail.Text);



    }
    /// <summary>
    /// Validate not empty/null and string is 1 to 20 characters.
    /// </summary>
    /// <param name="x">String to be validated</param>
    /// <returns></returns>
    protected bool validateString(string x)
    {
        if (String.IsNullOrEmpty(x) || x.Length < 1 || x.Length > 20)
        {
            return false;
        }
        return true;

    }
    /// <summary>
    /// Validate not empty/null and prevent duplicate users with same email
    /// </summary>
    /// <param name="x">String to be validated</param>
    /// <returns></returns>
    protected bool validateEmail(string x)
    {
        //prevent duplicate users with same email
        User usr = UserUtility.Instance.GetUser(x);  //find if user exists with email
        if (usr != null)  //if user found return fail.
        {
            return false;
        }
        if (String.IsNullOrEmpty(x))
        {
            return false;
        }
        else
            return true;

    }
    /// <summary>
    /// Adds all users to a table.
    /// </summary>
    protected void loadUserList()
    {
        foreach (User l in UserUtility.Instance.GetUsers())
        {
            addUserTable(l.FirstName, l.LastName, l.Email);

        }
    }
    /// <summary>
    /// Adds the firstname, last name and email of a user to a row/cells
    /// and then adds the row into a table.
    /// </summary>
    /// <param name="fn">String with First name</param>
    /// <param name="ln">String with Last Name</param>
    /// <param name="em">String with Email</param>
    protected void addUserTable(string fn, string ln, string em)
    {
        TableRow row = new TableRow();
        TableCell fnCell = new TableCell();
        TableCell lnCell = new TableCell();
        TableCell emCell = new TableCell();

        fnCell.Text = fn;
        row.Cells.Add(fnCell);
        lnCell.Text = ln;
        row.Cells.Add(lnCell);
        emCell.Text = em;
        row.Cells.Add(emCell);
        tblUsers.Rows.Add(row);

    }
}