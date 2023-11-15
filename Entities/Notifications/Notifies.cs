using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Notifications
{
    public class Notifies
    {
        public Notifies()  
        {
            notifications = new List<Notifies>();
        }

        [NotMapped]
        public string PropertyName { get; set; }

        [NotMapped]
        public string message { get; set; }

        [NotMapped]
        public List<Notifies> notifications;     
        
        public bool ValidateStringProperty(string value, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(propertyName))
            {
                notifications.Add(new Notifies
                {
                    message = "Required field",
                    PropertyName = propertyName
                });

                return false;
            }

            return true;
        }

        public bool ValidateIntProperty(int value, string propertyName)
        {
            if (value < 1 || string.IsNullOrWhiteSpace(propertyName))
            {
                notifications.Add(new Notifies
                {
                    message = "Required field",
                    PropertyName = propertyName
                });

                return false;
            }

            return true;
        }
    }
}
