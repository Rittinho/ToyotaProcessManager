using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyotaProcessManager.Services.Selectors
{
    public class ToyotaProcessDataTemplateSelector : DataTemplateSelector
    {
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return new DataTemplate();
        }
    }
}
