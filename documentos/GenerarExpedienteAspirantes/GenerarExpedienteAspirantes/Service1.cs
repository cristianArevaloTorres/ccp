using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using UnificacionDocumentosPDF.Service;
using System.Timers;
using System.Runtime.InteropServices;
using System.Threading;
using GenerarExpedienteAspirantes.LogSenadoConvocatoria;

namespace GenerarExpedienteAspirantes
{
    public partial class Service1 : ServiceBase
    {
        private int eventId = 1;
        private LogConvocatorias logConvocatoria;

        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool SetServiceStatus(System.IntPtr handle, ref ServiceStatus serviceStatus);

        public enum ServiceState
        {
            SERVICE_STOPPED = 0x00000001,
            SERVICE_START_PENDING = 0x00000002,
            SERVICE_STOP_PENDING = 0x00000003,
            SERVICE_RUNNING = 0x00000004,
            SERVICE_CONTINUE_PENDING = 0x00000005,
            SERVICE_PAUSE_PENDING = 0x00000006,
            SERVICE_PAUSED = 0x00000007,
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ServiceStatus
        {
            public int dwServiceType;
            public ServiceState dwCurrentState;
            public int dwControlsAccepted;
            public int dwWin32ExitCode;
            public int dwServiceSpecificExitCode;
            public int dwCheckPoint;
            public int dwWaitHint;
        };



        public Service1()
        {
            eventLog1 = new System.Diagnostics.EventLog();

            InitializeComponent();
            eventLog1 = new EventLog();
            if (!EventLog.SourceExists("serviceInstaller1"))
            {
                EventLog.CreateEventSource("serviceInstaller1", "");
            }
            eventLog1.Source = "serviceInstaller1";
            eventLog1.Log = "";

        }

        protected override void OnStart(string[] args)
        {

            try
            {

                var trabajo = new Thread(iniciar);
                trabajo.Name = "";
                trabajo.IsBackground = false;
                trabajo.Start();

            }
            catch (Exception ex)
            {
                logConvocatoria = new LogConvocatorias(777, "Service1", "OnStart", "ERROR: " + ex.GetBaseException().Message, "");
            }

        }


        public void iniciar()
        {
            UnificarDocumentos unificarDocumentos = new UnificarDocumentos();
            int nmilisegundo = 120000;
            try
            {
                while (true)
                {
                    Thread.Sleep(nmilisegundo);
                    logConvocatoria = new LogConvocatorias(777, "UnificarDocumentos", "OnTimer", "OnTimer_01", "");
                    unificarDocumentos.generacionDocumentoPDF();

                    logConvocatoria = new LogConvocatorias(777, "UnificarDocumentos", "OnTimer", "OnTimer_02", "");
                }

            }
            catch (Exception ex)
            {
                logConvocatoria = new LogConvocatorias(777, "Service1", "OnTimer_01", "ERROR: " + ex.GetBaseException().Message, "");
            }
            finally
            {
                Thread.Sleep(nmilisegundo);
            }
        }
    

        protected override void OnStop()
        {            
        }


    }
}
