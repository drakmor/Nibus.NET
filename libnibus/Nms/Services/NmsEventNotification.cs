﻿//-------------------------------------------------------------------
// Copyright (c) 2012 Nata-Info Ltd.
// Andrei Sarakeev
// NmsEventNotification.cs
// 
//-------------------------------------------------------------------

#region Using directives

using System.Diagnostics.Contracts;

#endregion

namespace NataInfo.Nibus.Nms.Services
{
    /// <summary>
    /// Класс-обертка для сообщений сервиса <see cref="NmsServiceType.EventNotification"/>
    /// "Сигнализация событий".
    /// </summary>
    public sealed class NmsEventNotification : NmsMessage
    {
        #region Constructors

        /// <summary>
        /// Конструктор создания NMS-сообщения из низлежащего сообщения <see cref="NibusDatagram"/>.
        /// </summary>
        /// <param name="datagram">Датаграмма.</param>
        /// <remarks>
        /// Минимальный размер длины данных <paramref name="datagram"/> должен быть не меньше размера
        /// заголовка <see cref="NmsMessage.NmsHeaderLength"/>.
        /// </remarks>
        /// <seealso cref="NmsMessage.CreateFrom"/>
        internal NmsEventNotification(NibusDatagram datagram)
            : base(datagram)
        {
            Contract.Requires(datagram != null);
            Contract.Requires(datagram.ProtocolType == ProtocolType.Nms);
            Contract.Requires(datagram.Data.Count >= NmsHeaderLength);
            Contract.Ensures(ServiceType == NmsServiceType.EventNotification);
            Contract.Assume(ServiceType == NmsServiceType.EventNotification);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NmsEventNotification"/> class.
        /// </summary>
        /// <param name="source">Адрес источника сообщения.</param>
        /// <param name="id">Идентификатор события.</param>
        /// <param name="priority">Приоритет.</param>
        public NmsEventNotification(Address source, int id, PriorityType priority = PriorityType.Normal)
        {
            Contract.Requires(source != null);
            Contract.Ensures(ServiceType == NmsServiceType.EventNotification);
            Initialize(
                source,
                Address.Broadcast,
                priority,
                NmsServiceType.EventNotification,
                false,
                id,
                false,
                new byte[0]);
        }

        #endregion //Constructors
    }
}