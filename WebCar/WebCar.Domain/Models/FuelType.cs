﻿namespace WebCar.Domain.Models
{
    public class FuelType
    {
        public FuelTypeEnum Id { get; private set; }
        public string Name { get; private set; }

        public FuelType(FuelTypeEnum id)
        {
            Id = id;
            Name = id.ToString();
        }
    }
    public enum FuelTypeEnum
    {
        Gasoline = 0,
        Alcohol = 1,
        Flex = 2,
        Diesel = 3,
        Electric = 4,
        Hybrid = 5
    }
}
