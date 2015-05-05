namespace Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Skill
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }
    }
}
