namespace OutSagram.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("user")]
    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            posts = new HashSet<post>();
            comments = new HashSet<comment>();
        }

        public int Id { get; set; }
        [RegularExpression("[a-z]{1,10}", ErrorMessage ="the name must be charecters ")]
        [Required(ErrorMessage = "*")]
        [StringLength(255)]
        public string firstName { get; set; }

        [RegularExpression("[a-z]{1,10}", ErrorMessage = "the name must be charecters")]
        [Required(ErrorMessage = "*")]
        [StringLength(255)]
        public string lastName { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(255)]
        public string userName { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(255)]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$")]
        public string email { get; set; }


        [StringLength(255)]
        public string profileImage { get; set; }


        [MinLength(8, ErrorMessage = "the length must be 8 or more")]
        [Required(ErrorMessage = "*")]
        [StringLength(255)]
        public string password { get; set; }

        [Required(ErrorMessage = "*")]
        [NotMapped]
        [Compare("password", ErrorMessage = "the password not match")]
        public string confirm_password { get; set; }

        [Required]
        [StringLength(255)]
        public string phone { get; set; }


        public string description { get; set; }

        public virtual friendRelation friendRelation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<post> posts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<comment> comments { get; set; }
    }
}
