using System.IO;

namespace CloysterBell.BusinessOperations
{
    public class ReadIrcCommand
    {
        private StreamReader _reader;

        public ReadIrcCommand(StreamReader reader)
        {
            _reader = reader;
        }


    }
}
