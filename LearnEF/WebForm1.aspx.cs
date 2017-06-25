using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LearnEF
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private static bool PageInited = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (PageInited) return;
            PageInited = true;
            ReloadData();
        }

        private void ReloadData()
        {
            int SelectedEmpID = string.IsNullOrEmpty(ddlEmployee.SelectedValue) ? -1 : int.Parse(ddlEmployee.SelectedValue);
            LearnEFEntities db = new LearnEFEntities();

            var empQuery = from emp in db.Employees
                           select emp;
            List<Employee> empList = empQuery.ToList();
            ddlEmployee.DataSource = empList;
            ddlEmployee.DataValueField = "EmpId";
            ddlEmployee.DataTextField = "FirstName";
            ddlEmployee.DataBind();
            
            ddlEmployee.Items.Insert(0, new ListItem("--Add New--", "0"));
            var selected = from emp in empList
                           where emp.EmpId== SelectedEmpID
                           select emp;
            if (selected.Any())
            {
                ddlEmployee.SelectedValue = SelectedEmpID.ToString();
            }
            //bind grid
            GridView1.DataSource = empList;
            GridView1.DataBind();
        }

        protected void btUpdate_Click(object sender, EventArgs e)
        {
            int SelectedEmpID = string.IsNullOrEmpty(ddlEmployee.SelectedValue) ? -1 : int.Parse(ddlEmployee.SelectedValue);
            //Read the record from the database.
            LearnEFEntities db = new LearnEFEntities();
            //following query will fetch a record based upon the EmpID passed through local variable empId
            var empQuery = from emp in db.Employees
                           where emp.EmpId == SelectedEmpID
                           select emp;
            Employee objEmp;
            if (!empQuery.Any())
            {
                objEmp = new Employee();
                db.Employees.Add(objEmp);
            }
            else
            {
                objEmp = empQuery.Single();
            }

            //set the new values of the columns (properties), based upon the values entered using the text boxes
            objEmp.HREmpId = txtHREmpID.Text;
            objEmp.FirstName = txtFirstName.Text;
            objEmp.LastName = txtLastName.Text;
            objEmp.Address = txtAddress.Text;
            objEmp.City = txtCity.Text;

            //save your changes into the database
            db.SaveChanges();
            ReloadData();
            ddlEmployee.SelectedValue = objEmp.EmpId.ToString();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int SelectedEmpID = string.IsNullOrEmpty(ddlEmployee.SelectedValue) ? -1 : int.Parse(ddlEmployee.SelectedValue);
            LearnEFEntities db = new LearnEFEntities();
            var empQuery = from emp in db.Employees
                           where emp.EmpId == SelectedEmpID
                           select emp;
            if(!empQuery.Any())
            {
                return;
            }
            //create a new object using the value of EmpId
            Employee objEmp = new Employee() { EmpId = SelectedEmpID };

            //attach object in the entity set
            db.Employees.Attach(objEmp);

            //mark the object for deletion
            db.Employees.Remove(objEmp);

            //save changes
            db.SaveChanges();
            ReloadData();
            txtHREmpID.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
        }


        protected void ddlEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            int SelectedEmpID = string.IsNullOrEmpty(ddlEmployee.SelectedValue) ? -1 : int.Parse(ddlEmployee.SelectedValue);
            LearnEFEntities db = new LearnEFEntities();
            var empQuery = from emp in db.Employees
                           where emp.EmpId == SelectedEmpID
                           select emp;
            if (empQuery.Any())
            {
                Employee objEmp = empQuery.Single();
                txtHREmpID.Text = objEmp.HREmpId;
                txtFirstName.Text = objEmp.FirstName;
                txtLastName.Text = objEmp.LastName;
                txtAddress.Text = objEmp.Address;
                txtCity.Text = objEmp.City;
            }
            else
            {
                txtHREmpID.Text = "";
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtAddress.Text = "";
                txtCity.Text = "";
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //below code does not work.....
            LearnEFEntities db = new LearnEFEntities();
            int ret = db.SearchEmployee(txtFirstNameSearch.Text, txtCitySearch.Text);
            db.Dispose();

            using (var context = new LearnEFEntities())
            {
                var firstNameParameter = new SqlParameter("@FirstName", txtFirstNameSearch.Text);
                var cityParameter = new SqlParameter("@City", txtCitySearch.Text);
                var result = context.Database
                    .SqlQuery<Employee>("SearchEmployee @FirstName, @City", firstNameParameter, cityParameter)
                    .ToList();
                //bind grid
                GridSearch.DataSource = result;
                GridSearch.DataBind();
            }
        }
    }
}