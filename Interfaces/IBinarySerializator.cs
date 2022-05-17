using OOP3.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP3.Interfaces
{
    public interface IBinarySerializator
    {
        DenizensOfAzeroth Deserialize(byte[] byteArray);

        byte[] Serialize(DenizensOfAzeroth Denizens);
    }
}
