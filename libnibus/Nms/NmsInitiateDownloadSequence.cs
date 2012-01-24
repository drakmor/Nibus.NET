﻿//-------------------------------------------------------------------
// Copyright (c) 2012 Nata-Info Ltd.
// Andrei Sarakeev
// NmsInitiateDownloadSequence.cs
// 
//-------------------------------------------------------------------

#region Using directives

using System.Diagnostics.Contracts;

#endregion

namespace NataInfo.Nibus.Nms
{
    public sealed class NmsInitiateDownloadSequence : NmsMessage
    {
        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        internal NmsInitiateDownloadSequence(NibusDatagram datagram)
            : base(datagram)
        {
            Contract.Requires(datagram != null);
            Contract.Requires(datagram.ProtocolType == ProtocolType.Nms);
            Contract.Requires(datagram.Data.Count >= NmsHeaderLength);
            Contract.Assume(ServiceType == NmsServiceType.InitiateDownloadSequence);
        }

        public NmsInitiateDownloadSequence(Address source, Address destanation, int id)
        {
            Contract.Ensures(ServiceType == NmsServiceType.InitiateDownloadSequence);
            Initialize(
                source,
                destanation,
                PriorityType.Normal,
                NmsServiceType.InitiateDownloadSequence,
                true,
                id,
                false,
                new byte[0]);
        }

        #endregion //Constructors

        #region Properties

        #endregion //Properties
    }
}