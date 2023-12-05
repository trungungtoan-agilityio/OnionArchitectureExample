using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProductFeatures.Commands;

public class CreateProductCommand : IRequest<int>
{
    public string Name { get; set; }
    public string Barcode { get; set; }
    public string Description { get; set; }
    public decimal Rate { get; set; }
    
    public class CreateProductCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateProductCommand, int>
    {
        public async Task<int> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Barcode = command.Barcode,
                Name = command.Name,
                Rate = command.Rate,
                Description = command.Description
            };
            
            context.Products.Add(product);
            
            await context.SaveChangesAsync();
            return product.Id;
        }
    }
}
