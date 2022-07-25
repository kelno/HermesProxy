using Framework.Constants;
using HermesProxy.Enums;
using HermesProxy.World;
using HermesProxy.World.Enums;
using HermesProxy.World.Objects;
using HermesProxy.World.Server.Packets;

namespace HermesProxy.World.Server
{
    public partial class WorldSocket
    {
        // Handlers for CMSG opcodes coming from the modern client
        [PacketHandler(Opcode.CMSG_GUILD_BANK_ACTIVATE)]
        void HandleGuildBankActivate(GuildBankActivateInfo query)
        {
            WorldPacket packet = new WorldPacket(Opcode.CMSG_GUILD_BANK_ACTIVATE);
            packet.WriteGuid(query.PlayerGuid.To64());
            packet.WriteBool(query.FullUpdate);
            SendPacketToServer(packet);
        }

    }
}
