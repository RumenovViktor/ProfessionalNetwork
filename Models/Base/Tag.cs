namespace Models.Base
{
    using System;

    using Common.Models;
    using Models.Interfaces;

    public abstract class Tag : AuditInfo, ITag
    {
        public virtual string Text { get; set; }
    }
}
