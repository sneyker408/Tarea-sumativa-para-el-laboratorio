﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ConexionEjemplo.Modelos;

namespace ConexionEjemplo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = 
                new SqlConnection
                ("Data Source=DESKTOP-JUKRMDJ\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True;");
            MessageBox.Show("Conexion creada");
            conexion.Open();

            //------------------------

            String selectFrom = "";
            selectFrom = selectFrom + "SELECT " + "\n";
            selectFrom = selectFrom + "      [CompanyName] " + "\n";
            selectFrom = selectFrom + "      ,[ContactName] " + "\n";
            selectFrom = selectFrom + "      ,[ContactTitle] " + "\n";
            selectFrom = selectFrom + "      ,[Address] " + "\n";
            selectFrom = selectFrom + "      ,[City] " + "\n";
            selectFrom = selectFrom + "      ,[Region] " + "\n";
            selectFrom = selectFrom + "      ,[PostalCode] " + "\n";
            selectFrom = selectFrom + "      ,[Country] " + "\n";
            selectFrom = selectFrom + "      ,[Phone] " + "\n";
            selectFrom = selectFrom + "      ,[Fax] " + "\n";
            selectFrom = selectFrom + "  FROM [dbo].[Customers]";

            //-----------------------

            SqlCommand comando = new SqlCommand(selectFrom, conexion);
            SqlDataReader reader = comando.ExecuteReader();

            List < Customers > Customers = new List < Customers >();

          while(reader.Read()){

                Customers customers = new Customers();
                customers.CompanyName = reader["CompanyName"] == DBNull.Value ? "" : (String)reader["CompanyName"];
                customers.ContactName =  reader["ContactName"] == DBNull.Value ?"": (String)reader["ContactName"];
                customers.ContactTitle = reader["ContactTitle"] == DBNull.Value ? "" : (String)reader["ContactTitle"];
                customers.Address =  reader["Address"] == DBNull.Value ? "" : (String)reader["Address"];
                customers.City =  reader["City"] == DBNull.Value ? "" : (String)reader["City"];
                customers.Region =  reader["Region"] == DBNull.Value ? "" : (String)reader["Region"];
                customers.PostalCode = reader["PostalCode"] == DBNull.Value ? "" : (String)reader["PostalCode"];
                customers.Country = reader["Country"] == DBNull.Value ? "" : (String)reader["Country"];
                customers.Phone = reader["Phone"] == DBNull.Value ? "" : (String)reader["Phone"];
                customers.Fax = reader["Fax"] == DBNull.Value ? "" : (String)reader["Fax"];
                
                Customers.Add(customers);
            }
            
            MessageBox.Show("Conexion cerrada");
            conexion.Close();
        }
    }
}
