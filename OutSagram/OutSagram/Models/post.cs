namespace OutSagram.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class post
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public post()
        {
            comments = new HashSet<comment>();
        }

        public int postID { get; set; }

        public int autherID { get; set; }

        [Required(ErrorMessage ="*")]
        public string header { get; set; }

        public string subHeader { get; set; }

        public string content { get; set; }

        public int like { get; set; }

        public int dislike { get; set; }

        [Required(ErrorMessage ="*")]
        [StringLength(255)]
        public string photo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<comment> comments { get; set; }

        public virtual user user { get; set; }
    }
}
