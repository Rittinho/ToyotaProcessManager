using CommunityToolkit.Mvvm.Messaging.Messages;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.Services.Constants.Messages.Process;
public class ProcessAddedMessage(ToyotaProcess addedProcess) : ValueChangedMessage<ToyotaProcess>(addedProcess)
{
}
