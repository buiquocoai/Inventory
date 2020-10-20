using Dapper;
using InventoryAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryAPI.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IConfiguration _config;
        public CustomerRepository(IConfiguration config)
        {
            _config = config;
        }
        public IDbConnection connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("InventoryDatabase"));
            }
        }
        public async Task<List<Customer>> GetCustomers()
        {
            try
            {
                using (IDbConnection con = connection)
                {
                    string Query = "USP_Customer";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@ACTION", "A");
                    var result = await con.QueryAsync<Customer>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Customer> DeleteCustomer(int id)
        {
            try
            {
                using (IDbConnection con = connection)
                {
                    string Query = "USP_Customer";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@ACTION", "D");
                    param.Add("@CUSTID", id);
                    var result = await con.QueryAsync<Customer>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Customer> ADDEditCustomer(Customer customer)
        {
            try
            {
                using (IDbConnection con = connection)
                {
                    string sQuery = "USP_Customer";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@ACTION", "E");
                    param.Add("@CUSTID", customer.CustID);
                    param.Add("@NAME", customer.Name);
                    param.Add("@AGE", customer.Age);
                    param.Add("@COMPANY", customer.Company);
                    param.Add("@EMAIL", customer.Email);
                    param.Add("@PHONE", customer.Phone);
                    param.Add("@ADDRESS", customer.Address);                    
                    var result = await con.QueryAsync<Customer>(sQuery, param, commandType: CommandType.StoredProcedure);
                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Customer> GetCustomerByID(int id)
        {
            try
            {
                using (IDbConnection con = connection)
                {
                    string sQuery = "USP_Customer";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@ACTION", "G");
                    param.Add("@CUSTID", id);
                    var result = await con.QueryAsync<Customer>(sQuery, param, commandType: CommandType.StoredProcedure);
                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DoesItemExist(int id)
        {
            throw new NotImplementedException();
        }
    }
}
