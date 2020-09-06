using System;

namespace CommandAPI.Models
{
    public class Command
    {
        public Guid CommandId { get; set; }
        public string HowTo { get; set; }
        public string Platform { get; set; }
        public string CommandLine { get; set; }
    }
}