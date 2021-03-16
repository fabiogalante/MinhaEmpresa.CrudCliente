using MinhaEmpresa.CrudCliente.Domain.Notifications;
using System.Collections.Generic;

namespace MinhaEmpresa.CrudCliente.Domain
{
    public interface INotifier
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
