using CommunityToolkit.Mvvm.Messaging.Messages;

namespace ToyotaProcessManager.Services.Constants.Messages.Employee;
class EmployeesCountChanged(int employeesCount) : ValueChangedMessage<int>(employeesCount)
{
}
