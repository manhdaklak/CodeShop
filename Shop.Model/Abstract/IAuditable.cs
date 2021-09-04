using System;
using System.ComponentModel.DataAnnotations;

namespace Shop.Model.Abstract
{
    public interface IAuditable
    {
        DateTime? CreateDate { set; get; }

        [MaxLength(256)]
        string CreateBy { set; get; }

        DateTime? ModifiedDate { set; get; }
        
        [MaxLength(256)]
        string ModifiedBy { set; get; }

        [MaxLength(256)]
        string MetaKeywords { set; get; }

        [MaxLength(256)]
        string MetaDescriptions { set; get; }

        bool? Status { set; get; }
    }
}