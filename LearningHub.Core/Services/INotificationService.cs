using LearningHub.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Services
{
   public interface INotificationService
   {
        public List<NotificationModel> getAllNotifications();
        public NotificationModel getNotificationByID(int ID);
        public NotificationModel getNotificationByUserID(int IDuser);

        public void CreateNotification(NotificationModel notification);
        public void UpdateNotification(NotificationModel notification);
        public void deleteNotification(int ID);
    }
}
