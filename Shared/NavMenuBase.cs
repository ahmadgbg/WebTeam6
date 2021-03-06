﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using WebTeam6.Data;
using WebTeam6.Services;

namespace WebTeam6.Shared
{
    public class NavMenuBase: ComponentBase
    {
        [Inject]
        public IGroupService GroupService { get; set; }

        [Inject]
        public IUserService UserService {get; set;}

        [CascadingParameter]
        public Task<AuthenticationState> authenticationStateTask { get; set; }
        public List<Group> UserGroupList { get; set; }
        public Group GroupObject { get; set; } = new Group();
        //[Inject]
        //public IGroupService GroupService { get; set; }
        //[CascadingParameter]
        //Task<AuthenticationState> authenticationStateTask { get; set; }
        //public List<Group> UserGroupList { get; set; }
        //public Group groupObject = new Group();

        protected bool collapseNavMenu = true;

        protected string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        protected void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }

  public User User { get; set; }

    protected async override Task OnInitializedAsync()
    {
        User = await UserService.GetAuthorizedUser(authenticationStateTask);
    }
        //protected override async Task OnInitializedAsync()
        //{
        //    UserGroupList = await GroupService.GetGetAuthorizedUserGroups(authenticationStateTask);
        //}

        //protected async void DataChanged()
        //{
        //    UserGroupList = await GroupService.GetGetAuthorizedUserGroups(authenticationStateTask);
        //    StateHasChanged();
        //}
        //protected void InitializeGroupObject()
        //{
        //    groupObject = new Group();
        //}
    }
}
