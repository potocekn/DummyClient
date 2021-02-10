using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DummyClient
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> languages = new List<string>();
            languages.Add("English");
            languages.Add("Czech");
            Request request1 = new Request(RequestType.CHANGED_LANGUAGES, languages);
            byte[] bytes1 = sendMessage(System.Text.Encoding.Unicode.GetBytes(JsonConvert.SerializeObject(request1)));
            var message = cleanMessage(bytes1);
            Console.WriteLine(message);
            ResponseChangedLanguages rchl = JsonConvert.DeserializeObject<ResponseChangedLanguages>(message);
            Console.WriteLine("Status" + rchl.Status);
            Console.WriteLine("Type: "+ rchl.Type);
            foreach (var item in rchl.ChangedLanguages)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Request request2 = new Request(RequestType.RESOURCES_FOR_LANGUAGES,languages);
            byte[] bytes2 = sendMessage(System.Text.Encoding.Unicode.GetBytes(JsonConvert.SerializeObject(request2)));
            var message2 = cleanMessage(bytes2);
            Console.WriteLine(message2);
            Console.ReadLine();
            ResponseResourcesForLanguages rrfl = JsonConvert.DeserializeObject<ResponseResourcesForLanguages>(message2);
            Console.WriteLine("Status" + rrfl.Status);
            Console.WriteLine("Type: " + rrfl.Type);
            foreach (var item in rrfl.ResourcesForLanguages)
            {
                Console.WriteLine("Key: "+item.Key);
                foreach (var item2 in item.Value)
                {
                    Console.WriteLine(item2);
                }
            }
            Console.WriteLine();
        }
        private static string cleanMessage(byte[] bytes)
        {
            string message = Encoding.Unicode.GetString(bytes);

            string messageToPrint = null;
            foreach (var nullChar in message)
            {
                if (nullChar != '\0')
                {
                    messageToPrint += nullChar;
                }
            }
            return messageToPrint;
        }
        private static byte[] sendMessage(byte[] messageBytes)
        {
            const int bytesize = 1024 * 1024;
            try // Try connecting and send the message bytes  
            {
                System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient("127.0.0.1", 1234); // Create a new connection  
                NetworkStream stream = client.GetStream();

                stream.Write(messageBytes, 0, messageBytes.Length); // Write the bytes  
                Console.WriteLine("================================");
                Console.WriteLine("=   Connected to the server    =");
                Console.WriteLine("================================");
                Console.WriteLine("Waiting for response...");

                messageBytes = new byte[bytesize]; // Clear the message   

                // Receive the stream of bytes  
                stream.Read(messageBytes, 0, messageBytes.Length);

                // Clean up  
                stream.Dispose();
                client.Close();
            }
            catch (Exception e) // Catch exceptions  
            {
                Console.WriteLine(e.Message);
            }

            return messageBytes; // Return response  
        }
    }
}
