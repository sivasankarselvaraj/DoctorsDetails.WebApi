using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DataAccessLayers
{
   public class DoctorsRepository:IDoctorsRepository
    {
        string Connection = "Data source=DESKTOP-UCPA9BN;initial catalog=batch7;user id=sa;password=Anaiyaan@123;";
       
       
        public void Insert(Doctors add)
        {
            try
            {
             
                var Send = new SqlConnection(Connection);
                Send.Open();
                var Insert = $"exec InsertProcedure'{add.DoctorsName}','{add.Qualification}',{add.PassoutYear},{add.PhoneNumber},'{add.Addresss}'";
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
        public void Update(long No, Doctors replace)
        {
            var Send = new SqlConnection(Connection);
            Send.Open();
            var Update = $"exec UpdateProcedure {No},'{replace.DoctorsName}','{replace.Qualification}',{replace.PassoutYear},{replace.PhoneNumber},'{replace.Addresss}'";
            Send.Execute(Update);
            Send.Close();
        }
        public List<Doctors> GetAll()
        {
            var Send = new SqlConnection(Connection);
            Send.Open();
            var Show = $"exec SelectProcedure ";
            var Details = Send.Query<Doctors>(Show);
            Send.Close();
            return Details.ToList();

        }

        public void Delete(long no)
        {
            var Send = new SqlConnection(Connection);
            Send.Open();
            var Delete = $"exec DeleteProcedure {no}";

            var Cut = Send.Query<Doctors>(Delete);
            Send.Close();
            
        }
    }
}
