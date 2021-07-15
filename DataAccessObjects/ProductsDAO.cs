using DataTransferObjects;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessObjects
{
    public class ProductsDAO
    {
        private IConfiguration Configuration;

        public ProductsDAO(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        public List<ProductsDTO> GetCartProductsForUser (int UserId)
        {
            ConnectionDAO objConnectionDAO = new ConnectionDAO(Configuration);
            SqlConnection objSqlConnection = objConnectionDAO.OpenConnection();
            List<ProductsDTO> lstProducts = new List<ProductsDTO>();
            try
            {
                SqlCommand objSqlCommand = new SqlCommand("Select * from Products", objSqlConnection);
                SqlDataReader objSqlDataReader = objSqlCommand.ExecuteReader();
                while (objSqlDataReader.Read())
                {
                    var products = new ProductsDTO();

                    products.ProductId = Convert.ToInt32(objSqlDataReader["PRODUCT_ID"]);
                    products.ProductName = objSqlDataReader["PRODUCT_NAME"].ToString();
                    products.ProductImage = objSqlDataReader["PRODUCT_IMAGE"].ToString();
                    products.Cost = Convert.ToDecimal(objSqlDataReader["COST"]);
                    products.Quantity = new Random().Next(1, 4);
                    lstProducts.Add(products);
                }
            }
            catch (Exception)
            {
                objConnectionDAO.CloseConnection();
            }
            finally
            {
                objConnectionDAO.CloseConnection();
            }
            return lstProducts;
        }
    }
}
