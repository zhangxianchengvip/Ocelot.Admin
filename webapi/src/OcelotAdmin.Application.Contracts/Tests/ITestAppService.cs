using OcelotAdmin.Tests.Cmds;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace OcelotAdmin.Tests;
public interface ITestAppService:IApplicationService
{
    Task<TestViewModel> Create(CreateDto input);
    Task<TestViewModel> UpdteAge(UpdateAgeDto input);
}
