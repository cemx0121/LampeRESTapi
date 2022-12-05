using LampLib.Models;

namespace LampeRESTapi.Managers
{
    public interface ILamp
    {
        Lamp Create(Lamp lamp);

        List<Lamp> GetAll();

        List<Lamp> GetAllByDeviceName(string deviceName);
    }
}
