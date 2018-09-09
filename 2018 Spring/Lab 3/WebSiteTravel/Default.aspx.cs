using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if (!IsPostBack)
		{
			ImageButtonClearFields_Click(ImageButtonClearFields, null);
		}
    }

	protected void ImageButtonClearFields_Click(object sender, ImageClickEventArgs e)
	{
		//lets clear some fields...

		//reset it to the default text
		TextBoxSec3EmailBody.Text = @"Thanks for including me in the planning of your vacation.  I think a Carnival cruise would be a great choice for your next trip.  Carnival offers a broad range of options for onboard fun, including a Waterworks(tm) water park, a luxury spa, award-winning youth programs, and gourmet and casual dining options.  There truly is something for everyone.

Please let me knmow if you have any questions.  I look forward to helping you plan a fantastic vacation.";
		TextBoxSec3Subject.Text = "Your Carnival cruise eBrochure";

		//clear the rest
		TextBoxOfferPrice.Text =
			TextBoxSec2Recipients.Text =
			TextBoxSec4AgencyName.Text =
			TextBoxSec4AgencyWebsite.Text =
			TextBoxSec4City.Text =
			TextBoxSec4EmailAddress.Text =
			TextBoxSec4FaxNumber.Text =
			TextBoxSec4FirstName.Text =
			TextBoxSec4LastName.Text =
			TextBoxSec4PhoneExt.Text =
			TextBoxSec4PhonePart1.Text =
			TextBoxSec4PhonePart2.Text =
			TextBoxSec4PhonePart3.Text =
			TextBoxSec4State.Text =
			TextBoxSec4Street.Text =
			TextBoxSec4TollFreeNumber.Text =
			TextBoxSec4Zip.Text = String.Empty;


		DropDownListDays.ClearSelection();
		DropDownListDestinations.ClearSelection();
		CheckBoxSend.Checked = true;	//defaul is true

	}


	protected void ImageButtonNext_Click(object sender, ImageClickEventArgs e)
	{
        //TODO -- this is the event handler for the submit button
        if (this.IsValid)
        {
            Response.Redirect("Passed.aspx");
        }
    }

    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (DropDownListDestinations.SelectedIndex != 0)
            args.IsValid = true;
        if (DropDownListDestinations.SelectedIndex == 0)
        {
            if (DropDownListDays.SelectedIndex >= 6)
                args.IsValid = true;
            else
                args.IsValid = false;
        }
    }

    protected void CustomValidator3_ServerValidate(object source, ServerValidateEventArgs args)
    {
        args.IsValid = TextBoxSec3EmailBody.Text.Length < 501;
    }

    protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
    {
        args.IsValid = CheckBoxAgrement.Checked;
    }

}
