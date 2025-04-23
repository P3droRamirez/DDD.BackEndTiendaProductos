using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.BackEndTiendaProductos.Domain.Models
{
    public class OkResponseModel
    {
        public int Id { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
