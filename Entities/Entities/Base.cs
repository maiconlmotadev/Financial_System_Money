using Entities.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Base : Notifies
    { 
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
