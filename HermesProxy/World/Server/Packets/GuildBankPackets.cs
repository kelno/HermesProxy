/*
 * Copyright (C) 2012-2020 CypherCore <http://github.com/CypherCore>
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */


using Framework.Constants;
using Framework.GameMath;
using HermesProxy.World.Enums;
using HermesProxy.World.Objects;
using System;
using System.Collections.Generic;

namespace HermesProxy.World.Server.Packets
{
    public class GuildBankActivateInfo : ClientPacket
    {
        public GuildBankActivateInfo(WorldPacket packet) : base(packet) { }

        public override void Read()
        {
            PlayerGuid = _worldPacket.ReadPackedGuid128();
            FullUpdate = _worldPacket.ReadBool();
        }

        public WowGuid128 PlayerGuid;
        public bool FullUpdate;
    }

    public class GuildBankBuyTab : ClientPacket
    {
        public GuildBankBuyTab(WorldPacket packet) : base(packet) { }

        public override void Read()
        {
            Banker = _worldPacket.ReadPackedGuid128();
            BankTab = _worldPacket.ReadUInt8();
        }

        public WowGuid128 Banker;
        public byte BankTab;
    }
    public class GuildBankQueryTab : ClientPacket
    {
        public GuildBankQueryTab(WorldPacket packet) : base(packet) { }

        public override void Read()
        {
            Banker = _worldPacket.ReadPackedGuid128();
            BankTab = _worldPacket.ReadUInt8();
            FullUpdate = _worldPacket.ReadBool();
        }

        public WowGuid128 Banker;
        public byte BankTab;
        public bool FullUpdate;
    }

    public class GuildBankItemInfo
    {
        public ItemInstance Item;
        public int Slot;
        public int Count;
        public int EnchantmentID;
        public int Charges;
        public int OnUseEnchantmentID;
        public int Flags;
        public bool Locked = false;
        public List<ItemGemData> SocketEnchant;
        public void Write(WorldPacket data)
        {
            data.WriteInt32(Slot);
            data.WriteInt32(Count);
            data.WriteInt32(EnchantmentID);
            data.WriteInt32(Charges);
            data.WriteInt32(OnUseEnchantmentID);
            data.WriteInt32(Flags);
            //FIXME
            //data << Item;
            //data.WriteBits(SocketEnchant.size(), 2);
            //data.WriteBit(Locked);
            //data.FlushBits();

            //for (Item::ItemGemData const&socketEnchant : SocketEnchant)
            //    data << socketEnchant;
        }
    }

    public class GuildBankTabInfo
    {
        public int TabIndex;
        public String Name;
        public String Icon;

        public void Write(WorldPacket data)
        {
            data.WriteInt32(TabIndex);
            data.WriteBits(Name.Length, 7);
            data.WriteBits(Icon.Length, 9);
            data.FlushBits();
            data.WriteString(Name);
            data.WriteString(Icon);
        }
    }

    public class GuildBankQueryResults : ServerPacket
    {
        public GuildBankQueryResults() : base(Opcode.SMSG_GUILD_BANK_QUERY_RESULTS) { }

        public override void Write()
        {
            //temp until GuildBankItemInfo.Write is fixed
            ItemInfo.Clear();
            //

            _worldPacket.WriteUInt64(Money);
            _worldPacket.WriteInt32(Tab);
            _worldPacket.WriteInt32(WithdrawalsRemaining);
            _worldPacket.WriteUInt32(Convert.ToUInt32(TabInfo.Count));
            _worldPacket.WriteUInt32(Convert.ToUInt32(ItemInfo.Count));
            _worldPacket.WriteBool(FullUpdate);

            TabInfo.ForEach(p => p.Write(_worldPacket));
            ItemInfo.ForEach(p => p.Write(_worldPacket));
        }

        public List<GuildBankItemInfo> ItemInfo = new List<GuildBankItemInfo>();
        public List<GuildBankTabInfo> TabInfo = new List<GuildBankTabInfo>();
        public int WithdrawalsRemaining;
        public int Tab;
        public UInt64 Money;
        public bool FullUpdate;
    }

}
