using System;
using System.Threading;
namespace Selenium
{
    internal class Program
    {
        static  Valiable valiable = new Valiable();
        static int LongX = 100;
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            for (int i = 0; i < valiable.Cout_User; i++)
            {
                Program_System(valiable.Username[i], valiable.Password[i],i*(LongX*2),0);
            }
        }
        static void Program_System(string username,string password,int PositionX, int PositionY)
        {
            Thread t = new Thread(() =>
            {
                Chrome chrome = new Chrome();

                chrome.OpenChrome(LongX, 750, PositionX, PositionY);
                chrome.login(username, password);
                while (true)
                {
                    chrome.auto_slip(1);
                    Valiable.random.Next(10,1000);
                }
            }); t.Start();
        }
    }
}
