using CoreLib_Common;
using CoreLib_Common.Model;

namespace CQRS_Core_App;

public class BeaverCommand
{
    public void AddBeaverTest(Beaver beaver)
    {
        using AnimalContext context = new AnimalContext();

        context.Add(beaver);
        context.SaveChanges();

        Beaver? beaver1 = new BeaverQuery().GetBeaver(1);
    }
}

public class BeaverQuery
{
    public Beaver? GetBeaver(int id)
    {
        using AnimalContext context = new();

        Beaver? beaver = context.Beavers.FirstOrDefault(beaver => beaver.Id == id);

        new BeaverCommand().AddBeaverTest(beaver ?? new Beaver());
        return beaver;
    }
}