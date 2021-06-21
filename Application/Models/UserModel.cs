using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Application.Validators.Interfaces;

namespace Application.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public virtual void Validate(IUserValidator userValidator) {
            
        }
    }
}
