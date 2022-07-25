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
            //_worldPacket << uint64(Money);
            //_worldPacket << uint8(Tab);
            //_withdrawalsRemainingPos = _worldPacket.wpos();
            //_worldPacket << int32(WithdrawalsRemaining);
            //_worldPacket << uint8(FullUpdate);

            //if (!Tab && FullUpdate)
            //{
            //    _worldPacket << uint8(TabInfo.size());
            //    for (GuildBankTabInfo const& tab : TabInfo)
            //    {
            //        _worldPacket << tab.Name;
            //        _worldPacket << tab.Icon;
            //    }
            //}

            //_worldPacket << uint8(ItemInfo.size());
            //for (GuildBankItemInfo const& item : ItemInfo)
            //{
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
            //}
        }
    }
}
