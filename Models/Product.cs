﻿namespace DapperCrudAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Autor { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
