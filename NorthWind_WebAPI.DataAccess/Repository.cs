using Northwind_WebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Northwind_WebAPI.DataAccess
{
    public class Repository
    {
        const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Invoice> GetAllInvoices(string customerID)
        {
            string sql = $"SELECT CustomerName, ExtendedPrice, Freight FROM Invoices WHERE CustomerID LIKE '{customerID}'";
            DataRowCollection dataRows = Execute(sql);
            List<Invoice> invoices = ProcessInvoices(dataRows);
            return invoices;
        }

        public List<Customer> GetAllCustomers()
        {
            string sql = "SELECT DISTINCT CustomerID FROM Customers";
            DataRowCollection dataRows = Execute(sql);
            List<Customer> customers = ProcessCustomers(dataRows);
            return customers;
        }

        public List<Order> GetAllCompletedOrders(string customerID)
        {
            string sql = $"SELECT CustomerID, OrderDate, RequiredDate, ShippedDate, ShipAddress, ShipCountry FROM Orders WHERE ShippedDate IS NOT NULL AND CustomerID = '{customerID}'";
            DataRowCollection datarows = Execute(sql);
            List<Order> orders = ProcessOrders(datarows);
            return orders;
        }

        public List<Order> GetAllNonCompletedOrders(string customerID)
        {
            string sql = $"SELECT CustomerID, OrderDate, RequiredDate, ShippedDate, ShipAddress, ShipCountry FROM Orders WHERE ShippedDate IS NULL AND CustomerID = '{customerID}'";
            DataRowCollection datarows = Execute(sql);
            List<Order> orders = ProcessOrders(datarows);
            return orders;
        }

        private List<Order> ProcessOrders(DataRowCollection datarows)
        {
            List<Order> orders = new List<Order>();
            foreach(DataRow row in datarows)
            {
                string customerID = (string)row["CustomerID"];
                DateTime orderDate = (DateTime)row["OrderDate"];
                DateTime requiredDate = (DateTime)row["RequiredDate"];
                DateTime shippedDate = Convert.IsDBNull(row["ShippedDate"]) ? DateTime.MinValue : (DateTime)row["ShippedDate"];
                string shipAddress = (string)row["ShipAddress"];
                string shipCountry = (string)row["ShipCountry"];
                Order order = new Order(customerID, orderDate, requiredDate, shippedDate, shipAddress, shipCountry);
                orders.Add(order);
            }
            return orders;
        }

        private DataRowCollection Execute(string sql)
        {
            try
            {
                DataSet resultSet = new DataSet();
                using(SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand(sql, new SqlConnection(ConnectionString))))
                {
                    adapter.Fill(resultSet);
                }
                return resultSet.Tables[0].Rows;
            }
            catch(Exception)
            {
                throw;
            }
        }

        private List<Customer> ProcessCustomers(DataRowCollection dataRows)
        {
            List<Customer> customers = new List<Customer>();
            foreach(DataRow row in dataRows)
            {
                string customerName = (string)row["CustomerID"];
                Customer customer = new Customer() { CustomerName = customerName };
                customers.Add(customer);
            }
            return customers;
        }

        private List<Invoice> ProcessInvoices(DataRowCollection dataRows)
        {
            List<Invoice> invoices = new List<Invoice>();
            foreach(DataRow row in dataRows)
            {
                string customerName = (string)row["CustomerName"];
                decimal extendedPrice = (decimal)row["ExtendedPrice"];
                decimal freightPrice = (decimal)row["Freight"];
                Invoice invoice = new Invoice(customerName, extendedPrice, freightPrice);
                invoices.Add(invoice);
            }
            return invoices;
        }
    }
}