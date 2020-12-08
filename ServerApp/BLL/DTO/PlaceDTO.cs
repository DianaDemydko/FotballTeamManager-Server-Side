using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.BLL.DTO
{
    public class PlaceDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Adress { get; set; }
        public decimal Price { get; set; }
    }
}
