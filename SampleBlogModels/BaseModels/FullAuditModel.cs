﻿using SampleBlogModels.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleBlogModels.BaseModels
{
    /// <summary>
    ///  ABSTRACT CLASS TO ENSURE BASIC IDENTITY AND AUDIT PROPERTIES / FIELDS
    /// </summary>
    public abstract class FullAuditModel : IIdentityModel, IAuditedModel, IActivatableModel, ISoftDeletable
    {
        [Key]
        public int Id { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? LastModifiedUserId { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
