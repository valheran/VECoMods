namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;

    [RequiresSkill(typeof(BlastingSkill), 1)]   
    public partial class NitratesRecipe : Recipe
    {
        public NitratesRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<NitratesItem>(2),           
            
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PotashItem>(typeof(BlastingEfficiencySkill), 3, BlastingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<HideAshFertilizerItem>(typeof(BlastingEfficiencySkill), 2, BlastingEfficiencySkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(NitratesRecipe), Item.Get<NitratesItem>().UILink(), 2, typeof(BlastingSpeedSkill));    
            this.Initialize("Nitrates", typeof(NitratesRecipe));

            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }


    [Serialized]
    [Weight(1000)]      
               
    public partial class NitratesItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Nitrates"; } }
        public override string Description { get { return "The base component of most explosives and other compounds."; } }

    }

}