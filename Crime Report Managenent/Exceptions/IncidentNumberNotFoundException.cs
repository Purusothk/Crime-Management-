using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crime_Report_Managenent.Exceptions
{
    public class IncidentNumberNotFoundException : Exception
    {
        public IncidentNumberNotFoundException()
        {
        }

        public IncidentNumberNotFoundException(string message)
            : base(message)
        {
        }

        public IncidentNumberNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
