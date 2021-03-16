using System.Collections.Generic;

namespace MinhaEmpresa.CrudCliente.Application.Notifications
{
    public interface IDomainNotificationContext
    {
        bool HasErrorNotifications { get; }
        void NotifyError(string message);
        void NotifySuccess(string message);
        List<DomainNotification> GetErrorNotifications();
    }
}