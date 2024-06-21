using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandler;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;

namespace MultiShop.Order.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly GetOrderDetailHandler _getOrderDetailQueryHandler;
        private readonly GetOrderDetailByIdQueryHandler _getOrderDetailByIdQueryHandler;
        private readonly CreateOrderDetailHandler _createOrderDetailCommand;
        private readonly UpdateOrderDetailCommandHandler _updateOrderDetailCommand;
        private readonly RemoveOrderDetailCommandHandler _removeOrderDetailCommand;
        public OrderDetailController(GetOrderDetailHandler getOrderDetailQueryHandler, GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler, CreateOrderDetailHandler createOrderDetailCommand, UpdateOrderDetailCommandHandler updateOrderDetailCommand, RemoveOrderDetailCommandHandler removeOrderDetailCommand)
        {
            _getOrderDetailQueryHandler = getOrderDetailQueryHandler;
            _getOrderDetailByIdQueryHandler = getOrderDetailByIdQueryHandler;
            _createOrderDetailCommand = createOrderDetailCommand;
            _updateOrderDetailCommand = updateOrderDetailCommand;
            _removeOrderDetailCommand = removeOrderDetailCommand;
        }

        [HttpGet]
        public async Task<IActionResult> OrderDetailList()
        {
            var result = await _getOrderDetailQueryHandler.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> OrderDetailListById(int id)
        {
            var result = await _getOrderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand createOrderDetailCommand)
        {
            await _createOrderDetailCommand.Handle(createOrderDetailCommand);
            return Ok("Sipariş Detay Bilgisi Başarı İle Eklendi✔");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetaİlCommands updateOrderDetailCommand)
        {
            await _updateOrderDetailCommand.Handle(updateOrderDetailCommand);
            return Ok("Sipariş Detay Bilgisi Başarı İle Güncellendi✔");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveOrderDetail(int id)
        {
            await _removeOrderDetailCommand.Handle(new RemoveOrderDetailCommand(id));
            return Ok("Sipariş Detay Bilgisi Başarı İle Silindi✔");
        }
    }
}
