using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UnibouwAPI.Models;

[Table("WorkItemCategoryType")]
public partial class WorkItemCategoryType
{
    [Key]
    [Column("CategoryID")]
    public Guid CategoryId { get; set; }

    [StringLength(255)]
    public string? CategoryName { get; set; }
}
