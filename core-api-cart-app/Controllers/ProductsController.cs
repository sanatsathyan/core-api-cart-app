using DataAccessObjects;
using DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace core_api_cart_app.Controllers
{
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IConfiguration Configuration;

        public ProductsController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        [Route("api/cart/{userId}")]
        [HttpGet]
        public JsonResult GetCartProducts(int userId)
        {
            ProductsDAO objProductsDAO = new ProductsDAO(Configuration);
            List<ProductsDTO> lstProducts = objProductsDAO.GetCartProductsForUser(userId);
            return new JsonResult(lstProducts);
        }
    }
}
