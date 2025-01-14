﻿using System.ComponentModel.DataAnnotations;

namespace DeUrgenta.Group.Api.Models
{
    public sealed record GroupRequest
    {
        [Required]
        [StringLength(250, MinimumLength = 3)]
        public string Name { get; init; }
    }
}