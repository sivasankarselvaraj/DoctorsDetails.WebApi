using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayers
{
    public interface IDoctors
    {
        public void Input();
        public void Insert(Doctors IN);
        public void Update(long No, Doctors Replace);
        public List<Doctors> GetAll();
        public List<Doctors> Delete(long no);
    }
}
