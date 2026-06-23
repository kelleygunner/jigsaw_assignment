namespace Infrastructure.UI
{
    [System.AttributeUsage(System.AttributeTargets.Class, Inherited = false)]
    public class RegisterScreenAttribute : System.Attribute
    {
        public string ScreenId { get; }

        public RegisterScreenAttribute(string screenId)
        {
            ScreenId = screenId;
        }
    }
}