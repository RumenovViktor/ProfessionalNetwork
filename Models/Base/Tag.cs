namespace Models.Base
{
    using System;

    using Models.Interfaces;

    public abstract class Tag : ITag
    {
        public virtual string Text { get; set; }
    }
}
