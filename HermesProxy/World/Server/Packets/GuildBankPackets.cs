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

}
