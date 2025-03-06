using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FsDataAccess.Models
{
    public class ToRetrieveCinList
    {
        public string CIN { get; set; }
        public bool Processed { get; set; }
        public DateTime ProcessDate { get; set; }
        public string ErrorMessage { get; set; }
    }
}
