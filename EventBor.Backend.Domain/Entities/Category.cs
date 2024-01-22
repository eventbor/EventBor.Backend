using EventBor.Backend.Domain.Entities.Commons;

namespace EventBor.Backend.Domain.Entities;

public class Category : Auditable
{
    public string Name { get; set; }
}