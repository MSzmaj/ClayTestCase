using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Application.Validators.Interfaces;

namespace Application.Models
{
    public class LogModel
    {
        public int Id { get; set; }

        public virtual void Validate(ILogValidator logValidator) {
            
        }
    }
}
