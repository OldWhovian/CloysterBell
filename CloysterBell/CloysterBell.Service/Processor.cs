using CloysterBell.BusinessOperations;
using CloysterBell.Contract;
using System.IO;

namespace CloysterBell.Service
{
    public class Processor
    {
        private const string PASS_COMMAND = "PASS";
        private const string NICK_COMMAND = "NICK";
        private const string JOIN_COMMAND = "JOIN";
        private const string SEND_MESSAGE_COMMAND = "PRIVMSG";
        private const string REQ_COMMAND = "CAP REQ";

        private Config _config;
        private StreamReader _reader;
        private StreamWriter _writer;
        private SendIrcCommand _sendIrcCommand;
        private ReadIrcCommand _readIrcCommand;

        private int _commandCount = 0;

        public Processor(Config config, StreamReader reader, StreamWriter writer)
        {
            _config = config;
            _reader = reader;
            _writer = writer;

            _sendIrcCommand = new SendIrcCommand(writer);
            _readIrcCommand = new ReadIrcCommand(reader);
        }

        public void Process()
        {
            AuthorizeClient();
            EnableTwitchIRCFeatures();
            JoinChannel(_config.Channel);

            bool runProcess = true;

            while (runProcess)
            {
                
            }
        }

        // Extracted in case multiple channel support is added
        private void JoinChannel(string channelName)
        {
            _sendIrcCommand.SendData(JOIN_COMMAND, channelName);
        }

        private void AuthorizeClient()
        {
            _sendIrcCommand.SendData(PASS_COMMAND, _config.ClientSecret);
            _sendIrcCommand.SendData(NICK_COMMAND, _config.Username);
        }

        private void EnableTwitchIRCFeatures()
        {
            // Adds membership state event data
            _sendIrcCommand.SendData(REQ_COMMAND, ":twitch.tv/membership");

            // Tags + Commands enables chat room access
            // Tags Adds IRC V3 message tags to commands
            _sendIrcCommand.SendData(REQ_COMMAND, ":twitch.tv/tags");

            // Enables several twitch specific commands
            _sendIrcCommand.SendData(REQ_COMMAND, ":twitch.tv/commands");
        }
    }
}
