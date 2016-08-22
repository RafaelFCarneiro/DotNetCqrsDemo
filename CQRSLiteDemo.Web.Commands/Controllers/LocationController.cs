﻿using AutoMapper;
using CQRSlite.Commands;
using CQRSLiteDemo.Domain.Commands;
using CQRSLiteDemo.Domain.ReadModel.Repositories.Interfaces;
using CQRSLiteDemo.Web.Commands.Requests.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CQRSLiteDemo.Web.Commands.Controllers
{
    [RoutePrefix("locations")]
    public class LocationController : ApiController
    {
        private IMapper _mapper;
        private ICommandSender _commandSender;
        private ILocationRepository _locationRepo;

        public LocationController(ICommandSender commandSender, IMapper mapper, ILocationRepository locationRepo)
        {
            _commandSender = commandSender;
            _mapper = mapper;
            _locationRepo = locationRepo;
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult Create(CreateLocationRequest request)
        {
            var command = _mapper.Map<CreateLocationCommand>(request);
            _commandSender.Send(command);
            return Ok();
        }

        [HttpPost]
        [Route("assignemployee")]
        public IHttpActionResult AssignEmployee(AssignEmployeeToLocationRequest request)
        {
            var command = _mapper.Map<AssignEmployeeToLocationCommand>(request);

            command.Id = _locationRepo.GetByID(request.LocationID).AggregateID;

            _commandSender.Send(command);
            return Ok();
        }
    }
}
