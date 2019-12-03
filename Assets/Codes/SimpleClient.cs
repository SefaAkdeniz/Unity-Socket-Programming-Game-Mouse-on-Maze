using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    public class SimpleClient
    {
        private TcpClient tcpClient;
        private NetworkStream stream;
        public StreamWriter writer;
        private StreamReader reader;

        public SimpleClient()
        {
            tcpClient = new TcpClient();
        }

        public bool Connect(string ipAddress, int port)
        {
            try
            {
                tcpClient.Connect(ipAddress, port);
                stream = tcpClient.GetStream();
                
                reader = new StreamReader(stream, Encoding.UTF8);
                writer = new StreamWriter(stream, Encoding.UTF8);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
                throw;
            }

            return true;
        }

        public void Run()
        {
            string userInput;
            Console.WriteLine("Processing server response...");
            
            ProcessServerResponse();

            Console.WriteLine("Input: ");
            while ((userInput = Console.ReadLine()) != null)
            {
                writer.WriteLine(userInput);
                writer.Flush();
                ProcessServerResponse();
                
                if (userInput == "/end")
                {
                    break;
                }
            }

        }

        private void ProcessServerResponse()
        {
            Console.WriteLine("test");
            Console.WriteLine("Server says: " + reader.ReadLine() + "\n");
        }
    }
}