using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    public class TransactionResult
    {
        public string Id { get; set; }
        public string Payment { get; set; }
        public char Status { get; set; }
    }
}
