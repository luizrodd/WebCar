using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCar.Domain.Models
{
    public class BodyType
    {
        public BodyTypeEnum Id { get; set; }
        public string Name { get; set; }
    }
    public enum BodyTypeEnum
    {
        Hatchback = 0,
        Sedan = 1,
        SUV = 2,
        Pickup = 3,
        Coupe = 4,
        Convertible = 5,
        Minivan = 6,
        Van = 7
    }
}
