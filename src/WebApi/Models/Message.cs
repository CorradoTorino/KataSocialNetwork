using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Message
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public DateTime CreationDateTime { get; set; }

        public string Text { get; set; }
    }
}
