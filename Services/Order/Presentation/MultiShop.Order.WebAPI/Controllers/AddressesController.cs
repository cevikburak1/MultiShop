using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandler;
using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;

namespace MultiShop.Order.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly GetAddressQueryHandler _getAddressQueryHandler;
        private readonly GetAddressByIdQueryHandler _getAddressByIdQueryHandler;
        private readonly CreateAddressCommandHandler _createAddressCommand;
        private readonly UpdateAddressCommandHandler _updateAddressCommand;
        private readonly RemoveAddressCommandHandler _removeAddressCommand;
        public AddressesController(GetAddressQueryHandler getAddressQueryHandler, GetAddressByIdQueryHandler getAddressByIdQueryHandler, CreateAddressCommandHandler createAddressCommand, UpdateAddressCommandHandler updateAddressCommand, RemoveAddressCommandHandler removeAddressCommand)
        {
            _getAddressQueryHandler = getAddressQueryHandler;
            _getAddressByIdQueryHandler = getAddressByIdQueryHandler;
            _createAddressCommand = createAddressCommand;
            _updateAddressCommand = updateAddressCommand;
            _removeAddressCommand = removeAddressCommand;
        }

        [HttpGet]
        public async Task<IActionResult> AddressList()
        {
            var result = await _getAddressQueryHandler.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> AddressListById(int id)
        {
            var result = await _getAddressByIdQueryHandler.Handle(new GetAddressByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand createAddressCommand)
        {
            await _createAddressCommand.Handle(createAddressCommand);
            return Ok("Adress Bilgisi Başarı İle Eklendi✔");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand updateAddressCommand)
        {
            await _updateAddressCommand.Handle(updateAddressCommand);
            return Ok("Adress Bilgisi Başarı İle Güncellendi✔");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAddress(int id)
        {
            await _removeAddressCommand.Handle(new RemoveAddressCommand(id));
            return Ok("Adress Bilgisi Başarı İle Silindi✔");
        }
    }
}
