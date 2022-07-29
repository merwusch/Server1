using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPAddress ipad = IPAddress.Parse("192.168.101.159");
            TcpListener mylist = new TcpListener(ipad, 8001);
            mylist.Start();
            Console.WriteLine("Sunucu 8001 numaralı portta çalışıyor.");
            Console.WriteLine("Tam sunucu adresi" +mylist.LocalEndpoint);
            Console.WriteLine("Bağlantı için bekleniyor...");
            
            Socket s = mylist.AcceptSocket();
            Console.WriteLine("Bağlantı kabul edildi." + s.RemoteEndPoint);

            byte[] b = new Byte[100];
            int k = s.Receive(b);
            Console.WriteLine("Alındı.");
            for(int i = 0; i< k; i++)
            {
                Console.Write(Convert.ToChar(b[i]));
            }

            ASCIIEncoding asen = new ASCIIEncoding();
            s.Send(asen.GetBytes("Mesaj sunucu tarafından alındı."));
            Console.WriteLine("Gönderim başarılı.");

            s.Close();
            mylist.Stop();

            Console.ReadLine();
        }
    }
}
