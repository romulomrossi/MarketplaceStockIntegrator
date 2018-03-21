using System.IO;
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

		public static T Deserialize<T>(byte[] source)
		{
			using (var stream = new MemoryStream(source))
			{
				var formatter = new BinaryFormatter();
				stream.Seek(0, SeekOrigin.Begin);
				return (T)formatter.Deserialize(stream);
			}
		}
    }
}