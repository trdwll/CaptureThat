/*
 * Copyright (c) 2016-2019 Russ 'trdwll' Treadwell. All rights reserved.
 * Licensed under the MIT License. See LICENSE.md file in the project root for full license information.
 */
using apollo.Core;

namespace CaptureThat
{
    public class Uploader
    {
        // Used to help determine if the image has been uploaded
        private static bool hasUploadedSuccessfully = false;

        /// <summary>
        /// Imgur Uploader Class
        /// </summary>
        public class ImgurUploader
        {
            // Store the Imgur url
            private static string ImgurUrl = "";

            /// <summary>
            /// Imgur class (JSON)
            /// </summary>
            private class Imgur
            {
                public Imgurdata data { get; set; }
                public bool success { get; set; }
                public int status { get; set; }
            }

            /// <summary>
            /// Imgur class (JSON)
            /// </summary>
            private class Imgurdata
            {
                public string id { get; set; }
            }

            /// <summary>
            /// Upload the image to Imgur as a base64 string
            /// </summary>
            /// <param name="Base64Image"></param>
            public static void Upload(string Base64Image)
            {
                // Set to false before every upload
                hasUploadedSuccessfully = false;

                // Send a POST request to Imgur API
                Net.Response res = Net.POST("https://api.imgur.com/3/upload.json", new System.Collections.Generic.Dictionary<string, string>
                {
                    {
                        "image",
                        Base64Image
                    }
                },
                new System.Collections.Generic.Dictionary<string, string>
                {
                    {
                        "Authorization",
                        $"Client-ID {Config.conf.ImgurAPI}"
                    }
                });

                // Deserialize the result from Imgur
                Imgur imgur = Serialization.JSON.Deserialize.getFromJson<Imgur>(res.source);

                // Check if Imgur result was successful
                if (imgur.success && imgur.status == 200)
                {
                    hasUploadedSuccessfully = true; // Set to true if the image was successfully uploaded
                    ImgurUrl = $"https://i.imgur.com/{imgur.data.id}.png";  // Set the url with the result data

                    // Notify the user that the image was uploaded (if enabled)
                    Utils.Notify("Image Uploaded!", "CaptureThat has uploaded your image to Imgur successfully!", 3);

                    // Play the Success sound
                    Utils.PlaySuccess();

                    // Set the clipboard to the Imgur url
                    Utils.SetClipboard(GetImgurURL());

                    // Open the url after the screenshot uploads
                    Utils.OpenUrlAfterCapture(GetImgurURL());
                }
                else
                {
                    // Notify the user that the image wasn't uploaded (if enabled)
                    Utils.Notify("Image Upload Failed!", "CaptureThat has failed to upload your image to Imgur!", 3);

                    // Play the Error sound
                    Utils.PlayError();
                }
            }

            /// <summary>
            /// Get the string ImgurURL
            /// </summary>
            /// <returns></returns>
            public static string GetImgurURL()
            {
                return hasUploadedSuccessfully ? ImgurUrl : "";
            }
        }

        /// <summary>
        /// Gyazo Uploader Class
        /// </summary>
        public class GyazoUploader
        {
            // Store the Gyazo url
            private static string GyazoURL = "";

            /// <summary>
            /// Gyazo class (JSON)
            /// </summary>
            private class Gyazo
            {
                public string image_id { get; set; }
                public string permalink_url { get; set; }
                public string thumb_url { get; set; }
                public string url { get; set; }
                public string type { get; set; }
            }

            /// <summary>
            /// Upload the image to Gyazo
            /// </summary>
            /// <param name="image"></param>
            public static void Upload(System.Drawing.Bitmap image)
            {
                // Set to false before every upload
                hasUploadedSuccessfully = false;

                // Save a temporary image
                Utils.SaveTmpImage(image);

                // Send a POST request to Gyazo API
                Net.Response res = Net.POST("https://upload.gyazo.com/api/upload", new Net.FormFile[]
                {
                    new Net.FormFile("imagedata", Utils.getTmpImage())
                }, 
                new System.Collections.Generic.Dictionary<string, string>
                {
                    {
                        "access_token",
                        Config.conf.GyazoAPI
                    }
                }, null);

                // Delete the temporary image
                Utils.DeleteTmpImage();

                // Deserialize the result from Gyazo
                Gyazo gyazo = Serialization.JSON.Deserialize.getFromJson<Gyazo>(res.source);

                // Check if Gyazo result was successful
                if (!IO.isEmpty(gyazo.image_id))
                {
                    hasUploadedSuccessfully = true; // Set to true if the image was successfully uploaded
                    GyazoURL = gyazo.permalink_url; // Set the url with the result data

                    // Notify the user that the image was uploaded (if enabled)
                    Utils.Notify("Image Uploaded!", "CaptureThat has uploaded your image to Gyazo successfully!", 3);

                    // Play the Success sound
                    Utils.PlaySuccess();

                    // Set the clipboard to the Gyazo url
                    Utils.SetClipboard(GetGyazoURL());

                    // Open the url after the screenshot uploads
                    Utils.OpenUrlAfterCapture(GetGyazoURL());
                }
                else
                {
                    // Notify the user that the image wasn't uploaded (if enabled)
                    Utils.Notify("Image Upload Failed!", "CaptureThat has failed to upload your image to Gyazo!", 3);

                    // Play the Error sound
                    Utils.PlayError();
                }
            }

            /// <summary>
            /// Get the string GyazoURL
            /// </summary>
            /// <returns></returns>
            public static string GetGyazoURL()
            {
                return hasUploadedSuccessfully ? GyazoURL : "";
            }
        }

        /// <summary>
        /// VgyMe Uploader Class
        ///  VgyMe support by Jack Taylor <OhYea777>
        /// </summary>
        public class VgyMeUploader
        {
            // Store the VgyMe url
            private static string VgyMeUrl = "";

            /// <summary>
            /// VgyMe class (JSON)
            /// </summary>
            private class VgyMe
            {
                public bool Error { get; set; }
                public string URL { get; set; }
                public string Image { get; set; }
                public long Size { get; set; }
                public string Filename { get; set; }
                public string Ext { get; set; }
                public string Delete { get; set; }
            }

            /// <summary>
            /// Upload the image to VgyMe
            /// </summary>
            /// <param name="image"></param>
            public static void Upload(System.Drawing.Bitmap image)
            {
                // Set to false before every upload
                hasUploadedSuccessfully = false;

                // Save a temporary image
                Utils.SaveTmpImage(image);

                // Send a POST request to VgyMe
                Net.Response res = Net.POST("https://vgy.me/upload", new Net.FormFile[]
                {
                    new Net.FormFile("file[]", Utils.getTmpImage(), "image/png")
                }, null, null);

                // Delete the temporary image
                Utils.DeleteTmpImage();

                // Deserialize the result from VgyMe
                VgyMe vgyme = Serialization.JSON.Deserialize.getFromJson<VgyMe>(res.source);

                // Check if VgyMe result was successful
                if (!vgyme.Error)
                {
                    hasUploadedSuccessfully = true; // Set to true if the image was successfully uploaded
                    VgyMeUrl = vgyme.URL; // Set the url with the result data

                    // Notify the user that the image was uploaded (if enabled)
                    Utils.Notify("Image Uploaded!", "CaptureThat has uploaded your image to Vgy.me successfully!", 3);

                    // Play the Success sound
                    Utils.PlaySuccess();

                    // Check if you want to save the delete url to a file (to allow deletion of the image later)
                    if (Config.conf.SaveDeletionUrl)
                    {
                        string content = $"URL: {vgyme.URL}\nDelete URL: {vgyme.Delete}\nTime Uploaded: {System.DateTime.Now}\n"; // Create the string to save
                        System.IO.File.AppendAllText($@"{System.Windows.Forms.Application.StartupPath}\urllist.txt", content); // Append the string to the file
                    }

                    // Set the clipboard to the VgyMe url
                    Utils.SetClipboard(GetVgyMeURL());

                    // Open the url after the screenshot uploads
                    Utils.OpenUrlAfterCapture(GetVgyMeURL());
                }
                else
                {
                    // Notify the user that the image wasn't uploaded (if enabled)
                    Utils.Notify("Image Upload Failed!", "CaptureThat has failed to upload your image to Vgy.me!", 3);

                    // Play the Error sound
                    Utils.PlayError();
                }
            }

            /// <summary>
            /// Get the string VgyMeUrl
            /// </summary>
            /// <returns></returns>
            public static string GetVgyMeURL()
            {
                return hasUploadedSuccessfully ? VgyMeUrl : "";
            }
        }

        /// <summary>
        /// Upload the image to the specified host
        /// </summary>
        /// <param name="img"></param>
        public static void Upload(System.Drawing.Bitmap img)
        {
            switch (Config.conf.Uploader.ToLower())
            {
                default:
                case "imgur":
                    ImgurUploader.Upload(Image.bitmapToBase64(img));
                    break;
                case "vgyme":
                    VgyMeUploader.Upload(img);
                    break;
                case "gyazo":
                    GyazoUploader.Upload(img);
                    break;
            }
        }
    }
}


