using AutoMapper;
using FluentResults;
using Payment_API.Data;
using Payment_API.Data.DTOs.ProductDto;
using Payment_API.Models;

namespace Payment_API.Services
{
    public class ProductService
    {
        private readonly PaymentApiContext _context;
        private readonly IMapper _mapper;

        public ProductService(PaymentApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ReadProductDto> GetProducts()
        {
            List<Product> products = _context.Products.ToList();
            List<ReadProductDto> readProductDto = _mapper.Map<List<ReadProductDto>>(products);
            return readProductDto;
        }

        public ReadProductDto GetProductById(int id)
        {
            Product productDatabase = _context.Products.Where(productQuery => productQuery.Id == id).FirstOrDefault();
            if (productDatabase == null) return null;

            ReadProductDto readProductDto = _mapper.Map<ReadProductDto>(productDatabase);

            return readProductDto;
        }

        public ReadProductDto RegisterProduct(CreateProductDto createProductDto)
        {
            Product product = _mapper.Map<Product>(createProductDto);

            _context.Products.Add(product);
            _context.SaveChanges();

            return _mapper.Map<ReadProductDto>(product);
        }

        public Result UpdateProduct(int id, UpdateProductDto updateProductDto)
        {
            Product productDatabase = _context.Products.Where(productQuery => productQuery.Id == id).FirstOrDefault();
            if (productDatabase == null) return Result.Fail("Product not found");

            _mapper.Map(updateProductDto, productDatabase);
            _context.SaveChanges();

            return Result.Ok();
        }

        public Result DeleteProduct(int id)
        {
            Product productDatabase = _context.Products.Where(productQuery => productQuery.Id == id).FirstOrDefault();
            if (productDatabase == null) return Result.Fail("Product not found");

            _context.Products.Remove(productDatabase);
            _context.SaveChanges();
            
            return Result.Ok();
        }
    }
}
