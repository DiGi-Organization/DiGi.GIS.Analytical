using DiGi.Analytical.Building.Classes;
using System;

namespace DiGi.GIS.Analytical.Solar
{
    public static partial class Query
    {
        /// <summary>
        /// Derives the building model id a stored solar radiation result is keyed by, from the building model's <see cref="Core.Classes.GuidObject.Guid"/>.
        /// <para>The UI never sees the <c>building_model</c> row id: <c>gis/buildingmodel/itemsbyreferences</c> answers the bare models, and the <c>id</c> of the solar routes is the <c>building_2d</c> id, which survives a regeneration of the model. The model's Guid does not - a regenerated model is a new object with a new Guid (<c>GuidObject</c> draws <see cref="Guid.NewGuid"/>) - so a stored result of the old model becomes a miss, which is what the key is for (DiGi.GIS.WebAPI.UI#73).</para>
        /// <para>The value is the first eight bytes of the Guid read little-endian, with the sign bit cleared and 0 mapped to 1, so it is positive, as the read and write endpoints require, and identical on every platform. Two models colliding in 63 bits within one county part is not a practical concern.</para>
        /// </summary>
        /// <param name="buildingModel">The building model.</param>
        /// <returns>The positive id, or null when <paramref name="buildingModel"/> is null or its Guid is empty.</returns>
        public static long? SolarBuildingModelId(this BuildingModel? buildingModel)
        {
            if (buildingModel is null || buildingModel.Guid == Guid.Empty)
            {
                return null;
            }

            // Little-endian by construction, so the value does not depend on the platform's byte order.
            byte[] bytes = buildingModel.Guid.ToByteArray();
            long value = 0;
            for (int i = 0; i < 8; i++)
            {
                value |= (long)bytes[i] << (8 * i);
            }

            value &= long.MaxValue;
            return value == 0 ? 1 : value;
        }
    }
}
