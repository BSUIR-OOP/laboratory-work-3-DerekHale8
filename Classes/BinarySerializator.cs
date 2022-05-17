using OOP3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP3.Classes
{
    public class BinarySerializator : IBinarySerializator
    {
        public DenizensOfAzeroth Deserialize(byte[] byteArray)
        {
            var binaryStr = System.Text.Encoding.Default.GetString(byteArray);
            var stringArray = Enumerable.Range(0, binaryStr.Length / 8).Select(i => Convert.ToByte(binaryStr.Substring(i * 8, 8), 2)).ToArray();
            var text = Encoding.UTF8.GetString(stringArray);
            DenizensOfAzeroth res = new DenizensOfAzeroth();
            string[] stream = text.Split('/');
            foreach (string s in stream)
            {
                if (!s.Equals(""))
                {
                    Dictionary<string, string> tokens = new Dictionary<string, string>();
                    string[] token = s.Split(':');
                    for (int i = 0; i < token.Length; i += 2)
                    {
                        tokens.Add(token[i], token[i + 1]);
                    }
                    Type type = Type.GetType(tokens["type"]);
                    Race c = (Race)Activator.CreateInstance(type);
                    foreach (var f in type.GetProperties())
                    {
                        if (f.PropertyType.Equals(typeof(string)))
                        {
                            f.SetValue(c, tokens[f.Name]);
                        }
                        else
                        {
                            f.SetValue(c, int.Parse(tokens[f.Name]));
                        }
                    }
                    foreach (var f in type.GetFields())
                    {
                        if (f.FieldType.Equals(typeof(string)))
                        {
                            f.SetValue(c, tokens[f.Name]);
                        }
                        else
                        {
                            f.SetValue(c, int.Parse(tokens[f.Name]));
                        }
                    }
                    res.Add(c);
                }
            }
            return res;
        }

        public byte[] Serialize(DenizensOfAzeroth Denizens)
        {
            string res = "";
            foreach (Race race in Denizens)
            {
                res += "/";
                Type type = race.GetType();
                res += $"type:{type.FullName}";
                foreach (var f in type.GetFields())
                {
                    res += $":{f.Name}:{f.GetValue(race)}";
                }
                foreach (var f in type.GetProperties())
                {
                    res += $":{f.Name}:{f.GetValue(race)}";
                }
            }
            //Encoding.ASCII.GetBytes(res);
            byte[] resultInBytes = Encoding.UTF8.GetBytes(res);
            byte[] buf = Encoding.UTF8.GetBytes(res);
            StringBuilder sb = new StringBuilder(buf.Length * 8);
            foreach (byte b in buf)
            {
                sb.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
            }
            //resultInBytes = res.ToByteArray();
            string binaryStr = sb.ToString();

            //string resultText = BinaryToString(binaryStr);
            //Encoding.UTF8.GetBytes(binaryStr
            //var stringArray = Enumerable.Range(0, binaryStr.Length / 8).Select(i => Convert.ToByte(binaryStr.Substring(i * 8, 8), 2)).ToArray();
            //var str = Encoding.UTF8.GetString(stringArray);

            return Encoding.UTF8.GetBytes(binaryStr);
        }
    }
}
