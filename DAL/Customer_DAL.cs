﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAL
{
    public class Customer_DAL
    {
        private static Customer_DAL _Instance;
        public static Customer_DAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Customer_DAL();
                }
                return _Instance;
            }
            private set { } //chỉ nội bộ lớp này mới đc set dữ liệu vào
        }
        private Customer_DAL() { }
        DataTable customers = new DataTable();
        public DataTable GetRecords()
        {
            string query = "select ID_Customer,Name_Customer,Gender_Customer,Address_Customer,PhoneNumber_Customer,AccountNumber from Customer";
            customers = DataProvider.Instance.GetRecords(query);
            return customers;
        }
        public void addCustomer(Customer customer)
        {
            string query = "insert into Customer(Name_Customer,Gender_Customer,Address_Customer,PhoneNumber_Customer,AccountNumber) " +
                    "values (N'" + customer.Name_Customer + "',N'" + customer.Gender_Customer + "',N'" + customer.Address_Customer + "','" + customer.PhoneNumber_Customer + "','" +
                    customer.AccountNumber + "')";
            DataProvider.Instance.ExcuteDB(query);
        }
        public void updateCustomer(Customer customer)
        {
            string query = "update Customer set Name_Customer = N'" + customer.Name_Customer + "', Gender_Customer = N'" + customer.Gender_Customer + "', Address_Customer = N'" + customer.Address_Customer + "', PhoneNumber_Customer = '" + customer.PhoneNumber_Customer + "', AccountNumber = '" + customer.AccountNumber + "' where ID_Customer = '" + customer.ID_Customer + "'";
            DataProvider.Instance.ExcuteDB(query);
        }
        public void deleteCustomer(Customer customer, string id_customer)
        {
            string query = "delete from Customer where ID_Customer = '" + id_customer + "'";
            DataProvider.Instance.ExcuteDB(query);
        }
    }
}