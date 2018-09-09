using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ticketing;
/// <summary>
/// Ticket Management Page to add the ability to create tickets.
/// </summary>
public partial class Lab2_Default : System.Web.UI.Page
{
    User[] users = UserUtility.Instance.GetUsers();
    Category[] categories = CategoryUtility.Instance.GetCategories();
    /// <summary>
    /// Build the dropdownlists dynamically on page load.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {

        //on GET from client Initialize control state
        if (!IsPostBack)
        {
           
            foreach (User l in users)
            {
                drlstUser.Items.Add(l.FirstName + " " + l.LastName);
            }
            foreach (Category l in categories)
            {
                drlstCat.Items.Add(l.Name);
            }
            

        }
        loadTickets();

    }
    /// <summary>
    /// Loads tickets into a list then filters them if needed and adds them to the ticket table.
    /// By default, the filter will will show “All”. user selects a specific  category, then all 
    /// the tickets related to the category will appear. If user selects a user, similarly, the
    /// tickets designated to the selected user are shown.
    /// BONUS implemented if user selects both a category & a user, you show tickets which are associated to both.
    /// </summary>
    private void loadTickets()
    {
        
        foreach (Ticket l in TicketsUtility.Instance.GetTickets())
        {
            addTickTable(l);

        }

    }
    protected void addTickTable(Ticket l)
    {
        TableRow row = new TableRow();
        TableCell titleCell = new TableCell();
        TableCell userCell = new TableCell();
        TableCell catCell = new TableCell();
        TableCell descCell = new TableCell();

        titleCell.Text = l.Title;
        row.Cells.Add(titleCell);
        userCell.Text = l.User.FirstName;
        row.Cells.Add(userCell);
        catCell.Text = l.Cateogry;
        row.Cells.Add(catCell);
        descCell.Text = l.Description;
        row.Cells.Add(descCell);
        tblTickets.Rows.Add(row);

    }

    /// <summary>
    /// Validates input then Adds a ticket to the system.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubTick_Click(object sender, EventArgs e)
    {
        if (validate())
        {
            String title = txtBxTitle.Text;
            String Cat= drlstCat.SelectedValue.ToString();
            User usr = users[drlstUser.SelectedIndex];
            String Desc = txtAreaDesc.Text;
            TicketsUtility.Instance.SaveTicket(title,Cat,usr,Desc);
            Ticket lastTick = new Ticket();
            lastTick.Cateogry = Cat;
            lastTick.Description = Desc;
            lastTick.Title = title;
            lastTick.User = usr;
            addTickTable(lastTick);

            txtBxTitle.Text = "";
            txtAreaDesc.Text = "";
            lblAddTickStatus.Text = "Ticket Added!";
            
            
        }
        else
        {
            inputError();
        }

    }
    /// <summary>
    /// Validate input on text changed. Simple message should show PRIOR to adding the the user.
    /// title (string no more than 50 characters)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void txtBxTitle_TextChanged(object sender, EventArgs e)
    {
        if (validate())
        {
            lblAddTickStatus.Text = "";
        }
        else
        {
            inputError();
        }

    }

    /// <summary>
    /// Validate input on text changed. Simple message should show PRIOR to adding the the user.
    /// description (larger text area) cannot be blank.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void txtAreaDesc_TextChanged(object sender, EventArgs e)
    {
        if (validate())
        {
            lblAddTickStatus.Text = "";
        }
        else
        {
            inputError();
        }

    }
    
    /// <summary>
    /// Simple message should show prior to adding the the user.
    /// </summary>
    private void inputError()
    {
        lblAddTickStatus.Text = "Invalid entry, Input areas cannot be blank and Title must be between 1 and 50 characters";
    }

    /// <summary>
    /// tickets will have the following fields along with their validations:
    /// title (string no more than 50 characters)
    /// category (selection from a list based on entries added from previous steps)
    /// designated user (selection from a list based on entries added from previous steps)
    /// description (larger text area)
    /// </summary>
    /// <returns></returns>
    protected bool validate()
    {
        return validateString(txtBxTitle.Text) && validateTextArea(txtAreaDesc.Text) && validateLists(drlstCat) && validateLists(drlstUser);



    }
    /// <summary>
    /// Validate list should have item selected.
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    private bool validateLists(DropDownList list)
    {
        if (list.SelectedIndex == -1)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    /// <summary>
    /// Validate not empty/null and string is 1 to 50 characters.
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    protected bool validateString(string x)
    {
        if (String.IsNullOrEmpty(x) ||  x.Length > 50)
        {
            return false;
        }
        foreach (Category l in CategoryUtility.Instance.GetCategories())
        {
            if (l.Name.Equals(x))
            {
                return false;
            }

        }
        return true;

    }
    /// <summary>
    /// Validate not empty/null.
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    protected bool validateTextArea(string x)
    {
        if (String.IsNullOrEmpty(x))
        {
            return false;
        }
        else        
        return true;

    }
   
   
}