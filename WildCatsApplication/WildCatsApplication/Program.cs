using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WildCatsApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string content;
            string rootPath = AppDomain.CurrentDomain.BaseDirectory;

            try
            {
                DirectoryInfo sourceDirectory = InitializeSourceDirectory(rootPath);
                string htmlOutputFilePath = Path.Combine(rootPath, "WildCats.html");

                FileInfo[] textFiles = sourceDirectory.GetFiles("*.txt");

                using(StreamWriter htmlFile =  new(htmlOutputFilePath))
                {
                    AddTopHtml(htmlFile);

                    foreach (FileInfo textFile in textFiles)
                    {
                        using (StreamReader sr = new(textFile.OpenRead()))
                        {
                            content = sr.ReadToEnd();
                        }
                        BuildHtmlBody(htmlFile, content, Path.GetFileNameWithoutExtension(textFile.FullName));
                    }
                    AddBottomHtml(htmlFile);
                }
                LaunchHtmlFileInBrowser(htmlOutputFilePath);
            }
            catch(UnauthorizedAccessException ex)
            {
                LogExceptionMessageToScreen(ex);
            }
            catch (DirectoryNotFoundException ex)
            {
                LogExceptionMessageToScreen(ex);
            }
            catch (FileNotFoundException ex)
            {
                LogExceptionMessageToScreen(ex);
            }
            catch (IOException ex)
            {
                LogExceptionMessageToScreen(ex);
            }
            catch (NotImplementedException ex)
            {
                LogExceptionMessageToScreen(ex);
            }
        }

        private static void LogExceptionMessageToScreen(Exception ex)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(ex.Message);
            Console.ResetColor();
        }

        private static void AddTopHtml(StreamWriter sw)
        {
            sw.WriteLine("<!doctype html>");
            sw.WriteLine(@"<html lang = ""en"">");
            sw.WriteLine("<head>");
            sw.WriteLine(@"<meta charset = ""utf-8"">");
            sw.WriteLine(@"<meta name = ""viewport"" content = ""width=device-width,intial-scale=1"">");
            sw.WriteLine("<title>Wild Cats</title>");
            sw.WriteLine(@"<link rel = ""stylesheet"" href = ""https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css"" >");
            sw.WriteLine(@"<script src = ""https://code.jquery.com/jquery-1.12.4.js""></script>");
            sw.WriteLine(@"<script src = ""https://code.jquery.com/ui/1.12.1/jquery-ui.js""></script>");

            sw.WriteLine("<script>");
            sw.WriteLine("$(function(){");
            sw.WriteLine(@"$(""#accordion"").accordion();");
            sw.WriteLine("});");
            sw.WriteLine("</script>");
            sw.WriteLine("</head>");
            sw.WriteLine("<body>");

            sw.WriteLine(@"<h1 style=""text-align:center;font-family:arial"">Wild Cats</h1> ");
            sw.WriteLine(@"<div id = ""accordion"">");
        }
        private static void BuildHtmlBody(StreamWriter sw, string topicContent, string topicHeading)
        {
            sw.WriteLine($"<h3>{topicHeading}</h3>");
            sw.WriteLine("<div>");
            sw.WriteLine("<p>");
            sw.Write(topicContent);
            sw.WriteLine("</p>");
            sw.WriteLine("</div>");

        }
        private static void AddBottomHtml(StreamWriter sw)
        {
            sw.WriteLine("</div>");
            sw.WriteLine("</body>");
            sw.WriteLine("</html>");
        }

        private static void LaunchHtmlFileInBrowser(string url)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                url = url.Replace("&", "^&");
                Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Process.Start("xdg-open", url);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Process.Start("open", url);
            }
            else
            {
                throw new NotImplementedException("Unable to launch your default browser through this application.");
            }
        }

        private static DirectoryInfo InitializeSourceDirectory(string rootPath)
        {
            int numFilesInDirectory;

            string wildCatsDirectoryPath = Path.Combine(rootPath, "WildCats");

            string infoFilePath = Path.Combine(wildCatsDirectoryPath, "Information.txt");

            if(!Directory.Exists(wildCatsDirectoryPath))
            {
                Directory.CreateDirectory(wildCatsDirectoryPath);
            }
            
            DirectoryInfo sourceDirectory = new(wildCatsDirectoryPath);

            numFilesInDirectory = sourceDirectory.GetFiles("*.txt").Length;

            if(numFilesInDirectory == 0)
            {
                using(StreamWriter sw = File.CreateText(infoFilePath))
                {
                    sw.WriteLine($"Text files have not yet been added to this directory, {wildCatsDirectoryPath}");
                }
            }
            else if(numFilesInDirectory >= 1 && File.Exists(infoFilePath))
            {
                File.Delete(infoFilePath);
            }

            return sourceDirectory;
        }
    }
}