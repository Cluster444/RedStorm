using Unity.Entities;

namespace RedStorm
{
    public static class EntityManagerExtensions
    {
        public static EntityArchetype CreateArchetype<T1>(this EntityManager em) where T1 : struct, IComponentData
        {
            return em.CreateArchetype(typeof(T1));
        }

        public static EntityArchetype CreateArchetype<T1, T2>(this EntityManager em)
            where T1 : struct, IComponentData
            where T2 : struct, IComponentData
        {
            return em.CreateArchetype(typeof(T1), typeof(T2));
        }

        public static EntityArchetype CreateArchetype<T1, T2, T3>(this EntityManager em)
            where T1 : struct, IComponentData
            where T2 : struct, IComponentData
            where T3 : struct, IComponentData
        {
            return em.CreateArchetype(typeof(T1), typeof(T2), typeof(T3));
        }
    }
}
