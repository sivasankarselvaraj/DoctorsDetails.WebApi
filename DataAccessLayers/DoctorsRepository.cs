using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DataAccessLayers
{
   public class DoctorsRepository:IDoctors
    {
        public void Insert()
        {
            List<Doctors> DoctorsList = new List<Doctors>();
            Doctors Add = new Doctors();
            Console.WriteLine("Enter the No of to ADD");
            int num = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i < num; i++)
            {
                Console.WriteLine("Enter the Doctor Name");
                Add.DoctorsName = Console.ReadLine();
                Console.WriteLine("Enter the Qualification");
                Add.Qualification = Console.ReadLine();
                Console.WriteLine("Enter the PassoutYear");
                Add.PassoutYear = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Enter the PhoneNUmber");
                Add.PhoneNumber = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Enter the Address");
                Add.Addresss = Console.ReadLine();
                DoctorsList.Add(Add);
                Insert(Add);


            }
        }
        public void Insert(Doctors IN)
        {
            try
            {
                var Connection = "Data source=DESKTOP-UCPA9BN;initial catalog=batch7;user id=sa;password=Anaiyaan@123;";
                var Send = new SqlConnection(Connection);
                Send.Open();
                var Insert = $"exec InsertProcedure'{IN.DoctorsName}','{IN.Qualification}',{IN.PassoutYear},{IN.PhoneNumber},'{IN.Addresss}'";
                Send.Execute(Insert);
                Send.Close();
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {

            }
        }
        public void Update(long No, Doctors Replace)
        {
            var Connection = "Data source=DESKTOP-UCPA9BN;initial catalog=batch7;user id=sa;password=Anaiyaan@123;";
            var Send = new SqlConnection(Connection);
            Send.Open();
            var Update = $"exec UpdateProcedure {No},'{Replace.DoctorsName}','{Replace.Qualification}',{Replace.PassoutYear},{Replace.PhoneNumber},'{Replace.Addresss}'";
            Send.Execute(Update);
            Send.Close();
        }
        public List<Doctors> GetAll()
        {
            var Connection = "Data source=DESKTOP-UCPA9BN;initial catalog=batch7;user id=sa;password=Anaiyaan@123;";
            var Send = new SqlConnection(Connection);
            Send.Open();
            var Show = $"exec SelectProcedure ";
            var Details = Send.Query<Doctors>(Show);
            Send.Close();
            return Details.ToList();

        }

        public List<Doctors> Delete(long No)
        {
            var Connection = "Data source=DESKTOP-UCPA9BN;initial catalog=batch7;user id=sa;password=Anaiyaan@123;";
            var Send = new SqlConnection(Connection);
            Send.Open();
            var Delete = $"exec DeleteProcedure {No}";

            var Cut = Send.Query<Doctors>(Delete);
            Send.Close();
            return Cut.ToList();
        }
    }
}
