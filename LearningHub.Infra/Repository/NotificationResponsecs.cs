using Dapper;
using LearningHub.Core.Common;
using LearningHub.Core.Repository;
using LearningHub.Core.Response;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace LearningHub.Infra.Repository
{
    public class NotificationResponsecs : INotificationRepository
    {
        private readonly IDbContext _dbContext;
        private readonly  IConfiguration _configuration;

        public NotificationResponsecs(IDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public void CreateNotification(NotificationModel notification)
        {
            var p = new DynamicParameters();
            p.Add("Nuserid", notification.userId,dbType:DbType.Int32 ,direction: ParameterDirection.Input);
            p.Add("Nmessage", notification.message, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.DbConnection.Execute(
            "notification_package.createnotification", p,commandType: CommandType.StoredProcedure);

        }

        public void deleteNotification(int ID)
        {
            var p = new DynamicParameters();
            p.Add("Nid", ID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.DbConnection.Execute(
                "notification_package.deleteNotification", p, commandType: CommandType.StoredProcedure);
        }

        public List<NotificationModel> getAllNotifications()
        {
            IEnumerable<NotificationModel> result =_dbContext.DbConnection.Query<NotificationModel>(
                "notification_package.getallnotifications", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public NotificationModel getNotificationByID(int ID)
        {
            var p = new DynamicParameters();
            p.Add("Nid", ID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.DbConnection.Query<NotificationModel>(
                "notification_package.getnotificationbyid", p , commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public NotificationModel getNotificationByUserID(int IDuser)
        {
            var p = new DynamicParameters();
            p.Add("Nuserid", IDuser, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.DbConnection.Query<NotificationModel>(
                "notification_package.getnotificationbyuserid", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void UpdateNotification(NotificationModel notification)
        {
            var p = new DynamicParameters();
            p.Add("Nid", notification.ID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Nuserid", notification.userId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Nmessage", notification.message, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("NCreatedAt", notification.createdAt, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = _dbContext.DbConnection.Execute
                ("notification_package.updatenotification", p,commandType:CommandType.StoredProcedure);
        }
    }
}
