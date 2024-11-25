    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
namespace Assestment_2_c_
{
    public class Job
    {
      public int Id { get; set; }
      public string JobName { get; set; }
      public DateOnly JobDate { get; set; }
      public float JobCost { get; set; }
      public Boolean JobCompleted { get; set; }
      public Boolean ContractorAssigned { get; set; }

      public List<Contractor> AssignedContractor { get; set; } = new List<Contractor>();

        public Job(int id, string jobname, DateOnly jobdate, float jobcost,Boolean jobcompleted, Boolean contractorassigned)
        {
            Id = id;
            JobName = jobname ?? throw new ArgumentNullException(nameof(jobname));
            JobDate = jobdate;
            JobCost = jobcost;
            JobCompleted = jobcompleted;
            ContractorAssigned = contractorassigned;

            
        }
       

        public override string ToString()
        {
            return $"{Id},{JobName},{JobDate},(${JobCost}),{JobCompleted},{ContractorAssigned}";
        }

        public bool AddContractor(Contractor contractor)
        {
            //if (AttendingStudents.Count >= RoomCapacity)
            //{
            //return false;
            // }
            //TO DO Need to write code for validation check if student is already to the list or not
            AssignedContractor.Add(contractor);
            return true;
        }
    } 
} 
