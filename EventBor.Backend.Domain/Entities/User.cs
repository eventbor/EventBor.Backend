﻿using EventBor.Backend.Domain.Entities.Commons;

namespace EventBor.Backend.Domain.Entities;

public class User : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string PasswordHash { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsVerified { get; set; }
    public bool IsActive { get; set; }
}