using DDD.BackEndTiendaProductos.Domain.Contracts.Services;
using DDD.BackEndTiendaProductos.Domain.Models;
using DDD.BackEndTiendaProductos.WebApi.Controllers.Swagger;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace DDD.BackEndTiendaProductos.WebApi.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices; // Servicio de productos

        //Constructor que inyecta el servicio de aplicación y el mapeador
        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        /// <summary>
        /// Obtiene todos los productos
        /// </summary>
        /// <returns>Lista completa de produtos existentes</returns>
        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(IEnumerable<ProductResponseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await _productServices.GetAllProductAsync();
            return Ok(response);
        }
        /// <summary>
        /// Busca un producto por su id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Producto con el id proporcionado</returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(OkResponseModel),StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductById([FromRoute]int id)
        {
            var response = await _productServices.GetProductByIdAsync(id);
            
            return Ok(response);
        }

        /// <summary>
        /// Crea un nuevo Producto
        /// </summary>
        /// <param name="model">El ProductModel recibido como request</param>
        /// <returns>Codigo de respuesta con el mensaje de exito o fracaso de la operación</returns>
        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(OkResponseModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponseExample(StatusCodes.Status200OK,typeof(ProductModelExample))]
        [Produces("application/json")]
        public async Task<ActionResult> PostProduct([FromBody] ProductModel model)
        {
            var response = await _productServices.AddProductAsync(model);
            return Ok(response);
        }

        /// <summary>
        /// Elimina un Producto
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Codigo de respuesta con el mensaje de exito o fracaso de la operación</returns>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(OkResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            var response = await _productServices.DeleteProductAsync(id);
            return Ok(response);
        }
        /// <summary>
        /// Actualiza un producto
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns>Codigo de respuesta con el mensaje de exito o fracaso de la operación</returns>
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(OkResponseModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateProducts([FromBody] ProductModel model,[FromRoute] int id)
        {
            var response = await _productServices.UpdateProductAsync(model, id);

            return Ok(response);
        }

    }
}
