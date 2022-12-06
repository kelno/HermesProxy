﻿/*
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

using Framework.Logging;
using System;
using System.Net;
using System.Net.Sockets;

namespace Framework.Networking
{
    public delegate void SocketAcceptDelegate(Socket newSocket);

    public class AsyncAcceptor
    {
        TcpListener _listener;
        volatile bool _closed;

        public bool IsListening => !_closed;

        public bool Start(string ip, int port)
        {
            IPAddress bindIP;
            if (!IPAddress.TryParse(ip, out bindIP))
            {
                Log.Print(LogType.Error, $"Server can't be started: Invalid IP-Address: {ip}");
                return false;
            }

            try
            {
                _listener = new TcpListener(bindIP, port);
                _listener.Start();
            }
            catch (SocketException ex)
            {
                Log.outException(ex);
                return false;
            }

            return true;
        }

        public async void AsyncAcceptSocket(SocketAcceptDelegate mgrHandler)
        {
            try
            {
                var _socket = await _listener.AcceptSocketAsync();
                if (_socket != null)
                {
                    mgrHandler(_socket);

                    if (!_closed)
                        AsyncAcceptSocket(mgrHandler);
                }
            }
            catch (ObjectDisposedException ex)
            {
                Log.outException(ex);
            }
        }

        public async void AsyncAccept<T>() where T : ISocket
        {
            try
            {
                var socket = await _listener.AcceptSocketAsync();
                if (socket != null)
                {
                    T newSocket = (T)Activator.CreateInstance(typeof(T), socket);
                    newSocket.Accept();

                    if (!_closed)
                        AsyncAccept<T>();
                }
            }
            catch (ObjectDisposedException)
            { }
        }

        public void Close()
        {
            if (_closed)
                return;

            _closed = true;
        }
    }
}
