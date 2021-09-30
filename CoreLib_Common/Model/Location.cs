﻿namespace CoreLib_Common.Model
{
    //[Owned]
    public class Location
    {
        public string Address { get; set; } = null!;

        public virtual Club                Club    { get; set; } = null!;
        public virtual ICollection<Animal> Animals { get; set; } = null!;

        public override string ToString()
        {
            return $@"Location: Address = {Address}";
        }
    }
}