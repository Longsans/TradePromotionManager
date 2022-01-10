using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkStub.Models
{
    public abstract class BaseCustomSerializable
    {
        public BaseCustomSerializable() { }
        public BaseCustomSerializable(string json) { }

        public abstract string toJson();
    }
}
