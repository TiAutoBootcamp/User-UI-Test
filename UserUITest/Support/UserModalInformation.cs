using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserUITest.Support
{
    public class UserModalInformation
    {
       
        public string FirstName { get; set; }

        public string LastName;
        public bool Status;
        public string BirthDate
        {
            get { return BirthDate ?? string.Empty; }
            set { BirthDate = value; }
        }
    }

    
       
 
}
