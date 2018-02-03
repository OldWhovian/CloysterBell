namespace CloysterBell.Contract
{
    public class Config
    {
        public string ServerName { get; set; }
        
        public int ServerPort { get; set; }

        public int BufferSize { get; set; } 

        public string Username { get; set; }

        public string ClientSecret { get; set; }

        public string Channel { get; set; }
    }
}
