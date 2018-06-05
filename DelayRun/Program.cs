using System;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace DelayRun
{
	class Program
	{
		static void Main(string[] args)
		{
			// The minimum number of argument is two.
			if (args.Length < 2)
			{
				ShowHelp();
				return;
			}

			int delaySeconds = 0;

			try
			{
				delaySeconds = Convert.ToInt32(args[0]);
			}
			catch
			{
				Console.WriteLine("Please specify an integer number of seconds.");
				ShowHelp();
				return;
			}

			string command = args[1];
			string workingDir = "";
			string arguments = "";

			if (args.Length > 2)
			{
				workingDir = args[2];
				if (args.Length > 3)
				{
					for (int argNum = 3; argNum < args.Length; argNum++)
					{
						arguments += args[argNum] + " ";
					}
				}
			}

			Thread.Sleep(delaySeconds * 1000);
			Process p = new Process();
			p.StartInfo.FileName = command;
			p.StartInfo.WorkingDirectory = workingDir;
			p.StartInfo.Arguments = arguments;
			p.Start();

			return;
		}

		static void ShowHelp()
		{
			Console.WriteLine(String.Format("Usage: {0} <seconds> <command> <workingDir> <arguments>", Path.GetFileName(Environment.CommandLine.Replace("\"", ""))));
			Console.WriteLine("Where: <seconds> specifies the number of seconds to pause.");
			Console.WriteLine("       <command> specifies the command to execute.");
			Console.WriteLine("       <workingDir> specifies the command's working directory.");
			Console.WriteLine("       <arguments> specifies arguments to be passed to the command.");
		}
	}
}
