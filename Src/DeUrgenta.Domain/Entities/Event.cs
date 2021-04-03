﻿using System;
using System.ComponentModel.DataAnnotations;

namespace DeUrgenta.Domain.Entities
{
    public class Event
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string OrganizedBy { get; set; }
        public string ContentBody { get; set; }
        public DateTime OccursOn { get; set; }
        public string Author { get; set; }
        public DateTime PublishedOn { get; set; }
        public bool IsArchived { get; set; }
    }
}