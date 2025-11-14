using CommunityToolkit.Mvvm.Messaging.Messages;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.Services.Constants.Messages.Employee;
public class EmployeeAddedMessage(ToyotaEmployee addedEmployee) : ValueChangedMessage<ToyotaEmployee>(addedEmployee)
{
}
