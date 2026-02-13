using System;
using System.Collections.Generic;
using System.Text;

namespace ProductFlow.OnionTest.Server.Domain.Entities
{
    public class Category
    {
        public Category()
        {
            Id = Guid.NewGuid(); // Nesne örneklendiğinde ID otomatik oluşur.
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
