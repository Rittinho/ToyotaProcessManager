using CommunityToolkit.Mvvm.Messaging.Messages;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.Services.Constants.Messages.Process;
public class ProcessRemovedMessage (ToyotaProcess removedProcess) : ValueChangedMessage<ToyotaProcess>(removedProcess)
{
}

