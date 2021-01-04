using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Buildings;
using System.Linq;

namespace HuggableScarecrows
{
    public class ModEntry : Mod
    {
        public override void Entry(IModHelper helper)
        {
            helper.Events.GameLoop.DayStarted += PetAnimals;
        }

        private void PetAnimals(object sender, DayStartedEventArgs e)
        {
            foreach (Building building in Game1.getFarm().buildings)
            {
                if (Monitor.IsVerbose)
                {
                    Monitor.Log($"Checking building {building.buildingType.Value}", LogLevel.Info);
                }
                if ((building is Barn || building is Coop) && building.indoors.Value is AnimalHouse indoors && indoors.Objects.Values.Any(p => p.Name.Contains("arecrow")))
                {
                    foreach (FarmAnimal animal in indoors.animals.Values)
                    {
                        if (Monitor.IsVerbose)
                        {
                            Monitor.Log($" => Petting {animal.Name}", LogLevel.Info);
                        }
                        animal.pet(Game1.MasterPlayer);
                    }
                }
            }
        }
    }
}
