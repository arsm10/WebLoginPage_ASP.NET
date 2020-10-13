using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerceWebsite.Models;
using System.Data.SqlClient;

namespace ECommerceWebsite.Controllers
{
    public class userLoginController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader sdr;

        // GET: userLogin
        [HttpGet]
        public ActionResult userAccess()
        {
            return View();
        }

        void connectionString() 
        {
            con.ConnectionString = "data source= LAPTOP-CEORD1LI; database= ECommerceDatabase; integrated security= SSPI;";
        }

        [HttpPost]
        public ActionResult userVerification(userLogin uL) 
        {
            connectionString();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select * from userLoginTable where Username='" + uL.username + "' and Password='" + uL.password + "'";
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                con.Close();
                return View("AccessGrant");
            }
            else 
            {
                con.Close();
                return View("Error");
            }
        }
    }
}