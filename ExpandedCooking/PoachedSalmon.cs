namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using System.Linq;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Mods.TechTree;
    using Eco.Shared.Items;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    [Serialized]
    [Weight(500)]                                          
    public partial class PoachedSalmonItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Poached Salmon"; } }
        public override string Description                      { get { return "A thick stew chock-full of fish, camas, and corn. A suprisingly good combination."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 6, Fat = 5, Protein = 13, Vitamins = 8};
        public override float Calories                          { get { return 1080; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }
    [RequiresSkill(typeof(CampfireCreationsSkill), 4)] 
    public class PoachedSalmonRecipe : Recipe
    {
        public PoachedSalmonRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<PoachedSalmonItem>(1),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<FishScrapsItem>(typeof(CampfireCreationsEfficiencySkill), 30, CampfireCreationsEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<CamasBulbItem>(typeof(CampfireCreationsEfficiencySkill), 10, CampfireCreationsEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<CornItem>(typeof(CampfireCreationsEfficiencySkill), 10, CampfireCreationsEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<FiddleheadsItem>(typeof(CampfireCreationsEfficiencySkill), 40, CampfireCreationsEfficiencySkill.MultiplicativeStrategy),
            };
            this.Initialize("Poached Salmon", typeof(PoachedSalmonRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(PoachedSalmonRecipe), this.UILink(), 9, typeof(CampfireCreationsSpeedSkill));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}