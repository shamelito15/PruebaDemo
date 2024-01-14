using AutoMapper;
using CleanArchitecture.Application.Contracts.Infraesctructure;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Features.Products.Commands.CreateProduct;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {

        private readonly IProductRepository _productrepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateProductCommandHandler> _logger;

        public DeleteProductCommandHandler(IProductRepository productrepository, IMapper mapper, ILogger<CreateProductCommandHandler> logger)
        {
            _productrepository = productrepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var productToDelete = await _productrepository.GetByIdAsync(request.Id);
            if (productToDelete == null)
            {
                _logger.LogError($"{request.Id} producto no existe en el sistema");
                throw new NotFoundException(nameof(Product),request.Id);
            }
            await _productrepository.DeleteAsync(productToDelete);

            _logger.LogInformation($"El {request.Id} producto fue eliminado con exito");

            return Unit.Value;
        }
    }
}
