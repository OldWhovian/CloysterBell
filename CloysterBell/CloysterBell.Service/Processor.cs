using CloysterBell.BusinessOperations;
using CloysterBell.Contract;
using System.IO;

namespace CloysterBell.Service
{
    public class Processor
    {
        private Config _config;
        private StreamReader _reader;
        private StreamWriter _writer;
        private SendIrcCommand _sendIrcCommand;


        public Processor(Config config, StreamReader reader, StreamWriter writer)
        {
            _config = config;
            _reader = reader;
            _writer = writer;


        }
    }
}
