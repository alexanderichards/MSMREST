using Mango.Services.ProductAPI.Models.DTO;
using Mango.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ProductAPI.Controllers
{
    [Route("/api/products")]
    public class ProductAPIController : ControllerBase
    {
        protected ResponseDTO _responseDTO;
        private IProductRepository _productRepository;

        public ProductAPIController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            this._responseDTO = new ResponseDTO();
        }
       

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<ProductDTO> productDTOs = await _productRepository.GetProducts();
                _responseDTO.Result = productDTOs;
            }
            catch (Exception ex)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.ErrorMessages = new List<string>() { ex.ToString()};
            }

            return _responseDTO;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                ProductDTO productDTO = await _productRepository.GetProductById(id);
                _responseDTO.Result = productDTO;
            }
            catch (Exception ex)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _responseDTO;
        }
    }
}
