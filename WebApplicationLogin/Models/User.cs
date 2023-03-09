using System;
using System.Collections.Generic;

namespace WebApplicationLogin.Models;

public partial class User
{
    public int UId { get; set; }

    public string? UName { get; set; }

    public string? UEmail { get; set; }

    public string? UKey { get; set; }
}
