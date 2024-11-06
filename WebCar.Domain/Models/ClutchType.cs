using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCar.Domain.Models
{
    public class ClutchType
    {
        public ClutchTypeEnum Id { get; set; }
        public string Name { get; set; }
    }
    public enum ClutchTypeEnum
    {
        Manual = 0,
        Automatic = 1
    }
}
