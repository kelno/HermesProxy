using HermesProxy.Enums;
using HermesProxy.World.Enums;
using HermesProxy.World.Objects;
using HermesProxy.World.Server.Packets;
using System;
using System.Collections.Generic;
using static HermesProxy.World.Server.Packets.QueryGuildInfoResponse.GuildInfo;

namespace HermesProxy.World.Client
{
    public partial class WorldClient
    {
        [PacketHandler(Opcode.SMSG_GUILD_BANK_QUERY_RESULTS, ClientVersionBuild.V2_0_1_6180)]
        void HandleGuildBankQueryResults(WorldPacket packet)
        {
            GuildBankQueryResults results = new();
            results.Money = packet.ReadUInt64();
            results.Tab = packet.ReadUInt8();
            results.WithdrawalsRemaining = packet.ReadInt32();
            results.FullUpdate = packet.ReadBool();

            if (results.Tab == 0 && results.FullUpdate)
            {
                var tabInfoSize = packet.ReadUInt8();
                for (int i = 0; i < tabInfoSize; ++i)
                {
                    GuildBankTabInfo tabInfo = new();
                    tabInfo.TabIndex = i;
                    tabInfo.Name = packet.ReadCString();
                    tabInfo.Icon = packet.ReadCString();
                    results.TabInfo.Add(tabInfo);
                }
            }

            var itemInfoSize = packet.ReadUInt8();
            for (int i = 0; i < itemInfoSize; ++i) //for (GuildBankItemInfo const& item : ItemInfo)
            {
                //    _worldPacket << uint8(item.Slot);
                //    _worldPacket << uint32(item.ItemID);
                //    if (item.ItemID)
                //    {
                //        _worldPacket << int32(item.RandomPropertiesID);
                //        if (item.RandomPropertiesID)
                //            _worldPacket << int32(item.RandomPropertiesSeed);

                //        _worldPacket << uint8(item.Count);
                //        _worldPacket << int32(item.EnchantmentID);
                //        _worldPacket << uint8(item.Charges);
                //        _worldPacket << uint8(item.SocketEnchant.size());

                //        for (GuildBankSocketEnchant const& socketEnchant : item.SocketEnchant)
                //        {
                //            _worldPacket << uint8(socketEnchant.SocketIndex);
                //            _worldPacket << int32(socketEnchant.SocketEnchantID);
                //        }
                //    }
            }

            SendPacketToClient(results);
        }
    }
}
