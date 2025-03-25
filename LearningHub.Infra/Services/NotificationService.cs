using LearningHub.Core.Repository;
using LearningHub.Core.Response;
using LearningHub.Core.Services;
using Microsoft.Extensions.Configuration;


namespace LearningHub.Infra.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
    

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
           
        }
        public void CreateNotification(NotificationModel notification)
        {
            _notificationRepository.CreateNotification(notification);
        }

        public void deleteNotification(int ID)
        {
            _notificationRepository.deleteNotification(ID);
        }

        public List<NotificationModel> getAllNotifications()
        {
           return _notificationRepository.getAllNotifications();
        }

        public NotificationModel getNotificationByID(int ID)
        {
            return _notificationRepository.getNotificationByID(ID);
        }

        public NotificationModel getNotificationByUserID(int IDuser)
        {
            return _notificationRepository.getNotificationByUserID(IDuser);
        }

        public void UpdateNotification(NotificationModel notification)
        {
            _notificationRepository.UpdateNotification(notification);
        }
    }
}
