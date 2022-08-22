using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumeWebAPI.Models
{
    public class BookModel
    {
        public int SerialNo { get; set; }
       
        public string BookName { get; set; }
        
        public string Author { get; set; }
        
        public string Edition { get; set; }
        
        public DateTime? DateOfPublish { get; set; }
    }
}
