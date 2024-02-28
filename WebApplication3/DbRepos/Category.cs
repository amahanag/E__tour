using System;
using System.Collections.Generic;

namespace ETour.DbRepos;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? CategoryImagePath { get; set; }

    public string? CategoryInfo { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<Package> Packages { get; set; } = new List<Package>();

    public virtual ICollection<SubCategory> SubCategories { get; set; } = new List<SubCategory>();
}
