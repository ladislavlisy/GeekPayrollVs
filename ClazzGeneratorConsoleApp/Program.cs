﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClazzGeneratorConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string configFolder = ConfigFilesFolder();

            ProgramModule.GenerateDefinitionForArticles(configFolder);

            ProgramModule.GenerateSourceForArticles(configFolder);

            ProgramModule.GenerateSourceForSources(configFolder);

            ProgramModule.GenerateSourceForResults(configFolder);
        }

        private static string ConfigFilesFolder()
        {
            string[] args = Environment.GetCommandLineArgs();

            string appExecutableFileNm = args[0];

            return ParentAppFolder(3, System.IO.Path.GetDirectoryName(appExecutableFileNm));
        }
        private static string ParentAppFolder(int levelsUp, string startDir)
        {
            string finalDir = startDir;
            for (int l = 0; l < levelsUp; l++)
            {
                finalDir = System.IO.Path.GetDirectoryName(finalDir);
            }
            return finalDir;
        }
    }
}
