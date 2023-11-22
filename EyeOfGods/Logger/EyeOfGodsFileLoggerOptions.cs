namespace EyeOfGods.Logger
{
    public class EyeOfGodsFileLoggerOptions
    {
        public virtual string FileName { get; set; } = "{date}.log";
        public virtual string FolderPath { get; set; } = "C:\\Users\\oldpo\\source\\repos\\EyeOfGods\\EyeOfGods\\wwwroot\\Logs\\";
    }
}