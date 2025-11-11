namespace ToyotaProcessManager.Services.ValueObjects
{
    public class ToyotaProcess(IconParameters iconParameters, string processTitle = "Sem titulo", string processDescription = "Descrição não realizada")
    {
        public string Title { get; set; } = processTitle;

        public string Description { get; set; } = processDescription;

        public IconParameters Icon { get; set; } = iconParameters;
    }
}
