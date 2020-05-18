using System;
using System.Threading.Tasks;

namespace Dropbox.Api.Acciones
{
    public class AccionesApi
    {

        static void Main(string[] args)
        {
            var task = Task.Run((Func<Task>)AccionesApi.Run);
            task.Wait();
        }

        static async Task Run()
        {
            using (var dbx = new DropboxClient("R4z7Pu5Qq4AAAAAAAAAAIrL-4XQIt490MYhrEpBfsb4amSTPHeWnMhpIsU5d0PM6"))
            {
                var full = await dbx.Users.GetCurrentAccountAsync();
                Console.WriteLine("{0} - {1}", full.Name.DisplayName, full.Email);
            }
        }

        public async void IniciarSessionDropBoxAsync()
        {
            try
            {
                await Run();
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                throw;
            }
        }
        public void IniciarSessionDropBox()
        {
            IniciarSessionDropBoxAsync();
        }

    }
}
