﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind_WebAPI.Entities
{
    public class Order
    {
        private string customerID;
        private DateTime orderDate;
        private DateTime requiredDate;
        private DateTime shippedDate;
        private string shipAddress;
        private string shipCountry;
        private bool isShipped;

        public Order(string customerID, DateTime orderDate, DateTime requiredDate, 
            DateTime shippedDate, string shipAddress, string shipCountry)
        {
            CustomerID = customerID;
            OrderDate = orderDate;
            RequiredDate = requiredDate;
            ShippedDate = shippedDate;
            ShipAddress = shipAddress;
            ShipCountry = shipCountry;
            IsShipped = shippedDate == default;
        }

        public string CustomerID
        {
            get
            {
                return customerID;
            }

            set
            {
                customerID = value;
            }
        }

        public DateTime OrderDate
        {
            get
            {
                return orderDate;
            }

            set
            {
                orderDate = value;
            }
        }

        public DateTime RequiredDate
        {
            get
            {
                return requiredDate;
            }

            set
            {
                requiredDate = value;
            }
        }

        public DateTime ShippedDate
        {
            get
            {
                return shippedDate;
            }

            set
            {
                shippedDate = value;
            }
        }

        public string ShipAddress
        {
            get
            {
                return shipAddress;
            }

            set
            {
                shipAddress = value;
            }
        }

        public string ShipCountry
        {
            get
            {
                return shipCountry;
            }

            set
            {
                shipCountry = value;
            }
        }

        public bool IsShipped
        {
            get
            {
                return isShipped;
            }

            set
            {
                isShipped = value;
            }
        }
    }
}