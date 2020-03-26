using Dropbox.Api;
using Dropbox.Api.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Windows;
namespace template01.Models
{
    public class DropboxUImodel
    {
        private DropboxClient DBClient;
        private ListFolderArg DBFolders;
        private string oauth2State;

        public string AppKey { get; }
        public string AppSecret { get; }
        public string AppName { get; }
        public string AuthenticationURL { get; private set; }
        public object AccessTocken { get; private set; }
        public string RedirectUri { get; private set; }

        public DropboxUImodel(string ApiKey = "epa71edcqqmt78k", string ApiSecret = "5i5mk4xig4r45mw", string ApplicationName = "democrat-axc")
        {
            try
            {
                AppKey = ApiKey;
                AppSecret = ApiSecret;
                AppName = ApplicationName;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string GenerateAccessToken()
        {
            try
            {
                    DBClient = new DropboxClient("R4z7Pu5Qq4AAAAAAAAAAIrL-4XQIt490MYhrEpBfsb4amSTPHeWnMhpIsU5d0PM6");
                return "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CreateFolder(string path)
        {
            try
            {
                //if (AccessTocken == null)
                //{
                //    throw new Exception("AccessToken not generated !");
                //}
                //if (AuthenticationURL == null)
                //{
                //    throw new Exception("AuthenticationURI not generated !");
                //}
             //   IniciarSessionDropBoxAsync();
                GenerateAccessToken();
                var folderArg = new CreateFolderArg(path,false);
                var folder = DBClient.Files.CreateFolderAsync(folderArg);
                var result = folder.Result;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool FolderExists(string path)
        {
            try
            {
                if (AccessTocken == null)
                {
                    throw new Exception("AccessToken not generated !");
                }
                if (AuthenticationURL == null)
                {
                    throw new Exception("AuthenticationURI not generated !");
                }

                var folders = DBClient.Files.ListFolderAsync(path);
                var result = folders.Result;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>  
        /// Method to delete file/folder from Dropbox  
        /// </summary>  
        /// <param name="path">path of file.folder to delete</param>  
        /// <returns></returns>  
        public bool Delete(string path)
        {
            try
            {
                if (AccessTocken == null)
                {
                    throw new Exception("AccessToken not generated !");
                }
                if (AuthenticationURL == null)
                {
                    throw new Exception("AuthenticationURI not generated !");
                }
               
                var folders = DBClient.Files.DeleteAsync(path);
                var result = folders.Result;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>  
        /// Method to upload files on Dropbox  
        /// </summary>  
        /// <param name="UploadfolderPath"> Dropbox path where we want to upload files</param>  
        /// <param name="UploadfileName"> File name to be created in Dropbox</param>  
        /// <param name="SourceFilePath"> Local file path which we want to upload</param>  
        /// <returns></returns>  
        public bool Upload(string UploadfolderPath, string UploadfileName, string SourceFilePath)
        {
            try
            {
                using (var stream = new MemoryStream(File.ReadAllBytes(SourceFilePath)))
                {
                    var response = DBClient.Files.UploadAsync(UploadfolderPath + "/" + UploadfileName, WriteMode.Overwrite.Instance, body: stream);
                    var rest = response.Result; //Added to wait for the result from Async method  
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        /// <summary>  
        /// Method to Download files from Dropbox  
        /// </summary>  
        /// <param name="DropboxFolderPath">Dropbox folder path which we want to download</param>  
        /// <param name="DropboxFileName"> Dropbox File name availalbe in DropboxFolderPath to download</param>  
        /// <param name="DownloadFolderPath"> Local folder path where we want to download file</param>  
        /// <param name="DownloadFileName">File name to download Dropbox files in local drive</param>  
        /// <returns></returns>  
        public bool Download(string DropboxFolderPath, string DropboxFileName, string DownloadFolderPath, string DownloadFileName)
        {
            try
            {
                var response = DBClient.Files.DownloadAsync(DropboxFolderPath + "/" + DropboxFileName);
                var result = response.Result.GetContentAsStreamAsync(); //Added to wait for the result from Async method  

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

  
        /// <summary>  
        /// Validation method to verify that AppKey and AppSecret is not blank.  
        /// Mendatory to complete Authentication process successfully.  
        /// </summary>  
        /// <returns></returns>  
        public bool CanAuthenticate()
        {
            try
            {
                if (AppKey == null)
                {
                    throw new ArgumentNullException("AppKey");
                }
                if (AppSecret == null)
                {
                    throw new ArgumentNullException("AppSecret");
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public string GeneratedAuthenticationURL()
        {
            try
            {
                this.oauth2State = Guid.NewGuid().ToString("N");
                Uri authorizeUri = DropboxOAuth2Helper.GetAuthorizeUri(OAuthResponseType.Token, AppKey, RedirectUri, state: oauth2State);
                AuthenticationURL = authorizeUri.AbsoluteUri.ToString();
                return authorizeUri.AbsoluteUri.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }
        static void Main(string[] args)
        {
            var task = Task.Run((Func<Task>)DropboxUImodel.Run);
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
        public void IninicarSessionSinc()
        {
            using (var dbx = new DropboxClient("R4z7Pu5Qq4AAAAAAAAAAIrL-4XQIt490MYhrEpBfsb4amSTPHeWnMhpIsU5d0PM6"))
            {
                var full = dbx.Users.GetCurrentAccountAsync();
                //   Console.WriteLine("{0} - {1}", full.Name.DisplayName, full.Email);
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