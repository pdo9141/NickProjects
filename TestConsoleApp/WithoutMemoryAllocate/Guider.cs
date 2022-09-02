namespace TestConsoleApp.WithoutMemoryAllocate
{
    public class Guider
    {
        public static string ToStringFromGuid(Guid id)
        {
            return Convert.ToBase64String(id.ToByteArray())
                .Replace("/", "-")
                .Replace("+", "_")
                .Replace("=", string.Empty);
        }

        public static Guid ToGuidFromString(string id)
        {
            var cleansedId = id.Replace("-", "/").Replace("_", "+") + "==";
            return new Guid(Convert.FromBase64String(cleansedId));
        }
    }
}