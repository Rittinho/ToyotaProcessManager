using CommunityToolkit.Mvvm.Messaging.Messages;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.Services.Constants.Messages.Employee;
public class EmployeeRemovedMessage(ToyotaEmployee removedEmployee) : ValueChangedMessage<ToyotaEmployee>(removedEmployee)
{
}
