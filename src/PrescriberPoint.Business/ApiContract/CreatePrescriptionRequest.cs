﻿namespace PrescriberPoint.Business.ApiContract
{
    public class CreatePrescriptionRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}