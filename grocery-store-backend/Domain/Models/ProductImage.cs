using System;

namespace grocery_store_backend.Domain.Models;

public class ProductImage
{
    public Guid Id { get; set; }
    public string Url { get; set; } = default!;
    public bool IsMain { get; set; } = false;

    public Guid ProductId { get; set; }
    public Product Product { get; set; } = default!;
}
