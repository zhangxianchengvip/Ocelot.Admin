using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Localization;

namespace Ocelot.Admin.Entity.NameSpaces;

public class NameSpace : BasicAggregateRoot<Guid>
{
    public string NId { get; init; }
    public string Name { get; private set; }
    public string? Desc { get; private set; }
    public Guid? Creator { get; init; }
    public DateTime CreateTime { get; init; }
    public Guid? Updater { get; set; }
    public DateTime UpdateTime { get; private set; }

    private NameSpace() { }
    internal NameSpace(Guid id, string nId, string name, string desc, Guid? creator) : base(id)
    {
        NId = nId;
        SetName(name);
        SetDesc(desc);
        Creator = creator;
        CreateTime = DateTime.Now;
        SetUpdater(Creator);
    }

    internal void SetName(string name)
    {
        Name = Check.NotNullOrEmpty(name, nameof(name));
    }

    internal void SetDesc(string desc)
    {
        Desc = Check.NotNullOrEmpty(desc, nameof(desc));
    }

    internal void SetUpdater(Guid? updater)
    {
        Updater = updater;
        UpdateTime = DateTime.Now;
    }
}