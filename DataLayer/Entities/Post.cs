using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Post:BaseEntity
	{
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public int Visit { get; set; }
		public string Photo1 { get; set; }
        public string Photo2 { get; set; }


        #region Relations

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        [ForeignKey("SubCategoryId")]
        public Category SubCategory { get; set; }
        public ICollection<PostComment> PostComments { get; set; }

        #endregion
    }
}
