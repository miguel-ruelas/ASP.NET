using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ticketing;
/// <summary>
/// This page will simply have a text field along with a button allowing the 
/// visitor to add a category to the system.
/// </summary>
public partial class Lab2_Default : System.Web.UI.Page
{
    /// <summary>
    /// List all the categories currently in the system on Page Load.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {

        loadCatList();


    }
    /// <summary>
    /// button allowing the visitor to add a category to the system.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddCategory_Click(object sender, EventArgs e)
    {
        if (validate(txtBxCategory.Text))
        {
            CategoryUtility.Instance.AddCategory(txtBxCategory.Text);
            addCatTable(txtBxCategory.Text);
            lblCatStatus.Text = "";

        }
        else
        {
            lblCatStatus.Text = "Invalid entry, Category cannot be blank, must be unique and between 1 and 20 characters";
        }

    }
    /// <summary>
    /// Basic validation should not allow categories with minimum of 1 character upto 20 characters.
    /// You should also not allow duplicate categories.
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    protected bool validate(string x)
    {
        if (String.IsNullOrEmpty(x) || x.Length < 1 || x.Length > 20)
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
    /// Adds all categories in the system to a table.
    /// </summary>
    protected void loadCatList()
    {
        foreach (Category l in CategoryUtility.Instance.GetCategories())
        {
            addCatTable(l.Name);

        }
    }
    /// <summary>
    /// Puts a category name into a row/cell object and inserts it into a table
    /// </summary>
    /// <param name="l"></param>
    protected void addCatTable(string l)
    {
        TableRow row = new TableRow();
        TableCell cell = new TableCell();

        cell.Text = l;
        row.Cells.Add(cell);
        tblCategories.Rows.Add(row);

    }
}