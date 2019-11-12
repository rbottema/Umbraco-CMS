﻿using System;
using NPoco;
using Umbraco.Core.Persistence.DatabaseAnnotations;
using Umbraco.Core.Persistence.DatabaseModelDefinitions;

namespace Umbraco.Core.Persistence.Dtos
{
    [TableName(TableName)]
    [PrimaryKey("id", AutoIncrement = false)]
    [ExplicitColumns]
    internal class AccessRuleDto
    {
        public const string TableName = Constants.DatabaseSchema.Tables.AccessRule;

        [Column("id")]
        [PrimaryKeyColumn(Name = "PK_umbracoAccessRule", AutoIncrement = false)]
        public Guid Id { get; set; }

        [Column("accessId")]
        [ForeignKey(typeof(AccessDto), Name = "FK_umbracoAccessRule_umbracoAccess_id")]
        [Index(IndexTypes.NonClustered, Name = "IX_" + TableName + "_AccessId")]
        public Guid AccessId { get; set; }

        [Column("ruleValue")]
        [Index(IndexTypes.UniqueNonClustered, ForColumns = "ruleValue,ruleType,accessId", Name = "IX_umbracoAccessRule")]
        public string RuleValue { get; set; }

        [Column("ruleType")]
        public string RuleType { get; set; }

        [Column("createDate")]
        [Constraint(Default = SystemMethods.CurrentDateTime)]
        public DateTime CreateDate { get; set; }

        [Column("updateDate")]
        [Constraint(Default = SystemMethods.CurrentDateTime)]
        public DateTime UpdateDate { get; set; }
    }
}
