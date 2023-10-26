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

    ///----------------------------------------------------CLASS CIUDAD------------------------------------------------
    public class ValuesController : ApiController
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webapi_conn"].ConnectionString);
        Ciudad ciu = new Ciudad();
        // GET api/values
        public List<Ciudad> Get()
        {
            SqlDataAdapter da = new SqlDataAdapter("usp_GetAllCiudad",con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Ciudad> lstCiudad = new List<Ciudad>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Ciudad ciu = new Ciudad();
                    ciu.idCiudad = Convert.ToInt32(dt.Rows[i]["IdCiudad"]);
                    ciu.CiudadNombre = dt.Rows[i]["CiudadNombre"].ToString();
                    ciu.Departamento = dt.Rows[i]["Departamento"].ToString();
                    ciu.PostalCode = Convert.ToInt32(dt.Rows[i]["PostalCode"]);
                    lstCiudad.Add(ciu);
                }
            }
            if (lstCiudad.Count > 0)
            {
                return lstCiudad;
            }
            else { return null; }
        }

        // GET api/values/5
        public Ciudad Get(int id)
        {
            SqlDataAdapter da = new SqlDataAdapter("usp_GetAllCiudadById", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@idCiudad", id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Ciudad ciu = new Ciudad();
            if (dt.Rows.Count > 0)
            {
                    ciu.idCiudad = Convert.ToInt32(dt.Rows[0]["IdCiudad"]);
                    ciu.CiudadNombre = dt.Rows[0]["CiudadNombre"].ToString();
                    ciu.Departamento = dt.Rows[0]["Departamento"].ToString();
                    ciu.PostalCode = Convert.ToInt32(dt.Rows[0]["PostalCode"]);
                
            }
            if (ciu != null)
            {
                return ciu;
            }
            else { return null; }
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
        public string Put(int id, Ciudad ciudad)
        {
            string msg = "";
            if (ciudad != null)
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateCiudad", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCiudad", id);
                cmd.Parameters.AddWithValue("@CiudadNombre", ciudad.CiudadNombre);
                cmd.Parameters.AddWithValue("@Departamento", ciudad.Departamento);
                cmd.Parameters.AddWithValue("@PostalCode", ciudad.PostalCode);
                con.Open();
                int i = ExecuteNonQuery();
                con.Close();
                if (i > 0)
                {
                    msg = "Se han actualizado los datos";

                }
                else { msg = "Error"; }



            }
            return msg;
        }

        // DELETE api/values/5
        public string Delete(int id)
        {
            string msg = "";

                SqlCommand cmd = new SqlCommand("usp_DeleteCiudad", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCiudad", id);
                con.Open();
                int i = ExecuteNonQuery();
                con.Close();
                if (i > 0)
                {
                    msg = "Se han borrado los datos";

                }
                else { msg = "Error"; }
            return msg;
        }

     


    }

    ///----------------------------------------------------CLASS PERSONA------------------------------------------------

    public class ValuesController2 : ApiController
    {
        SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["webapi_conn"].ConnectionString);
        Persona per = new Persona();
        // GET api/values
        public List<Persona> Get()
        {
            SqlDataAdapter da = new SqlDataAdapter("usp_GetAllPersona", con2);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Persona> lstPersona = new List<Persona>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Persona per = new Persona();
                    per.idPersona = Convert.ToInt32(dt.Rows[i]["idPersona"]);
                    per.idCiudad = Convert.ToInt32(dt.Rows[i]["IdCiudad"]);
                    per.Nombre = dt.Rows[i]["Nombre"].ToString();
                    per.Apellido = dt.Rows[i]["Apellido"].ToString();
                    per.Direccion = dt.Rows[i]["Direccion"].ToString();
                    per.Email = dt.Rows[i]["Email"].ToString();
                    per.Celular = dt.Rows[i]["Celular"].ToString();
                    per.Edad = dt.Rows[i]["Edad"].ToString();
                    lstPersona.Add(per);
                }
            }
            if (lstPersona.Count > 0)
            {
                return lstPersona;
            }
            else { return null; }
        }

        // GET api/values/5
        public Persona Get(int id)
        {
            SqlDataAdapter da = new SqlDataAdapter("usp_GetAllPersonaById", con2);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@idPersona", id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Persona per = new Persona();
            if (dt.Rows.Count > 0)
            {
                per.idPersona = Convert.ToInt32(dt.Rows[0]["idPersona"]);
                per.idCiudad = Convert.ToInt32(dt.Rows[0]["IdCiudad"]);
                per.Nombre = dt.Rows[0]["Nombre"].ToString();
                per.Apellido = dt.Rows[0]["Apellido"].ToString();
                per.Direccion = dt.Rows[0]["Direccion"].ToString();
                per.Email = dt.Rows[0]["Email"].ToString();
                per.Celular = dt.Rows[0]["Celular"].ToString();
                per.Edad = dt.Rows[0]["Edad"].ToString();

            }
            if (per != null)
            {
                return per;
            }
            else { return null; }
        }

        // POST api/values
        public string Post(Persona persona)
        {
            string msg = "";
            if (persona != null)
            {
                SqlCommand cmd = new SqlCommand("usp_AddPersona", con2);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCiudad", persona.idCiudad);
                cmd.Parameters.AddWithValue("@Nombre", persona.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", persona.Apellido);
                cmd.Parameters.AddWithValue("@Direccion", persona.Direccion);
                cmd.Parameters.AddWithValue("@Email", persona.Email);
                cmd.Parameters.AddWithValue("@Celular", persona.Celular);
                cmd.Parameters.AddWithValue("@Edad", persona.Edad);
                con2.Open();
                int i = ExecuteNonQuery();
                con2.Close();
                if (i > 0)
                {
                    msg = "Se han insertado los datos";

                }
                else { msg = "Error"; }



            }
            return msg;
        }

        private int ExecuteNonQuery()
        {
            throw new NotImplementedException();
        }

        // PUT api/values/5
        public string Put(int id, Persona persona)
        {
            string msg = "";
            if (persona != null)
            {
                SqlCommand cmd = new SqlCommand("usp_UpdatePersona", con2);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPersona", id);
                cmd.Parameters.AddWithValue("@IdCiudad", persona.idCiudad);
                cmd.Parameters.AddWithValue("@Nombre", persona.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", persona.Apellido);
                cmd.Parameters.AddWithValue("@Direccion", persona.Direccion);
                cmd.Parameters.AddWithValue("@Email", persona.Email);
                cmd.Parameters.AddWithValue("@Celular", persona.Celular);
                cmd.Parameters.AddWithValue("@Edad", persona.Edad);
                con2.Open();
                int i = ExecuteNonQuery();
                con2.Close();
                if (i > 0)
                {
                    msg = "Se han actualizado los datos";

                }
                else { msg = "Error"; }



            }
            return msg;
        }

        // DELETE api/values/5
        public string Delete(int id)
        {
            string msg = "";

            SqlCommand cmd = new SqlCommand("usp_DeletePersona", con2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idPersona", id);
            con2.Open();
            int i = ExecuteNonQuery();
            con2.Close();
            if (i > 0)
            {
                msg = "Se han borrado los datos";

            }
            else { msg = "Error"; }
            return msg;
        }




    }
}
