namespace Adborroto.FlowJs.Error
{
    public abstract class ApplicationError
    {
        protected ApplicationError(string description)
        {
            Description = description;
        }

        public string Description { get; private set; }
    }
}
