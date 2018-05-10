﻿using System;

namespace uic_forms.models
{
    public class QueryModel
    {
        public Guid Id { get; set; }
        public int EsriId { get; set; }
        public Guid WellId { get; set; }
        public DateTime ViolationDate { get; set; }
        public DateTime? ReturnToComplianceDate { get; set; }
        public DateTime? EnforcementDate { get; set; }
        public string EnforcementType { get; set; }
    }
}