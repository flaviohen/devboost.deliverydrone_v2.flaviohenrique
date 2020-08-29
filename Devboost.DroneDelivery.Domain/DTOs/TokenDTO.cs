﻿using System;

namespace Devboost.DroneDelivery.Domain.DTOs
{
    public class TokenDTO
    {
        public bool Authenticated { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string AccessToken { get; set; }
        public string Message { get; set; }
        
    }
}