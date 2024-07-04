using AdoptionAgency.Backend.Domain.Model.Common;
using AdoptionAgency.Backend.Domain.Model.Post;
using AdoptionAgency.Backend.Domain.Model.User;
using AdoptionAgency.Backend.Services.PostServices;
using AdoptionAgency.Frontend.ViewModel.PostViewModels.EntityViewModels;
using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace AdoptionAgency.Frontend.ViewModel.PostViewModels.PageViewModels
{
    public class AddPostViewModel
    {
        public PostViewModel Post { get; set; }

        public AddPostViewModel()
        {
            Post = new();            
        }

        public void AttachPicture()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png",
                Multiselect = true
            };

            bool? result = openFileDialog.ShowDialog();

            if (result == false) return;
            
            string[] selectedFiles = openFileDialog.FileNames;
            string imagesDirectory = GetImagesDirectory();
            int existingImagesCount = GetExistingImagesCount(imagesDirectory);

            foreach (string file in selectedFiles)
            {
                try
                {
                    string targetFilePath = SavePicture(file, imagesDirectory, existingImagesCount);
                    AddPictureToPost(targetFilePath);
                    existingImagesCount++;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving picture: {ex.Message}");
                }
            }
        }

        private string GetImagesDirectory()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..", "Frontend", "Assets", "Images");
        }

        private int GetExistingImagesCount(string imagesDirectory)
        {
            return Directory.GetFiles(imagesDirectory).Length;
        }

        private string SavePicture(string sourceFilePath, string imagesDirectory, int index)
        {
            string targetFileName = $"image_{index}{Path.GetExtension(sourceFilePath)}";
            string targetFilePath = Path.Combine(imagesDirectory, targetFileName);
            File.Copy(sourceFilePath, targetFilePath, true);
            return targetFilePath;
        }

        private void AddPictureToPost(string filePath)
        {
            Post.Pictures.Add(new Picture(filePath));
        }

        public bool PublishPost()
        {
            var postService = new PostService();

            Post.Person = App.LoggedIn;

            if (Post.Description == null || Post.Pictures.Count == 0)
            {
                MessageBox.Show("You must enter a description and at least one image.");
                return false;
            }

            if (Post.Person.User.Type == UserType.Volunteer)
            {
                MessageBox.Show("Post successfully published");
                Post.Status = Status.Accepted;
            }
            else
            {
                Post.Status = Status.Pending;
                MessageBox.Show("Post request sent. Please wait for a volunteer to approve.");
            }
            
            postService.Add(Post.ToPost());
            return true;
        }
    }   
}
