using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.Services.Constants.Messages.TableGroup;
public class TableGroupRemovedMessage(ToyotaTableGroup removedTableGroup) : ValueChangedMessage<ToyotaTableGroup>(removedTableGroup)
{
}
