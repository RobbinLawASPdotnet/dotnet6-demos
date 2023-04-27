using System; //need for DateTime
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("BuildVersion")]
    public class BuildVersion : Object
    {
        [Key]
        public int Id { get; set; }
        public int Major { get; set; }
        public int Minor { get; set; }
        public int Build { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ReleaseDate { get; set; }

        public override string ToString() 
        {
		    return $"Id: {Id}, Major: {Major}, Minor: {Minor}, Build: {Build}, Release Date: {ReleaseDate}";
	    }
    }
}