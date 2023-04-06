using Firebase.Auth;
using Firebase.Storage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.FirebaseCloudApi
{
    public class FirebaseAPI
    {
        private readonly IHostingEnvironment hostEnvironment;

        // Fields of Firebase
        private static string WebApiKey = "AIzaSyCFNbwSpqcUh86iMDxz__PoR0SLhy_4XEo";
        private static string Bucket = "itijumia.appspot.com";
        private static string AuthEmail = "testinguploadimage@gmail.com";
        private static string AuthPassword = "ITI@12345";

        public FirebaseAPI(IHostingEnvironment _hostEnvironment) => hostEnvironment = _hostEnvironment;

        #region Upload File on Firebas API Cloud Storage
        public async Task<string> UploadFileonFirebase(IFormFile imgfile,string FolderName)
        {
            // Upload File to Firebase
            FileStream stream = null!;
            if (imgfile != null && imgfile.Length > 0)
            {
                string folderName = "FireBaseProduct";
                string path = Path.Combine(hostEnvironment.WebRootPath, $"{FolderName}/{folderName}");
                string imageExtension = Path.GetExtension(imgfile.FileName);
                if (imageExtension == ".jpg" || imageExtension == ".png" || imageExtension == ".tiff" || imageExtension == ".jpeg" || imageExtension == ".gif")
                {
                    if (Directory.Exists(path))
                    {
                        using (stream = new FileStream(Path.Combine(path, imgfile.FileName), FileMode.Create))
                        {
                            await imgfile.CopyToAsync(stream);
                        }
                        stream = new FileStream(Path.Combine(path, imgfile.FileName), FileMode.Open);

                    }
                    else
                    {
                        Directory.CreateDirectory(path);
                        // stream = new FileStream(Path.Combine(path, imgfile.FileName), FileMode.Create);
                    }


                    // Firebase Uploading Stuffs
                    var auth = new FirebaseAuthProvider(new FirebaseConfig(WebApiKey));
                    var a = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);


                    // you can use CancellationTokenSource to cancel the upload midway
                    var cancellation = new CancellationTokenSource();
                    try
                    {
                        if (stream != null)
                        {
                            var task = new FirebaseStorage(
                            Bucket,
                            new FirebaseStorageOptions
                            {
                                AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                                ThrowOnCancel = true // when you cancel the upload, exception is thrown. By default no exception is thrown
                            })
                            .Child("assets")
                            .Child($"{FolderName}")
                            .Child($"{imgfile.FileName}")
                            .PutAsync(stream, cancellation.Token);

                            task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");


                            var URL = await task;
                            return URL;
                        }



                    }
                    catch (Exception ex)
                    {
                        return $"Exception was thrown: {ex}";
                    }

                }
            }

            return "Error on Uploading on Firebase";
        }

        
        #endregion

    }
}
