using System;
using System.Collections.Generic;
using System.Text;

namespace TestTask.Domain
{
    public class Note
    {
        public Note(string id, string content)
        {
            Id = id;
            Content = content;
        }
        public string Id { get; }

        public string Content { get; private set; }

        public void Update(string content)
        {
            Content = content;
        }
    }
}
