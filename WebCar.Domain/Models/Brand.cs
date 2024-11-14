﻿using WebCar.Domain.Core;

namespace WebCar.Domain.Models
{
    public class Brand : Entity<Guid>
    {
        private readonly List<Model> _models;
        private Brand()
        {
            _models = [];
        }
        public Brand(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
        public string Name { get; set; }
        public IReadOnlyCollection<Model> Models => _models;
    }
}
