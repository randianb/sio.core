using Microsoft.EntityFrameworkCore.Storage;
using Sio.Cms.Lib.Models.Account;
using Sio.Cms.Lib.Models.Cms;
using Sio.Cms.Lib.Repositories;
using Sio.Cms.Lib.Services;
using Sio.Common.Helper;
using Sio.Domain.Data.ViewModels;
using Newtonsoft.Json;
using Sio.Cms.Lib.ViewModels.Account;
using System;
using System.Collections.Generic;

namespace Sio.Cms.Lib.ViewModels.Account
{
    public class UserInfoViewModel
        : ViewModelBase<SioCmsContext, SioCmsUser, UserInfoViewModel>
    {
        #region Properties
        //[JsonProperty("id")]

        #region Models

        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("middleName")]
        public string MiddleName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("avatar")]
        public string Avatar { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }
        [JsonProperty("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }
        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        #endregion

        #region Views

        [JsonProperty("detailsUrl")]
        public string DetailsUrl { get; set; }

        [JsonProperty("userRoles")]
        public List<UserRoleViewModel> UserRoles { get; set; } = new List<UserRoleViewModel>();


        [JsonProperty("domain")]
        public string Domain { get { return SioService.GetConfig<string>("Domain"); } }

        [JsonProperty("avatarUrl")]
        public string AvatarUrl
        {
            get
            {
                if (Avatar != null && (Avatar.IndexOf("http") == -1 && Avatar[0] != '/'))
                {
                    return CommonHelper.GetFullPath(new string[] {
                    Domain,  Avatar
                });
                }
                else
                {
                    return Avatar;
                }
            }
        }
        [JsonProperty("mediaFile")]
        public FileViewModel MediaFile { get; set; } = new FileViewModel();
        #endregion

        #endregion

        #region Contructors

        public UserInfoViewModel() : base()
        {
        }

        public UserInfoViewModel(SioCmsUser model, SioCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        #endregion

        #region Overrides
        public override SioCmsUser ParseModel(SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            if (MediaFile.FileStream != null)
            {
                MediaFile.FileFolder = CommonHelper.GetFullPath(new[] {
                    SioConstants.Folder.UploadFolder,
                    DateTime.UtcNow.ToString("MMM-yyyy")
                }); ;
                var isSaved = FileRepository.Instance.SaveWebFile(MediaFile);
                if (isSaved)
                {
                    Avatar = MediaFile.FullPath;
                }
                else
                {
                    IsValid = false;
                }

            }
            return base.ParseModel(_context, _transaction);
        }

        public override void ExpandView(SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            UserRoles = UserRoleViewModel.Repository.GetModelListBy(ur => ur.UserId == Id).Data;
        }

        #endregion

        #region Expands

        #endregion
    }
}
