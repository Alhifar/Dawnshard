﻿using AutoMapper;
using DragaliaAPI.Database.Entities;
using DragaliaAPI.Models.Generated;

namespace DragaliaAPI.Models.AutoMapper;

public class QuestMapProfile : Profile
{
    public QuestMapProfile()
    {
        this.CreateMap<DbQuest, QuestList>();

        this.CreateMap<DbPlayerStoryState, QuestStoryList>()
            .ForCtorParam(
                nameof(QuestStoryList.quest_story_id),
                o => o.MapFrom(nameof(DbPlayerStoryState.StoryId))
            );

        this.SourceMemberNamingConvention = new PascalCaseNamingConvention();
        this.DestinationMemberNamingConvention = new LowerUnderscoreNamingConvention();
    }
}