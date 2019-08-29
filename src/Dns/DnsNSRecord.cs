﻿using System;

namespace Dns
{
    /// <summary>
    /// Name Server Record
    /// </summary>
    public class DnsNSRecord : DnsRecord
    {
        /// <summary>
        /// A host which should be authoritative for the domain
        /// </summary>
        public string NameServer { get; set; }

        /// <summary>
        /// Constructs a new instance of <see cref="DnsNSRecord"/>.
        /// </summary>
        /// <param name="zone">Associated zone</param>
        /// <param name="name">Owner name</param>
        /// <param name="class">Record class</param>
        /// <param name="timeToLive">Record time to live (TTL)</param>
        /// <param name="nameServer">A host which should be authoritative for the domain</param>
        public DnsNSRecord(DnsZone zone, string name, DnsRecordClasses @class, TimeSpan timeToLive, string nameServer)
            : base(zone, name, DnsRecordTypes.NS, @class, timeToLive)
        {
            if (string.IsNullOrWhiteSpace(nameServer))
                throw new ArgumentNullException(nameof(nameServer));

            NameServer = nameServer;
        }

        /// <summary>
        /// Constructs a new instance of <see cref="DnsNSRecord"/>.
        /// </summary>
        /// <param name="name">Owner name</param>
        /// <param name="class">Record class</param>
        /// <param name="timeToLive">Record time to live (TTL)</param>
        /// <param name="nameServer">A host which should be authoritative for the domain</param>
        public DnsNSRecord(string name, DnsRecordClasses @class, TimeSpan timeToLive, string nameServer)
            : this(zone: null, name, @class, timeToLive, nameServer)
        {
        }

        /// <summary>
        /// Constructs a new instance of <see cref="DnsNSRecord"/>.
        /// </summary>
        /// <param name="zone">Associated zone</param>
        /// <param name="name">Owner name</param>
        /// <param name="timeToLive">Record time to live (TTL)</param>
        /// <param name="nameServer">A host which should be authoritative for the domain</param>
        public DnsNSRecord(DnsZone zone, string name, TimeSpan timeToLive, string nameServer)
            : this(zone, name, DnsRecordClasses.IN, timeToLive, nameServer)
        {
        }

        /// <summary>
        /// Constructs a new instance of <see cref="DnsNSRecord"/>.
        /// </summary>
        /// <param name="name">Owner name</param>
        /// <param name="timeToLive">Record time to live (TTL)</param>
        /// <param name="nameServer">A host which should be authoritative for the domain</param>
        public DnsNSRecord(string name, TimeSpan timeToLive, string nameServer)
            : this(zone: null, name, timeToLive, nameServer)
        {
        }

        /// <summary>
        /// Clones the record associating it with the provided zone
        /// </summary>
        /// <param name="zone">Record associated zone</param>
        /// <returns>A record clone</returns>
        public override DnsRecord Clone(DnsZone zone)
            => new DnsNSRecord(zone, Name, Class, TimeToLive, NameServer);

        /// <summary>
        /// Returns a textual representation of the current instance data
        /// </summary>
        /// <returns>A textual representation of the current instance data</returns>
        protected override string GetDataText()
            => NameServer;

    }
}
