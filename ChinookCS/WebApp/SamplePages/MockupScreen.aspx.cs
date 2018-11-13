using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public class DummyData
    {
        public string id { get; set; }
        public string name { get; set; }
        public string Picked { get; set; }
        public string Issues { get; set; }
    }
    public partial class MockupScreen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<DummyData> myData = new List<DummyData>();
            DummyData item = new DummyData
            {
                id = "41",
                name = "bob",
                Picked = "4",
                Issues = ""

            };
            myData.Add(item);
            item = new DummyData
            {
                id = "12",
                name = "do food",
                Picked = "2",
                Issues = "insufficient stock"
            };
            myData.Add(item);
            item = new DummyData
            {
                id = "123",
                name = "human food",
                Picked = "",
                Issues = ""

            };
            myData.Add(item);
            GridView1.DataSource = myData;
            GridView1.DataBind();
        }
    }
}