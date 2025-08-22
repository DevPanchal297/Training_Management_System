using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillPro_Training_System.Services
{
    public delegate void Notification(string message);

    public class NotificationService
    {
        public event Notification OnNotification;
        public void RaiseNotification(string message)
        {
            OnNotification?.Invoke(message);
        }
    }
}
