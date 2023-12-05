using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ProductFeatures.Commands;

public class DeleteProductByIdCommand : IRequest<int>
{
    public int Id { get; set; }
    
    public class DeleteProductByIdCommandHandler(IApplicationDbContext context) : IRequestHandler<DeleteProductByIdCommand, int>
    {
        public async Task<int> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
        {
            var product = await context.Products.Where(a => a.Id == command.Id).FirstOrDefaultAsync(cancellationToken: cancellationToken);
            if (product == null) return default;
            context.Products.Remove(product);
            await context.SaveChangesAsync();
            return product.Id;
        }
    }
}
