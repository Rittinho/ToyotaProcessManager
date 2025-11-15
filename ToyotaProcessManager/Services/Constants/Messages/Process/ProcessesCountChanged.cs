using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyotaProcessManager.Services.Constants.Messages.Process;
class ProcessesCountChanged(int processesCount) : ValueChangedMessage<int>(processesCount)
{
}
