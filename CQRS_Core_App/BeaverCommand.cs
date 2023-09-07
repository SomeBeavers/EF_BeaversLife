using CoreLib_Common;
using CoreLib_Common.Model;

namespace CQRS_Core_App;

public class BeaverCommand
{
    public bool AddBeaver(Beaver beaver)
    {
        using var context = new AnimalContext();
    }
}