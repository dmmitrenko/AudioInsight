﻿namespace AudioInsight.Domain.Model;

public class Category
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public List<string> Points { get; set; }
}
