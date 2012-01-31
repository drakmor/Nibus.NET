﻿//-------------------------------------------------------------------
// Copyright (c) 2012 Nata-Info Ltd.
// Andrei Sarakeev
// NmsRequestDomainUpload.cs
// 
//-------------------------------------------------------------------

#region Using directives

using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

#endregion

namespace NataInfo.Nibus.Nms.Services
{
    public sealed class NmsRequestDomainUpload : NmsMessage
    {
        #region Member Variables

        #endregion

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        internal NmsRequestDomainUpload(NibusDatagram datagram)
            : base(datagram)
        {
            Contract.Requires(datagram != null);
            Contract.Requires(datagram.ProtocolType == ProtocolType.Nms);
            Contract.Requires(datagram.Data.Count >= NmsHeaderLength);
            Contract.Assume(ServiceType == NmsServiceType.RequestDomainUpload);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NmsRequestDomainUpload"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="destanation">The destanation.</param>
        /// <param name="domain">The domain (8 симв).</param>
        public NmsRequestDomainUpload(Address source, Address destanation, string domain)
        {
            Contract.Requires(domain != null);
            Contract.Requires(domain.Length <= 8);
            Contract.Ensures(ServiceType == NmsServiceType.RequestDomainUpload);
            var data = new byte[8];
            Encoding.Default.GetBytes(domain).CopyTo(data, 0);
            Initialize(
                source,
                destanation,
                PriorityType.Normal,
                NmsServiceType.RequestDomainUpload,
                true,
                0,
                false,
                data);
        }

        #endregion //Constructors

        #region Properties

        public string Domain
        {
            get
            {
                Contract.Requires(!IsResponse);
                return
                    Encoding.Default.GetString(
                        Datagram.Data.Skip(NmsHeaderLength).Take(8).TakeWhile(b => b != 0).ToArray());
            }
        }

        public uint DomainSize
        {
            get
            {
                Contract.Requires(IsResponse);
                return BitConverter.ToUInt32(Datagram.Data.ToArray(), NmsHeaderLength + 1);
            }
        }

        #endregion //Properties
    }
}