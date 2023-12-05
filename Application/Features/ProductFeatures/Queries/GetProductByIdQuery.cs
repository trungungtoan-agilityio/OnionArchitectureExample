using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProductFeatures.Queries;

public class GetProductByIdQuery : IRequest<Product>
{
    public int Id { get; set; }
    public class GetProductByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetProductByIdQuery, Product>
    {
        public Task<Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            var product = context.Products.FirstOrDefault(a => a.Id == query.Id);
            return product == null ? Task.FromResult<Product>(null) : Task.FromResult(product);
        }
    }
}
