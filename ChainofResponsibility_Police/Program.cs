using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainofResponsibility_Police
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PoliceOfficer patrolOfficer = new PatrolOfficer();
            PoliceOfficer sergeant= new Sergeant();
            PoliceOfficer lieutenant= new Lieutenant();

            patrolOfficer.SetNextOfficer(sergeant);
            sergeant.SetNextOfficer(lieutenant);

            Console.WriteLine("Reporting a minor offense:");
            patrolOfficer.HandlerCrime("Small Offense");

            Console.WriteLine("Reporting a Serious Offense:");
            patrolOfficer.HandlerCrime("Serious Offense");


            Console.WriteLine("Reporting a Major Offense:");
            patrolOfficer.HandlerCrime("Major Offense");

            Console.ReadLine();


        }
    }

    public abstract class PoliceOfficer //HandlerBase
    {
        protected PoliceOfficer nextOfficer;
        public void SetNextOfficer(PoliceOfficer officer)
        {
            nextOfficer = officer; 
        }
        public abstract void HandlerCrime(string crime);
    }

    public class PatrolOfficer:PoliceOfficer
    {
        public override void HandlerCrime(string crime)
        {
            if(crime=="Small Offense")
            {
                Console.WriteLine("Patrol Officer is handling the small offense ");
            }
            else if (nextOfficer!=null)
            {
                Console.WriteLine("The Patrol Officer is passing crie to the next officer");
                nextOfficer.HandlerCrime(crime);
            }
        }
    }

    public class Sergeant : PoliceOfficer
    {
        public override void HandlerCrime(string crime)
        {
            if (crime == "Serious Offense")
            {
                Console.WriteLine("Sergeant is handling the Serious offense ");
            }
            else if (nextOfficer != null)
            {
                Console.WriteLine("The Sergeant is passing the crime to the next officer");
                nextOfficer.HandlerCrime(crime);
            }
        }
    }

    public class Lieutenant : PoliceOfficer
    {
        public override void HandlerCrime(string crime)
        {
            if (crime == "Major Offense")
            {
                Console.WriteLine("Lieutenant is handling the Major offense ");
            }
            else if (nextOfficer != null)
            {
                Console.WriteLine("The Lieutenant is passing the crime to the next officer");
                nextOfficer.HandlerCrime(crime);
            }
        }
    }
}
