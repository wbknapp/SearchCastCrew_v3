using SearchCastCrew.Data.Models;
using SearchCastCrew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchCastCrew.Adapters
{
    public interface IUserAdapter
    {
        /***********************************************/
        /*      USER FUNCTIONS        1.1             */
        /***********************************************/
        // Get all users
        List<UserVm> GetAllUsers(int num);

        // Get the count of all users
        int GetAllUserCount();
        //Get all user Addresses
        List<UserVm> GetAllUsersAddresses();
        // Get a single user
        //talk with team about the connections
        UserProfileVm GetUser(string uid);

        // Return the user to be deleted
        UserToDeleteVm UserToDelete(string uid);

        // Delete the user if confirmed
        void DeleteUser(string uid);

        // Return the user to be edited
        UserEditVm UserToEdit(string uid);

        // Edit the user
        void SaveChangesToUser(UserEditVm user);

        /***********************************************/
        /*      VIDEO FUNCTIONS                        */
        /***********************************************/
        // Add a new video
        void AddVideo(VideoAddVm nVm);

        // Return the video to be deleted
        VideoToDeleteVm VideoToDelete(int vid);

        // Delete a video
        void DeleteVideo(int VideoId);

        /***********************************************/
        /*      IMAGE FUNCTIONS                        */
        /***********************************************/
        // Add an image
        void AddImage(ImageAddVm iVm);

        // Return the video to be deleted
        ImageToDeleteVm ImageToDelete(int imgId);
        
        // Delete an image
        void DeleteImage(ImageToDeleteVm ivm);

        // Return the image to edit
        ImageProfileVm ImageToEdit(int imgId);

        // Setting Profile Pic
        void SetProfilePicture(ImageProfileVm ipVm);

        /***********************************************/
        /*      EXPERIENCE FUNCTIONS                   */
        /***********************************************/
        // Add an Experience entry
        void AddExperience(ExperienceAddVm eVm);

        // Return the Experience entry to be edited
        ExperienceEditVm ExperienceToEdit(int eid);

        // Save the Experience entry edits
        void SaveChangesToExperience(ExperienceEditVm eVm);

        // Return the Experience entry to be deleted
        ExperienceToDeleteVm ExperienceToDelete(int eid);

        // Delete an Experience entry
        void DeleteExperience(int eid);

        /***********************************************/
        /*      LINK FUNCTIONS                         */
        /***********************************************/
        // Add a Link
        void AddLink(LinkAddVm lVm);

        // Return the Link entry to be deleted
        LinkToDeleteVm LinkToDelete(int lid);

        // Delete a Link
        void DeleteLink(int lid);

        /***********************************************/
        /*      SEARCH FUNCTIONS                       */
        /***********************************************/
        SearchFilterVm FilteredUsers(SearchFilterVm svm);
     ///   List<UserVm> GetAllUsers();
    }
}
