﻿using CartService.Application.Carts.Queries.GetCart;
using CartService.Application.Common.Interfaces;
using CartService.Domain.Entities;

namespace CartService.Application.Carts.Queries.GetCarts;

public record GetCartQuery(string cartKey) : IRequest<CartDto>
{
}

public class GetCartQueryHandler : IRequestHandler<GetCartQuery, CartDto>
{
    private readonly IMapper _mapper;
    private readonly IRepository<Cart> _repository;

    public GetCartQueryHandler(IMapper mapper, IRepository<Cart> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<CartDto> Handle(GetCartQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.FirstOrDefaultAsync(x => x.CartKey == request.cartKey, cancellationToken);
        Guard.Against.NotFound(request.cartKey, entity);
        
        var cartItems = _mapper.Map<List<CartItemDto>>(entity.Items);
        
        return new CartDto
        {
            Id = entity.Id,
            Items = cartItems
        };
    }
}
