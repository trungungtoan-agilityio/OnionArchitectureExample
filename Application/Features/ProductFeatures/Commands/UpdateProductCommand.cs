using Application.Interfaces;
using MediatR;

namespace Application.Features.ProductFeatures.Commands;

public class UpdateProductCommand : IRequest<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Barcode { get; set; }
    public string Description { get; set; }
    public decimal Rate { get; set; }
    
    public class UpdateProductCommandHandler(IApplicationDbContext context) : IRequestHandler<UpdateProductCommand, int>
    {
        public async Task<int> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var product = context.Products.FirstOrDefault(a => a.Id == command.Id);

            if (product == null)
            {
                return default;
            }

            product.Barcode = command.Barcode;
            product.Name = command.Name;
            product.Rate = command.Rate;
            product.Description = command.Description;
            await context.SaveChangesAsync();
            return product.Id;
        }
    }
}
