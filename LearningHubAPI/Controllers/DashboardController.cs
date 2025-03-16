using System.Security.Claims;
using LearningHub.Core.Dto;
using LearningHub.Core.Repository;
using LearningHub.Core.Services;
using LearningHubAPI.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningHubAPI.Controllers;

[ApiController]
[Route("api/event-manager/admin-dashboard")]
public class DashboardController:ControllerBase
{
    
    private readonly IAuthRepo _authRepo;
    private readonly IDashboardService _dashboardService;

    public DashboardController(IAuthRepo authRepo,IDashboardService dashboardService)
    {
        _authRepo = authRepo;
        _dashboardService = dashboardService;

        
    }
    [HttpGet("AllRegisteredUsers")]
    [Authorize]
    [IdentityRequiresClaims(ClaimTypes.Role,new[]{"1"})]
    public async Task<IActionResult> AllRegisteredUsers()
    {
        var users = await _authRepo.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpGet("All-Roles")]
    [Authorize]
    [IdentityRequiresClaims(ClaimTypes.Role,new[]{"1"})]
    public async Task<IActionResult> GetAllRoles()
    {
        return Ok(await _dashboardService.GetRoles());
    }

    [HttpPut("UpdateUser/{userId}")]
    [Authorize]
    [IdentityRequiresClaims(ClaimTypes.Role, new[] { "1" })]
    public async Task<IActionResult> UpdateUser([FromRoute] decimal userId ,[FromBody] UpdateUserProfileDto dto)
    {
        if (!await _authRepo.UserExistsAsync(userId))
        {
            return NotFound("User not found");
        }
        if (! await _dashboardService.UpdateUserAsync(userId, dto))
        {
            return  BadRequest("Failed to update user");
        }
        return Ok("user updated successfully");

        
    }
    
   
}