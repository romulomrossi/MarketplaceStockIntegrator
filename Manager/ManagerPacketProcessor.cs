using System;
using Messenger;

namespace Manager
{
    public abstract class ManagerPacketProcessor
    {
        public static IManagerPacketProcessor FactoryProcessor(Packet packet)
        {
            switch(packet.type)
            {
                case PacketEnum.Test : return new TestPacketProcessor();
                default: return null;
            }
        }
    }
}