using System;
using System.ComponentModel.DataAnnotations;

namespace Tweetbook.Domain
{
    public class Post
    {
        [Key]//Le explicitamos que es una clave primaria, sino lo tomaría automaticamente incremental
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
