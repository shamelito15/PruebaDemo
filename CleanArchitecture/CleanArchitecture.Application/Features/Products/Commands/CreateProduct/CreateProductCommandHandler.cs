

using AutoMapper;
using CleanArchitecture.Application.Contracts.Infraesctructure;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository _productrepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateProductCommandHandler> _logger;

        public CreateProductCommandHandler(IProductRepository productrepository, IMapper mapper, ILogger<CreateProductCommandHandler> logger)
        {
            _productrepository = productrepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productEntity = _mapper.Map<Product>(request);
            var newProduct = await _productrepository.AddAsync(productEntity);
            _logger.LogInformation($"Prodtucto {newProduct.Id}  fue creado exitosamente");
            await SendEmail(newProduct);
            return newProduct.Id;
        }
        private async Task SendEmail(Product product)
        {
            var email = new Email
            {
                To = "samuel.samame.che@gmail.com",
                Body = "El producto se creo correctamente",
                Subject = "Mensaje de Alerta"
            };
           
        }
    }
}
