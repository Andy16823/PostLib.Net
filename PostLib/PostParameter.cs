using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostLib
{
    public class PostParameter
    {
        public String Name { get; set; }
        public String Value{ get; set; }

        public PostParameter()
        {

        }

        public PostParameter(String Name, String Value)
        {
            this.Name = Name;
            this.Value = Value;
        }

        public override string ToString()
        {
            return this.Name + "=" + this.Value + "&";
        } 
    }
}
