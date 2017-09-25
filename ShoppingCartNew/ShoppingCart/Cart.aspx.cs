using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingCart
{
    public partial class Cart : System.Web.UI.Page
    {
        Dictionary<string, float> cartItem;
        Dictionary<string, int> itemQty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cartItem"] != null)
            {
                float productTotal = 0;
                float purchase = 0;
                cartItem = (Dictionary<string, float>)Session["cartItem"];
                itemQty = (Dictionary<string, int>)Session["itemQty"];
                foreach (KeyValuePair<string, float> pair in cartItem)
                {
                    TableCell productName = new TableCell();
                    TableCell productQuantity = new TableCell();
                    TableCell price = new TableCell();
                    productName.Text = pair.Key;
                    productQuantity.Text = itemQty[pair.Key].ToString();
                    productTotal = itemQty[pair.Key] * pair.Value;
                    purchase += productTotal;
                    price.Text = productTotal.ToString();
                    TableRow productRow = new TableRow();
                    productRow.Cells.Add(productName);
                    productRow.Cells.Add(productQuantity);
                    productRow.Cells.Add(price);
                    CartTable.Rows.Add(productRow);
                }
                PayableAmount.Text = purchase.ToString();
                PayableAmount.Visible = true;
                Session["purchase"] = purchase;
            }
            else Response.Redirect("Home.aspx");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Order.aspx");
        }
    }
}
