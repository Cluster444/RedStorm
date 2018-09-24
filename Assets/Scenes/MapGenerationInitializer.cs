using System;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace RedStorm.Initialization
{
    public class MapGenerationInitializer : BaseInitializer
    {
        private World MapGenWorld;
        private GameObject Map;

        public override void Initialize()
        {
            byte xSize = 10;
            byte zSize = 10;

            // Create World
            SetupWorld("MapGeneration");

            // Setup the camera

            Camera mainCamera = Camera.main;
            if (mainCamera == null) throw new Exception("Missing MainCamera");

            mainCamera.transform.position = new Vector3(xSize * 5, xSize * 10, -xSize * 7.5f);

            // Create tile entities
            int tileCount = xSize * zSize;

            NativeArray<Entity> mapTiles = new NativeArray<Entity>(xSize * zSize, Allocator.Temp);
            EntityManager.CreateEntity(Archetypes.MapTile, mapTiles);

            for (byte i = 0; i < xSize; i++)
            {
                for (byte j = 0; j < zSize; j++)
                {
                    int k = i * zSize + j;
                    EntityManager.SetComponentData(mapTiles[k], new TilePosition
                    {
                        x = i,
                        y = j
                    });
                }
            }

            // Build map plane
            Map = new GameObject("Map");
            Map.transform.localScale = new Vector3(xSize, 1, zSize);
            Mesh mesh = new Mesh();

            Vector3[] vertices = new Vector3[(xSize + 1) * (zSize + 1)];
            for (int z = 0; z <= zSize; z++)
            {
                for (int x = 0; x <= xSize; x++)
                {
                    int i = z * xSize + x;
                    vertices[i] = new Vector3(x, 0, z);
                }
            }
            mesh.vertices = vertices;

            int[] triangles = new int[tileCount * 6];
            for (int ti = 0, vi = 0, z = 0; z < zSize; z++, vi++)
            {
                for (int x = 0; x < xSize; x++, ti += 6, vi++)
                {
                    triangles[ti] = vi;
                    triangles[ti + 1] = vi + xSize + 1;
                    triangles[ti + 2] = vi + 1;
                    triangles[ti + 3] = vi + 1;
                    triangles[ti + 4] = vi + xSize + 1;
                    triangles[ti + 5] = vi + xSize + 2;
                }
            }
            mesh.triangles = triangles;
            mesh.RecalculateNormals();

            MeshFilter meshFilter = Map.AddComponent<MeshFilter>();
            MeshRenderer meshRenderer = Map.AddComponent<MeshRenderer>();
            meshFilter.mesh = mesh;

            mapTiles.Dispose();
        }
    }
}
