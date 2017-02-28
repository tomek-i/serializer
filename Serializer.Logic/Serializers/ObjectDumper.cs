using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text;

namespace TI.Serializer.Logic.Serializers
{
    [ExcludeFromCodeCoverage]
    public class ObjectDumper:Serializer
    {
        StringBuilder _writer;
        int _pos;
        int _level;
        int _depth;
        
       
        public override string Serialize(object obj)
        {
           return Serialize(obj, 0);
        }

        public  string Serialize(object obj, int depth)
        {
            return Serialize(obj, depth, new StringBuilder());
        }

        public string Serialize(object obj, int depth, StringBuilder log)
        {
            _writer = log;
            _depth = depth;
            WriteObject(null, obj);
            
            return log.ToString();
        }

        //private static void WriteYAML(object o)
        //{
        //    var stringBuilder = new StringBuilder();
        //    var serializer = new Serializer();
        //    serializer.Serialize(new IndentedTextWriter(new StringWriter(stringBuilder)), o);
        //    Console.WriteLine(stringBuilder);
        //}

      

      

        private void Write(string s)
        {
            if (s != null)
            {
                _writer.Append(s);
                _pos += s.Length;
            }
        }

        private void WriteIndent()
        {
            for (int i = 0; i < _level; i++) _writer.Append("  ");
        }

        private void WriteLine()
        {
            _writer.AppendLine();
            _pos = 0;
        }

        private void WriteTab()
        {
            Write("  ");
            while (_pos % 8 != 0) Write(" ");
        }

        private void WriteObject(string prefix, object element)
        {
            if (element == null || element is ValueType || element is string)
            {
                WriteIndent();
                Write(prefix);
                WriteValue(element);
                WriteLine();
            }
            else
            {
                IEnumerable enumerableElement = element as IEnumerable;
                if (enumerableElement != null)
                {
                    foreach (object item in enumerableElement)
                    {
                        if (item is IEnumerable && !(item is string))
                        {
                            WriteIndent();
                            Write(prefix);
                            Write("...");
                            WriteLine();
                            if (_level >= _depth) continue;
                            _level++;
                            WriteObject(prefix, item);
                            _level--;
                        }
                        else
                        {
                            WriteObject(prefix, item);
                        }
                    }
                }
                else
                {
                    MemberInfo[] members = element.GetType().GetMembers(BindingFlags.Public | BindingFlags.Instance);
                    WriteIndent();
                    Write(prefix);
                    bool propWritten = false;
                    foreach (MemberInfo m in members)
                    {
                        FieldInfo f = m as FieldInfo;
                        PropertyInfo p = m as PropertyInfo;
                        if (f != null || p != null)
                        {
                            if (propWritten)
                            {
                                WriteTab();
                            }
                            else
                            {
                                propWritten = true;
                            }
                            Write(m.Name);
                            Write("=");
                            Type t = f?.FieldType ?? p.PropertyType;
                            if (t.IsValueType || t == typeof(string))
                            {
                                WriteValue(f != null ? f.GetValue(element) : p.GetValue(element, null));
                            }
                            else
                            {
                                Write(typeof (IEnumerable).IsAssignableFrom(t) ? "..." : "{ }");
                            }
                        }
                    }
                    if (propWritten) WriteLine();
                    if (_level >= _depth) return;
                    foreach (MemberInfo m in members)
                    {
                        FieldInfo f = m as FieldInfo;
                        PropertyInfo p = m as PropertyInfo;
                        if (f == null && p == null) continue;
                        Type t = f?.FieldType ?? p.PropertyType;
                        if (t.IsValueType || t == typeof (string)) continue;
                        object value = f != null ? f.GetValue(element) : p.GetValue(element, null);
                        if (value == null) continue;
                        _level++;
                        WriteObject(m.Name + ": ", value);
                        _level--;
                    }
                }
            }
        }

        private void WriteValue(object o)
        {
            if (o == null)
            {
                Write("null");
            }
            else if (o is DateTime)
            {
                Write(((DateTime)o).ToShortDateString());
            }
            else if (o is ValueType || o is string)
            {
                Write(o.ToString());
            }
            else if (o is IEnumerable)
            {
                Write("...");
            }
            else
            {
                Write("{ }");
            }
        }

        #region Overrides of Serializer

        public override T Deserialize<T>(string serializedString)
        {
            throw new NotImplementedException();
        }

        public override object Deserialize(string serializedString, Type type = null)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}