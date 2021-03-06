﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using FSO.Server.Common;

namespace FSO.Server.Database.DA.Shards
{
    public class SqlShards : AbstractSqlDA, IShards
    {
        public SqlShards(ISqlContext context) : base(context) {
        }

        public List<Shard> All()
        {
            return Context.Connection.Query<Shard>("SELECT * FROM fso_shards").ToList();
        }

        public void CreateTicket(ShardTicket ticket)
        {
            Context.Connection.Execute("INSERT INTO fso_shard_tickets VALUES (@ticket_id, @user_id, @date, @ip, @avatar_id)", ticket);
        }

        public void DeleteTicket(string id)
        {
            Context.Connection.Execute("DELETE FROM fso_shard_tickets WHERE ticket_id = @ticket_id", new { ticket_id = id });
        }

        public ShardTicket GetTicket(string id)
        {
            return
                Context.Connection.Query<ShardTicket>("SELECT * FROM fso_shard_tickets WHERE ticket_id = @ticket_id", new { ticket_id = id }).FirstOrDefault();
        }

        public void PurgeTickets(uint time)
        {
            Context.Connection.Query("DELETE FROM fso_shard_tickets WHERE date < @time", new { time = time });
        }

        public void UpdateVersion(int shard_id, string name, string number)
        {
            Context.Connection.Query("UPDATE fso_shards SET version_name = @version_name, version_number = @version_number WHERE shard_id = @shard_id", new
            {
                version_name = name,
                version_number = number,
                shard_id = shard_id
            });
        }
    }
}
