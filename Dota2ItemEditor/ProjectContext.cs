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
            Items = new List<Item>();
        }
        public List<Item> Items { get; }
    }

    public class Item
    {
        public Item()
        {
            Fields = new List<IField>();
        }
        public Item(string name)
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
    public class Field : IField
    {
        public Field() { }
        public Field(string key)
        {
            Key = key;
        }
        public Field(string key, string val)
            : this(key)
        {
            Value = val;
        }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
