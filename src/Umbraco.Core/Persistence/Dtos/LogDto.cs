﻿using System;
using NPoco;
using Umbraco.Core.Persistence.DatabaseAnnotations;
using Umbraco.Core.Persistence.DatabaseModelDefinitions;

namespace Umbraco.Core.Persistence.Dtos
{
    [TableName(TableName)]
    [PrimaryKey("id")]
    [ExplicitColumns]
    internal class LogDto
    {
        public const string TableName = Constants.DatabaseSchema.Tables.Log;

        private int? _userId;

        [Column("id")]
        [PrimaryKeyColumn]
        public int Id { get; set; }

        [Column("userId")]
        [ForeignKey(typeof(UserDto))]
        [NullSetting(NullSetting = NullSettings.Null)]
        [Index(IndexTypes.NonClustered, Name = "IX_" + TableName + "_UserId")]
        public int? UserId { get => _userId == 0 ? null : _userId; set => _userId = value; } //return null if zero

        [Column("NodeId")]
        [Index(IndexTypes.NonClustered, Name = "IX_umbracoLog")]
        public int NodeId { get; set; }

        /// <summary>
        /// This is the entity type associated with the log
        /// </summary>
        [Column("entityType")]
        [Length(50)]
        [NullSetting(NullSetting = NullSettings.Null)]
        public string EntityType { get; set; }

        [Column("Datestamp")]
        [Constraint(Default = SystemMethods.CurrentDateTime)]
        [Index(IndexTypes.NonClustered, Name = "IX_" + TableName + "_Datestamp")]
        public DateTime Datestamp { get; set; }

        [Column("logHeader")]
        [Length(50)]
        [Index(IndexTypes.NonClustered, Name = "IX_" + TableName + "_LogHeader")]
        public string Header { get; set; }

        [Column("logComment")]
        [NullSetting(NullSetting = NullSettings.Null)]
        [Length(4000)]
        public string Comment { get; set; }

        /// <summary>
        /// Used to store additional data parameters for the log
        /// </summary>
        [Column("parameters")]
        [NullSetting(NullSetting = NullSettings.Null)]
        [Length(500)]
        public string Parameters { get; set; }
    }
}
