using System;
using System.Collections.Generic;

namespace PostgreSQL_Core_App;

public partial class Pet
{
    public int PetId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Person> PersonPeople { get; set; } = new List<Person>();
}
