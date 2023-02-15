using System;

namespace LocationAPI.Models
{
    public class State
    {
        public int StateID {get;set;}
        public string StateCode { get; set; }= null!;
        public string StateName { get; set; }= null!;
    }
}