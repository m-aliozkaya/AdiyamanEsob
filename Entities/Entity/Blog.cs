﻿using System.ComponentModel.DataAnnotations;
using Core.Entities.Concrete;

namespace Entities.Entity;

public class Blog : ContentEntity
{
    [Required]
    public string Image { get; set; }
    public bool IsHome { get; set; }
}