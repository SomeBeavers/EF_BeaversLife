using Microsoft.EntityFrameworkCore;

namespace CoreLib_Common.Model
{
    [Owned]
    public class Location
    {
        public string Address { get; set; }

        public virtual Club Club { get; set; }

        public override string ToString()
        {
            return $@"Location: Address = {Address}";
        }
    }
}