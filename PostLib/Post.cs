using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostLib
{
    public class Post
    {
        public String RequestAdress { get; set; }
        public List<PostParameter> Parameters { get; set; }
        public String ContentType { get; set; }

        public Post(String RequestAdress)
        {
            this.RequestAdress = RequestAdress;
            this.ContentType = "application/x-www-form-urlencoded";
            this.Parameters = new List<PostParameter>();
        }

        /// <summary>
        /// Sendet die Abfrage zum Server
        /// </summary>
        /// <returns></returns>
        public String SendRequest()
        {
            // Parameter
            byte[] bytes = Encoding.UTF8.GetBytes(this.GetRequestCommand());
            System.Net.WebRequest request = System.Net.WebRequest.Create(this.RequestAdress);
            request.Method = "POST";
            request.ContentType = this.ContentType;
            request.ContentLength = bytes.Length;

            // Ausgangs Stream
            System.IO.Stream reqStr = request.GetRequestStream();
            reqStr.Write(bytes, 0, bytes.Length);
            reqStr.Close();
            reqStr.Flush();

            // Antwort Stream
            System.Net.WebResponse response = request.GetResponse();
            System.IO.Stream resStr = response.GetResponseStream();
            System.IO.StreamReader reader = new System.IO.StreamReader(resStr);
            String ResponseString = reader.ReadToEnd();
            reader.Close();
            resStr.Close();
            response.Close();

            return ResponseString;
        }

        /// <summary>
        /// Gibt den Command für die Abfrage aus
        /// </summary>
        /// <returns></returns>
        public String GetRequestCommand()
        {
            StringBuilder builder = new StringBuilder();
            foreach (PostParameter param  in this.Parameters)
            {
                builder.Append(param.ToString());
            }

            return builder.ToString();
        }

    }
}
