using CloysterBell.Contract;
using CloysterBell.Service;
using System;
using System.IO;
using System.Net.Sockets;

namespace CloysterBell
{
    class CloysterBell
    {
        private LoadConfigFile _loadConfigFile;
        private TcpClient _client;
        private Stream _stream;
        private NetworkStream _networkStream;
        private StreamReader _reader;
        private StreamWriter _writer;
        private Config _config;

        public CloysterBell()
        {
            try
            {
                _loadConfigFile = new LoadConfigFile();
                _client = new TcpClient();

                _config = _loadConfigFile.GetConfigFromFile();
                _client.ReceiveBufferSize = _config.BufferSize;
                _client.Connect(_config.ServerName, _config.ServerPort);

                _stream = _client.GetStream();
                _networkStream = new NetworkStream(_client.Client);
                _writer = new StreamWriter(_stream);
                _reader = new StreamReader(_stream);
                _stream.
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
