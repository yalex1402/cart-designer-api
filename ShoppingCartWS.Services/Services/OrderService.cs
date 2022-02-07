using System.Threading.Tasks;
using AutoMapper;
using ShoppingCartWS.Domain.Entities;
using ShoppingCartWS.Domain.Repositories;
using ShoppingCartWS.Services.DtoModels;
using ShoppingCartWS.Services.ServicesContracts;

namespace ShoppingCartWS.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public OrderService(IRepositoryManager repository,
                            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddOrderAsync(OrderDto order)
        {
            Order orderEntity = _mapper.Map<OrderDto, Order>(order);
            await _repository.OrderRepository.AddOrderAsync(orderEntity);
        }

        public async Task CancelOrderAsync(OrderDto order)
        {
            Order orderEntity = _mapper.Map<OrderDto, Order>(order);
            await _repository.OrderRepository.CancelOrderAsync(orderEntity);
        }

        public async Task UpdateOrderAsync(OrderDto order)
        {
            Order orderEntity = _mapper.Map<OrderDto, Order>(order);
            await _repository.OrderRepository.UpdateOrderAsync(orderEntity);
        }
    }
}