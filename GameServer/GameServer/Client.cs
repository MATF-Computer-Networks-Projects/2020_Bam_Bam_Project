using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace GameServer
{
    class Client
    {
        public static int dataBufferSize = 4096;
        public int id;
        public TCP tcp;

        public Client(int _clientId)
        {
            id = _clientId;
            tcp = new TCP(id);
        }

        //Tu cemo da cuvamo ono sto ce da nam vrati server callback
        public class TCP
        {
            public TcpClient socket;
            private NetworkStream stream;
            private byte[] recivedBuffer;

            private readonly int id;

            public TCP(int _id)
            {
                id = _id;
            }

            public void Connect(TcpClient _socket)
            {
                socket = _socket;
                socket.ReceiveBufferSize = dataBufferSize;
                socket.SendBufferSize = dataBufferSize;

                stream = socket.GetStream();

                recivedBuffer = new byte[dataBufferSize];

                stream.BeginRead(recivedBuffer, 0, dataBufferSize, ReceiveCallback, null);

                //TODO
            }

            private void ReceiveCallback(IAsyncResult _result)
            {
                try
                {
                    int _byteLength = stream.EndRead(_result);
                    if (_byteLength <= 0)
                    {
                        //TODO otkaci klijenata

                    }

                    byte[] _data = new byte[_byteLength];
                    Array.Copy(recivedBuffer, _data, _byteLength);

                    //TODO resiti podatke
                    stream.BeginRead(recivedBuffer, 0, dataBufferSize, ReceiveCallback, null); //Da nastavi da cita sa strima
                }catch (Exception _ex)
                {
                    Console.WriteLine($"Error receiving TCP data {_ex}");
                    //TODO otkaci adekvanto koorisnika
                }
            }
        }
    }
}
