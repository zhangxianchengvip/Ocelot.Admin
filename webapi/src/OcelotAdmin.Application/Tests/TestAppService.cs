﻿using OcelotAdmin.Tests.Cmds;
using OcelotAdmin.Tests.Specifications;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace OcelotAdmin.Tests;
public class TestAppService : ApplicationService, ITestAppService
{
    private readonly TestManager _manager;
    private readonly IRepository<Test, Guid> _repository;

    public TestAppService(TestManager manager, IRepository<Test, Guid> repository)
    {
        _manager = manager;
        _repository = repository;
    }
    [HttpPost]
    public async Task<TestViewModel> Create(CreateDto input)
    {
        var test = await _manager.Create(input.Name);

        return ObjectMapper.Map<Test, TestViewModel>(test);
    }
    [HttpPut]
    public async Task<TestViewModel> UpdteAge(UpdateAgeDto input)
    {
        var test = await _manager.SetAge(input.Id, input.Age);

        return ObjectMapper.Map<Test, TestViewModel>(test);
    }

    [HttpGet]
    public async Task<TestViewModel> Get(Guid id)
    {
        var test = await _repository.FirstAsync(new TestIdEqualSpec(id));

        return ObjectMapper.Map<Test, TestViewModel>(test);
    }
}
