namespace Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Models.Base;
    using Common.Models.Intefaces;

    public class SkillTag : Tag, IDeletableEntity
    {
        [Key]
        public int SkillId { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
