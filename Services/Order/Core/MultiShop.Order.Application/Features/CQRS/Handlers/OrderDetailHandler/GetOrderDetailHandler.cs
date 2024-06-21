using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandler
{
    public class GetOrderDetailHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetOrderDetailQueryResult>> Handle()
        {
            var result = await _repository.GetAllAsync();
            return result.Select(x => new GetOrderDetailQueryResult
            {
             OrderDetailId = x.OrderDetailId,
             OrderingId = x.OrderingId,
             ProductAmount = x.ProductAmount,
             ProductId = x.ProductId,
             ProductName = x.ProductName,
             ProductPrice = x.ProductPrice,
             ProductTotalPrice = x.ProductTotalPrice
            }).ToList();
        }
    }
}
