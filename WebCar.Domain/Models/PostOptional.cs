using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCar.Domain.Models
{
    public class PostOptional
    {
        public Post Post { get; private set; }
        public Optional Optional { get; private set; }
    }
}
