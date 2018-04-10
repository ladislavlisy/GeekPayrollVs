using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClazzGeneratorConsoleApp.Defs
{
    public abstract class SourceBlokBase
    {
        public const string INDENT_BLOK_NONE = "";
        public const string INDENT_BLOK_ONE = "    ";
        private const string DELIMIT_BLOK_ONE = "";

        public int BlokIndent { get; protected set; }
        public int BaseIndent { get; protected set; }

        public SourceBlokBase(SourceBlokBase parent)
        {
            BaseIndent = parent.BlokIndent;
            BlokIndent = BaseIndent + 1;
        }
        public SourceBlokBase()
        {
            BaseIndent = 0;
            BlokIndent = 1;
        }

        public abstract void StartBlok(StreamWriter writer);

        public abstract void BlokBody(StreamWriter writer);

        public abstract void CloseBlok(StreamWriter writer);

        private void WriteIndent(StreamWriter writer, int blokIndent)
        {
            string emptySpace = Enumerable.Range(0, blokIndent).Aggregate(INDENT_BLOK_NONE, (f, x) => (f + INDENT_BLOK_ONE));
            writer.Write(emptySpace);
        }

        public void WriteBlokLine(StreamWriter writer, string line)
        {
            WriteIndent(writer, BlokIndent);
            writer.WriteLine(line);
        }

        public void WriteBlokLine(StreamWriter writer, string format, params object[] arg)
        {
            WriteIndent(writer, BlokIndent);
            writer.WriteLine(format, arg);
        }
        public void WriteStartLine(StreamWriter writer, string line)
        {
            WriteIndent(writer, BlokIndent);
            writer.Write(line);
        }
        public void WriteStartLine(StreamWriter writer, string format, params object[] arg)
        {
            WriteIndent(writer, BlokIndent);
            writer.Write(format, arg);
        }
        public void WriteIndentBlokLine(StreamWriter writer, int blok, string line)
        {
            WriteIndent(writer, BlokIndent + blok);
            writer.WriteLine(line);
        }
        public void WriteIndentBlokLine(StreamWriter writer, int blok, string format, params object[] arg)
        {
            WriteIndent(writer, BlokIndent + blok);
            writer.WriteLine(format, arg);
        }
        public void WriteIndentStartLine(StreamWriter writer, int blok, string line)
        {
            WriteIndent(writer, BlokIndent + blok);
            writer.Write(line);
        }
        public void WriteIndentStartLine(StreamWriter writer, int blok, string format, params object[] arg)
        {
            WriteIndent(writer, BlokIndent + blok);
            writer.Write(format, arg);
        }
        public void WriteBaseBlokLine(StreamWriter writer, string line)
        {
            WriteIndent(writer, BaseIndent);
            writer.WriteLine(line);
        }
        public void WriteBaseBlokLine(StreamWriter writer, string format, params object[] arg)
        {
            WriteIndent(writer, BaseIndent);
            writer.WriteLine(format, arg);
        }
        public void WriteBaseStartLine(StreamWriter writer, string line)
        {
            WriteIndent(writer, BaseIndent);
            writer.Write(line);
        }
        public void WriteBaseStartLine(StreamWriter writer, string format, params object[] arg)
        {
            WriteIndent(writer, BaseIndent);
            writer.Write(format, arg);
        }
        public void Write(StreamWriter writer, string line)
        {
            writer.Write(line);
        }
        public void Write(StreamWriter writer, string format, params object[] arg)
        {
            writer.Write(format, arg);
        }
        public void WriteLine(StreamWriter writer, string line)
        {
            writer.WriteLine(line);
        }
        public void WriteLine(StreamWriter writer, string format, params object[] arg)
        {
            writer.WriteLine(format, arg);
        }

        public void DelimitLine(StreamWriter writer)
        {
            writer.WriteLine(DELIMIT_BLOK_ONE);
        }
    }
}
