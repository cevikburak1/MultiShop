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
    public class CreateOrderDetailHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public CreateOrderDetailHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateOrderDetailCommand createOrderDetailCommand)
        {
            await _repository.CreateAsync(new OrderDetail
            {
               ProductAmount=createOrderDetailCommand.ProductAmount,
               ProductId=createOrderDetailCommand.ProductId,    
               ProductName=createOrderDetailCommand.ProductName,
               OrderingId=createOrderDetailCommand.OrderingId,
               ProductPrice=createOrderDetailCommand.ProductPrice,
               ProductTotalPrice=createOrderDetailCommand.ProductTotalPrice,
            });
        }
    }
}
