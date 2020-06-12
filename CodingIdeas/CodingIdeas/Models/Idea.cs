using System;
using SQLite;

namespace CodingIdeas.Models
{
    // Note that this class needs to be public
    [Table("ideas")]
    public class Idea
    {        
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DateAdded { get; set; }
    }
}
