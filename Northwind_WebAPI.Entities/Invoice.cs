using System;

namespace Northwind_WebAPI.Entities
{
    public class Invoice
    {
        int id;
        string shipName;
        string shipAddress;
        string shipCity;
        string shipRegion;
        string shipPostalCode;
        string shipCountry;
        string customerId;
        string customerName;
        string address;
        string city;
        string region;
        string postalCode;
        string country;
        string salesPerson;
        int orderId;
        DateTime orderDate;
        DateTime requiredDate;
        DateTime shippedDate;
        string shipperName;
        int productId;
        string productName;
        decimal unitPrice;
        int quantity;
        decimal discount;
        decimal extendedPrice;
        decimal freight;
    }
}
