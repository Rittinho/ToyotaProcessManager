using CommunityToolkit.Mvvm.Messaging.Messages;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.Services.Constants.Messages.TableGroup;
public class TableGroupAddedMessage(ToyotaTableGroup addedTableGroup) : ValueChangedMessage<ToyotaTableGroup>(addedTableGroup)
{
}
