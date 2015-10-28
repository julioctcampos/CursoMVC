using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GTAC.GTACAir.Web.Identity
{
    public class GTACIdentityDbContext
        : IdentityDbContext
    {
        public GTACIdentityDbContext()
            : base("GTACIdentityDbContext")
        { }
    }
}