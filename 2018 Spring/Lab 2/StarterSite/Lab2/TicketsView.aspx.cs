using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ticketing;
/// <summary>
/// Page for Viewing and filtering tickets by Category and by User
/// </summary>
public partial class Lab2_Default : System.Web.UI.Page
{
    User[] users = UserUtility.Instance.GetUsers();
    Category[] categories = CategoryUtility.Instance.GetCategories();
    Ticket[] tickets = TicketsUtility.Instance.GetTickets();
    /// <summary>
    /// Load users and categories and tickets dynamically on initial page load
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {

        //on GET from client Initialize control state
        if (!IsPostBack)
        {
            drlstUser.Items.Add("All");
            drlstCat.Items.Add("All");

            foreach (User l in users)
            {
                drlstUser.Items.Add(l.FirstName + " " + l.LastName);
            }
            foreach (Category l in categories)
            {
                drlstCat.Items.Add(l.Name);
            }
            loadTickets();
        }


    }
    /// <summary>
    /// Button to filter all the tickets in the system by either Category or User.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnFilter_Click(object sender, EventArgs e)
    {
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
        int selCat = drlstCat.SelectedIndex-1;
        int selUsr = drlstUser.SelectedIndex-1;
        List<Ticket> filtered = new List<Ticket>();
        foreach (Ticket l in tickets)
        {
            filtered.Add(l);

        }
  
        
        if (selUsr >= 0 && filtered.Count > 0)
        {
            filtered = filterUser(filtered, selUsr);
        }
        if (selCat >= 0 && filtered.Count > 0)
        {
            filtered = filterCat(filtered, selCat);
        }
        foreach (Ticket l in filtered)
        {
            addTickTable(l);
        }

    }
    /// <summary>
    /// Returns a filtered list of tickets by a specific category.
    /// </summary>
    /// <param name="filtered"></param>
    /// <param name="selCat"></param>
    /// <returns></returns>
    private List<Ticket> filterCat(List<Ticket> filtered, int selCat)
    {
        Category c = categories[selCat];
        List<Ticket> filteredByCat = new List<Ticket>();
        foreach (Ticket l in filtered)
        {
            if (l.Cateogry == c.Name)
            {
                filteredByCat.Add(l);
            }
        }
        return filteredByCat;
    }
    /// <summary>
    /// Returns a filtered list of tickets by a specific user.
    /// </summary>
    /// <param name="filtered"></param>
    /// <param name="selUsr"></param>
    /// <returns></returns>
    private List<Ticket> filterUser(List<Ticket> filtered, int selUsr)
    {
        User usr = users[selUsr];
        List<Ticket> filteredByUsr = new List<Ticket>();
        foreach (Ticket l in filtered)
        {
            if (l.User.FirstName == usr.FirstName)
            {
                filteredByUsr.Add(l);
            }
        }
        return filteredByUsr;
    }
    /// <summary>
    /// Adds an individual ticket to the ticket table.
    /// </summary>
    /// <param name="l"></param>
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
        descCell.Text=l.Description;
        row.Cells.Add(descCell);
        tblTickets.Rows.Add(row);

    }
}