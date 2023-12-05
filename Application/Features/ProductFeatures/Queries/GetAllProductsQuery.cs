using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ProductFeatures.Queries;

public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
{

    public class GetAllProductsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
        {
            var productList = await context.Products.ToListAsync(cancellationToken: cancellationToken);
            return productList.AsReadOnly();
        }
    }
}
