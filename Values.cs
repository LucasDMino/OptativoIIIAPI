using ASPWEBAPI2.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ASPWEBAPI2.Controllers
{
    public class ValuesController : ApiController
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webapi_conn"].ConnectionString);
        Ciudad ciu = new Ciudad();
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public string Post(Ciudad ciudad)
        {
            string msg = "";
            if(ciudad != null)
            {
                SqlCommand cmd = new SqlCommand("usp_AddCiudad", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CiudadNombre", ciudad.CiudadNombre);
                cmd.Parameters.AddWithValue("@Departamento", ciudad.Departamento);
                cmd.Parameters.AddWithValue("@PostalCode", ciudad.PostalCode);
                con.Open();
                int i = ExecuteNonQuery();
                con.Close();
                if(i > 0)
                {
                    msg = "Se han insertado los datos";

                }else { msg = "Error"; }



            }
            return msg;
        }

        private int ExecuteNonQuery()
        {
            throw new NotImplementedException();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
