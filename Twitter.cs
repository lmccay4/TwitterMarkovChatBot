using System;
using System.Threading;
using System.Collections;
using Tweetinvi;


namespace NoMoreBotrooms
{
    public class Twitter
    {
        static DateTime pullTime;

        public static void CheckForDMs()
        {
            Auth.SetUserCredentials("####YOUR TWITTER API TOKENS HERE####");

            var user = User.GetAuthenticatedUser();

            TimeSpan twoMins = TimeSpan.FromMinutes(2);

            foreach (var msg in user.GetLatestMessages()) 
            {
                if (msg.SenderId.ToString() != "####YOUR OWN TWITTER USER_ID####" && (msg.CreatedAt >= pullTime || msg.CreatedAt.Subtract(twoMins) < pullTime))
                {
                    string textToTweet = Markov.MarkovChain("yellowwallpaper.txt", 2, 300);
                    long userID = msg.SenderId;
                    Tweet(textToTweet, userID);
                }
                else if (msg.CreatedAt < pullTime) 
                {
                    break;
                }
            }
            Console.WriteLine("Checking again...");
        }

        public static void RegisterPullTime() 
        {
            pullTime = DateTime.Now;
            Thread.Sleep(200000);
        }


        public static void Tweet(string textToTweet, long userID) 
        {
            Auth.SetUserCredentials("####YOUR TWITTER TOKENS HERE####");

            var message = Message.PublishMessage(textToTweet, userID);  
                      
        }



    }
}