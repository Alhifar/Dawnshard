﻿using DragaliaAPI.Shared.Definitions.Enums;

namespace DragaliaAPI.Shared.MasterAsset.Models.Trade;

public record AbilityCrestTrade(
    int Id,
    AbilityCrestId AbilityCrestId,
    int NeedDewPoint,
    int Priority,
    DateTimeOffset CompleteDate,
    DateTimeOffset PickupViewStartDate,
    DateTimeOffset PickupViewEndDate
);
