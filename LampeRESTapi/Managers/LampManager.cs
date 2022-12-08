using LampLib.Data;
using LampLib.Models;

namespace LampeRESTapi.Managers
{
    public class LampManager : ILamp
    {
        private readonly LampDBContext _dbContext = new LampDBContext();

        public Lamp Create(Lamp lamp)
        {
            _dbContext.Lamps.Add(lamp);
            _dbContext.SaveChanges();
            return lamp;
        }

        public List<Lamp> GetAll()
        {
            if (_dbContext.Lamps.ToList().Count() == 0)
            {
                throw new ArgumentException("Der er ingen data i øjeblikket!");
            }
            else
            {
                return new List<Lamp>(_dbContext.Lamps.ToList());
            }
        }

        public List<Lamp> GetAllByDeviceName(string deviceName)
        {
            if (_dbContext.Lamps.ToList().FirstOrDefault(d => d.DeviceName == deviceName) == null)
            {
                throw new ArgumentException("Der er ingen data på dette device navn!");
            }
            else
            {
                return _dbContext.Lamps.ToList().FindAll(d => d.DeviceName == deviceName);
            }
        }
    }
}
