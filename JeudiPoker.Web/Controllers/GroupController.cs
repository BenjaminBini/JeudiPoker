using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using JeudiPoker.Model.Models;
using JeudiPoker.Service;
using Microsoft.AspNet.Identity;

namespace JeudiPoker.Web.Controllers
{
    [Authorize]
    [RoutePrefix("api/group")]
    public class GroupController : ApiController
    {
        private readonly IGroupService _groupService;
        private readonly IUserService _userService;

        public GroupController(IGroupService groupService, IUserService userService)
        {
            _groupService = groupService;
            _userService = userService;
        }

        [Route("")]
        public IHttpActionResult GetGroups()
        {
            return Ok(_groupService.Get());
        }

        // GET /api/group/1
        [Route("{id:int}")]
        public IHttpActionResult GetGroup(int id)
        {
            var group = _groupService.Get(g => g.Id == id);

            if (group == null)
                return NotFound();

            return Ok(group);
        }

        // POST /api/group
        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateGroup(Group group)
        {
            group.CreatorId = RequestContext.Principal.Identity.GetUserId();

            var user = _userService.GetOne(u => u.Id == group.CreatorId);
            group.Players = new List<ApplicationUser> { user };

            if (!ModelState.IsValid)
                return BadRequest();

            group.Id = 0;
            _groupService.Create(group);
            _groupService.Commit();

            return Created(new Uri(Request.RequestUri + "/" + group.Id), group);
        }

        // PUT /api/group/1
        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult UpdateGroup(int id, Group group)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var groupInDb = _groupService.GetOne(g => g.Id == id);
            if (groupInDb == null)
                return NotFound();

            var principal = RequestContext.Principal;
            if (groupInDb.CreatorId != principal.Identity.GetUserId())
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }

            groupInDb.Name = group.Name;

            _groupService.Commit();

            return Ok(group);
        }

        // POST /api/group/1/users
        [HttpPost]
        [Route("{groupId}/users")]
        public IHttpActionResult AddUserToGroup(int groupId, string userId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var groupInDb = _groupService.GetOne(g => g.Id == groupId, g => g.Players);
            if (groupInDb == null)
            {
                return Content(HttpStatusCode.NotFound, "Group does not exist");
            }

            var principal = RequestContext.Principal;
            if (groupInDb.CreatorId != principal.Identity.GetUserId())
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }

            if (groupInDb.Players.Any(p => p.Id == userId))
            {
                return Content(HttpStatusCode.Conflict, "User already in group");
            }

            var user = _userService.GetOne(u => u.Id == userId);
            if (user == null)
            {
                return Content(HttpStatusCode.NotFound, "User does not exist");
            }
            groupInDb.Players.Add(user);

            _groupService.Commit();

            return Ok(groupInDb);
        }

        // DELETE /api/group/1
        [HttpDelete]
        public IHttpActionResult DeleteGroup(int id)
        {
            var groupInDb = _groupService.GetOne(g => g.Id == id);
            if (groupInDb == null)
                return NotFound();

            var principal = RequestContext.Principal;
            if (groupInDb.CreatorId != principal.Identity.GetUserId())
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }

            _groupService.Delete(groupInDb);
            _groupService.Commit();

            return Ok();
        }
    }
}