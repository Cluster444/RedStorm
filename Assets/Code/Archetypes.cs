using Unity.Entities;

namespace RedStorm
{
    public static class Archetypes
    {
        public static readonly EntityArchetype MapTile;

        static Archetypes()
        {
            EntityManager em = World.Active.GetExistingManager<EntityManager>();

            MapTile = em.CreateArchetype<TilePosition>();
        }
    }
}
