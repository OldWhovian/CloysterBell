using System.IO;

namespace CloysterBell.BusinessOperations
{
    public class SendIrcCommand
    {
        private StreamWriter _writer;

        public SendIrcCommand(StreamWriter writer)
        {
            _writer = writer;
        }

        public void SendData(string command, string message)
        {
            _writer.WriteLine($"{command} {message}");
            _writer.Flush();
        }
    }
}
