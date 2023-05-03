using System;
using System.Collections.Generic;

namespace MSSQL_Core_App.Models;

public partial class Pet
{
    public int PetId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Person> PersonPeople { get; set; } = new List<Person>();
}
