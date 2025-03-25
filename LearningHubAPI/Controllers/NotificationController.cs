using LearningHub.Core.Response;
using LearningHub.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace LearningHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
       
        [HttpGet]
        [Route("getAllNotifications")]
        public List<NotificationModel> getAllNotifications() 
        {
            return _notificationService.getAllNotifications(); 
        }
        [HttpGet]
        [Route("getNotificationByID/{ID}")]
        public NotificationModel getNotificationByID(int ID)
        {
            return _notificationService.getNotificationByID(ID);    
        }
        [HttpGet]
        [Route("getNotificationByUserID/{ID}")]
        public NotificationModel getNotificationByUserID(int IDuser)
        {
            return _notificationService.getNotificationByUserID(IDuser);
        }

        [HttpPost]
        [Route("CreateNotification")]
        public void CreateNotification(NotificationModel notification) 
        {
            _notificationService.CreateNotification(notification);
        }
        [HttpPut]
        [Route("UpdateNotification")]
        public void UpdateNotification(NotificationModel notification) 
        {
            _notificationService.UpdateNotification(notification);
        }

        [HttpDelete]
        [Route("deleteNotification/{id}")]
        public void deleteNotification(int ID)
        {
            _notificationService.deleteNotification(ID);
        }
    }
}
