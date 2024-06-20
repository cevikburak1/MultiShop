using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultCouponDto>> GetAllCouponAsync();

        Task CreateCouponAsync(CreateCouponDto createCouponDto);
        Task DeleteCouponAsync(int id);
        Task UpdateCouponAsync(UpdateCouponDto updateCouponDto);
        Task<GetByIdCouponDto> GetCouponAsync(int id);


    }
}
