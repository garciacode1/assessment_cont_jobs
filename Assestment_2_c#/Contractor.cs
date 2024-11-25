using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Assestment_2_c_
{
    public class Contractor //Class contractor
    {
        public int ContractorNumber { get; set; }
        public string FirstName { get; set; }  
        public string LastName { get; set;}
        public DateOnly StartDate { get; set; }
        public float HourlyRate { get; set; }
        public bool IsActive { get; set; }

        public Contractor(int contractornumber, string firstname, string lastname, DateOnly startdate, float hourlyrate)
        {
            ContractorNumber = contractornumber;
            FirstName = firstname;
            LastName = lastname;
            StartDate = startdate;
            HourlyRate = hourlyrate;
            

        
        }
        public override string ToString()
        {
            return $"{ContractorNumber},{FirstName},{LastName},{StartDate},(${HourlyRate})";
        }

    }
}    
