//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TeamManagement.BO
{
    using System;
    using System.Collections.Generic;
    
    public partial class PlayDetail
    {
        public int Id { get; set; }
        public string TeamAgainst { get; set; }
        public Nullable<System.DateTime> FixtureDate { get; set; }
        public string Venue { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public Nullable<int> TeamId { get; set; }
        public string Season { get; set; }
    }
}