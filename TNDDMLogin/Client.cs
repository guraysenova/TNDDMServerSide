using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace TNDDMLogin
{
    class Client
    {
        public static int dataBufferSize = 4096;

        public int id;
        public TCP tcp;

        public Client(int clientId)
        {
            id = clientId;
            tcp = new TCP(id);
        }

        public class TCP
        {
            public TcpClient socket;

            private readonly int id;

            private NetworkStream stream;
            private byte[] receiveBuffer;

            public TCP(int idVal)
            {
                id = idVal;
            }

            public void Connect(TcpClient socketVal)
            {
                socket = socketVal;
                socket.ReceiveBufferSize = dataBufferSize;
                socket.SendBufferSize = dataBufferSize;

                stream = socket.GetStream();

                receiveBuffer = new byte[dataBufferSize];

                stream.BeginRead(receiveBuffer, 0, dataBufferSize, ReceiveCallback, null);
            }

            private void ReceiveCallback(IAsyncResult result)
            {
                try
                {
                    int byteLength = stream.EndRead(result);
                    if(byteLength <= 0)
                    {
                        // TODO: Disconnect client.

                        return;
                    }

                    byte[] data = new byte[byteLength];
                    Array.Copy(receiveBuffer, data, byteLength);

                    // TODO: Handle data.

                    stream.BeginRead(receiveBuffer, 0, dataBufferSize, ReceiveCallback, null);
                }
                catch(Exception exception)
                {
                    Console.Write($"Error receiving TCP data: {exception}");
                    // TODO: Disconnect client.

                }
            }
        }
    }
}
