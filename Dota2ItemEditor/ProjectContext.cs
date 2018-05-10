using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota2ItemEditor
{
    public class ProjectContext
    {
        public List<Item> items;

        public ProjectContext()
        {
            items = new List<Item>();
        }
    }

    public class Item
    {
        private List<IField> _fields;

        public Item()
        {
            _fields = new List<IField>();
        }
        public Item(string name)
            : this()
        {
            Name = name;
        }

        public string Name { get; set; }
    }
    public interface IField
    {
        string Key { get; set; }
    }
    public class Map : IField
    {
        private List<IField> _fields;

        public Map()
        {
            _fields = new List<IField>();
        }
        public Map(string key)
            : this()
        {
            Key = key;
        }

        public string Key { get; set; }
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
