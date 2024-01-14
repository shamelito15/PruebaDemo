using AutoMapper;
using CleanArchitecture.Application.Contracts.Infraesctructure;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Features.Products.Commands.CreateProduct;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>    
    {

        private readonly IProductRepository _productrepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateProductCommandHandler> _logger;

        public UpdateProductCommandHandler(IProductRepository productrepository, IMapper mapper, ILogger<CreateProductCommandHandler> logger)
        {
            _productrepository = productrepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productToUpdate=  await _productrepository.GetByIdAsync(request.Id);
                if (productToUpdate == null)
            {
                _logger.LogError($"No se encontro el producto id {request.Id}");
                throw   new NotFoundException(nameof(Product),request.Id);
            }
               _mapper.Map(request, productToUpdate,typeof(UpdateProductCommand),typeof(Product));
            await _productrepository.UpdateAsync(productToUpdate);

            _logger.LogInformation($"La operacion fue existosa actualizando el producto {request.Id}");

            return Unit.Value;
        }
    }
}
