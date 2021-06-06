using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Location of the proxy.
using MagicEightBallServiceClient.ServiceReference1;
using static System.Console;
namespace MagicEightBallServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {

             WriteLine("***** Ask the Magic 8 Ball *****\n");
            using (EightBallClient ball = new EightBallClient())
            {
                WriteLine("Your question: ");
                string question = ReadLine();
                string answer = ball.ObtainAnswerToQuestion(question);
                 WriteLine("8-Ball says: {0}", answer);
            }
            ReadLine();
        
        }
            
    }
}
