﻿namespace EcommerceApp.Shared.DTOs
{
    public class CategoryDto
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<ProductDto> Products { get; set; }
    }
}
