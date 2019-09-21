using Mystat.Domain.Data;
using Mystat.DataAccess.HTTPServer;
using Mystat.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace Mystat
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static HttpClient client = new HttpClient();
        public static Student CurrentStudent;
        public static IUnitOfWork db;
        public static string ip;
        public static string Port;

        public App()
        {
            db = new HTTPUnitOfWork();
            ip = "10.2.11.56";
            Port = "27000";
            CurrentStudent = db.StudentRepository.GetStudentById(1);
        }
    }
}
