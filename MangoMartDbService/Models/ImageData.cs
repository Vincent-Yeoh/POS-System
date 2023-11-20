using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoMartDb.Models
{
    public class ImageData
    {
        public int Id { get; set; }
        public string? ImageId { get; set; }
        public byte[]? Data { get; set; }

    }
}
