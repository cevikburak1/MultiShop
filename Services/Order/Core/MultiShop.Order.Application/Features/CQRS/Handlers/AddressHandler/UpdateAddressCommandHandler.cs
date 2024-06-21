using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandler
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAddressCommand updateAddressCommand)
        {
            var result =await _repository.GetByIdAsync(updateAddressCommand.AddressId);
            result.Detail = updateAddressCommand.Detail;
            result.District = updateAddressCommand.District;
            result.City = updateAddressCommand.City;
            result.UserId = updateAddressCommand.UserId;
            await _repository.UpdateAsync(result);
        }
    }
}
