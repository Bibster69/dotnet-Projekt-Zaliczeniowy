using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Kalkulatol.Areas.Identity.Data;

// Add profile data for application users by adding properties to the KalkulatolUser class
public class KalkulatolUser : IdentityUser
{
    public string Imie { get; set; }
    public int Waga { get; set; }
}

