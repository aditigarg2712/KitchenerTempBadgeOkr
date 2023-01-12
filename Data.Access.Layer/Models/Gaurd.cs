using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace Data.Access.Layer.Models;

public partial class Gaurd
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string TempBadge { get; set; } = null!;

    public DateTime SignIn { get; set; }
    public DateTime SignOut { get; set; }

    public int EmpCode { get; set; }
   

    public virtual Employee EmpCodeNavigation { get; set; } = null!;
}
