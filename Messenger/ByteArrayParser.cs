using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Messenger
{
    public class ByteArrayParser
    {
		public static byte[] Serialize<T>(T source)
		{
			using (var stream = new MemoryStream())
			{
				var formatter = new BinaryFormatter();
				formatter.Serialize(stream, source);
				return stream.ToArray();
			}
		}

		public static T Deserialize<T>(byte[] source, int length)
		{
			using (var stream = new MemoryStream(source.Take(length).ToArray()))
			{
				var formatter = new BinaryFormatter();
				return (T)formatter.Deserialize(stream);
			}
		}
    }
}