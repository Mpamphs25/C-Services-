using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;

namespace demoService
{
    public partial class Service1 : ServiceBase
    {
        
        protected override void OnSessionChange(SessionChangeDescription changeDescription)
        {
            //katagrafei thn wra pou kanei o xrhsths log on klp

            FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory +" SystemActiveTimeInformation.txt",
            FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sWriter = new StreamWriter(fs);
            sWriter.BaseStream.Seek(0, SeekOrigin.End);
            switch (changeDescription.Reason)
            {
                case SessionChangeReason.SessionLogon:
                    sWriter.WriteLine("System Log On Time: \t " + DateTime.Now);
                    break;
                case SessionChangeReason.SessionLogoff:
                    sWriter.WriteLine("System Log Off Time: \t " + DateTime.Now);
                    break;
                case SessionChangeReason.RemoteConnect:
                    sWriter.WriteLine("System Remote Connect Time: \t " + DateTime.Now);
                    break;
                case SessionChangeReason.RemoteDisconnect:
                    sWriter.WriteLine("System Shut Down: \t " + DateTime.Now);
                    break;
                case SessionChangeReason.SessionLock:
                    sWriter.WriteLine("System Locked Time: \t" + DateTime.Now);
                    break;
                case SessionChangeReason.SessionUnlock:
                    sWriter.WriteLine("System Unlocked Time: \t " + DateTime.Now);
                    break;
                default:
                    break;
            }
            sWriter.Flush();
            sWriter.Close();
        }



        public Service1()
        {
            InitializeComponent();
           
           
        }

      
       
        protected override void OnStart(string[] args)
        {
            //katagrafei pote einai anoixto
            string time = (DateTime.Now.ToLongTimeString());
            string date = (DateTime.Now.ToLongDateString());
            FileStream fs1 = new FileStream(AppDomain.CurrentDomain.BaseDirectory + " OnStart.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fs1);
            writer.Write(time);
            writer.Write(date);
            writer.Close();
            
        }

        protected override void OnStop()
        {
            //katagrafei pote stamataei to service 

            string time = (DateTime.Now.ToLongTimeString());
            string date = (DateTime.Now.ToLongDateString());
            FileStream fs1 = new FileStream(AppDomain.CurrentDomain.BaseDirectory + " OnStop.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fs1);
            writer.Write(time);
            writer.Write(date);
            writer.Close();
           
          

        }

     
        
    }
    
          

    }


