using System;
using System.Diagnostics;

namespace NoMoreBotrooms
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch s = new Stopwatch();
            s.Start();

            while (s.Elapsed < TimeSpan.FromMinutes(60))
            {
                Twitter.RegisterPullTime();
                Twitter.CheckForDMs();
            }

            s.Stop();
            
        }
    }
}
