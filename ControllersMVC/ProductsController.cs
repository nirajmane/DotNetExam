using Q1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Q1.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            List<Product> ls = new List<Product>();
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Exam;Integrated Security=True;";
            sc.Open();
            SqlCommand scm = new SqlCommand();
            scm.Connection = sc;
            scm.CommandType = System.Data.CommandType.Text;
            scm.CommandText = "select * from Products";
            SqlDataReader dr = scm.ExecuteReader();
            while (dr.Read())
            {
                ls.Add(new Product { ProductId = (int)dr["ProductId"], ProductName = (string)dr["ProductName"], Rate = (decimal)dr["Rate"], Description = (string)dr["Description"], CategoryName = (string)dr["CategoryName"] });
            }
            dr.Close();
            sc.Close();
            return View(ls);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            Product Prod = new Product();
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Exam;Integrated Security=True;";
            sc.Open();
            SqlCommand scm = new SqlCommand();
            scm.Connection = sc;
            scm.CommandType = System.Data.CommandType.Text;
            scm.CommandText = "select * from Products where ProductId=@Id";
            scm.Parameters.AddWithValue("@Id", id);
            SqlDataReader dr = scm.ExecuteReader();
            while (dr.Read())
            {
                Prod = new Product { ProductId = (int)dr["ProductId"], ProductName = (string)dr["ProductName"], Rate = (decimal)dr["Rate"], Description = (string)dr["Description"], CategoryName = (string)dr["CategoryName"] };
            }
            dr.Close();
            sc.Close();
            return View(Prod);
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product Prod)
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Exam;Integrated Security=True;";
            sc.Open();
            SqlCommand scm = new SqlCommand();
            scm.Connection = sc;
            scm.CommandType = System.Data.CommandType.Text;
            scm.CommandText = "update Products set ProductName = @ProductName, Rate = @Rate, Description = @Description, CategoryName = @CategoryName where ProductId = @ProductId";
          
            scm.Parameters.AddWithValue ("@ProductId",id);
            scm.Parameters.AddWithValue("@ProductName", Prod.ProductName);
            scm.Parameters.AddWithValue("@Rate", Prod.Rate);
            scm.Parameters.AddWithValue("@Description", Prod.Description);
            scm.Parameters.AddWithValue("@CategoryName", Prod.CategoryName);

            scm.ExecuteNonQuery();
            sc.Close();
         
            return RedirectToAction("Index");
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
