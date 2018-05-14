using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Dota2ItemEditor
{
    public class FieldCollection
    {
        public FieldCollection()
        {
            Fields = new ObservableCollection<IField>();
        }

        public ObservableCollection<IField> Fields { get; }

        private void addField(string key = "")
        {
            Fields.Add(new StringField(key));
        }

        private Command _addField;
        public ICommand AddField
        {
            get
            {
                if (_addField == null)
                {
                    _addField = new Command(param => this.addField());
                }
                return _addField;
            }
        }

        private void addTableField(string key = "")
        {
            Fields.Add(new TableField(key));
        }

        private Command _addTableField;
        public ICommand AddTableField
        {
            get
            {
                if (_addTableField == null)
                {
                    _addTableField = new Command(param => this.addTableField());
                }
                return _addTableField;
            }
        }
    }
    public class Dota2Item: FieldCollection
    {
        public Dota2Item()
        {
        }
        public Dota2Item(string name)
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
    public class TableField : FieldCollection, IField
    {
        public TableField()
        {
        }
        public TableField(string key)
            : this()
        {
            Key = key;
        }

        public string Key { get; set; }
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
