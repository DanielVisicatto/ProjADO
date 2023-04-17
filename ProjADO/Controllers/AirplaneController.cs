using ProjADO.Model;
using ProjADO.Services;

namespace ProjADO.Controllers
{
    public class AirplaneController
    {
        public bool Insert (Airplane airplane)
        {
            return new AirplaneService().Insert(airplane);
        }

        public List<Airplane> FindAll()
        {
            return new AirplaneService().FindAll();
        }
    }
}
