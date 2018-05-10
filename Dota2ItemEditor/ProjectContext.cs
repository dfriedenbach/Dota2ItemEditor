using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota2ItemEditor
{
    public class ProjectContext
    {
        public ProjectContext()
        {
            Items = new List<Dota2Item>();
        }
        public List<Dota2Item> Items { get; }
    }

    public class Dota2Item
    {
        public Dota2Item()
        {
            Fields = new List<IField>();
        }
        public Dota2Item(string name)
            : this()
        {
            Name = name;
        }

        public string Name { get; set; }
        public List<IField> Fields { get; }
    }
    public interface IField
    {
        string Key { get; set; }
    }
    public class TableField : IField
    {
        public TableField()
        {
            Fields = new List<IField>();
        }
        public TableField(string key)
            : this()
        {
            Key = key;
        }

        public string Key { get; set; }
        public List<IField> Fields { get; }
    }
    public class StringField : IField
    {
        public StringField() { }
        public StringField(string key)
        {
            Key = key;
        }
        public StringField(string key, string val)
            : this(key)
        {
            Value = val;
        }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
