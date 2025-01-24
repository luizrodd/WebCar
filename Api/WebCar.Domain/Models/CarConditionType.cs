using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCar.Domain.Models
{
    public class CarConditionType
    {
        public CarConditionTypeEnum Id { get; private set; }
        public string Name { get; private set; }

        public CarConditionType(CarConditionTypeEnum id)
        {
            Id = id;
            Name = id.ToString();
        }
    }
    public enum CarConditionTypeEnum
    {
        New = 0,
        Used = 1,
        SemiNew = 2
    }
}
