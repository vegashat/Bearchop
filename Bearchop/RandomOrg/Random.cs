using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
namespace RandomOrg
{
    public class Random
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email">Random Org will notify you if you are causing them problems</param>
        /// <param name="timeOutSeconds">Timeout in seconds</param>
        public Random(string email, int timeOutSeconds)
        {
            Email = email;
            TimeOutSeconds = timeOutSeconds;
        }
        const string Address = "http://www.random.org/integers";
        public string Email
        {
            get;
            private set;
        }
        public int TimeOutSeconds
        {
            get;
            set;
        }

        /// <summary>
        /// Gets a list of random numbers from Random.org inclusive of min and max
        /// </summary>
        /// <param name="min">min number in series</param>
        /// <param name="max">max number in series</param>
        /// <param name="length">number of ints returned</param>
        /// <returns></returns>
        public List<int> GetNumbers(int min, int max, int length)
        {

            if (min > max)
            {
                throw new ArgumentException("Min cannot be greater than max");
            }
            if (length < 1)
            {
                throw new ArgumentException("Length must be greater than or equal to 1");
            }


            List<int> randomNumbers = new List<int>();
            UriBuilder builder = new UriBuilder(Address);
            builder.Query = string.Format("num={0}&min={1}&max={2}&col=1&base=10&format=plain&rnd=new", length, min, max);

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(builder.Uri);
            request.Timeout = TimeOutSeconds * 1000;
            request.Method = "GET";

            request.UserAgent = string.IsNullOrWhiteSpace(Email) ? "vegashat@gmail.com" : Email;
  
            var response = request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                while (!streamReader.EndOfStream)
                {
                    randomNumbers.Add(Int32.Parse(streamReader.ReadLine()));
                }
            }

            return randomNumbers;
        }
    }
}