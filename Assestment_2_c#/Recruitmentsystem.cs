using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Assestment_2_c_
{
    public class Recruitmentsystem
    {
        public List<Contractor> contractors = new()
        {
            new Contractor(101, "John", "Menes",new DateOnly(2024,06,20),40),
            new Contractor(102, "Laura", "Tomson",new DateOnly(2023,02,21),50),
            new Contractor(103, "Tom", "Oliveira", new DateOnly(2022,03,15),65),
            new Contractor(104, "James","Rones", new DateOnly(2022,04,07),55),
            new Contractor(105, "Olivia", "Black", new DateOnly (2020,02,22),50),
            new Contractor(106,"Eliese", "Smith", new DateOnly(2021,07,09),75)



        };

        public List<Job> jobs = new()
        {
           new Job(01,"Plumber",new DateOnly(2024,07,22),500,true,true),
           new Job(02,"Electrician", new DateOnly(2024,08,02),700,false,true),
           new Job(03,"Painter", new DateOnly(2024,06,04),900,true,false),
           new Job(04,"Carpenter", new DateOnly(2024,05,06),400,false,true),
           new Job(05,"Landscaper", new DateOnly(2024,06,06),600, false,false),
           new Job(06, "Drywall hanger", new DateOnly(2024,04,20),300, false,false)

        };

        public bool ContractorExist(Contractor contractor)
        {
            foreach (Contractor contractorExisting in contractors)
            {
                if (contractorExisting.ContractorNumber == contractor.ContractorNumber) return true;
            }
            return false;
        }

        public void AddContractor(Contractor contractor)
        {
            if (ContractorExist(contractor))
            {
                MessageBox.Show("Contractor exists");
                return;
            }
            contractors.Add(contractor);
        }

        public void RemoveStudent(Contractor contractor)
        {
            contractors.Remove(contractor);
        }

        public bool JobExist(Job job)
        {
            foreach (Job jobExisting in jobs)
            {
                if (jobExisting.Id == job.Id) return true;
            }
            return false;
        }

        public void AddJob(Job job)
        {
            if (JobExist(job))
            {
                MessageBox.Show("Job exists");
                return;
            }
            jobs.Add(job);
        }

        public void AssignContractorJob(Contractor contractor, Job job)
        {
            //TO DO Need to write code for validation check
            job.AddContractor(contractor);
        }

        /*
        */

        // Method to filter available contractors
        public List<Contractor> GetAvailableContractors()
        {
            return contractors.Where(c => c.IsActive).ToList();
        }

        // Method to filter unassigned jobs
        public List<Job> GetUnassignedJobs()
        {
            return jobs.Where(j => !j.ContractorAssigned).ToList();
        }
    }
}
