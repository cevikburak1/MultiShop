using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandler
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderDetaİlCommands orderDetaİlCommands)
        {
            var result = await _repository.GetByIdAsync(orderDetaİlCommands.OrderDetailId);
            result.ProductName = orderDetaİlCommands.ProductName;
            result.ProductPrice = orderDetaİlCommands.ProductPrice;
            result.ProductId =orderDetaİlCommands.ProductId;
            result.ProductTotalPrice = orderDetaİlCommands.ProductTotalPrice;
            result.OrderingId = orderDetaİlCommands.OrderingId;
            result.ProductAmount = orderDetaİlCommands.ProductAmount;
            await _repository.UpdateAsync(result);
        }
    }
}
