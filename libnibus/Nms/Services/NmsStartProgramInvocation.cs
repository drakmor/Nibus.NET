﻿//-------------------------------------------------------------------
// Copyright (c) 2012 Nata-Info Ltd.
// Andrei Sarakeev
// NmsStartProgramInvocation.cs
// 
//-------------------------------------------------------------------

#region Using directives

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;

#endregion

namespace NataInfo.Nibus.Nms.Services
{
    /// <summary>
    /// Класс-обертка для сообщений о начале выполнения подпрограммы.
    /// </summary>
    public sealed class NmsStartProgramInvocation : NmsMessage
    {
        #region Member Variables

        private ReadOnlyCollection<Tuple<NmsValueType, object>> _args;

        #endregion

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        internal NmsStartProgramInvocation(NibusDatagram datagram)
            : base(datagram)
        {
            Contract.Requires(datagram != null);
            Contract.Requires(datagram.ProtocolType == ProtocolType.Nms);
            Contract.Requires(datagram.Data.Count >= NmsHeaderLength);
            Contract.Assume(ServiceType == NmsServiceType.StartProgramInvocation);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NmsStartProgramInvocation"/> class.
        /// </summary>
        /// <param name="source">Адрес источника.</param>
        /// <param name="destanation">Адрес приемника.</param>
        /// <param name="id">Идентификатор подпрограммы.</param>
        /// <param name="waitResponse"><c>true</c> - если требуется ожидание подтверждения.</param>
        /// <param name="args">Пары с аргументами (тип, значение) подпрограммы.</param>
        public NmsStartProgramInvocation(
            Address source, Address destanation, int id, bool waitResponse = true, params Tuple<NmsValueType, object>[] args)
        {
            Contract.Ensures(ServiceType == NmsServiceType.StartProgramInvocation);
            var nmsData = new List<byte>(NmsMaxDataLength) { (byte)args.Length };
            foreach (var argData in args.Select(tuple => WriteValue(tuple.Item1, tuple.Item2)))
            {
                if (nmsData.Count + argData.Length > NmsMaxDataLength)
                {
                    throw new ArgumentOutOfRangeException("args");
                }

                nmsData.AddRange(argData);
            }

            Initialize(
                source,
                destanation,
                PriorityType.Normal,
                NmsServiceType.StartProgramInvocation,
                waitResponse,
                id,
                false,
                nmsData.ToArray());
        }

        #endregion //Constructors

        #region Properties

        /// <summary>
        /// Возвращает аргументы переданные в подпрограмму в виде пар (тип, значение).
        /// </summary>
        public ReadOnlyCollection<Tuple<NmsValueType, object>> Args
        {
            get
            {
                Contract.Requires(!IsResponse);
                if (_args == null)
                {
                    byte count = Datagram.Data[NmsHeaderLength + 0];
                    var args = new Tuple<NmsValueType, object>[count];
                    byte[] buffer = Datagram.Data.Skip(1).ToArray();
                    int offset = 0;
                    for (int i = 0; i < count; i++)
                    {
                        var vt = (NmsValueType)buffer[offset++];
                        object value = ReadValue(vt, buffer, offset);
                        offset += GetSizeOf(vt, value);
                        args[i] = new Tuple<NmsValueType, object>(vt, value);
                    }
                    _args = new ReadOnlyCollection<Tuple<NmsValueType, object>>(args);
                }

                return _args;
            }
        }

        #endregion //Properties
    }
}